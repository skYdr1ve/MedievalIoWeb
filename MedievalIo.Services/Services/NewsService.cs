using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Server.Client.Models.News.Requests;
using MedievalIo.Services.Interfaces;
using MedievalIo.Services.Mappers;
using MedievalIo.Services.Models.News;

namespace MedievalIo.Services.Services
{
    public class NewsService: INewsService
    {
        private readonly INewsClient _newsClient;

        public NewsService(INewsClient newsClient)
        {
            _newsClient = newsClient;
        }

        public async Task<bool> CreateNewsAsync(CreateNewsModel model, string endPoint, string token)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint, token);

            var requestModel = NewsMapper.MapCreateNewsModel(model);

            var result = await _newsClient.CreateNewsAsync(apiRequestModel, requestModel);
            if (result == null)
            {
                return false;
            }

            return true;
        }

        public async Task<List<NewsModel>> ListNewsRequestAsync(string endPoint, string token)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint, token);

            var result = await _newsClient.ListNewsRequestAsync(apiRequestModel, new ListNewsRequestModel());

            return NewsMapper.Map(result);
        }

        public async Task<NewsModel> ReadNewsRequestAsync(ReadNewsModel model, string endPoint, string token)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint, token);

            var requestModel = NewsMapper.MapReadNewsModel(model);

            var result = await _newsClient.ReadNewsRequestAsync(apiRequestModel, requestModel);

            return NewsMapper.MapNewsEntity(result.News);

        }

        public async Task<bool> UpdateNewsRequestAsync(UpdateNewsModel model, string endPoint, string token)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint, token);

            var requestModel = NewsMapper.MapUpdateNewsModel(model);

            var result = await _newsClient.UpdateNewsRequestAsync(apiRequestModel, requestModel);
            if (result == null)
            {
                return false;
            }

            return true;
        }
    }
}
