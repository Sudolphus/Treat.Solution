using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Treat.Models;
using Treat.ViewModels;

namespace Treat.Controllers
{
  public class AccountController : Controller
  {
    private readonly TreatContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(TreatContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
      _db = db;
      _userManager = userManager;
      _signInManager = signInManager;
    }

    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.UserName };
      await _userManager.CreateAsync(user, model.Password);
      return RedirectToAction("Index");
    }

    public ActionResult Login()
    {
      return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
      return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> Logout()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
  }
}