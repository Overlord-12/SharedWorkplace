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
        public Reservation Create(Reservation reservation)
        {
         
            _boardContext.Reservations.Add(reservation);
            _boardContext.SaveChanges();
            return reservation;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _boardContext.Reservations.Include(t=>t.Devices).Include(t=>t.Desk).Include(t=>t.User);
        }
    }
}
