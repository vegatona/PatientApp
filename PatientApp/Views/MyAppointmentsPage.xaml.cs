using PatientApp.Models;
using PatientApp.Services;

namespace PatientApp.Views;

public partial class MyAppointmentsPage : ContentPage
{
    public MyAppointmentsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (UserStore.CurrentUser != null)
        {
            UpcomingList.ItemsSource = UserStore.CurrentUser.UpcomingAppointments;
            PastList.ItemsSource = UserStore.CurrentUser.PastAppointments;
        }
    }

    private void OnProximasClicked(object sender, EventArgs e)
    {
        UpcomingList.IsVisible = true;
        PastList.IsVisible = false;

        BtnProximas.BackgroundColor = Color.FromArgb("#2563EB");
        BtnProximas.TextColor = Colors.White;
        BtnHistorial.BackgroundColor = Colors.White;
        BtnHistorial.TextColor = Colors.Gray;
    }

    private void OnHistorialClicked(object sender, EventArgs e)
    {
        UpcomingList.IsVisible = false;
        PastList.IsVisible = true;

        BtnHistorial.BackgroundColor = Color.FromArgb("#2563EB");
        BtnHistorial.TextColor = Colors.White;
        BtnProximas.BackgroundColor = Colors.White;
        BtnProximas.TextColor = Colors.Gray;
    }

    private async void OnReprogramarClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is Appointment cita)
        {
            await Navigation.PushAsync(new ReschedulePage(cita));
        }
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is Appointment cita)
        {
            bool confirmar = await DisplayAlert(
                "Cancelar Cita",
                $"¿Estás seguro de cancelar tu cita del {cita.Date} ({cita.Time})?",
                "Confirmar",
                "Cancelar");

            if (confirmar)
            {
                UserStore.CurrentUser?.UpcomingAppointments.Remove(cita);
            }
        }
    }
}