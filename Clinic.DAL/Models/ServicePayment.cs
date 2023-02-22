namespace Clinic.DAL.Models
{
    public class ServicePayment
    {
        public int Id { get; set; }

        public int Paid { get; set; }

        public int ServiceId { get; set; }

        public int ClientId { get; set; }


        public Client Client { get; set; }

        public Service Service { get; set; }
    }
}
