using Camera.MAUI;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModels;
using ZXing;

namespace LivreLand.ViewModel
{
    [ObservableObject]
    public partial class ScanVM
    {
        #region Fields

        [ObservableProperty]
        private NavigatorVM navigator;

        [ObservableProperty]
        private ManagerVM manager;

        [ObservableProperty]
        private CameraView cameraView;

        [ObservableProperty]
        private CameraInfo camera = null;

        [ObservableProperty]
        private ObservableCollection<CameraInfo> cameras = new();

        [ObservableProperty]
        private Result[] result;

        [ObservableProperty]
        private string barcodeText = "ISBN";

        [ObservableProperty]
        private bool addIsVisible = false;

        #endregion

        #region Properties

        public int CamerasCount
        {
            get => Cameras.Count();
            set
            {
                if (value > 0)
                {
                    Camera = Cameras.First();
                }
            }
        }

        public Result[] BarCodeResult
        {
            get => result;
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged(nameof(BarCodeResult));
                }
            }
        }

        #endregion

        #region Constructor

        public ScanVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
        }

        #endregion

        #region Methods

        [RelayCommand]
        private async Task CamerasLoad()
        {
            if (Cameras.Count > 0)
            {
                Camera = Cameras.First();
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await CameraView.StopCameraAsync();
                    await CameraView.StartCameraAsync();
                });
            }
        }

        [RelayCommand]
        private async Task BarcodeDetect()
        { 
            MainThread.BeginInvokeOnMainThread(() =>
            {
                BarcodeText = BarCodeResult[0].Text;
                AddIsVisible = true;
            });
        }

        [RelayCommand]
        private async Task AddBookISBNDetected(string isbn)
        {
            Manager.AddBookCommand.Execute(isbn);

            var toast = Toast.Make("Livre ajouté !", CommunityToolkit.Maui.Core.ToastDuration.Short);
            await toast.Show();

            Manager.GetBooksFromCollectionCommand.Execute(null);
            Navigator.NavigationCommand.Execute("/tous");
        }

        #endregion
    }
}
