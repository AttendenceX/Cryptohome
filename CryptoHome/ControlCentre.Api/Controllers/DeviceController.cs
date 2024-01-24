using ControlCentre.Api.DTO;
using ControlCentre.Api.Helpers;
using ControlCentre.Api.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace ControlCentre.Api.Controllers
{

    [ApiController]
    public class DeviceController : Controller
    {

        private readonly CryptohomeManager _cryptohomeManager;
        public DeviceController(CryptohomeManager cryptohomeManager)
        {
            _cryptohomeManager = cryptohomeManager;

        }


        [HttpGet("ControlCentres/{id}/Devices")]
        public async Task<ActionResult<IEnumerable<DeviceDTO>>> ListDevices(int id)
        {
            var tmpControlCentre = _cryptohomeManager.GetControlCentre(id);
            if (tmpControlCentre == null)
            {
                return NotFound();
            }

            return tmpControlCentre.ListDevices().Select(x => DTOHelper.ToDTO(x)).ToList();
        }


        [HttpGet("ControlCentres/{id}/Devices/{deviceId}")]
        public async Task<ActionResult<DeviceDTO>> GetDevice(int id, int deviceId)
        {
            var tmpControlCentre = _cryptohomeManager.GetControlCentre(id);
            if (tmpControlCentre == null)
            {
                return NotFound();
            }

            var tmpDevice = tmpControlCentre.GetDevice(deviceId);
            if (tmpDevice == null)
            {
                return NotFound();
            }

            return DTOHelper.ToDTO(tmpDevice.GetBase());
        }


        [HttpGet("ControlCentres/{id}/Devices/{deviceId}/State/{state}")]
        public async Task<ActionResult<DeviceDTO>> UpdateDeviceState(int id, int deviceId, string state)
        {
            var tmpControlCentre = _cryptohomeManager.GetControlCentre(id);
            if (tmpControlCentre == null)
            {
                return NotFound();
            }

            var tmpDevice = tmpControlCentre.GetDevice(deviceId);
            if (tmpDevice == null)
            {
                return NotFound();
            }

            if (tmpDevice.UpdateDeviceState(state) == null)
            {
                return BadRequest("Error updating device state");
            }

            return DTOHelper.ToDTO(tmpDevice.GetBase());
        }


        [HttpGet("ControlCentres/{id}/Devices/{deviceId}/Undo")]
        public async Task<ActionResult<DeviceDTO>> UpdateDeviceState(int id, int deviceId)
        {
            var tmpControlCentre = _cryptohomeManager.GetControlCentre(id);
            if (tmpControlCentre == null)
            {
                return NotFound();
            }

            var tmpDevice = tmpControlCentre.GetDevice(deviceId);
            if (tmpDevice == null)
            {
                return NotFound();
            }

            if (tmpDevice.UndoDeviceStateChange() == null)
            {
                return BadRequest("Error updating device state");
            }

            return DTOHelper.ToDTO(tmpDevice.GetBase());
        }


        [HttpPost("ControlCentres/{id}/Devices/New")]
        public async Task<ActionResult<DeviceDTO>> AddDevice(int id, [FromBody] NewDeviceDTO newDevice)
        {
            var tmpControlCentre = _cryptohomeManager.GetControlCentre(id);
            if (tmpControlCentre == null)
            {
                return NotFound();
            }

            var tmpDevice = DTOHelper.ToModel(newDevice);

            if (tmpDevice == null)
            {
                return BadRequest("Device is badly formed");
            }

            if (tmpControlCentre.AddDevice(tmpDevice) == null)
            {
                return BadRequest("Error adding device");
            }

            return DTOHelper.ToDTO(tmpDevice);
        }
    }
}
