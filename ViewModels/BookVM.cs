using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BookVM : ObservableObject
    {

        #region Fields

        #endregion

        #region Properties

        public Book Model { get; }

        public string Id
        {
            get => Model.Id;
        }

        public string ISBN13
        {
            get => Model.ISBN13;
        }

        public string Title
        {
            get => Model.Title;
        }

        public List<string> Publishers
        {
            get => Model.Publishers;
        }

        public DateTime PublishDate
        {
            get => Model.PublishDate;
        }

        public List<AuthorVM> Authors
        {
            get => Model.Authors.Select(a => new AuthorVM(a)).ToList();
        }

        public string Author => Model.Authors.Count > 0 ? Model.Authors.First().Name : "Auteur inconnu";

        public Status Status
        {
            get => Model.Status;
            set => SetProperty(Model.Status, value, status => Model.Status = status);
        }

        public int NbPages
        {
            get => Model.NbPages;
        }

        public Languages Language
        {
            get => Model.Language;
        }

        public string ImageSmall
        {
            get => Model.ImageSmall;
        }

        public float? UserRating
        {
            get => Model?.UserRating;
            set
            {
                if (Model == null) return;
                SetProperty(Model.UserRating, value, rating => Model.UserRating = rating);
            }
        }

        #endregion

        #region Constructor

        public BookVM(Book b)
        {
            Model = b;
        }

        #endregion
    }
}