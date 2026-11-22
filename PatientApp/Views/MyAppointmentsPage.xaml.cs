using PatientApp.Models;
using PatientApp.Services;

namespace PatientApp.Views;

public partial class MyAppointmentsPage : ContentPage
{
    private Appointment? _citaACancelar;

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

    private void OnCancelarClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is Appointment cita)
        {
            _citaACancelar = cita;
            LblCancelInfo.Text = $"¿Estás seguro de cancelar tu cita del {cita.Date} ({cita.Time})?\nExplica brevemente el motivo:";
            EntryCancelReason.Text = string.Empty;

            LblCancelError.IsVisible = true;
            BtnConfirmarCancelacion.IsEnabled = false;
            BtnConfirmarCancelacion.BackgroundColor = Color.FromArgb("#D1D5DB");
            BtnConfirmarCancelacion.TextColor = Color.FromArgb("#6B7280");

            CancelModalOverlay.IsVisible = true;
        }
    }

    private void OnCancelReasonChanged(object sender, TextChangedEventArgs e)
    {
        bool tieneTexto = !string.IsNullOrWhiteSpace(e.NewTextValue);

        LblCancelError.IsVisible = !tieneTexto;
        BtnConfirmarCancelacion.IsEnabled = tieneTexto;

        if (tieneTexto)
        {
            BtnConfirmarCancelacion.BackgroundColor = Color.FromArgb("#DC2626");
            BtnConfirmarCancelacion.TextColor = Colors.White;
        }
        else
        {
            BtnConfirmarCancelacion.BackgroundColor = Color.FromArgb("#D1D5DB");
            BtnConfirmarCancelacion.TextColor = Color.FromArgb("#6B7280");
        }
    }

    private void OnCerrarModalClicked(object sender, EventArgs e)
    {
        CancelModalOverlay.IsVisible = false;
        _citaACancelar = null;
    }

    private void OnConfirmarCancelacionClicked(object sender, EventArgs e)
    {
        if (_citaACancelar == null) return;

        _citaACancelar.Status = "CANCELADA";
        _citaACancelar.CancelReason = EntryCancelReason.Text.Trim();

        UserStore.CurrentUser?.UpcomingAppointments.Remove(_citaACancelar);
        UserStore.CurrentUser?.PastAppointments.Insert(0, _citaACancelar);

        CancelModalOverlay.IsVisible = false;
        _citaACancelar = null;
    }
}