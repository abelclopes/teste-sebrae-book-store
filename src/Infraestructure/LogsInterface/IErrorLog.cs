using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{
    public interface IErrorLog
    {
        Task Write(string data);
    }
} 