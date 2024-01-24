namespace ControlCentre.Api.Model
{
    public class CryptohomeControlCentre
    {
        public int ControlCentreId { get; set; }
        public required string Name { get; set; }
        public List<CryptohomeDevice> Devices { get; set; } = new();
    }
}
