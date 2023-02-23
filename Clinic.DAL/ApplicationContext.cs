using Clinic.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientCard> ClientCards { get; set; }

        public DbSet<ClientCardRecord> ClientCardRecords { get; set; }

        public DbSet<Departament> Departaments { get; set; }

        public DbSet<DoctorReferral> DoctorReferrals { get; set; }

        public DbSet<Disease> Diseases { get; set; }
        
        public DbSet<LabProcessType> LabProcessTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<LabProcess> LabProcesses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<MedicamentStorage> MedicamentStorages { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }

        public DbSet<Rank> Ranks { get; set; }

        public DbSet<StorageRequest> StorageRequests { get; set; }
    }
}