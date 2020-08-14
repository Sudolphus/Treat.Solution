using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
  }
}