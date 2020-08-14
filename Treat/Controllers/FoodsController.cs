using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    [Authorize]
    public ActionResult Edit(int id)
    {
      Food food = _db.Foods.First(f => f.FoodId == id);
      return View(food);
    }

    [Authorize]
    [HttpPost]
    public ActionResult Edit(Food food)
    {
      _db.Entry(food).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = food.FoodId });
    }

    [Authorize]
    [HttpPost]
    public ActionResult Delete(int id)
    {
      Food food = _db.Foods.First(f => f.FoodId == id);
      _db.Foods.Remove(food);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult AddFlavor(int id)
    {
      Food food = _db.Foods.First(f => f.FoodId == id);
      IEnumerable<Flavor> flavorList = _db.Flavors
        .ToList()
        .OrderBy(f => f.Name);
      ViewBag.FlavorId = new SelectList(flavorList, "FlavorId", "Name");
      return View(food);
    }

    [Authorize]
    [HttpPost]
    public ActionResult AddFlavor(Food food, int flavorId)
    {
      Flavor flavor = _db.Flavors.First(f => f.FlavorId == flavorId);
      FlavorFood join = null;
      try
      {
        join = _db.FlavorFood
          .Where(entry => entry.FoodId == food.FoodId)
          .First(entry => entry.FlavorId == flavorId);
      }
      catch
      {
        _db.FlavorFood.Add(new FlavorFood() { FlavorId = flavorId, FoodId = food.FoodId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = food.FoodId });
    }
  }
}