using System.Threading.Tasks;
using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Server.Client.Models;
using MedievalIo.Services.Interfaces;
using MedievalIo.Services.Mappers;
using MedievalIo.Services.Models.Authentication;


namespace MedievalIo.Services.Services
{
    public class NewsService: INewsService
    {
        private readonly INewsClient _newsClient;

        public NewsService(INewsClient newsClient)
        {
            _newsClient = newsClient;
        }

        public async Task<AuthenticateResult> AuthenticateUserAsync(LoginModel model, string endPoint)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint);

            return await _newsClient.AuthenticateUserAsync(apiRequestModel, model.UserEmail, model.Password);
        }

        public async Task<bool> RegisterUserAsync(RegistrationModel model, string endPoint)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint);

            var request = UserMapper.Map(model);

            var result = await _userClient.SendRegistrationRequestAsync(apiRequestModel, request);

            if (result != null)
            {
                return true;
            }

            return false;
        }
    }
}
