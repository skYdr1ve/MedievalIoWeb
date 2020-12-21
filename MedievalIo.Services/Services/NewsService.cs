using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Server.Client.Models;
using MedievalIo.Services.Interfaces;
using MedievalIo.Services.Mappers;
using MedievalIo.Services.Models.Authentication;
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

        public async Task<bool> CreateNewsAsync(CreateNewsModel model, string endPoint)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint);

            var requestModel = NewsMapper.MapCreateNewsModel(model);

            var result = await _newsClient.CreateNewsAsync(apiRequestModel, requestModel);
            if (result == null)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<NewsModel>> ListNewsRequestAsync(ListNewsModel model, string endPoint)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint);

            var requestModel = NewsMapper.MapListNewsModel(model);

            var result = await _newsClient.ListNewsRequestAsync(apiRequestModel, requestModel);

            return result.NewsList.Select(x=> NewsMapper.MapNewsEntity(x));
        }

        public async Task<NewsModel> ReadNewsRequestAsync(ReadNewsModel model, string endPoint)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint);

            var requestModel = NewsMapper.MapReadNewsModel(model);

            var result = await _newsClient.ReadNewsRequestAsync(apiRequestModel, requestModel);

            return NewsMapper.MapNewsEntity(result.News);

        }

        public async Task<bool> UpdateNewsRequestAsync(UpdateNewsModel model, string endPoint)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint);

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
