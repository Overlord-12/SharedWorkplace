using DataBase;
using DataBase.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private IUserService _userService;
        private IReservationService _reservationService;

        public DeskController(IReservationService reservationService, IUserService userService, IDeskService deskService, IDeviceService deviceService, BoardContext boardContext)
        {
            _deskService = deskService;
            _deviceService = deviceService;
            _userService = userService;
            _reservationService = reservationService;
        }

        [Authorize(Roles = "user, admin")]
        public IActionResult UserDesk()
        {
            return View(_deskService.GetAllDesk());
        }
        [Authorize(Roles = "user, admin")]
        public IActionResult ReservationDesk()
        {
            return View(_reservationService.GetAll());
        }

        [Authorize(Roles = "user, admin")]
        public IActionResult Reservation(int id)
        {
            List<string> dateTimes = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                var date = DateTime.Now.AddDays(i);
                if (_reservationService.GetAll().FirstOrDefault(t => t.StartTime.Date == DateTime.Now.AddDays(i).Date &&
                t.Desk.Id == id) == null)
                    dateTimes.Add(DateTime.Now.AddDays(i).ToString("d"));
            }
            var reservation = new Reservation
            {
                Desk = _deskService.GetAllDesk().FirstOrDefault(t => t.Id == id),
                Devices = _deskService.GetAllDesk().FirstOrDefault(t => t.Id == id).Devices
            };
            ViewBag.Date = dateTimes;
            ViewBag.Id = reservation.Desk.Id;
            return View(reservation);
        }
        [Authorize(Roles = "user, admin")]
        [HttpPost]
        public IActionResult Reservation(string time, int[] selectedItems, int deskId)
        {
            var Reservation = new Reservation
            {
                Desk = _deskService.GetAllDesk().FirstOrDefault(t => t.Id == deskId),
                Devices = _deviceService.GetAll().Where(x => selectedItems.Contains(x.Id)).ToList(),
                StartTime = Convert.ToDateTime(time),
                User = _userService.GetAllUser().FirstOrDefault(t => t.Login == User.Identity.Name)
            };
            _reservationService.Create(Reservation);
            return RedirectToAction("UserDesk", "Desk");
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
        public IActionResult CreateDesk(Desk table, int[] selectedItems)
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
            return RedirectToAction("CreateDevice", "Desk");
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
            return RedirectToAction("UserDesk", "Desk");
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
            return RedirectToAction("EditDesk", "Desk", new { id = id });
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
