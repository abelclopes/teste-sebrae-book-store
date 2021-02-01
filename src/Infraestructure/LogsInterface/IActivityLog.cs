using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{
    public interface IActivityLog
    {
        Task Write(string data);
    }
} 