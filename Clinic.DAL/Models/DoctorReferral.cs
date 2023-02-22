namespace Clinic.DAL.Models
{
    public class DoctorReferral
    {
        public int Id { get; set; }

        public int? DoctorId { get; set; }

        public int ClientId { get; set; }


        public Employee Doctor { get; set; }

        public Client Client { get; set; }
    }
}
