using System.Collections.Generic;

namespace Treat.Models
{
  public class Treat
  {
    public Treat()
    {
      this.Flavors = new HashSet<Flavor>();
    }

    public int TreatId { get; set; }
    public string Name { get; set; }
    public ICollection<Flavor> Flavors { get; set; }
  }
}