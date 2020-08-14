using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Treat.Models;

namespace Treat.Controllers
{
  public class FoodsController : Controller
  {
    private readonly TreatContext _db;
    public FoodsController(TreatContext db)
    {
      _db = db;
    }

    public ActionResult Index(string foodName)
    {
      IQueryable<Food> foodQuery = _db.Foods;
      if (!string.IsNullOrEmpty(foodName))
      {
        Regex foodSearch = new Regex(foodName, RegexOptions.IgnoreCase);
        foodQuery = foodQuery.Where(f => foodSearch.IsMatch(f.Name));
      }
      IEnumerable<Food> foodList = foodQuery
        .Include(food => food.Flavors)
        .ThenInclude(join => join.Flavor)
        .ToList()
        .OrderBy(food => food.Name);
      return View(foodList);
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [Authorize]
    [HttpPost]
    public ActionResult Create(Food food)
    {
      _db.Foods.Add(food);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = food.FoodId });
    }

    public ActionResult Details(int id)
    {
      Food food = _db.Foods
        .Include(f => f.Flavors)
        .ThenInclude(join => join.Flavor)
        .First(f => f.FoodId == id);
      return View(food);
    }
  }
}