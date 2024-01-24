using System.Xml;

namespace ControlCentre.Api.Model
{
    public class CryptohomeDevice
    {
        public int DeviceId { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public string? CurrentState { get; set; }
        public string? PreviousState { get; set; }
    }


}
