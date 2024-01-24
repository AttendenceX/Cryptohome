
namespace ControlCentre.Test
{
    [Collection("Sequential")]
    public class DeviceOpenCloseTest
    {
        private ControlCentreManager _controlCentreManager;
        private IDeviceManager _device;


        public DeviceOpenCloseTest()
        {
            CryptohomeManager _cryptohomeManager = new();
            var tmpControlCentre = _cryptohomeManager.GetControlCentre(1);
            _device = tmpControlCentre.GetDevice(1);
        }

        [Fact]
        public void Test0()
        {
            Assert.Equal("Garage Door", _device.GetBase().Name);
        }

        [Fact] public void Test1()
        {
            Assert.Equal("OpenClose", _device.GetBase().Type);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal("close", _device.GetBase().CurrentState);
        }

        [Fact]
        public void Test3()
        {
            _device.UpdateDeviceState("open");
            Assert.Equal("open", _device.GetBase().CurrentState);
            Assert.Equal("close", _device.GetBase().PreviousState);
        }

        [Fact]
        public void Test4()
        {
            _device.UpdateDeviceState("open");
            _device.UndoDeviceStateChange();
            Assert.Equal("close", _device.GetBase().CurrentState);
            Assert.Equal("open", _device.GetBase().PreviousState);
        }


    }
}