using System.Threading.Tasks;
using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Server.Client.Models.News.Responces;
using MedievalIo.Server.Client.Models.News.Requests;
using MedievalIo.Server.Client.Models;
using System;

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

			using (var response = await SendGetRequestAsync(apiRequestModel, requestUrl, requestBody))
			{
				if (!response.IsSuccessStatusCode)
				{
					throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
				}

				return await GetResponse<CreateNewsResponce>(response);
			}
		}

		public async Task<ListNewsResponce> ListNewsRequestAsync(ApiRequestModel apiRequestModel, ListNewsRequestModel model)
		{
			var requestUrl = "/news";

			var requestBody = new
			{
			};

			using (var response = await SendPutRequestAsync(apiRequestModel, requestUrl, requestBody))
			{
				if (!response.IsSuccessStatusCode)
				{
					throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
				}

				return await GetResponse<ListNewsResponce>(response);
			}
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

			using (var response = await SendPutRequestAsync(apiRequestModel, requestUrl, requestBody))
			{
				if (!response.IsSuccessStatusCode)
				{
					throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
				}

				return await GetResponse<UpdateNewsResponce>(response);
			}
		}

		public async Task<ReadNewsResponce> ReadNewsRequestAsync(ApiRequestModel apiRequestModel, ReadNewsRequestModel model)
		{
			var requestUrl = $"/news/{model.Id}";

			var requestBody = new
			{
			};

			using (var response = await SendGetRequestAsync(apiRequestModel, requestUrl, requestBody))
			{
				if (!response.IsSuccessStatusCode)
				{
					throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
				}

				return await GetResponse<ReadNewsResponce>(response);
			}
		}
	}
}
