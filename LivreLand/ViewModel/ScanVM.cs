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

namespace LivreLand.ViewModel
{
    public class ScanVM : BaseViewModel
    {
        #region Fields

        private CameraInfo camera = null;
        private ObservableCollection<CameraInfo> cameras = new();
        private int camerasCount;
        private string barcodeText = "ISBN";

        #endregion

        #region Properties

        public CameraInfo Camera
        {
            get => camera;
            set
            {
                camera = value;
                OnPropertyChanged(nameof(Camera));
                AutoStartPreview = false;
                OnPropertyChanged(nameof(AutoStartPreview));
                AutoStartPreview = true;
                OnPropertyChanged(nameof(AutoStartPreview));
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

        public ICommand StartCameraCommand { get; private set; }

        public ICommand BarcodeDetectCommand { get; private set; }

        public ICommand StartRecordingCommand { get; private set; }

        #endregion

        #region Constructor

        public ScanVM(NavigatorVM navigatorVM, ManagerVM managerVM)
        {
            Navigator = navigatorVM;
            Manager = managerVM;
            StartCameraCommand = new RelayCommand(() => StartCamera());
            BarcodeDetectCommand = new RelayCommand(() => BarcodeDetect());
            StartRecordingCommand = new RelayCommand(() => StartRecording());
        }

        #endregion

        #region Methods

        private async Task StartCamera()
        {
            AutoStartPreview = true;
            OnPropertyChanged(nameof(AutoStartPreview));
        }

        private async Task BarcodeDetect()
        {

        }

        private async Task StartRecording()
        {
            AutoStartRecording = true;
            OnPropertyChanged(nameof(AutoStartRecording));
        }

        #endregion
    }
}
