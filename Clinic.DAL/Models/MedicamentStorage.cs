namespace Clinic.DAL.Models
{
    public class MedicamentStorage
    {
        public int Id { get; set; }

        public int MedicamentId { get; set; }

        public int CountOnStorage { get; set; }


        public Medicament Medicament { get; set; }
    }
}
