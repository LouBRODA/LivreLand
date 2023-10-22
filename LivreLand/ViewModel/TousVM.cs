﻿using LivreLand.View;
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
    public class TousVM : BaseViewModel
    {
        #region Properties

        public NavigatorVM Navigator { get; private set; }

        public ManagerVM Manager { get; private set; }

        public ICommand OnSelectionChangedCommand { get; private set; }

        #endregion

        #region Constructor

        public TousVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            OnSelectionChangedCommand = new RelayCommand<BookVM>((bookVM) => OnSelectionChanged(bookVM));
        }

        #endregion

        #region Methods

        private void OnSelectionChanged(BookVM bookVM)
        {
            if (bookVM != null)
            {
                var result = new DetailsLivreVM(Manager, Navigator, bookVM);
                App.Current.MainPage.Navigation.PushAsync(new DetailsLivreView(result));

                var bookRating = bookVM.UserRating;
                StarNotationVM starNotationVM = new StarNotationVM(this.Manager);

                for (int i = 1; i <= 5; i++)
                {
                    if (bookRating >= i)
                    {
                        var starProperty = typeof(StarNotationVM).GetProperty($"Star{i}IsVisible");
                        starProperty?.SetValue(starNotationVM, true);
                    }
                }
            }
        }

        #endregion
    }
}
