using DataBase.Entities;
using SharedWorkplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Service
{
    public interface IReservationService
    {
        bool Create(ReservationViewModel reservation);
        IEnumerable<Reservation> GetAll();
    }
}
