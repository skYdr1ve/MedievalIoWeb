using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalIo.Services.Models.News
{
    public class CreateNewsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
    }
}
