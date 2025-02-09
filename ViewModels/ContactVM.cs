﻿using Model;
using PersonalMVVMToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ContactVM : BaseViewModel<Model.Contact>
    {
        #region Fields

        #endregion

        #region Properties

        public string Id
        {
            get => Model.Id;
            set => SetProperty(Model.Id, value, v => Model.Id = value);
        }

        public string FirstName
        {
            get => Model.FirstName;
            set => SetProperty(Model.FirstName, value, v => Model.FirstName = value);
        }

        public string LastName
        {
            get => Model.LastName;
            set => SetProperty(Model.LastName, value, v => Model.LastName = value);
        }

        #endregion

        #region Constructor

        public ContactVM(Model.Contact c) : base(c)
        {

        }

        #endregion
    }
}
