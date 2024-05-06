using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using MovieBooking.Models;

namespace MovieBooking.Controllers
{
    public class AccountController : Controller
    {
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;

        private readonly AppDbContext _db;
        private readonly ISession _session;
        public AccountController(AppDbContext db, ISession session)
        {
            _db = db;
            _session = session;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if(ModelState.IsValid)
            {
                var obj = _db.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
                if(obj != null)
                {
                    _session.SetString("User",obj.Email);
                    _session.SetString("IsAdmin", obj.IsAdmin.ToString());

                }
            }
            return RedirectToAction("Index", "Home");
            
        }

        



    }
}
