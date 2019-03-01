using System.Data.Entity;
namespace EarthquakeWPF
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
        }
        public DbSet<Client> Clients { get; set; }        
    }
}