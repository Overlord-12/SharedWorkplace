﻿using DataBase.Entities;
using SharedWorkplace.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Service
{
    public class ReservationSevice:IReservationService
    {
        private IReservationRepository _reservationRepository;
       public ReservationSevice(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Reservation Create(Reservation reservation)
        {
            return _reservationRepository.Create(reservation);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }

       
    }
}