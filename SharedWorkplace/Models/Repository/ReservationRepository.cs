using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace SharedWorkplace.Models.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private BoardContext _boardContext;
        public ReservationRepository(BoardContext boardContext)
        {
            _boardContext = boardContext;
        }
        public bool Create(ReservationViewModel reservation)
        {
            try
            {
                var res = new Reservation
                {
                    Desk = reservation.Desk,
                    Id = reservation.Id,
                    Devices = reservation.Devices,
                    StartTime = reservation.StartTime,
                    User = reservation.User
                };
                if (_boardContext.Reservations.FirstOrDefault(t => t.User == reservation.User && t.StartTime ==
             reservation.StartTime) != null)
                    throw new Exception("Вы не можете занимать 2 места на одно время");
                _boardContext.Reservations.Add(res);
                _boardContext.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
            
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _boardContext.Reservations.Include(t=>t.Devices).Include(t=>t.Desk).Include(t=>t.User);
        }
    }
}
