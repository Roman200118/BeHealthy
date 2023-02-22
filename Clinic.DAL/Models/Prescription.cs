namespace Clinic.DAL.Models
{
    public class Prescription
    {
        public int Id { get; set; }

        public string Reason { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public int ClientId { get; set; }

        public int? ResponsibleEmployeeId { get; set; }


        public Client Client { get; set; }

        public Employee ResponsibleEmployee { get; set; }
    }
}
