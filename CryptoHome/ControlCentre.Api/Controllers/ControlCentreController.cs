using ControlCentre.Api.DTO;
using ControlCentre.Api.Helpers;
using ControlCentre.Api.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace ControlCentre.Api.Controllers
{
    [ApiController]
    public class ControlCentreController : Controller
    {
        private readonly CryptohomeManager _cryptohomeManager;
        public ControlCentreController(CryptohomeManager cryptohomeManager)
        {
            _cryptohomeManager = cryptohomeManager;
            
        }

        [HttpGet("ControlCentres/{id}")]
        public async Task<ActionResult<ControlCentreDTO>> GetControlCentre(int id)
        {
            var tmpControlCentre = _cryptohomeManager.GetControlCentre(id);

            if (tmpControlCentre == null)
            {
                return NotFound();
            }

            return DTOHelper.ToDTO(tmpControlCentre.GetBase());
        }

    }
}
