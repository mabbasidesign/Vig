using System.Threading.Tasks;
using Vig.Models;

namespace Vig.Persistance
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id);

    }
}