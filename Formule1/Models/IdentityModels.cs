using Microsoft.AspNet.Identity.EntityFramework;

namespace Formule1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Formule1")
        {
        }

        public System.Data.Entity.DbSet<Formule1.Models.ProfileViewModel> ProfileViewModels { get; set; }

        public System.Data.Entity.DbSet<Formule1.Models.EngineModel> EngineModels { get; set; }

        public System.Data.Entity.DbSet<Formule1.Models.ChassisModel> ChassisModels { get; set; }

        public System.Data.Entity.DbSet<Formule1.Models.DriverModel> DriverModels { get; set; }
       
        
    }
}