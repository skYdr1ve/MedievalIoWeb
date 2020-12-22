using MedievalIo.Server.Client.Models.News;
using MedievalIo.Server.Client.Models.News.Requests;
using MedievalIo.Server.Client.Models.News.Responces;
using MedievalIo.Services.Models.News;
using System;
using System.Collections.Generic;
using System.Text;

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

        public static NewsModel MapCreateNewsResponce(CreateNewsResponce model)
        {
            return MapNewsEntity(model.News);
        }

        public static UpdateNewsModel MapUpdateNewsResponce(UpdateNewsResponce model)
        {
            return new UpdateNewsModel
            {

            };
        }

        public static ListNewsModel MapListNewsResponce(ListNewsResponce model)
        {
            return new ListNewsModel
            {
                
            };
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
