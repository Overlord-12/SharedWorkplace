using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedWorkplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Controllers
{
    public class DeskController : Controller
    {
        private BoardContext _context;
        public DeskController(BoardContext context)
        {
            _context = context;
        }

        public IActionResult UserDesk()
        {
            return View(_context.Desks);
        }
        [Authorize(Roles = "user, admin")]
        public IActionResult Details(int id)
        {
            return View(_context.Desks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Desk table)
        {
            return RedirectToAction("UserDesk", "Desk");
        }
    }
}
