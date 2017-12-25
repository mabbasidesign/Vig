
using System.Threading.Tasks;

namespace Vig.Core
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}