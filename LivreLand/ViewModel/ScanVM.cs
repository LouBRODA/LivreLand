using Camera.MAUI;
using CommunityToolkit.Maui.Alerts;
using PersonalMVVMToolkit;
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
    public class ScanVM : BaseViewModel
    {
        #region Fields

        private CameraView cameraView;
        private CameraInfo camera = null;
        private ObservableCollection<CameraInfo> cameras = new();
        private Result[] result;
        private string barcodeText = "ISBN";
        private bool addIsVisible = false;

        #endregion

        #region Properties

        public CameraView CameraView
        {
            get => cameraView;
            set
            {
                if (cameraView != value)
                {
                    cameraView = value;
                    OnPropertyChanged(nameof(CameraView));
                }
            }
        }

        public CameraInfo Camera
        {
            get => camera;
            set
            {
                if (camera != value)
                {
                    camera = value;
                    OnPropertyChanged(nameof(Camera));
                }
            }
        }

        public ObservableCollection<CameraInfo> Cameras
        {
            get => cameras;
            set
            {
                if (cameras != value)
                {
                    cameras = value;
                    OnPropertyChanged(nameof(Cameras));
                }
            }
        }

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

        public string BarcodeText
        {
            get => barcodeText;
            set
            {
                if (barcodeText != value)
                {
                    barcodeText = value;
                    OnPropertyChanged(nameof(BarcodeText));
                }
            }
        }

        public bool AddIsVisible
        {
            get => addIsVisible;
            set
            {
                if (addIsVisible != value)
                {
                    addIsVisible = value;
                    OnPropertyChanged(nameof(AddIsVisible));
                }
            }
        }

        public NavigatorVM Navigator { get; private set; }

        public ManagerVM Manager { get; private set; }

        public ICommand CamerasLoadCommand { get; private set; }

        public ICommand BarcodeDetectCommand { get; private set; }

        public ICommand AddBookISBNDetectedCommand { get; private set; }

        #endregion

        #region Constructor

        public ScanVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            CamerasLoadCommand = new RelayCommand(() => CamerasLoad());
            BarcodeDetectCommand = new RelayCommand(() => BarcodeDetect());
            AddBookISBNDetectedCommand = new RelayCommand<string>((isbn) => AddBookISBNDetected(isbn));
        }

        #endregion

        #region Methods

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

        private async Task BarcodeDetect()
        { 
            MainThread.BeginInvokeOnMainThread(() =>
            {
                BarcodeText = BarCodeResult[0].Text;
                AddIsVisible = true;
            });
        }

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
