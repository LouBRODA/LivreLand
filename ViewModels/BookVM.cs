using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    [ObservableObject]
    public partial class BookVM
    {

        #region Fields

        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private string isbn13;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private List<string> publishers;

        [ObservableProperty]
        private DateTime publishDate;

        [ObservableProperty]
        private List<AuthorVM> authors;

        [ObservableProperty]
        private string author;

        [ObservableProperty]
        private Status status;

        [ObservableProperty]
        private int nbPages;

        [ObservableProperty]
        private Languages language;

        [ObservableProperty]
        private string imageSmall;

        [ObservableProperty]
        private float? userRating;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public BookVM(Book b)
        {
            
        }

        #endregion
    }
}
