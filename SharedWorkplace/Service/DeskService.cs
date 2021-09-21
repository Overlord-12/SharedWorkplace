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
        public async void CreateDesk(Desk table, int[] selectedItems)
        {
            await _deskService.CreateDesk(table,selectedItems);
        }

        public void DeleteDesk(int id)
        {
            _deskService.DeleteDesk(id);
        }

        public Desk Details(int id)
        {
            return _deskService.Details(id);
        }

        public void EditDesk(Desk desk, int[] selectedItems)
        {
            _deskService.EditDesk(desk, selectedItems);
        }

        public IEnumerable<Desk> GetAllDesk()
        {
            return _deskService.GetAllDesk();
        }
    }
}
