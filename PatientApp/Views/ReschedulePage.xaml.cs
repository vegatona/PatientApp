using PatientApp.Models;

namespace PatientApp.Views;

public partial class ReschedulePage : ContentPage
{
    private readonly Appointment _appointment;

    public ReschedulePage(Appointment appointment)
    {
        InitializeComponent();
        _appointment = appointment;
        LblInfoCita.Text = $"{_appointment.ClinicName} • {_appointment.Specialty} ({_appointment.Folio})";
    }

    private void OnDiaSelected(object sender, EventArgs e)
    {
        var dia = PickerDia.SelectedItem as string;
        if (string.IsNullOrEmpty(dia)) return;

        List<string> horas = dia switch
        {
            "19/11/2026" => new() { "10:00 AM a 10:30 AM", "12:45 PM a 01:10 PM", "04:00 PM a 04:30 PM" },
            "20/11/2026" => new() { "09:00 AM a 09:30 AM", "11:30 AM a 12:00 PM" },
            "21/11/2026" => new() { "09:30 AM a 10:00 AM", "10:30 AM a 11:00 AM", "01:00 PM a 01:30 PM" },
            _ => new()
        };

        PickerHora.ItemsSource = horas;
        PickerHora.Title = "Elige un horario";
        PickerHora.IsEnabled = true;
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (PickerDia.SelectedItem == null || PickerHora.SelectedItem == null)
        {
            await DisplayAlert("Faltan datos", "Selecciona un nuevo día y horario.", "OK");
            return;
        }

        _appointment.Date = PickerDia.SelectedItem as string ?? _appointment.Date;
        _appointment.Time = PickerHora.SelectedItem as string ?? _appointment.Time;

        await DisplayAlert("Cita Actualizada", $"Nuevo horario:\n{_appointment.Date} • {_appointment.Time}", "OK");
        await Navigation.PopAsync();
    }
}