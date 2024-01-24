using ControlCentre.Api.Model;

namespace ControlCentre.Api.Sevices
{
    public class DeviceOnOffManager : DeviceManagerBase, IDeviceManager
    {
        
        public DeviceOnOffManager(CryptohomeDevice device) : base(device)
        {
        }

        public void DeviceInit()
        {
            _device.CurrentState = "off";
            _device.PreviousState = "off";
            // todo: send init state to device
        }


        public string GetDeviceStatus()
        {
            return $"DeviceId = {_device.DeviceId}, " +
                $"Device Name = {_device.Name}, " +
                $"Device State = {_device.CurrentState}, " +
                $"Previous State = {_device.PreviousState}";
        }


        public CryptohomeDevice UndoDeviceStateChange()
        {
            var tmpState = _device.CurrentState;
            _device.CurrentState = _device.PreviousState;
            _device.PreviousState = tmpState;
            Console.WriteLine(GetDeviceStatus());
            // todo: send new state to device and save state
            return _device;
        }


        public CryptohomeDevice? UpdateDeviceState(string newState)
        {
            newState = string.IsNullOrEmpty(newState) ? newState : newState.ToLower();
            if (IsValidState(newState))
            {
                _device.PreviousState = _device.CurrentState;
                _device.CurrentState = newState;
                Console.WriteLine(GetDeviceStatus());
                // todo: send new state to device and save state
                return _device;
            }
            return null;
        }


        private bool IsValidState(string state)
        {
            return state == "on" || state == "off";
        }

        
    }
}
