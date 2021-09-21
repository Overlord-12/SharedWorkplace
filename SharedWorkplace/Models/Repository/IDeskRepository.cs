﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models.Repository
{
   public interface IDeskRepository
    {
        Task<bool> CreateDesk(Desk table, int[] selectedItems);
        IEnumerable<Desk> GetAllDesk();
        void DeleteDesk(int id);

        void EditDesk(Desk desk, int[] selectedItems);

        Desk Details(int id);

    }
}
