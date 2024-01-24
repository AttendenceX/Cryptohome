using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCentre.Test
{
    [Collection("Sequential")]
    public class DeviceOnOffTest
    {
        private ControlCentreManager _controlCentreManager;
        private IDeviceManager _device;


        public DeviceOnOffTest()
        {
            CryptohomeManager _cryptohomeManager = new();
            var tmpControlCentre = _cryptohomeManager.GetControlCentre(1);
            _device = tmpControlCentre.GetDevice(2);
        }

        [Fact]
        public void Test0()
        {
            Assert.Equal("Dishwasher", _device.GetBase().Name);
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal("OnOff", _device.GetBase().Type);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal("off", _device.GetBase().CurrentState);
        }

        [Fact]
        public void Test3()
        {
            _device.UpdateDeviceState("on");
            Assert.Equal("on", _device.GetBase().CurrentState);
            Assert.Equal("off", _device.GetBase().PreviousState);
        }

        [Fact]
        public void Test4()
        {
            _device.UpdateDeviceState("on");
            _device.UndoDeviceStateChange();
            Assert.Equal("off", _device.GetBase().CurrentState);
            Assert.Equal("on", _device.GetBase().PreviousState);
        }


    }

}
