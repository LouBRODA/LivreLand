﻿using PersonalMVVMToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace LivreLand.ViewModel
{
    public class TousVM : BaseViewModel
    {
        #region Properties

        public NavigatorVM Navigator { get; private set; }

        public ManagerVM Manager { get; private set; }

        #endregion

        #region Constructor

        public TousVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
        }

        #endregion
    }
}
