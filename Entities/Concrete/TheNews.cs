using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TheNews: BaseEntity
    {
        public int GenreId { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        [JsonIgnore]
        public virtual Genre? Genre { get; set; }
        public virtual ICollection<NewsImage> NewsImage { get; set; }
    }
}
