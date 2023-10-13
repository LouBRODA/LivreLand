using Model;
using PersonalMVVMToolkit;
using System.Collections.ObjectModel;
using System.Linq;
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
        private int index;
        private long nbBooks;
         
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

        public AuthorVM SelectedAuthor { get; private set; }

        public PublishDateVM SelectedDate { get; private set; }

        public RatingsVM SelectedRating { get; private set; }

        public Status SelectedStatus { get; set; }

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

        public ICommand GetAllRatingsCommand { get; private set; }

        public ICommand GetToBeReadBooksCommand { get; private set; }

        public ICommand GetFavoriteBooksCommand { get; private set; }

        public ICommand AddToFavoritesCommand { get; private set; }

        public ICommand RemoveFromFavoritesCommand { get; private set; }

        public ICommand GetCurrentLoansCommand { get; private set; }

        public ICommand GetPastLoansCommand { get; private set; }

        public ICommand GetCurrentBorrowingsCommand { get; private set; }

        public ICommand GetPastBorrowingsCommand { get; private set; }

        public ICommand GetBooksByRatingCommand { get; private set; }

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
            GetToBeReadBooksCommand = new RelayCommand(() => GetToBeReadBooks());
            GetFavoriteBooksCommand = new RelayCommand(() => GetFavoriteBooks());
            AddToFavoritesCommand = new RelayCommand<BookVM>(bookVM => AddToFavorites(bookVM));
            RemoveFromFavoritesCommand = new RelayCommand<BookVM>(bookVM => RemoveFromFavorites(bookVM));
            GetCurrentLoansCommand = new RelayCommand(() =>  GetCurrentLoans());
            GetPastLoansCommand = new RelayCommand(() =>  GetPastLoans());
            GetCurrentBorrowingsCommand = new RelayCommand(() => GetCurrentBorrowings());
            GetPastBorrowingsCommand = new RelayCommand(() => GetPastBorrowings());
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

        //private async Task LendBook()
        //{
        //    await Model.LendBook();
        //}

        #endregion
    }
}