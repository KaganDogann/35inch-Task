using Core.DataAccess;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface INewsRepository:  IAsyncRepository<TheNews>
    {
        Task<List<NewsDetailDto>> GetNewsDetails();

        Task<List<NewsDetailDto>> GetNewsDetailsWithPagination(int limit, int skip);

        Task<List<NewsDetailDto>> GetNewsByGenreId(int genreId);
    }
}
