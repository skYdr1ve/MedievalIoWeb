using System.Threading.Tasks;

using MedievalIo.Server.Client.Models;
using MedievalIo.Services.Models.Authentication;

namespace MedievalIo.Services.Interfaces
{
	public interface IUserService
    {
        Task<AuthenticateResult> AuthenticateUserAsync(LoginModel model, string endPoint);

        Task<(bool, string)> RegisterUserAsync(RegistrationModel model, string endPoint);
    }
}
