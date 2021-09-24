using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Service
{
    public interface IReservationService
    {
        Reservation Create(Reservation reservation);
        IEnumerable<Reservation> GetAll();
    }
}
