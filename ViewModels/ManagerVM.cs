using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using static System.Reflection.Metadata.BlobBuilder;

namespace ViewModels
{
    [ObservableObject]
    public partial class ManagerVM
    {

        #region Fields

        [ObservableProperty]
        private Manager model;

        [ObservableProperty]
        private ObservableCollection<BookVM> books = new ObservableCollection<BookVM>();

        [ObservableProperty]
        private IEnumerable<IGrouping<string, BookVM>> groupedBooks;

        [ObservableProperty]
        private IEnumerable<IGrouping<Status, BookVM>> groupedStatusBooks;

        [ObservableProperty]
        private ObservableCollection<AuthorVM> authors = new ObservableCollection<AuthorVM>();

        [ObservableProperty]
        private ObservableCollection<PublishDateVM> publishDates = new ObservableCollection<PublishDateVM>();

        [ObservableProperty]
        private ObservableCollection<RatingsVM> ratings = new ObservableCollection<RatingsVM>();

        [ObservableProperty]
        private ObservableCollection<BookVM> toBeReadBooks = new ObservableCollection<BookVM>();

        [ObservableProperty]
        private ObservableCollection<BookVM> favoriteBooks = new ObservableCollection<BookVM>();

        [ObservableProperty]
        private ObservableCollection<LoanVM> currentLoans = new ObservableCollection<LoanVM>();

        [ObservableProperty]
        private IEnumerable<IGrouping<ContactVM, LoanVM>> currentGroupedLoans;

        [ObservableProperty] 
        private ObservableCollection<LoanVM> pastLoans = new ObservableCollection<LoanVM>();

        [ObservableProperty]
        private IEnumerable<IGrouping<ContactVM, LoanVM>> pastGroupedLoans;

        [ObservableProperty]
        private ObservableCollection<BorrowingVM> currentBorrowings = new ObservableCollection<BorrowingVM>();

        [ObservableProperty]
        private IEnumerable<IGrouping<ContactVM, BorrowingVM>> currentGroupedBorrowings;

        [ObservableProperty]
        private ObservableCollection<BorrowingVM> pastBorrowings = new ObservableCollection<BorrowingVM>();

        [ObservableProperty]
        private IEnumerable<IGrouping<ContactVM, BorrowingVM>> pastGroupedBorrowings;

        [ObservableProperty]
        private ObservableCollection<ContactVM> contacts = new ObservableCollection<ContactVM>();

        [ObservableProperty]
        private ObservableCollection<Status> allStatus = new ObservableCollection<Status>();

        [ObservableProperty]
        private int indexPage;

        [ObservableProperty]
        private long nbBooks;

        [ObservableProperty]
        private BookVM selectedBook;

        [ObservableProperty]
        private AuthorVM selectedAuthor;

        [ObservableProperty]
        private PublishDateVM selectedDate;

        [ObservableProperty]
        private RatingsVM selectedRating;

        [ObservableProperty]
        private Status selectedStatus;

        [ObservableProperty]
        private ContactVM selectedContact;

        [ObservableProperty]
        private LoanVM selectedLoan;

        [ObservableProperty]
        private BorrowingVM selectedBorrowing;

        [ObservableProperty]
        private string entryText;

        [ObservableProperty]
        private string givenFirstName;

        [ObservableProperty]
        private string givenLastName;

        [ObservableProperty]
        private bool isFavorite;

        #endregion

        #region Properties 

        public string SearchTitle { get; private set; }

        public int Count { get; set; } = 5;

        public int NbPages => (int)((NbBooks - 1) / Count);

        #endregion

        #region Constructor

        public ManagerVM(Manager model)
        {
            Model = model;
            //GetBooksByTitleCommand = new RelayCommand(() => AllBooks = model.GetBooksByTitle(SearchTitle, Index, Count).Result.books.Select(book => new BookVM(book)));
        }

        //public ManagerVM(ILibraryManager libMgr, IUserLibraryManager userLibMgr) : this (new Manager(libMgr, userLibMgr)) { }

        #endregion

        #region Methods

        [RelayCommand]
        private async Task Previous()
        {
            if (IndexPage > 0)
            {
                IndexPage--;
                await GetBooksFromCollection();
            }
        }

        [RelayCommand]
        private async Task Next()
        {
            if (IndexPage < NbPages)
            {
                IndexPage++;
                await GetBooksFromCollection();
            }
        }

