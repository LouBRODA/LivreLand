using Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ViewModels.LivreLand.ViewModel;

namespace ViewModels
{
    public class ManagerVM
    {

        #region Fields

        private Manager model;

        #endregion

        #region Properties 

        public Manager Model
        {
            get => model;
            private set => model = value;
        }

        public IEnumerable<BookVM> AllBooks { get; private set; } = new ObservableCollection<BookVM>();

        public string SearchTitle { get; private set; }

        public int Index { get; private set; }
        
        public int Count { get; private set; }

        public int NbPages { get; private set; }

        public ICommand GetBooksByTitleCommand { get; }

        #endregion

        #region Constructor

        public ManagerVM(Manager model)
        {
            Model = model;
            GetBooksByTitleCommand = new Command(() => AllBooks = model.GetBooksByTitle(SearchTitle, Index, Count).Result.books.Select(book => new BookVM(book)));
        }  

        #endregion
    }
}