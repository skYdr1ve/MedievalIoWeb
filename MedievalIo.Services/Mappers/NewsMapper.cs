using System.Collections.Generic;
using System.Linq;
using MedievalIo.Server.Client.Models.News;
using MedievalIo.Server.Client.Models.News.Requests;
using MedievalIo.Server.Client.Models.News.Responses;
using MedievalIo.Services.Models.News;

namespace MedievalIo.Services.Mappers
{
    public static class NewsMapper
    {
        #region toRequestModel
        public static CreateNewsRequestModel MapCreateNewsModel(CreateNewsModel model)
        {
            return new CreateNewsRequestModel
            {
                Title = model.Title,
                Description = model.Description,
                ImageLink = model.ImageLink,
            };
        }

        public static UpdateNewsRequestModel MapUpdateNewsModel(UpdateNewsModel model)
        {
            return new UpdateNewsRequestModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                ImageLink = model.ImageLink,
            };
        }

        public static ListNewsRequestModel MapListNewsModel(ListNewsModel model)
        {
            return new ListNewsRequestModel
            {
            };
        }

        public static ReadNewsRequestModel MapReadNewsModel(ReadNewsModel model)
        {
            return new ReadNewsRequestModel
            {
                Id = model.Id
            };
        }

        #endregion


        #region toServiceModelFromResponce

        public static NewsModel MapCreateNewsResponce(CreateNewsResponse model)
        {
            return MapNewsEntity(model.News);
        }

        public static UpdateNewsModel MapUpdateNewsResponce(UpdateNewsResponse model)
        {
            return new UpdateNewsModel
            {

            };
        }

        public static ListNewsModel MapListNewsResponce(ListNewsResponse model)
        {
            return new ListNewsModel
            {
                
            };
        }

        public static List<NewsModel> Map(ListNewsResponse model)
        {
            return model?.Results?.Select(x=> new NewsModel
            {
                Id= x.Id,
                CreatedAt = x.CreatedAt,
                Description = x.Description,
                Title = x.Title,
                ImageLink = x.ImageLink
            }).ToList();
        }

        //public static ReadNewsRequestModel MapReadNewsModel(ReadNewsModel model)
        //{
        //    return new ReadNewsRequestModel
        //    {
        //        Id = model.Id
        //    };
        //}


        #endregion

        public static NewsEntity MapNewsModel(NewsModel model)
        {
            return new NewsEntity
            {
                Id = model.Id,
                Title = model.Title,
                CreatedAt = model.CreatedAt,
                Description = model.Description,
                ImageLink = model.ImageLink,
            };
        }
        public static NewsModel MapNewsEntity(NewsEntity model)
        {
            return new NewsModel
            {
                Id = model.Id,
                Title = model.Title,
                CreatedAt = model.CreatedAt,
                Description = model.Description,
                ImageLink = model.ImageLink,
            };
        }
    }
}
