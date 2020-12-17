using System.Collections.Generic;
using System.Threading.Tasks;

using MedievalIo.Server.Client.Models;

namespace MedievalIo.Server.Client.Interfaces
{
    public interface IUserClient
    {
        Task<AuthenticateResult> AuthenticateUserAsync(ApiRequestModel apiRequestModel, string userEmail, string password);

        Task<(bool, string)> SendRegistrationRequestAsync(ApiRequestModel apiRequestModel, RegistrationRequest contract);

        Task<StatisticsResult> GetStatisticsAsync(ApiRequestModel apiRequestModel, string filter);
    }
}
