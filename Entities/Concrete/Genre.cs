using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Genre: BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<TheNews> TheNews { get; set; }
    }
}
