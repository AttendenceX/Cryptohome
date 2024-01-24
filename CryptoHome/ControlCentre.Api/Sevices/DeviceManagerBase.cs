using ControlCentre.Api.Model;

namespace ControlCentre.Api.Sevices
{
    public class DeviceManagerBase
    {
        public readonly CryptohomeDevice _device;
        public DeviceManagerBase(CryptohomeDevice device)
        {
            _device = device;
        }


        public int GetDeviceId()
        {
            return _device.DeviceId;
        }

        public string GetDeviceName()
        {
            return _device.Name;
        }

        public CryptohomeDevice GetBase()
        {
            return _device;
        }
    }
}
