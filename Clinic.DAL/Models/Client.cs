namespace Clinic.DAL.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FistName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int ResponsibleDoctorId { get; set; }


        public Employee ResponsibleDoctor { get; set; }

        public ClientCard Card { get; set; }
    }
}
