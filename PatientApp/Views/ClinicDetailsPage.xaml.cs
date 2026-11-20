using PatientApp.Models;

namespace PatientApp.Views;

public partial class ClinicDetailsPage : ContentPage
{
    private readonly Clinic _clinic;

    public ClinicDetailsPage(Clinic clinic)
    {
        InitializeComponent();
        _clinic = clinic;

        LblNombre.Text = _clinic.Name;
        LblUbicacion.Text = _clinic.Location;
        LblEspecialidades.Text = string.Join("\n", _clinic.Specialties.Select(s => $"• {s}"));
        LblHorarios.Text = _clinic.Schedule;
    }

    private async void OnAgendarCitaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AppointmentFormPage(_clinic));
    }
}