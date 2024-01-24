using ControlCentre.Api.Model;

namespace ControlCentre.Api.Sevices
{
    public interface IDeviceManager
    {
        int GetDeviceId();
        string GetDeviceName();
        CryptohomeDevice UpdateDeviceState(string newState);
        CryptohomeDevice UndoDeviceStateChange();
        string GetDeviceStatus();
        CryptohomeDevice GetBase();
    }
}