        [RelayCommand]
        private async Task GetBooksFromCollection()
        {
            var result = await Model.GetBooksFromCollection(IndexPage, Count);
            NbBooks = result.count;
            IEnumerable<Book> someBooks = result.books;
            someBooks = someBooks.OrderBy(b => b.Status);
            Books.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b))) 
            {
                Books.Add(b);
                GroupedBooks = Books.GroupBy(b => b.Author).OrderBy(group => group.Key);
                GroupedStatusBooks = Books.GroupBy(b => b.Status).OrderBy(group => group.Key);
            }
            OnPropertyChanged(nameof(GroupedBooks));
            OnPropertyChanged(nameof(Books));
        }

        [RelayCommand]
        private async Task AddBook(string isbn)
        {
            var result = await Model.GetBookByISBN(isbn);
            if (result != null)
            {
                await Model.AddBookToCollection(result.Id);
            }
            GetBooksFromCollectionCommand.Execute(null);
        }

        [RelayCommand]
        private async Task UpdateBook(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.UpdateBook(book);
        }

        [RelayCommand]
        private async Task UpdateStatusBook(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            book.Status = SelectedStatus;
            await Model.UpdateBook(book);
            var updatedBook = new BookVM(book);
            bookVM = updatedBook;
            OnPropertyChanged(nameof(bookVM));
        }

        [RelayCommand]
        private async Task UpdateToBeReadBook(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            book.Status = Status.ToBeRead;
            await Model.UpdateBook(book);
        }

        [RelayCommand]
        private async Task RemoveBook(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.RemoveBook(book);
            OnPropertyChanged(nameof(NbBooks));
            await GetBooksFromCollection();
        }

        [RelayCommand]
        private async Task GetBooksByAuthor()
        {
            var result = await Model.GetBooksByAuthor(SelectedAuthor.Name, 0, 1000);
            NbBooks = result.count;
            IEnumerable<Book> someBooks = result.books;
            books.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b)))
            {
                books.Add(b);
                GroupedBooks = Books.GroupBy(b => b.Author).OrderBy(group => group.Key);
            }
            OnPropertyChanged(nameof(GroupedBooks));
            OnPropertyChanged(nameof(Books));
        }

        [RelayCommand]
        private async Task GetAllAuthors()
        {
            var result = await Model.GetBooksFromCollection(0, 1000);
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
            OnPropertyChanged(nameof(Authors));
        }

        [RelayCommand]
        private async Task GetBooksByDate()
        {
            var result = await Model.GetBooksFromCollection(0, 1000);
            NbBooks = result.count;
            IEnumerable<Book> someBooks = result.books;
            books.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b)))
            {
                if (b.PublishDate.Year == SelectedDate.PublishDate.Year)
                {
                    books.Add(b);
                    GroupedBooks = Books.GroupBy(b => b.PublishDate.Year.ToString()).OrderBy(group => group.Key);
                }                
            }
            OnPropertyChanged(nameof(GroupedBooks));
            OnPropertyChanged(nameof(Books));
        }

        [RelayCommand]
        private async Task GetAllPublishDates()
        {
            var result = await Model.GetBooksFromCollection(0, 1000);
            IEnumerable<Book> someBooks = result.books;
            Books.Clear();
            PublishDates.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b)))
            {
                var date = new PublishDateVM { PublishDate = b.PublishDate };
                date.NbBooksWritten++;
                PublishDates.Add(date);
                foreach (var p in PublishDates)
                {
                    if (date.PublishDate.Year == p.PublishDate.Year && !date.Equals(p))
                    {
                        p.NbBooksWritten++;
                        PublishDates.Remove(date);
                    }
                }
            }
            OnPropertyChanged(nameof(PublishDates));
        }

        [RelayCommand]
        private async Task GetBooksByRating()
        {
            var result = await Model.GetBooksFromCollection(0, 1000);
            NbBooks = result.count;
            IEnumerable<Book> someBooks = result.books;
            Books.Clear();

            var groupedBooks = someBooks
                .Where(book => book.UserRating.HasValue)
                .Select(book => new BookVM(book))
                .GroupBy(book => Math.Floor(book.UserRating.Value).ToString("0"))
                .OrderBy(group => group.Key);

            GroupedBooks = groupedBooks;

            OnPropertyChanged(nameof(GroupedBooks));
            OnPropertyChanged(nameof(Books));
        }

        [RelayCommand]
        private async Task GetAllRatings()
        {
            var result = await Model.GetBooksFromCollection(0, 1000);
            IEnumerable<Book> someBooks = result.books;
            Books.Clear();
            Ratings.Clear();

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

            OnPropertyChanged(nameof(Ratings));
        }

        [RelayCommand]
        private async Task GetAllStatus()
        {
            var allStatusValues = Enum.GetValues(typeof(Status)).OfType<Status>();
            foreach (var s in allStatusValues)
            {
                allStatus.Add(s);
            }
            OnPropertyChanged(nameof(AllStatus));
        }

        [RelayCommand]
        private async Task GetToBeReadBooks()
        {
            var result = await Model.GetBooksFromCollection(0, 1000);
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

        [RelayCommand]
        private async Task GetFavoriteBooks()
        {
            var result = await Model.GetFavoritesBooks(0, 1000);
            IEnumerable<Book> someBooks = result.books;
            books.Clear();
            favoriteBooks.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b)))
            {
                favoriteBooks.Add(b);
            }
            OnPropertyChanged(nameof(FavoriteBooks));
        }

        [RelayCommand]
        private async Task AddToFavorites(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.AddToFavorites(book.Id);
            await GetFavoriteBooks();
        }

        [RelayCommand]
        private async Task RemoveFromFavorites(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.RemoveFromFavorites(book.Id);
            await GetFavoriteBooks();
        }

        [RelayCommand]
        private async Task CheckBookIsFavorite(BookVM bookVM)
        {
            await GetFavoriteBooks();
            if (FavoriteBooks.Any(favoriteBook => favoriteBook.Id == bookVM.Id))
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

        [RelayCommand]
        private async Task GetCurrentLoans()
        {
            var result = await Model.GetCurrentLoans(0, 1000);
            IEnumerable<Loan> someLoans = result.loans;
            currentLoans.Clear();
            foreach (var l in someLoans.Select(l => new LoanVM(l)))
            {
                currentLoans.Add(l);
                CurrentGroupedLoans = CurrentLoans.GroupBy(l => l.Loaner).OrderBy(group => group.Key);
            }
            OnPropertyChanged(nameof(CurrentLoans));
        }

        [RelayCommand]
        private async Task GetPastLoans()
        {
            var result = await Model.GetPastLoans(0, 1000);
            IEnumerable<Loan> someLoans = result.loans;
            pastLoans.Clear();
            foreach (var l in someLoans.Select(l => new LoanVM(l)))
            {
                pastLoans.Add(l);
                PastGroupedLoans = PastLoans.GroupBy(l => l.Loaner).OrderBy(group => group.Key);
            }
            OnPropertyChanged(nameof(PastLoans));
        }

        [RelayCommand]
        private async Task GetCurrentBorrowings()
        {
            var result = await Model.GetCurrentBorrowings(0, 1000);
            IEnumerable<Borrowing> someBorrowings = result.borrowings;
            currentBorrowings.Clear();
            foreach (var b in someBorrowings.Select(b => new BorrowingVM(b)))
            {
                currentBorrowings.Add(b);
                CurrentGroupedBorrowings = CurrentBorrowings.GroupBy(b => b.Owner).OrderBy(group => group.Key);
            }
            OnPropertyChanged(nameof(CurrentBorrowings));
        }

        [RelayCommand]
        private async Task GetPastBorrowings()
        {
            var result = await Model.GetPastBorrowings(0, 1000);
            IEnumerable<Borrowing> someBorrowings = result.borrowings;
            pastBorrowings.Clear();
            foreach (var b in someBorrowings.Select(b => new BorrowingVM(b)))
            {
                pastBorrowings.Add(b);
                PastGroupedBorrowings = PastBorrowings.GroupBy(b => b.Owner).OrderBy(group => group.Key);
            }
            OnPropertyChanged(nameof(PastBorrowings));
        }

        [RelayCommand]
        private async Task LendBook(ContactVM contactVM)
        {
            var book = await Model.GetBookById(SelectedBook.Id);
            Model.Contact contact = new Model.Contact();
            var resultContacts = await Model.GetContacts(IndexPage, Count);
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

        [RelayCommand]
        private async Task GetContacts()
        {
            var result = await Model.GetContacts(IndexPage, Count);
            IEnumerable<Model.Contact> someContacts = result.contacts;
            someContacts = someContacts.OrderBy(c => c.FirstName);
            contacts.Clear();
            foreach (var c in someContacts.Select(c => new ContactVM(c)))
            {
                contacts.Add(c);
            }
            OnPropertyChanged(nameof(Contacts));
        }

        [RelayCommand]
        private async Task AddContact()
        {
            var result = await Model.GetContacts(IndexPage, Count);
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
            OnPropertyChanged(nameof(Contacts));
        }

        #endregion
    }
}