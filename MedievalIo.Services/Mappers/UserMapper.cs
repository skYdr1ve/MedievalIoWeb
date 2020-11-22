using MedievalIo.Server.Client.Models;
using MedievalIo.Services.Models.Authentication;

namespace MedievalIo.Services.Mappers
{
    public static class UserMapper
    {
        public static RegistrationRequest Map(RegistrationModel model)
        {
            return new RegistrationRequest
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
            };
        }
    }
}
