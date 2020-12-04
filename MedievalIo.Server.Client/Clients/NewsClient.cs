using System.Threading.Tasks;
using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Server.Client.Models.News.Responces;
using MedievalIo.Server.Client.Models.News.Requests;
using MedievalIo.Server.Client.Models;

namespace MedievalIo.Server.Client.Clients
{
    public class NewsClient: BaseClient, INewsClient
    {
		public async Task<CreateNewsResponce> CreateNewsAsync(ApiRequestModel apiRequestModel, CreateNewsRequestModel model)
		{
			var requestUrl = "/news";

			var requestBody = new
			{
				title = model.Title,
				description = model.Description,
				image_link = model.ImageLink
			};

			return await SendRequestAsync<CreateNewsResponce>(apiRequestModel, requestUrl, requestBody);
		}

		public async Task<ListNewsResponce> ListNewsRequestAsync(ApiRequestModel apiRequestModel, ListNewsRequestModel model)
		{
			var requestUrl = "/news";

			return await SendGetRequestAsync<ListNewsResponce>(apiRequestModel, requestUrl);
		}
		public async Task<UpdateNewsResponce> UpdateNewsRequestAsync(ApiRequestModel apiRequestModel, UpdateNewsRequestModel model)
		{
			var requestUrl = $"/news/{model.Id}";

			var requestBody = new
			{
				title = model.Title,
				description = model.Description,
				image_link = model.ImageLink
			};

			return await SendPutRequestAsync<UpdateNewsResponce>(apiRequestModel, requestUrl, requestBody);
		}

		public async Task<ReadNewsResponce> ReadNewsRequestAsync(ApiRequestModel apiRequestModel, ReadNewsRequestModel model)
		{
			var requestUrl = $"/news/{model.Id}";

			return await SendGetRequestAsync<ReadNewsResponce>(apiRequestModel, requestUrl);
		}
	}
}
