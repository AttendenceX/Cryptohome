using ControlCentre.Api.Model;

namespace ControlCentre.Api.Sevices
{
    public class CryptohomeManager
    {
        private List<ControlCentreManager> _controlCentreManagers = new();

        public CryptohomeManager()
        {
            // todo: need to add a switch to determine if we are using mock data or not
            InitWithMockData();
        }

        public ControlCentreManager? GetControlCentre(int controlCentreId)
        {
            var tmpControlCentreManager = _controlCentreManagers
                .FirstOrDefault(x => x.GetControlCentreId() == controlCentreId);
            if (tmpControlCentreManager == null)
            {
                Console.WriteLine($"Control Centre {controlCentreId} not found");
                return null;
            }
            Console.WriteLine($"ControlCentreId: {tmpControlCentreManager.GetControlCentreId()}. " +
                 $"ControlCentreName = {tmpControlCentreManager.GetControlCentreName()}");
            return tmpControlCentreManager;
        }

        public void InitWithMockData()
        {
            _controlCentreManagers.Add(new ControlCentreManager(
                new CryptohomeControlCentre()
                {
                    ControlCentreId = 1,
                    Name = "Test Control Centre",
                    Devices = new List<CryptohomeDevice>()
                    {
                        new CryptohomeDevice()
                        {
                            DeviceId = 1,
                            Name = "Garage Door",
                            Type = "OpenClose",
                            CurrentState = "close",
                            PreviousState = "close"
                        },
                        new CryptohomeDevice()
                        {
                            DeviceId = 2,
                            Name = "Dishwasher",
                            Type = "OnOff",
                            CurrentState = "off",
                            PreviousState = "off"
                        },
                        new CryptohomeDevice()
                        {
                            DeviceId = 3,
                            Name = "Lights",
                            Type = "OnOff",
                            CurrentState = "off",
                            PreviousState = "off"
                        },
                    }

                }
            ));
 
        }
    }
}
