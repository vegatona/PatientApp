using PatientApp.Services;

namespace PatientApp.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var user = UserStore.CurrentUser;
        if (user == null) return;

        LblNombreCompleto.Text = user.FullName;
        LblCorreo.Text = user.Email;
        EntryNombre.Text = user.FirstName;
        EntryPaterno.Text = user.LastNameP;
        EntryMaterno.Text = user.LastNameM;
        EntryTelefono.Text = user.Phone;
        EntryEdad.Text = user.Age;
        EntryAlergias.Text = user.Allergies;
        EditorCondiciones.Text = user.Conditions;
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var user = UserStore.CurrentUser;
        if (user == null) return;

        user.FirstName = EntryNombre.Text?.Trim() ?? "";
        user.LastNameP = EntryPaterno.Text?.Trim() ?? "";
        user.LastNameM = EntryMaterno.Text?.Trim() ?? "";
        user.Phone = EntryTelefono.Text?.Trim() ?? "";
        user.Age = EntryEdad.Text?.Trim() ?? "";
        user.Allergies = EntryAlergias.Text?.Trim() ?? "";
        user.Conditions = EditorCondiciones.Text?.Trim() ?? "";

        LblNombreCompleto.Text = user.FullName;
        await DisplayAlert("Perfil Actualizado", "Tus datos se guardaron correctamente.", "OK");
    }

    private void OnCerrarSesionClicked(object sender, EventArgs e)
    {
        UserStore.CurrentUser = null;
        Application.Current!.MainPage = new NavigationPage(new LoginPage());
    }
}