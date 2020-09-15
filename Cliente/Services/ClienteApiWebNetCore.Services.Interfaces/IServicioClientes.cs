using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Services.Interfaces
{
    public interface IServicioClientes
    {
        Task<string> GetMessage();
    }
}
