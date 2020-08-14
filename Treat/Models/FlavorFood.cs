namespace Treat.Models
{
  public class FlavorFood
  {
    public int FlavorFoodId { get; set; }
    public int FlavorId { get; set; }
    public int FoodId { get; set; }
    public Flavor Flavor { get; set; }
    public Food Food { get; set; }
  }
}