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
            ViewBag.Devices = _deviceService.GetAll();
            return View(_deskService.Details(id));
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public  ActionResult EditDesk(Desk desk, int[] selectedItems)
        {
            _deskService.EditDesk(desk, selectedItems);
            return RedirectToAction("UserDesk", "Desk");
        }
    }
}
