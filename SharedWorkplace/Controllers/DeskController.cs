using DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedWorkplace.Models;
using SharedWorkplace.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Controllers
{
    public class DeskController : Controller
    {
        private IDeskRepository _deskRepository;
        private IDeviceRepository _deviceRepository;
        public DeskController(IDeskRepository repository, IDeviceRepository deviceRepository)
        {
            _deskRepository = repository;
            _deviceRepository = deviceRepository;
        }

        [Authorize(Roles = "user, admin")]
        public IActionResult UserDesk()
        {
            return View(_deskRepository.GetAllDesk());
        }
        [Authorize(Roles = "user, admin")]
        public IActionResult Details(int id)
        {
            return View(_deskRepository.Details(id));
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult CreateDesk()
        {
            ViewBag.Devices = _deviceRepository.GetAll();
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public  IActionResult CreateDesk(Desk table,int[] selectedItems)
        {
            //if (table.DeskName == null) throw new Exception("Вы пытаетесь создать пустой стол");
            //var devices = await _context.Devices.Where(x => selectedItems.Contains(x.Id)).ToListAsync();
            //var desk = new Desk
            //{
            //    DeskName = table.DeskName,
            //    Devices = devices
            //};
            // _context.Desks.Add(desk);
            //await _context.SaveChangesAsync();
            _deskRepository.CreateDesk(table, selectedItems);
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
        public IActionResult CreateDevice(Device name)
        {
            //if (_context.Devices.Find() throw new Exception("Вы пытаетесь создать пустой стол");
            //var desk = new Device
            //{
            //    DeviceName = name.DeviceName
            //};
            //_context.Devices.Add(desk);
            //await _context.SaveChangesAsync();
            _deviceRepository.CreateDevice(name);
            return RedirectToAction("UserDesk", "Desk"); ;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult DeleteDesk(int id)
        {
            //Desk desk = _context.Desks.FirstOrDefault(t => t.Id == id);
            //_context.Desks.Remove(desk);
            //_context.SaveChanges();
            _deskRepository.DeleteDesk(id);
            return RedirectToAction("UserDesk","Desk");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult EditDesk(int id)
        {
            ViewBag.Devices = _deviceRepository.GetAll();
            return View(_deskRepository.Details(id));
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public  ActionResult EditDesk(Desk desk, int[] selectedItems)
        {
            //List<Device> devices = await _context.Devices.Where(x => selectedItems.Contains(x.Id)).ToListAsync();
            //for (int i = 0; i < devices.Count; i++)
            //{
            //    if(desk.Devices.FirstOrDefault(t=>t.Id == devices[i].Id) == null) desk.Devices.Add(devices[i]);
            //}
            //_context.Desks.Update(desk);
            //_context.SaveChanges();
            _deskRepository.EditDesk(desk, selectedItems);
            return RedirectToAction("UserDesk", "Desk");
        }
    }
}
