using LivreLand.ViewModel;

namespace LivreLand.View;

public partial class ScanView : ContentPage
{
    #region Properties

    public ScanVM ScanVM { get; set; }

    #endregion

    #region Constructor

    public ScanView(ScanVM scanVM)
	{
        ScanVM = scanVM;
		InitializeComponent();
        ScanVM.CameraView = cameraView;
        BindingContext = this;
	}

    #endregion
}