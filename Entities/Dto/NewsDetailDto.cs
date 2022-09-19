using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class NewsDetailDto:IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateTime { get; set; }
    }
}
