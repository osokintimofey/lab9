using lab9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace lab9.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext _context;
        public HomeController(UserContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null)
            {
                ModelState.AddModelError("", "Заполните обязательные поля");
                return BadRequest(ModelState);
            }
            /*
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Заполните верно");
                return BadRequest(ModelState);
            }*/

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

    }
}