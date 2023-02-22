namespace Clinic.DAL.Models
{
    public class ClientCard
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public DateTime LastUpdatedAt { get; set; }


        public Client Client { get; set; }
    }
}