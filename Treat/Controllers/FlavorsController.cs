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
  public class FlavorsController : Controller
  {
    private readonly TreatContext _db;
    public FlavorsController(TreatContext db)
    {
      _db = db;
    }

    public ActionResult Index(string flavorName)
    {
      IQueryable<Flavor> flavorQuery = _db.Flavors;
      if (!string.IsNullOrEmpty(flavorName))
      {
        Regex flavorSearch = new Regex(flavorName, RegexOptions.IgnoreCase);
        flavorQuery = flavorQuery.Where(f => flavorSearch.IsMatch(f.Name));
      }
      IEnumerable<Flavor> flavorList = flavorQuery
        .Include(f => f.Foods)
        .ThenInclude(join => join.Food)
        .OrderBy(f => f.Name);
      return View(flavorList);
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [Authorize]
    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    public ActionResult Details(int id)
    {
      Flavor flavor = _db.Flavors
        .Include(f => f.Foods)
        .ThenInclude(join => join.Food)
        .First(f => f.FlavorId == id);
      return View(flavor);
    }

    [Authorize]
    public ActionResult Edit(int id)
    {
      Flavor flavor = _db.Flavors.First(f => f.FlavorId == id);
      return View(flavor);
    }

    [Authorize]
    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    [Authorize]
    [HttpPost]
    public ActionResult Delete(int id)
    {
      Flavor flavor = _db.Flavors.First(f => f.FlavorId == id);
      _db.Flavors.Remove(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult AddFood(int id)
    {
      Flavor flavor = _db.Flavors.First(f => f.FlavorId == id);
      IEnumerable<Food> foodList = _db.Foods
        .ToList()
        .OrderBy(f => f.Name);
      ViewBag.FoodId = new SelectList(foodList, "FoodId", "Name");
      return View(flavor);
    }

    [Authorize]
    [HttpPost]
    public ActionResult AddFood(Flavor flavor, int foodId)
    {
      Food food = _db.Foods.First(f => f.FoodId == foodId);
      try
      {
        FlavorFood join = _db.FlavorFood
          .Where(entry => entry.FoodId == foodId)
          .First(entry => entry.FlavorId == flavor.FlavorId);
      }
      catch
      {
        _db.FlavorFood.Add(new FlavorFood() { FoodId = foodId, FlavorId = flavor.FlavorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    [Authorize]
    [HttpPost]
    public ActionResult RemoveFood(int id, int joinId)
    {
      FlavorFood joinEntry = _db.FlavorFood.First(entry => entry.FlavorFoodId == joinId);
      _db.FlavorFood.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = id });
    }
  }
}