using SharedWorkplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Service
{
    public interface IDeskService
    {
        void CreateDesk(Desk table, int[] selectedItems);
        IEnumerable<Desk> GetAllDesk();
        void DeleteDesk(int id);

        void EditDesk(Desk desk, int[] selectedItems);

        Desk Details(int id);
    }
}
