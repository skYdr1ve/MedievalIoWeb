using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MedievalIo.Server.Client.Models;

namespace MedievalIo.Server.Client.Interfaces
{
    public interface IUserClient
    {
        Task<AuthenticateResult> AuthenticateUserAsync(ApiRequestModel apiRequestModel, string userEmail, string password);

        Task<RegisterUserResult> SendRegistrationRequestAsync(ApiRequestModel apiRequestModel, RegistrationRequest contract);
    }
}
