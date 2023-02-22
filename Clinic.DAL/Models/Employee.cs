namespace Clinic.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime EmploymentDate { get; set; }

        public int RankId { get; set; }


        public Rank Rank { get; set; }
    }
}
