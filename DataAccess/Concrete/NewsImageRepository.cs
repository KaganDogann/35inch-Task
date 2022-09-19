using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class NewsImageRepository : EfEntityRepositoryBase<NewsImage, NewsDbContext>, INewsImageRepository
    {
        public NewsImageRepository(NewsDbContext context) : base(context)
        {
        }
    }
}
