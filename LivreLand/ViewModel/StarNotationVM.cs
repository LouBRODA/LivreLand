using Model;
using PersonalMVVMToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModels;

namespace LivreLand.ViewModel
{
    public class StarNotationVM : BaseViewModel
    {
        #region Properties

        public bool Star1IsVisible { get; private set; }

        public bool Star2IsVisible { get; private set; }

        public bool Star3IsVisible { get; private set; }

        public bool Star4IsVisible { get; private set; }

        public bool Star5IsVisible { get; private set; }

        public ManagerVM Manager { get; private set; }

        public ICommand StarRatingConverterCommand { get; private set; }

        #endregion

        #region Constructor

        public StarNotationVM(ManagerVM managerVM)
        {
            Manager = managerVM;
            StarRatingConverterCommand = new RelayCommand(() => StarRatingConverter());
        }

        #endregion

        #region Methods

        private void StarRatingConverter()
        {
            var bookRating = Manager.SelectedBook.UserRating;

            for (int i = 1; i <= 5; i++)
            {
                if (bookRating >= i)
                {
                    var starProperty = typeof(StarNotationVM).GetProperty($"Star{i}IsVisible");
                    starProperty?.SetValue(this, true);
                }
            }
        }

        #endregion
    }
}
