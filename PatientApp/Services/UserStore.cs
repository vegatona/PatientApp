using PatientApp.Models;

namespace PatientApp.Services;

public static class UserStore
{
    public static UserProfile? CurrentUser { get; set; }

    public static List<UserProfile> Users { get; } = new()
    {
        new UserProfile
        {
            Email = "oswaldo@test.com",
            Password = "123",
            FirstName = "Jesús Oswaldo",
            LastNameP = "Vega",
            LastNameM = "Tona",
            Phone = "644 123 4567",
            Age = "22",
            Allergies = "Ninguna",
            Conditions = "",
            PastAppointments =
            {
                new Appointment
                {
                    Folio = "#00098",
                    PatientName = "Jesús Oswaldo Vega",
                    Specialty = "Medicina General",
                    ClinicName = "Clínica San José",
                    Date = "25/10/2026",
                    Time = "04:00 PM a 04:30 PM",
                    Status = "FINALIZADA"
                }
            }
        },
        new UserProfile
        {
            Email = "maria@test.com",
            Password = "123",
            FirstName = "María",
            LastNameP = "López",
            LastNameM = "García",
            Phone = "644 987 6543",
            Age = "28",
            Allergies = "Penicilina",
            Conditions = "Asma leve",
            PastAppointments =
            {
                new Appointment
                {
                    Folio = "#00074",
                    PatientName = "María López",
                    Specialty = "Odontología",
                    ClinicName = "Dental Care Plus",
                    Date = "10/09/2026",
                    Time = "10:00 AM a 10:30 AM",
                    Status = "FINALIZADA"
                }
            }
        }
    };
}