using SharedWorkplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Service
{
    public interface IDeskService
    {
        void CreateDesk(DeskViewModel table, int[] selectedItems);
        IEnumerable<Desk> GetAllDesk();
        void DeleteDesk(int id);
        void EditDesk(Desk desk);
        Desk DeleteDevice(int desk, int deviceId);
        Desk Details(int id);
        void AddDevice(Desk desk, int id);
    }
}
