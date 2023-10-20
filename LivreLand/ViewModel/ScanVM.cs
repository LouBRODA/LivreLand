using Camera.MAUI;
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
        private int camerasCount;
        private Result[] result;
        private string barcodeText = "ISBN";

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
            get => camerasCount = Cameras.Count();
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

        public bool AutoStartPreview { get; set; } = false;
        
        public bool AutoStartRecording { get; set; } = false;

        public NavigatorVM Navigator { get; private set; }

        public ManagerVM Manager { get; private set; }

        public ICommand CamerasLoadCommand { get; private set; }

        public ICommand BarcodeDetectCommand { get; private set; }

        #endregion

        #region Constructor

        public ScanVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            CamerasLoadCommand = new RelayCommand(() => CamerasLoad());
            BarcodeDetectCommand = new RelayCommand(() => BarcodeDetect());
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
            });
        }

        #endregion
    }
}
