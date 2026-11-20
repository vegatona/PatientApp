using PatientApp.Models;

namespace PatientApp.Views;

public partial class ExplorePage : ContentPage
{
    public ExplorePage()
    {
        InitializeComponent();

        ClinicsList.ItemsSource = new List<Clinic>
        {
            new Clinic
            {
                Name = "Clínica San José",
                Location = "Calle Miguel Alemán #123, Col. Centro, Ciudad Obregón.",
                Specialties = new List<string> { "Medicina General", "Pediatría", "Cardiología" },
                Schedule = "Lunes a Viernes: 08:00 AM - 07:00 PM\nSábados: 09:00 AM - 02:00 PM\nDomingos: Cerrado"
            },
            new Clinic
            {
                Name = "Dental Care Plus",
                Location = "Blvd. Rodolfo Elías Calles #450, Zona Norte, Ciudad Obregón.",
                Specialties = new List<string> { "Odontología General", "Ortodoncia", "Endodoncia" },
                Schedule = "Lunes a Viernes: 09:00 AM - 08:00 PM\nSábados: 10:00 AM - 03:00 PM\nDomingos: Cerrado"
            }
        };
    }

    private async void OnVerDetallesClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is Clinic clinica)
        {
            await Navigation.PushAsync(new ClinicDetailsPage(clinica));
        }
    }
}