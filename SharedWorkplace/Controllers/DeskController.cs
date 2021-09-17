using DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View(_context.Desks.OrderBy(t => t.Id));
        }
        [Authorize(Roles = "user, admin")]
        public IActionResult Details(int id)
        {
            return View(_context.Desks.FirstOrDefault(i => i.Id == id).Devices);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        //public async Task<IActionResult> Create(CreateDesk table)
        //{
        //        int check = await _context.Desks.MaxAsync(u => u.Id);
        //        Desk desk = new Desk { Id = check + 1, TableId = Convert.ToString(table.DeskId), NameTable = table.NameDesk,DeviceId = table.DeviceId };
        //        _context.Desks.Add(desk);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("UserDesk", "Desk"); ;
        //}
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Device = _context.Devices.Select(t => t.Desks).ToList();
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(Desk table)
        //{
        //    int check = await _context.Users.MaxAsync(u => u.Id);
        //    Desk desk= new Desk {Id = check+1, TableId = table.TableId, NameTable = table.NameTable,DeviceId =1};
        //    _context.Desks.Add(desk);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("UserDesk", "Desk");;
        //}

    }
}
