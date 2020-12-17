using MedievalIo.Server.Client.Models;

namespace MedievalIo.Services.Mappers
{
    public class AuthenticationMapper
    {
        public static ApiRequestModel MapToApiRequestModel(string endPoint)
        {
            var result = Map(endPoint);

            return result;
        }

        public static ApiRequestModel MapToApiRequestModel(string endPoint, string token)
        {
            var result = Map(endPoint);

            result.Authorization = $"Bearer {token}";

            return result;
        }

        private static ApiRequestModel Map(string endPoint)
        {
            var formattedBaseUrl = endPoint.TrimEnd('/');

            return new ApiRequestModel
            {
                BaseUrl = $"{formattedBaseUrl}/"
            };
        }
    }
}
