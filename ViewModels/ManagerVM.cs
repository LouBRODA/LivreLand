using Model;
using PersonalMVVMToolkit;
using System.Collections.ObjectModel;
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

        public AuthorVM SelectedAuthor { get; private set; }

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

        public ICommand GetBooksByAuthorCommand { get; private set; }
        
        public ICommand GetAllAuthorsCommand { get; private set; }

        public ICommand GetAllPublishDatesCommand { get; private set; }

        public ICommand GetAllRatingsCommand { get; private set; }

        public ICommand GetToBeReadBooksCommand { get; private set; }

        #endregion

        #region Constructor

        public ManagerVM(Manager model) : base(model)
        {
            PreviousCommand = new RelayCommand(() => Previous());
            NextCommand = new RelayCommand(() => Next());
            GetBooksFromCollectionCommand = new RelayCommand(() => GetBooksFromCollection());
            GetBooksByAuthorCommand = new RelayCommand(() => GetBooksByAuthor());
            GetAllAuthorsCommand = new RelayCommand(() => GetAllAuthors());
            GetAllPublishDatesCommand = new RelayCommand(() => GetAllPublishDates());
            GetAllRatingsCommand = new RelayCommand(() => GetAllRatings());
            GetToBeReadBooksCommand = new RelayCommand(() => GetToBeReadBooks());
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
            books.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b))) 
            {
                books.Add(b);              
            }
            OnPropertyChanged(nameof(AllBooks));
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

        private async Task GetAllRatings()
        {
            var result = await Model.GetBooksFromCollection(0, 20);
            IEnumerable<Book> someBooks = result.books;
            books.Clear();
            ratings.Clear();
            foreach (var b in someBooks.Select(b => new BookVM(b)))
            {
                var rating = new RatingsVM { Average = b.UserRating};
                if (rating.Average != null)
                {               
                    rating.NbBooksWritten++;
                    ratings.Add(rating);
                    foreach (var r in ratings)
                    {
                        if (rating.Average == r.Average && !rating.Equals(r))
                        {
                            r.NbBooksWritten++;
                            ratings.Remove(rating);
                        }
                    }
                }
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
        }

        #endregion
    }
}