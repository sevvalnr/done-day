using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DoneDay.Infrastructure.Data
{
    public class DoneDayDbContextFactory : IDesignTimeDbContextFactory<DoneDayDbContext>
    {
        public DoneDayDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DoneDayDbContext>();
            optionsBuilder.UseSqlite("Data Source=doneday.db"); // SQLite kullanıyoruz

            return new DoneDayDbContext(optionsBuilder.Options);
        }
    }
}
