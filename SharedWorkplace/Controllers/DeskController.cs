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
            return View(_context.Desks.OrderBy(t => t.Id).Include(t => t.Devices));
        }
        [Authorize(Roles = "user, admin")]
        public IActionResult Details(int id)
        {
            var c = _context.Desks.FirstOrDefault(t => t.Id == id).Devices;
            return View(_context.Desks.Include(i => i.Devices).FirstOrDefault(t => t.Id == id).Devices);
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult CreateDesk()
        {
            ViewBag.Devices = _context.Devices;
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateDesk(Desk table,int[] selectedItems)
        {
            if (table.DeskName == null) throw new Exception("Вы пытаетесь создать пустой стол");
            var devices = await _context.Devices.Where(x => selectedItems.Contains(x.Id)).ToListAsync();
            var desk = new Desk
            {
                DeskName = table.DeskName,
                Devices = devices
            };
             _context.Desks.Add(desk);
            await _context.SaveChangesAsync();

            return RedirectToAction("UserDesk", "Desk"); ;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult CreateDevice()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateDevice(Device name)
        {
            //if (_context.Devices.Find() throw new Exception("Вы пытаетесь создать пустой стол");
            var desk = new Device
            {
                DeviceName = name.DeviceName
            };
            _context.Devices.Add(desk);
            await _context.SaveChangesAsync();

            return RedirectToAction("UserDesk", "Desk"); ;
        }


    }
}
