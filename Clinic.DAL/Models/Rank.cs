namespace Clinic.DAL.Models
{
    public class Rank
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public List<Employee> Employees { get; set; }
    }
}
