namespace Clinic.DAL.Models
{
    public class LabProcess
    {
        public int Id { get; set; }

        public string Reason { get; set; }

        public int? DoctorId { get; set; }

        public int ClientId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string Status { get; set; }

        public string ProcessResult { get; set; }
        
        public int LabProcessTypeId { get; set; }


        public LabProcessType LabProcessType { get; set; }
        
        public Employee Doctor { get; set; }

        public Client Client { get; set; }
    }
}
