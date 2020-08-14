using System.Collections.Generic;

namespace Treat.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.Treats = new HashSet<Treat>();
    }

    public int FlavorId { get; set; }
    public string Name { get; set; }
    public ICollection<Treat> Treats { get; set; }
  }
}