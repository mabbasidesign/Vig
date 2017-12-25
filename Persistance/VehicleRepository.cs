using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vig.Models;

namespace Vig.Persistance
{
    public class VehicleRepository
    {
        private readonly VigaDbContext context;
        public VehicleRepository(VigaDbContext context)
        {
            this.context = context;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            return await context.Vehicles
            .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
            .Include(v => v.Model)
                .ThenInclude(m => m.Make)
            .SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}