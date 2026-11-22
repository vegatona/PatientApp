using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PatientApp.Models;

public class Appointment : INotifyPropertyChanged
{
    private string _date = string.Empty;
    private string _time = string.Empty;

    public string Folio { get; set; } = string.Empty;
    public string PatientName { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string ClinicName { get; set; } = "Clínica San José";
    public string Status { get; set; } = "PENDIENTE";
    public string CancelReason { get; set; } = string.Empty;
    public bool HasCancelReason => !string.IsNullOrWhiteSpace(CancelReason);

    public string Date
    {
        get => _date;
        set { _date = value; OnPropertyChanged(); }
    }

    public string Time
    {
        get => _time;
        set { _time = value; OnPropertyChanged(); }
    }

    public Color StatusBgColor => Status == "CANCELADA"
    ? Color.FromArgb("#FEE2E2")
    : Color.FromArgb("#D1FAE5");

    public Color StatusTextColor => Status == "CANCELADA"
        ? Color.FromArgb("#DC2626")
        : Color.FromArgb("#059669");

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}