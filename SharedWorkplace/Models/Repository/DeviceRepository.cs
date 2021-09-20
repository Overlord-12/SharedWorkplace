using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private BoardContext _context;
        public DeviceRepository(BoardContext board)
        {
            _context = board;
        }
        public void CreateDevice(Device name)
        {
            if (_context.Devices.FirstOrDefault(t => t.DeviceName == name.DeviceName) != null)
                throw new Exception("Такой девайс уже есть");
            var device = new Device
            {
                DeviceName = name.DeviceName
            };
            _context.Devices.Add(device);
            _context.SaveChangesAsync();
        }

        public IEnumerable<Device> GetAll()
        {
            return _context.Devices;
        }
    }
}
