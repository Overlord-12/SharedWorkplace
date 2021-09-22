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

        public void AddDevice(Desk desk, int id)
        {
            Desk des = _context.Desks.FirstOrDefault(t=> t.Id == desk.Id);
            Device device = _context.Devices.FirstOrDefault(t => t.Id == id);
            des.Devices.Add(device);
            _context.SaveChanges();
        }

        public async Task<bool> CreateDesk(Desk table, int[] selectedItems)
        {
            try
            {
                if (table.DeskName == null) throw new Exception("Вы пытаетесь создать пустой стол");
                var devices = _context.Devices.Where(x => selectedItems.Contains(x.Id)).ToList();
                var desk = new Desk
                {
                    DeskName = table.DeskName,
                    Devices = devices
                };
                _context.Desks.Add(desk);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void DeleteDesk(int id)
        {
            Desk desk = _context.Desks.FirstOrDefault(t => t.Id == id);
            _context.Desks.Remove(desk);
            _context.SaveChanges();
        }

        public Desk DeleteDevice(int deskId, int id)
        {
            var c = _context.Devices.FirstOrDefault(i => i.Id == id);
            var desk = _context.Desks.Include(t=>t.Devices).FirstOrDefault(i => i.Id == deskId);
            desk.Devices.Remove(c);
            _context.Desks.Update(desk);
            _context.SaveChanges();
            return desk;
        }

        public Desk Details(int id)
        {
            return _context.Desks.Include(i => i.Devices).FirstOrDefault(t => t.Id == id);
        }
        public void EditDesk(Desk desk)
        {
            _context.Desks.Update(desk);
            _context.SaveChanges();
        }

        public IEnumerable<Desk> GetAllDesk()
        {
            return _context.Desks.OrderBy(t => t.Id).Include(t => t.Devices);
        }
    }
}
