using LivreLand.Model;
using LivreLand.ViewModel;

namespace LivreLand.View;

public partial class StatutLectureView : ContentPage
{
    #region Properties

    public StatutLectureVM StatutLectureVM { get; set; }

    #endregion

    #region Constructor

    public StatutLectureView(StatutLectureVM statutLectureVM)
	{
        StatutLectureVM = statutLectureVM;
        InitializeComponent();
        BindingContext = this;
	}

    #endregion

    #region Methods

    #endregion
}