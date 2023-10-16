using Model;
using PersonalMVVMToolkit;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace ViewModels
{
    public class ManagerVM : BaseViewModel<Manager>
    {

        #region Fields

        private readonly ObservableCollection<BookVM> books = new ObservableCollection<BookVM>();
        private readonly ObservableCollection<AuthorVM> authors = new ObservableCollection<AuthorVM>();
        private readonly ObservableCollection<PublishDateVM> publishDates = new ObservableCollection<PublishDateVM>();
        private readonly ObservableCollection<RatingsVM> ratings = new ObservableCollection<RatingsVM>();
        private readonly ObservableCollection<BookVM> toBeReadBooks = new ObservableCollection<BookVM>();
        private readonly ObservableCollection<BookVM> favoriteBooks = new ObservableCollection<BookVM>();
        private readonly ObservableCollection<LoanVM> currentLoans = new ObservableCollection<LoanVM>();
        private readonly ObservableCollection<LoanVM> pastLoans = new ObservableCollection<LoanVM>();
        private readonly ObservableCollection<BorrowingVM> pastBorrowings = new ObservableCollection<BorrowingVM>();
        private readonly ObservableCollection<BorrowingVM> currentBorrowings = new ObservableCollection<BorrowingVM>();
        private readonly ObservableCollection<ContactVM> contacts = new ObservableCollection<ContactVM>();
        private readonly ObservableCollection<Status> status = new ObservableCollection<Status>();
        private int index;
        private long nbBooks;

        private BookVM selectedBook;
        private AuthorVM selectedAuthor;
        private PublishDateVM selectedDate;
        private RatingsVM selectedRating;
        private Status selectedStatus;
        private ContactVM selectedContact;

        private string givenFirstName;
        private string givenLastName;
        private bool isFavorite;

        #endregion

        #region Properties 

        public ObservableCollection<BookVM> AllBooks 
        {
            get => books; 
        }

        public ObservableCollection<AuthorVM> AllAuthors
        {
            get => authors;
        }

        public ObservableCollection<PublishDateVM> AllPublishDates
        {
            get => publishDates;
        }

        public ObservableCollection<RatingsVM> AllRatings
        {
            get => ratings;
        }

        public ObservableCollection<BookVM> ToBeReadBooks
        {
            get => toBeReadBooks;
        }

        public ObservableCollection<BookVM> AllFavoriteBooks
        {
            get => favoriteBooks;
        }

        public ObservableCollection<LoanVM> AllCurrentLoans
        {
            get => currentLoans;
        }

        public ObservableCollection<LoanVM> AllPastLoans
        {
            get => pastLoans;
        }

        public ObservableCollection<BorrowingVM> AllCurrentBorrowings
        {
            get => currentBorrowings;
        }

        public ObservableCollection<BorrowingVM> AllPastBorrowings
        {
            get => pastBorrowings;
        }

        public ObservableCollection<ContactVM> AllContacts
        {
            get => contacts;
        }

        public ObservableCollection<Status> AllStatus
        {
            get => status;
        }

        public BookVM SelectedBook
        {
            get { return selectedBook; }
            set
            {
                if (selectedBook != value)
                {
                    selectedBook = value;
                    OnPropertyChanged(nameof(SelectedBook));
                }
            }
        }

        public AuthorVM SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                if (selectedAuthor != value)
                {
                    selectedAuthor = value;
                    OnPropertyChanged(nameof(SelectedAuthor));
                }
            }
        }

        public PublishDateVM SelectedDate
        {
            get { return selectedDate; }
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        public RatingsVM SelectedRating
        {
            get { return selectedRating; }
            set
            {
                if (selectedRating != value)
                {
                    selectedRating = value;
                    OnPropertyChanged(nameof(SelectedRating));
                }
            }
        }

        public Status SelectedStatus
        {
            get { return selectedStatus; }
            set
            {
                if (selectedStatus != value)
                {
                    selectedStatus = value;
                    OnPropertyChanged(nameof(SelectedStatus));
                }
            }
        }

        public ContactVM SelectedContact
        {
            get { return selectedContact; }
            set
            {
                if (selectedContact != value)
                {
                    selectedContact = value;
                    OnPropertyChanged(nameof(SelectedContact));
                }
            }
        }

        public string GivenFirstName
        {
            get { return givenFirstName; }
            set
            {
                if (givenFirstName != value)
                {
                    givenFirstName = value;
                    OnPropertyChanged(nameof(GivenFirstName));
                }
            }
        }

        public string GivenLastName
        {
            get { return givenLastName; }
            set
            {
                if (givenLastName != value)
                {
                    givenLastName = value;
                    OnPropertyChanged(nameof(GivenLastName));
                }
            }
        }

        public bool IsFavorite
        {
            get { return isFavorite; }
            set
            {
                if (isFavorite != value)
                {
                    isFavorite = value;
                    OnPropertyChanged(nameof(IsFavorite));
                }
            }
        }

        public string SearchTitle { get; private set; }

        public int Index 
        {
            get => index; 
            set => SetProperty(ref index, value); 
        }

        public int Count { get; set; } = 5;

        public long NbBooks
        {
            get => nbBooks;
            set
            {
                SetProperty(ref nbBooks, value);
                OnPropertyChanged(nameof(NbPages));
            }
        }

        public int NbPages => (int)(NbBooks / Count);

        public ICommand PreviousCommand { get; private set; }

        public ICommand NextCommand { get; private set; }

        public ICommand GetBooksByTitleCommand { get; private set; }

        public ICommand GetBooksFromCollectionCommand { get; private set; }

        public ICommand UpdateBookCommand { get; private set; }

        public ICommand UpdateStatusBookCommand { get; private set; }

        public ICommand UpdateToBeReadBookCommand { get; private set; }

        public ICommand RemoveBookCommand { get; private set; }

        public ICommand GetBooksByAuthorCommand { get; private set; }

        public ICommand GetAllAuthorsCommand { get; private set; }

        public ICommand GetBooksByDateCommand { get; private set; }

        public ICommand GetAllPublishDatesCommand { get; private set; }

        public ICommand GetBooksByRatingCommand { get; private set; }

        public ICommand GetAllRatingsCommand { get; private set; }

        public ICommand GetAllStatusCommand { get; private set; } 

        public ICommand GetToBeReadBooksCommand { get; private set; }

        public ICommand GetFavoriteBooksCommand { get; private set; }

        public ICommand AddToFavoritesCommand { get; private set; }

        public ICommand RemoveFromFavoritesCommand { get; private set; }

        public ICommand CheckBookIsFavoriteCommand { get; private set; }

        public ICommand GetCurrentLoansCommand { get; private set; }

        public ICommand GetPastLoansCommand { get; private set; }

        public ICommand GetCurrentBorrowingsCommand { get; private set; }

        public ICommand GetPastBorrowingsCommand { get; private set; }

        public ICommand LendBookCommand { get; private set; }

        public ICommand GetContactsCommand { get; private set; } 

        public ICommand AddContactCommand { get; private set; }

        #endregion

        #region Constructor

        public ManagerVM(Manager model) : base(model)
        {
            PreviousCommand = new RelayCommand(() => Previous());
            NextCommand = new RelayCommand(() => Next());
            GetBooksFromCollectionCommand = new RelayCommand(() => GetBooksFromCollection());
            UpdateBookCommand = new RelayCommand<BookVM>((bookVM) => UpdateBook(bookVM));
            UpdateStatusBookCommand = new RelayCommand<BookVM>((bookVM) => UpdateStatusBook(bookVM));
            UpdateToBeReadBookCommand = new RelayCommand<BookVM>((bookVM) => UpdateToBeReadBook(bookVM));
            RemoveBookCommand = new RelayCommand<BookVM>((bookVM) => RemoveBook(bookVM));
            GetBooksByAuthorCommand = new RelayCommand(() => GetBooksByAuthor());
            GetAllAuthorsCommand = new RelayCommand(() => GetAllAuthors());
            GetBooksByDateCommand = new RelayCommand(() => GetBooksByDate());
            GetAllPublishDatesCommand = new RelayCommand(() => GetAllPublishDates());
            GetBooksByRatingCommand = new RelayCommand(() => GetBooksByRating());
            GetAllRatingsCommand = new RelayCommand(() => GetAllRatings());
            GetAllStatusCommand = new RelayCommand(() => GetAllStatus());
            GetToBeReadBooksCommand = new RelayCommand(() => GetToBeReadBooks());
            GetFavoriteBooksCommand = new RelayCommand(() => GetFavoriteBooks());
            AddToFavoritesCommand = new RelayCommand<BookVM>(bookVM => AddToFavorites(bookVM));
            RemoveFromFavoritesCommand = new RelayCommand<BookVM>(bookVM => RemoveFromFavorites(bookVM));
            CheckBookIsFavoriteCommand = new RelayCommand<BookVM>(bookVM => CheckBookIsFavorite(bookVM));
            GetCurrentLoansCommand = new RelayCommand(() =>  GetCurrentLoans());
            GetPastLoansCommand = new RelayCommand(() =>  GetPastLoans());
            GetCurrentBorrowingsCommand = new RelayCommand(() => GetCurrentBorrowings());
            GetPastBorrowingsCommand = new RelayCommand(() => GetPastBorrowings());
            LendBookCommand = new RelayCommand<ContactVM>((contactVM) => LendBook(contactVM));
            GetContactsCommand = new RelayCommand(() => GetContacts());
            AddContactCommand = new RelayCommand(() => AddContact());
            //GetBooksByTitleCommand = new RelayCommand(() => AllBooks = model.GetBooksByTitle(SearchTitle, Index, Count).Result.books.Select(book => new BookVM(book)));
        }

        //public ManagerVM(ILibraryManager libMgr, IUserLibraryManager userLibMgr) : this (new Manager(libMgr, userLibMgr)) { }

        #endregion

        #region Methods

        private async Task Previous()
        {
            if (Index > 0)
            {
                Index--;
                await GetBooksFromCollection();
            }
        }

        private async Task Next()
        {
            if (Index < NbPages)
            {
                Index++;
                await GetBooksFromCollection();
            }
        }

        private async Task GetBooksFromCollection()
        {
            var result = await Model.GetBooksFromCollection(Index, Count);
            NbBooks = result.count;
            IEnumerable<Book> someBooks = result.books;
            someBooks = someBooks.OrderBy(b => b.Status);
            books.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b))) 
            {
                books.Add(b);              
            }
            OnPropertyChanged(nameof(AllBooks));
        }

        private async Task UpdateBook(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.UpdateBook(book);
        }
        
        private async Task UpdateStatusBook(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            book.Status = SelectedStatus;
            await Model.UpdateBook(book);
        }

        private async Task UpdateToBeReadBook(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            book.Status = Status.ToBeRead;
            await Model.UpdateBook(book);
        }

        private async Task RemoveBook(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.RemoveBook(book);
            OnPropertyChanged(nameof(NbBooks));
            await GetBooksFromCollection();
        }

        private async Task GetBooksByAuthor()
        {
            var result = await Model.GetBooksByAuthor(SelectedAuthor.Name, Index, Count);
            NbBooks = result.count;
            IEnumerable<Book> someBooks = result.books;
            books.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b)))
            {
                books.Add(b);
            }
            OnPropertyChanged(nameof(AllBooks));
        }

        private async Task GetAllAuthors()
        {
            var result = await Model.GetBooksFromCollection(0, 20);
            IEnumerable<Book> someBooks = result.books;
            books.Clear();
            authors.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b)))
            {
                foreach (var a in b.Authors)
                {
                    authors.Add(a);
                    a.NbBooksWritten++;
                }
            }
            OnPropertyChanged(nameof(AllAuthors));
        }

        private async Task GetBooksByDate()
        {
            var result = await Model.GetBooksFromCollection(Index, Count);
            NbBooks = result.count;
            IEnumerable<Book> someBooks = result.books;
            books.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b)))
            {
                if (b.PublishDate == SelectedDate.PublishDate)
                {
                    books.Add(b);
                }                
            }
            OnPropertyChanged(nameof(AllBooks));
        }

        private async Task GetAllPublishDates()
        {
            var result = await Model.GetBooksFromCollection(0, 20);
            IEnumerable<Book> someBooks = result.books;
            books.Clear();
            publishDates.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b)))
            {
                var date = new PublishDateVM { PublishDate = b.PublishDate };
                date.NbBooksWritten++;
                publishDates.Add(date);
                foreach (var p in publishDates)
                {
                    if (date.PublishDate.Year == p.PublishDate.Year && !date.Equals(p))
                    {
                        p.NbBooksWritten++;
                        publishDates.Remove(date);
                    }
                }
            }
            OnPropertyChanged(nameof(AllPublishDates));
        }

        private async Task GetBooksByRating()
        {
            var result = await Model.GetBooksFromCollection(Index, Count);
            NbBooks = result.count;
            IEnumerable<Book> someBooks = result.books;
            books.Clear();
            var filteredBooks = someBooks.Where(b => b.UserRating.HasValue && Math.Floor(b.UserRating.Value) == SelectedRating.Average);
            foreach (var book in filteredBooks)
            {
                books.Add(new BookVM(book));
            }
            OnPropertyChanged(nameof(AllBooks));
        }

        private async Task GetAllRatings()
        {
            var result = await Model.GetBooksFromCollection(0, 20);
            IEnumerable<Book> someBooks = result.books;
            books.Clear();
            ratings.Clear();

            Dictionary<string, List<BookVM>> groupedBooks = new Dictionary<string, List<BookVM>>();

            foreach (var b in someBooks.Select(b => new BookVM(b)))
            {
                var rating = new RatingsVM { Average = b.UserRating };
                if (rating.Average != null)
                {
                    string noteKey = Math.Floor(rating.Average.Value).ToString("0");

                    if (!groupedBooks.ContainsKey(noteKey))
                    {
                        groupedBooks[noteKey] = new List<BookVM>();
                    }

                    groupedBooks[noteKey].Add(b);
                }
            }

            foreach (var entry in groupedBooks)
            {
                var noteKey = entry.Key;
                var booksWithSameRating = entry.Value;

                var rating = new RatingsVM
                {
                    Average = float.Parse(noteKey),
                    NbBooksWritten = booksWithSameRating.Count
                };

                ratings.Add(rating);
            }

            OnPropertyChanged(nameof(AllRatings));
        }

        private async Task GetAllStatus()
        {
            var allStatusValues = Enum.GetValues(typeof(Status)).OfType<Status>();
            foreach (var s in allStatusValues)
            {
                status.Add(s);
            }
            OnPropertyChanged(nameof(AllStatus));
        }

        private async Task GetToBeReadBooks()
        {
            var result = await Model.GetBooksFromCollection(0, 20);
            IEnumerable<Book> someBooks = result.books;
            books.Clear();
            toBeReadBooks.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b)))
            {
                if (b.Status == Status.ToBeRead)
                {
                    toBeReadBooks.Add(b);
                }
            }
            OnPropertyChanged(nameof(ToBeReadBooks));
        }

        private async Task GetFavoriteBooks()
        {
            var result = await Model.GetFavoritesBooks(Index, Count);
            IEnumerable<Book> someBooks = result.books;
            books.Clear();
            favoriteBooks.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b)))
            {
                favoriteBooks.Add(b);
            }
            OnPropertyChanged(nameof(AllFavoriteBooks));
        }

        private async Task AddToFavorites(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.AddToFavorites(book.Id);
            await GetFavoriteBooks();
        }

        private async Task RemoveFromFavorites(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.RemoveFromFavorites(book.Id);
            await GetFavoriteBooks();
        }

        private async Task CheckBookIsFavorite(BookVM bookVM)
        {
            await GetFavoriteBooks();
            if (AllFavoriteBooks.Any(favoriteBook => favoriteBook.Id == bookVM.Id))
            {
                IsFavorite = true;
                OnPropertyChanged(nameof(IsFavorite));
            }
            else
            {
                IsFavorite = false;
                OnPropertyChanged(nameof(IsFavorite));
            }
        }

        private async Task GetCurrentLoans()
        {
            var result = await Model.GetCurrentLoans(0, 20);
            IEnumerable<Loan> someLoans = result.loans;
            currentLoans.Clear();
            foreach (var l in someLoans.Select(l => new LoanVM(l)))
            {
                currentLoans.Add(l);
            }
            OnPropertyChanged(nameof(AllCurrentLoans));
        }

        private async Task GetPastLoans()
        {
            var result = await Model.GetPastLoans(0, 20);
            IEnumerable<Loan> someLoans = result.loans;
            pastLoans.Clear();
            foreach (var l in someLoans.Select(l => new LoanVM(l)))
            {
                pastLoans.Add(l);
            }
            OnPropertyChanged(nameof(AllPastLoans));
        }

        private async Task GetCurrentBorrowings()
        {
            var result = await Model.GetCurrentBorrowings(0, 20);
            IEnumerable<Borrowing> someBorrowings = result.borrowings;
            currentBorrowings.Clear();
            foreach (var b in someBorrowings.Select(b => new BorrowingVM(b)))
            {
                currentBorrowings.Add(b);
            }
            OnPropertyChanged(nameof(AllCurrentBorrowings));
        }

        private async Task GetPastBorrowings()
        {
            var result = await Model.GetPastBorrowings(0, 20);
            IEnumerable<Borrowing> someBorrowings = result.borrowings;
            pastBorrowings.Clear();
            foreach (var b in someBorrowings.Select(b => new BorrowingVM(b)))
            {
                pastBorrowings.Add(b);
            }
            OnPropertyChanged(nameof(AllPastBorrowings));
        }

        private async Task LendBook(ContactVM contactVM)
        {
            var book = await Model.GetBookById(SelectedBook.Id);
            Model.Contact contact = new Model.Contact();
            var resultContacts = await Model.GetContacts(Index, Count);
            var allContacts = resultContacts.contacts;
            foreach (var c in allContacts)
            {
                if (c.Id == contactVM.Id)
                {
                    contact = c;
                }
            }
            if (contact != null)
            {
                await Model.LendBook(book, contact, null);
            }
        }

        private async Task GetContacts()
        {
            var result = await Model.GetContacts(Index, Count);
            IEnumerable<Model.Contact> someContacts = result.contacts;
            someContacts = someContacts.OrderBy(c => c.FirstName);
            contacts.Clear();
            foreach (var c in someContacts.Select(c => new ContactVM(c)))
            {
                contacts.Add(c);
            }
            OnPropertyChanged(nameof(AllContacts));
        }

        private async Task AddContact()
        {
            var result = await Model.GetContacts(Index, Count);
            IEnumerable<Model.Contact> someContacts = result.contacts;

            int lastSequence = someContacts
                .Where(c => Regex.IsMatch(c.Id, @"^/contacts/\d+$"))
                .Select(c => int.Parse(Regex.Match(c.Id, @"\d+").Value))
                .DefaultIfEmpty(0)
                .Max();

            int newSequence = lastSequence + 1;

            string newId = $"/contacts/{newSequence:D2}";

            var newContact = new Model.Contact
            {
                Id = newId,
                FirstName = GivenFirstName,
                LastName = GivenLastName
            };

            GivenFirstName = null;
            GivenLastName = null;

            await Model.AddContact(newContact);
            OnPropertyChanged(nameof(AllContacts));
        }

        #endregion
    }
}