using Microsoft.EntityFrameworkCore;
using WebApi.Model;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Nofication> nofications { get; set; }
        public DbSet<MonitoredDestination> monitoredDestinations { get; set; }
        public DbSet<DianosticTest> dianosticTests { get; set; }
       
    }
}
