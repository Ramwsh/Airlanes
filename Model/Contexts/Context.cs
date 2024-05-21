using Microsoft.EntityFrameworkCore;

namespace Airlanes.Model.Contexts;

public class Context<T>:DbContext where T : class
{
    public DbSet<T> DataConteiner { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = ConnectionHelper.ConnectionString;
        optionsBuilder.UseJet(connectionString);
    }
}
