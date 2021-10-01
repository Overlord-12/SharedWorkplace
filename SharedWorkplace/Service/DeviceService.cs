using SharedWorkplace.Models;
using SharedWorkplace.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Service
{
    public class DeviceService : IDeviceService
    {
        private IDeviceRepository _deviceRepository;
        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        public async Task<bool> CreateDevice(DeviceViewModel name)
        {
            try
            {
                await _deviceRepository.CreateDevice(name);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void DeleteService(int id)
        {
            _deviceRepository.DeleteDevice(id);
        }
        public IEnumerable<Device> GetAll()
        {
            return _deviceRepository.GetAll();
        }

    }
}
