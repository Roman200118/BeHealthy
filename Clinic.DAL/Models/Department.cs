namespace Clinic.DAL.Models
{
    public class Departament
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentDepartmentId { get; set; }

        public int? ResponsibleEmployeeId { get; set; }


        public Employee ResponsibleEmployee { get; set; }

        public Departament ParentDepartment { get; set; }
    }
}
