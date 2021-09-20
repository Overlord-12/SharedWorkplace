using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models.Repository
{
   public interface IDeviceRepository
    {
        IEnumerable<Device> GetAll();
        void CreateDevice(Device name);
    }
}
