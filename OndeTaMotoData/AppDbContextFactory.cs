using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OndeTaMotoData;

namespace OndeTaMotoData 
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseOracle("User Id=rm557844;Password=160804;Data Source=oracle.fiap.com.br:1521/ORCL");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}