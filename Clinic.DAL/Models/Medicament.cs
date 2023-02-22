namespace Clinic.DAL.Models
{
    public class Medicament
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Compound { get; set; }


        public List<Prescription> Prescriptions { get; set; }
    }
}
