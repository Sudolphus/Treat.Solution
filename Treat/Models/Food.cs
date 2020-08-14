using System.Collections.Generic;

namespace Treat.Models
{
  public class Food
  {
    public Food()
    {
      this.Flavors = new HashSet<FlavorFood>();
    }

    public int FoodId { get; set; }
    public string Name { get; set; }
    public ICollection<FlavorFood> Flavors { get; set; }
  }
}