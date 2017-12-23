using Microsoft.AspNetCore.Mvc;
using Vig.Models;
using Vig.Persistance;

namespace Vig.Controllers
{
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly VigaDbContext context;
        public VehiclesController(VigaDbContext context)
        {
            this.context = context;
        }

        // public IActionResult CreateVehicle(Vehicle vehicle)
        // {
            
        // }
    }
}