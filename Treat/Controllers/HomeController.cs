using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
    public ActionResult Index(string treatName, string flavorName)
    {
      IQueryable<Food> foodQuery = _db.Foods;
      return View();
    }
  }
}