namespace PatientApp.Models;

public class Clinic
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public List<string> Specialties { get; set; } = new();
    public string Schedule { get; set; } = string.Empty;
}