using ControlCentre.Api.Helpers;
using ControlCentre.Api.Model;

namespace ControlCentre.Api.Sevices
{
    public class ControlCentreManager
    {
        private CryptohomeControlCentre _controlCentre;
        private List<IDeviceManager> _devices = new();

        private void ResolveDeviceType(CryptohomeDevice device)
        {
            switch (device.Type)
            {
                case "OnOff":
                    _devices.Add(new DeviceOnOffManager(device));
                    break;
                case "OpenClose":
                    _devices.Add(new DeviceOpenCloseManager(device));
                    break;
                //case "Dimmer":
                //    _devices.Add(new DeviceDimmerManager(device));
                //    break;
                //case "Thermostat":
                //    _devices.Add(new DeviceThermostatManager(device));
                //    break;
                default:
                    Console.WriteLine($"Unknown device type {device.Type}");
                    break;
            }
        }

        public ControlCentreManager(CryptohomeControlCentre controlCentre)
        {
            _controlCentre = controlCentre;
            _controlCentre.Devices.ForEach(item => ResolveDeviceType(item));
        }


        public async Task<int?> AddDevice(CryptohomeDevice newDevice)
        {
            ResolveDeviceType(newDevice);
            _controlCentre.Devices.Add(newDevice);
            // todo: persist device to database and return the id
            return newDevice.DeviceId;
        }

        public CryptohomeControlCentre GetBase()
        {
            return _controlCentre;
        }


        public int GetControlCentreId()
        {
            return _controlCentre.ControlCentreId;
        }


        public string GetControlCentreName()
        {
            return _controlCentre.Name;
        }


        public IDeviceManager? GetDevice(int deviceId)
        {
            return _devices.FirstOrDefault(d => d.GetDeviceId() == deviceId);
        }


        public List<CryptohomeDevice> ListDevices()
        {
            _devices.ForEach(d => Console.WriteLine(d.GetDeviceStatus()));
            return _devices.Select(x => x.GetBase()).ToList();
        }


    }
}
