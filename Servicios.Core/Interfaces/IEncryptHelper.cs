using Servicios.Core.DTOs;

namespace Servicios.Core.Interfaces
{
    public interface IEncryptHelper
    {
        Task<ServiceHelperDTO> EncryptText(string textB64);
        Task<ServiceHelperDTO> DecryptText(string textB64);
    }
}
