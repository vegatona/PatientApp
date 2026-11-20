using PatientApp.Services;

namespace PatientApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = EntryEmail.Text?.Trim().ToLower() ?? "";
        string pass = EntryPassword.Text ?? "";

        var user = UserStore.Users.FirstOrDefault(u => u.Email.ToLower() == email && u.Password == pass);

        if (user == null)
        {
            await DisplayAlert("Error", "Correo o contraseña incorrectos.", "OK");
            return;
        }

        UserStore.CurrentUser = user;
        Application.Current!.MainPage = new AppShell();
    }

    private async void OnGoToRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}