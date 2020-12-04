using System.Threading.Tasks;
using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Server.Client.Models;
using MedievalIo.Services.Interfaces;
using MedievalIo.Services.Mappers;
using MedievalIo.Services.Models.Authentication;

namespace MedievalIo.Services.Services
{
	public class UserService : IUserService
	{
		private readonly IUserClient _userClient;

        public UserService(IUserClient userClient)
		{
			_userClient = userClient;
        }

		public async Task<AuthenticateResult> AuthenticateUserAsync(LoginModel model, string endPoint)
		{
			var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint);

            return await _userClient.AuthenticateUserAsync(apiRequestModel, model.UserEmail, model.Password);
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
