using LivreLand.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LivreLand.ViewModel
{
    public class NavigatorVM
    {
        #region Properties

        public INavigation Navigator => (App.Current as App).MainPage.Navigation;
        public ICommand TousNavigationCommand { get; }
        public ICommand EmpruntsPretsNavigationCommand { get; }
        public ICommand ALirePlusTardNavigationCommand { get; }
        public ICommand StatutLectureNavigationCommand { get; }
        public ICommand FavorisNavigationCommand { get; }
        public ICommand AuteurNavigationCommand { get; }
        public ICommand DatePublicationNavigationCommand { get; }
        public ICommand NoteNavigationCommand { get; }

        #endregion

        #region Constructor

        public NavigatorVM()
        {
            TousNavigationCommand = new Command(() => Navigator.PushAsync(new TousView()));
            EmpruntsPretsNavigationCommand = new Command(() => Navigator.PushAsync(new EmpruntsPretsView()));
            ALirePlusTardNavigationCommand = new Command(() => Navigator.PushAsync(new ALirePlusTardView()));
            StatutLectureNavigationCommand = new Command(() => Navigator.PushAsync(new StatutLectureView()));
            FavorisNavigationCommand = new Command(() => Navigator.PushAsync(new FavorisView()));
            AuteurNavigationCommand = new Command(() => Navigator.PushAsync(new FiltrageAuteurView()));
            DatePublicationNavigationCommand = new Command(() => Navigator.PushAsync(new FiltrageDateView()));
            NoteNavigationCommand = new Command(() => Navigator.PushAsync(new FiltrageNoteView()));
        }

        #endregion

        #region Methods

        #endregion
    }
}
