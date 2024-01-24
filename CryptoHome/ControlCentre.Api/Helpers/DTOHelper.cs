using ControlCentre.Api.DTO;
using ControlCentre.Api.Model;

namespace ControlCentre.Api.Helpers
{
    public static class DTOHelper
    {
        public static ControlCentreDTO ToDTO(this CryptohomeControlCentre controlCentre)
        {
            return new ControlCentreDTO
            {
                ControlCentreId = controlCentre.ControlCentreId,
                Name = controlCentre.Name
            };
        }

        public static DeviceDTO ToDTO(this CryptohomeDevice device)
        {
            return new DeviceDTO
            {
                DeviceId = device.DeviceId,
                Name = device.Name,
                Type = device.Type,
                CurrentState = device.CurrentState,
                PreviousState = device.PreviousState
            };
        }

        public static CryptohomeDevice ToModel(this NewDeviceDTO device)
        {
            return new CryptohomeDevice
            {
                DeviceId = -1,
                Name = device.Name,
                Type = device.Type,
                CurrentState = null,
                PreviousState = null
            };
        }
    }
}
