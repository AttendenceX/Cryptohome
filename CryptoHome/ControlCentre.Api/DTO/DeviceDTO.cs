namespace ControlCentre.Api.DTO
{
    public class DeviceDTO
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? CurrentState { get; set; }
        public string? PreviousState { get; set; }
    }
}
