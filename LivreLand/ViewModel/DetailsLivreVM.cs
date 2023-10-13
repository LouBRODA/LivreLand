﻿using PersonalMVVMToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace LivreLand.ViewModel
{
    public class DetailsLivreVM : BaseViewModel
    {
        #region Properties

        public ManagerVM Manager { get; private set; }

        public BookVM Book { get; private set; }

        #endregion

        #region Constructor

        public DetailsLivreVM(ManagerVM managerVM, BookVM bookVM) 
        {
            Manager = managerVM;
            Book = bookVM;
        }

        #endregion
    }
}
