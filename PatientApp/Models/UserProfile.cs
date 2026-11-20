using System.Collections.ObjectModel;

namespace PatientApp.Models;

public class UserProfile
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastNameP { get; set; } = string.Empty;
    public string LastNameM { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Age { get; set; } = string.Empty;
    public string Allergies { get; set; } = string.Empty;
    public string Conditions { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastNameP} {LastNameM}".Trim();

    // Citas propias de cada usuario
    public ObservableCollection<Appointment> UpcomingAppointments { get; } = new();
    public ObservableCollection<Appointment> PastAppointments { get; } = new();
}