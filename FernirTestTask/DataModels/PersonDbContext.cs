using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FernirTestTask.DataModels
{
    public class PersonDbContext: DbContext
    {
        private readonly IConfiguration _appConfig;

        public DbSet<Person> Persons { get; set; }

        public PersonDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DENISKRAVCHENKO\\SQLEXPRESS;Database=FernirTestProjectDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
