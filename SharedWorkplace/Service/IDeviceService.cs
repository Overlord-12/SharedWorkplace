using SharedWorkplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Service
{
    public interface IDeviceService
    {
        IEnumerable<Device> GetAll();
        Task<bool> CreateDevice(DeviceViewModel name);
        public void DeleteService(int id);
    }
}
