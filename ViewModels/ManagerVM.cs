using Model;
using PersonalMVVMToolkit;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels
{
    public class ManagerVM : BaseViewModel<Manager>
    {

        #region Fields

        private Manager model;
        private readonly ObservableCollection<BookVM> books;
        private int index;
        private long nbBooks;
         

        #endregion

        #region Properties 

        public Manager Model
        {
            get => model;
            private set => model = value;
        }

        public ReadOnlyObservableCollection<BookVM> AllBooks { get; private set; }

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

        public ICommand NextCommand { get; private set; }

        public ICommand GetBooksByTitleCommand { get; private set; }

        public ICommand GetBooksFromCollectionCommand { get; private set; }

        #endregion

        #region Constructor

        public ManagerVM(Manager model)
        {
            Model = model;
            AllBooks = new ReadOnlyObservableCollection<BookVM>(books);
            GetBooksFromCollectionCommand = new RelayCommand(() => GetBooksFromCollection());
            //GetBooksByTitleCommand = new RelayCommand(() => AllBooks = model.GetBooksByTitle(SearchTitle, Index, Count).Result.books.Select(book => new BookVM(book)));
        }

        #endregion

        #region Methods

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
        }

        #endregion
    }
}