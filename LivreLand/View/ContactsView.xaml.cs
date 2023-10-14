using LivreLand.ViewModel;

namespace LivreLand.View;

public partial class ContactsView : ContentPage
{
    #region Properties

    public ContactsVM ContactsVM { get; set; }

    #endregion

    #region Constructor

    public ContactsView(ContactsVM contactsVM)
    {
        ContactsVM = contactsVM;
        InitializeComponent();
        BindingContext = this;
    }

    #endregion

    #region Methods

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ContactsVM.Manager.GetContactsCommand.Execute(null);
    }

    #endregion
}