﻿using Model;
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
                publishDates.Add(date);
            }
            OnPropertyChanged(nameof(AllPublishDates));
        }
        #endregion
    }
}