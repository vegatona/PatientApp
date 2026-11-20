using PatientApp.Models;
using PatientApp.Services;

namespace PatientApp.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EntryEmail.Text) ||
            string.IsNullOrWhiteSpace(EntryPassword.Text) ||
            string.IsNullOrWhiteSpace(EntryNombre.Text) ||
            string.IsNullOrWhiteSpace(EntryTelefono.Text))
        {
            await DisplayAlert("Campos requeridos", "Completa al menos correo, contraseña, nombre y teléfono.", "OK");
            return;
        }

        var nuevoUsuario = new UserProfile
        {
            Email = EntryEmail.Text.Trim(),
            Password = EntryPassword.Text,
            FirstName = EntryNombre.Text.Trim(),
            LastNameP = EntryPaterno.Text?.Trim() ?? "",
            LastNameM = EntryMaterno.Text?.Trim() ?? "",
            Phone = EntryTelefono.Text.Trim(),
            Age = EntryEdad.Text?.Trim() ?? "",
            Allergies = string.IsNullOrWhiteSpace(EntryAlergias.Text) ? "Ninguna" : EntryAlergias.Text.Trim(),
            Conditions = EditorCondiciones.Text?.Trim() ?? ""
        };

        UserStore.Users.Add(nuevoUsuario);
        UserStore.CurrentUser = nuevoUsuario;

        await DisplayAlert("¡Bienvenido!", "Tu cuenta ha sido creada.", "Continuar");
        Application.Current!.MainPage = new AppShell();
    }
}