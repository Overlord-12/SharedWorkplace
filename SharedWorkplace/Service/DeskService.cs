using SharedWorkplace.Models;
using SharedWorkplace.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Service
{
    public class DeskService : IDeskService
    {
        private IDeskRepository _deskService;

        public DeskService(IDeskRepository deskService)
        {
            _deskService = deskService;
        }
        public bool CreateDesk(DeskViewModel table, int[] selectedItems)
        {
            try
            {
                 _deskService.CreateDesk(table, selectedItems);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public Desk DeleteDevice(int desk, int id)
        {
            return _deskService.DeleteDevice(desk, id);
        }
        public void DeleteDesk(int id)
        {
            _deskService.DeleteDesk(id);
        }

        public Desk Details(int id)
        {
            return _deskService.Details(id);
        }

        public void EditDesk(Desk desk)
        {
            _deskService.EditDesk(desk);
        }

        public IEnumerable<Desk> GetAllDesk()
        {
            return _deskService.GetAllDesk();
        }

        public void AddDevice(Desk desk, int id)
        {
             _deskService.AddDevice(desk, id);
        }
    }
}
