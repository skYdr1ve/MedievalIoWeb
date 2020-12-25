using System;
using System.Threading.Tasks;

using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Server.Client.Models.News.Requests;
using MedievalIo.Server.Client.Models;
using MedievalIo.Server.Client.Models.News.Responses;

namespace MedievalIo.Server.Client.Clients
{
    public class NewsClient: BaseClient, INewsClient
    {
		public async Task<CreateNewsResponse> CreateNewsAsync(ApiRequestModel apiRequestModel, CreateNewsRequestModel model)
		{
			var requestUrl = "news";

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

				return await GetResponse<CreateNewsResponse>(response);
			}
		}

		public async Task<ListNewsResponse> ListNewsRequestAsync(ApiRequestModel apiRequestModel, ListNewsRequestModel model)
		{
			var requestUrl = "news";

			var requestBody = new
			{
			};

			using (var response = await SendGetRequestAsync(apiRequestModel, requestUrl, requestBody))
			{
				if (!response.IsSuccessStatusCode)
				{
					throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
				}

				return await GetResponse<ListNewsResponse>(response);
			}
		}
		public async Task<UpdateNewsResponse> UpdateNewsRequestAsync(ApiRequestModel apiRequestModel, UpdateNewsRequestModel model)
		{
			var requestUrl = $"news/{model.Id}";

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

				return await GetResponse<UpdateNewsResponse>(response);
			}
		}

		public async Task<ReadNewsResponse> ReadNewsRequestAsync(ApiRequestModel apiRequestModel, ReadNewsRequestModel model)
		{
			var requestUrl = $"news/{model.Id}";

			var requestBody = new
			{
			};

			using (var response = await SendGetRequestAsync(apiRequestModel, requestUrl, requestBody))
			{
				if (!response.IsSuccessStatusCode)
				{
					throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
				}

				return await GetResponse<ReadNewsResponse>(response);
			}
		}
	}
}
