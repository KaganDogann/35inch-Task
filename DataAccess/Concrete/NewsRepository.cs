using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class NewsRepository : EfEntityRepositoryBase<TheNews, NewsDbContext>, INewsRepository
    {
        public NewsRepository(NewsDbContext context) : base(context)
        {
        }

        public  async Task<List<NewsDetailDto>> GetNewsByGenreId(int genreId)
        {
            var result = await(from m in Context.Newss
                               join g in Context.Genres

                               on m.GenreId equals g.Id
                               where m.GenreId==genreId
                               select new NewsDetailDto
                               {
                                   Id = m.Id,
                                   Title = m.Title,
                                   Description = m.Description,
                                   ImagePath = (from ni in Context.NewsImages where ni.TheNewsId == m.Id select ni.ImagePath).FirstOrDefault(),
                                   GenreName = g.Name
                               }).ToListAsync();
            return result;
        }

        public async Task<List<NewsDetailDto>> GetNewsDetails()
        {
            var result = await (from m in Context.Newss
                                join g in Context.Genres
                                
                                on m.GenreId equals g.Id
                                select new NewsDetailDto
                                {
                                    Id = m.Id,
                                    Title = m.Title,
                                    Description = m.Description,
                                    ImagePath = (from ni in Context.NewsImages where ni.TheNewsId == m.Id select ni.ImagePath).FirstOrDefault(),
                                    GenreName = g.Name
                                }).ToListAsync();
            return result;
        }

        public async Task<List<NewsDetailDto>> GetNewsDetailsWithPagination(int limit, int skip)
        {
            var result = await(from m in Context.Newss
                               join g in Context.Genres

                               on m.GenreId equals g.Id
                               select new NewsDetailDto
                               {
                                   Id = m.Id,
                                   Title = m.Title,
                                   Description = m.Description,
                                   ImagePath = (from ni in Context.NewsImages where ni.TheNewsId == m.Id select ni.ImagePath).FirstOrDefault(),
                                   GenreName = g.Name
                               }).Skip(skip).Take(limit).ToListAsync();
            return result;
        }
    }
}
