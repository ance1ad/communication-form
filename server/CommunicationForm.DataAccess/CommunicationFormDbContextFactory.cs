using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CommunicationForm.DataAccess
{
    public class CommunicationFormDbContextFactory : IDesignTimeDbContextFactory<CommunicationFormDbContext>
    {
        public CommunicationFormDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CommunicationFormDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=db;Username=postgres;Password=123");

            return new CommunicationFormDbContext(optionsBuilder.Options);
        }
    }
}
