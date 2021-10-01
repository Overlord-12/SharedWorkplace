using Moq;
using NUnit.Framework;
using SharedWorkplace.Models;
using SharedWorkplace.Models.Repository;
using SharedWorkplace.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedWorkPlace.Tests
{
    public class DeviceServiceTests
    {
        private readonly DeviceService _sut;
        private readonly Mock<IDeviceRepository> _deviceRepositoryMock = new Mock<IDeviceRepository>();
        public DeviceServiceTests()
        {
            _sut = new DeviceService(_deviceRepositoryMock.Object);
        }

        [Test]
        public void GetAllDevicesTest()
        {

            var devices = _sut.GetAll();

            Assert.IsEmpty(devices);
        }

    }
    public class DeskServiceTests
    {
        private readonly Mock<IDeskRepository> _deskRepositoryMock = new Mock<IDeskRepository>();
        private readonly DeskService _sut;
        public DeskServiceTests()
        {
            _sut = new DeskService(_deskRepositoryMock.Object);
        }
        [Test]
        public void GetAllDesksTest()
        {
            var desk = _sut.GetAllDesk();
            Assert.IsEmpty(desk);
        }
        [Test]
        public void CreateDesk()
        {
            int[] selectedItems = { 1, 2, 3 };
            var desk = new DeskViewModel
            {
                DeskName = "TestTable",
                Id = 10
            };
            var expected = true;

            var actual = _sut.CreateDesk(desk, selectedItems);
            Assert.AreEqual(expected, actual);
        }
    }
}
