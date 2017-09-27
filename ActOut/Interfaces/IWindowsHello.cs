using System.Threading.Tasks;
using ActOut.Models;

namespace ActOut.Interfaces
{
    public interface IWindowsHello
    {
        //Interface de Windows Hello
        Task<bool> GetPassportAuthenticationMessageAsync(LastUser account);
    }
}
