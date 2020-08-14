using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Treat.Models;

namespace Treat.Controllers
{
  public class HomeController : Controller
  {
    private readonly TreatContext _db;
    public HomeController(TreatContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index(string foodName, string flavorName)
    {
      IQueryable<Food> foodQuery = _db.Foods;
      IQueryable<Flavor> flavorQuery = _db.Flavors;
      if (!string.IsNullOrEmpty(foodName))
      {
        Regex foodSearch = new Regex(foodName, RegexOptions.IgnoreCase);
        foodQuery = foodQuery.Where(f => foodSearch.IsMatch(f.Name));
      }
      if (!string.IsNullOrEmpty(flavorName))
      {
        Regex flavorSearch = new Regex(flavorName, RegexOptions.IgnoreCase);
        flavorQuery = flavorQuery.Where(f => flavorSearch.IsMatch(f.Name));
      }
      IEnumerable<Food> foodList = foodQuery
        .ToList()
        .OrderBy(f => f.Name);
      IEnumerable<Flavor> flavorList = flavorQuery
        .ToList()
        .OrderBy(f => f.Name);
      ViewBag.FoodList = foodList;
      ViewBag.FlavorList = flavorList;
      return View();
    }
  }
}