using Microsoft.AspNetCore.Mvc;
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
    public ActionResult Index(string searchString)
    {
      IQueryable<Food> foodQuery = _db.Foods;
      IQueryable<Flavor> flavorQuery = _db.Flavors;
      if (!string.IsNullOrEmpty(searchString))
      {
        Regex search = new Regex(searchString, RegexOptions.IgnoreCase);
        foodQuery = foodQuery.Where(f => search.IsMatch(f.Name));
        flavorQuery = flavorQuery.Where(f => search.IsMatch(f.Name));
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

    [HttpPost]
    public ActionResult Index(string searchOption, string searchString)
    {
      if (searchOption == "all")
      {
        return RedirectToAction("Index", new { searchString = searchString});
      }
      else if (searchOption == "foods")
      {
        return RedirectToAction("Index", "Foods", new { foodName = searchString });
      }
      else if (searchOption == "flavors")
      {
        return RedirectToAction("Index", "Flavors", new { flavorName = searchString });
      }
      else
      {
        return RedirectToAction("Index");
      }
    }
  }
}