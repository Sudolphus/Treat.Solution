using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Treat.Models
{
  public class TreatContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Food> Foods { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<FlavorFood> FlavorFood { get; set; }

    public TreatContext(DbContextOptions options) : base(options) { }
  }
}