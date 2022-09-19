using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class NewsImage:BaseEntity
    {
        public int TheNewsId { get; set; }
        public string ImagePath { get; set; } //resim adı
        public DateTime DateTime { get; set; } // resim yüklendiği tarih
        [JsonIgnore]
        public virtual TheNews? TheNews { get; set; }
        
    }
}
