using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models.Repository
{
    public interface IReservationRepository
    {
        bool Create(Reservation reservation);
        IEnumerable<Reservation> GetAll();
    }
}
