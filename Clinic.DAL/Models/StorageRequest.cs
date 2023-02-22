namespace Clinic.DAL.Models
{
    public class StorageRequest
    {
        public int Id { get; set; }

        public int RequesterId { get; set; }

        public int MedicamentId { get; set; }

        public int RequestedCount { get; set; }

        public string Reason { get; set; }


        public Medicament Medicament { get; set; }

        public Employee Requester { get; set; }
    }
}
