using PatientApp.Models;
using PatientApp.Services;

namespace PatientApp.Views;

public partial class AppointmentFormPage : ContentPage
{
    private readonly Clinic _clinic;

    public AppointmentFormPage(Clinic clinic)
    {
        InitializeComponent();
        _clinic = clinic;

        Title = $"Agendar - {_clinic.Name}";
        PickerEspecialidad.ItemsSource = _clinic.Specialties;
    }

    private void OnDiaSelected(object sender, EventArgs e)
    {
        var diaSeleccionado = PickerDia.SelectedItem as string;
        if (string.IsNullOrEmpty(diaSeleccionado))
            return;

        List<string> horasDisponibles = diaSeleccionado switch
        {
            "19/11/2026" => new List<string> { "10:00 AM a 10:30 AM", "12:45 PM a 01:10 PM", "04:00 PM a 04:30 PM" },
            "20/11/2026" => new List<string> { "09:00 AM a 09:30 AM", "11:30 AM a 12:00 PM" },
            "21/11/2026" => new List<string> { "09:30 AM a 10:00 AM", "10:30 AM a 11:00 AM", "01:00 PM a 01:30 PM" },
            _ => new List<string>()
        };

        PickerHora.ItemsSource = horasDisponibles;
        PickerHora.Title = "Elige un horario";
        PickerHora.IsEnabled = true;
    }

    private async void OnConfirmarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EntryNombre.Text) ||
            PickerEspecialidad.SelectedItem == null ||
            PickerDia.SelectedItem == null ||
            PickerHora.SelectedItem == null)
        {
            await DisplayAlert("Campos incompletos", "Por favor llena tu nombre, especialidad, día y horario.", "OK");
            return;
        }

        string nombreCompleto = $"{EntryNombre.Text} {EntryPaterno.Text} {EntryMaterno.Text}".Trim();
        string especialidad = PickerEspecialidad.SelectedItem as string ?? "";
        string dia = PickerDia.SelectedItem as string ?? "";
        string hora = PickerHora.SelectedItem as string ?? "";

        UserStore.CurrentUser?.UpcomingAppointments.Add(new Appointment
        {
            Folio = $"#{Random.Shared.Next(10000, 99999)}",
            PatientName = nombreCompleto,
            Specialty = especialidad,
            ClinicName = _clinic.Name,
            Date = dia,
            Time = hora,
            Status = "PENDIENTE"
        });

        await DisplayAlert("¡Cita Agendada!", $"Clínica: {_clinic.Name}\nEspecialidad: {especialidad}\nDía: {dia}\nHora: {hora}", "Aceptar");
        await Navigation.PopToRootAsync();
    }
}