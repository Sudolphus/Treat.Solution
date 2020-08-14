using System.Collections.Generic;

namespace Treat.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.Foods = new HashSet<FlavorFood>();
    }

    public int FlavorId { get; set; }
    public string Name { get; set; }
    public ICollection<FlavorFood> Foods { get; set; }
  }
}