using DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models.Repository
{
    public class DeskRepository : IDeskRepository
    {
        private BoardContext _context;
        public DeskRepository(BoardContext board)
        {
            _context = board;
        }
        public void CreateDesk(Desk table, int[] selectedItems)
        {
            if (table.DeskName == null) throw new Exception("Вы пытаетесь создать пустой стол");
            var devices =  _context.Devices.Where(x => selectedItems.Contains(x.Id)).ToList();
            var desk = new Desk
            {
                DeskName = table.DeskName,
                Devices = devices
            };
            _context.Desks.Add(desk);
             _context.SaveChangesAsync();
        }

        public void DeleteDesk(int id)
        {
            Desk desk = _context.Desks.FirstOrDefault(t => t.Id == id);
            _context.Desks.Remove(desk);
            _context.SaveChanges();
        }

        public Desk Details(int id)
        {
            return _context.Desks.Include(i => i.Devices).FirstOrDefault(t => t.Id == id);
        }

        public async void EditDesk(Desk desk, int[] selectedItems)
        {

            List<Device> devices = await _context.Devices.Where(x => selectedItems.Contains(x.Id)).ToListAsync();
            for (int i = 0; i < devices.Count; i++)
            {
                if (desk.Devices.FirstOrDefault(t => t.Id == devices[i].Id) == null) desk.Devices.Add(devices[i]);
            }
            _context.Desks.Update(desk);
            _context.SaveChanges();
        }

        public IEnumerable<Desk> GetAllDesk()
        {
            return _context.Desks.OrderBy(t => t.Id).Include(t => t.Devices);
        }
    }
}
