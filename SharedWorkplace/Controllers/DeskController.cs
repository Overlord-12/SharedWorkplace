using DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedWorkplace.Models;
using SharedWorkplace.Models.Repository;
using SharedWorkplace.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Controllers
{
    public class DeskController : Controller
    {
        private IDeskService _deskService;
        private IDeviceService _deviceService;
        public DeskController(IDeskService deskService, IDeviceService deviceService)
        {
            _deskService = deskService;
            _deviceService = deviceService;
        }

        [Authorize(Roles = "user, admin")]
        public IActionResult UserDesk()
        {
            return View(_deskService.GetAllDesk());
        }
        [Authorize(Roles = "user, admin")]
        public IActionResult Details(int id)
        {
            ViewBag.Devices = _deviceService.GetAll();
            return View(_deskService.Details(id));
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult CreateDesk()
        {
            ViewBag.Devices = _deviceService.GetAll();
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public  IActionResult CreateDesk(Desk table,int[] selectedItems)
        {
            _deskService.CreateDesk(table, selectedItems);
            return RedirectToAction("UserDesk", "Desk"); ;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult CreateDevice()
        {
            ViewBag.Devices = _deviceService.GetAll();
            return View();
        }
        public IActionResult DeleteDevice(int id)
        {
            _deviceService.DeleteService(id);
            return RedirectToAction("CreateDevice","Desk");
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult CreateDevice(Device name)
        {
            _deviceService.CreateDevice(name);
            return RedirectToAction("CreateDevice", "Desk"); ;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult DeleteDesk(int id)
        {
            _deskService.DeleteDesk(id);
            return RedirectToAction("UserDesk","Desk");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult EditDesk(int id)
        {
            Desk desk = _deskService.Details(id);
            ViewBag.Devices = _deviceService.GetAll().ToList().Where(d => !desk.Devices.Contains(d)).ToArray();
            return View(desk);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult DelDeviceinDesk(int id, int id2)
        {
            _deskService.DeleteDevice(id, id2);
            return RedirectToAction("EditDesk", "Desk",new {id = id});
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AddDeviceInDesk(Desk desk, int device)
        {
            _deskService.AddDevice(desk, device);
            return RedirectToAction("EditDesk", "Desk", new { id = desk.Id });
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult EditName(Desk desk)
        {
            _deskService.EditDesk(desk);
            return RedirectToAction("EditDesk", "Desk", new { id = desk.Id });
        }
    }
}
