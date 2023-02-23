namespace Clinic.DAL.Models
{
    public class ClientCardRecord
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }

        public int CardId { get; set; }
        
        public int DiseaseId { get; set; }

        
        public Disease Disease { get; set; }

        public ClientCard Card { get; set; }
    }
}
