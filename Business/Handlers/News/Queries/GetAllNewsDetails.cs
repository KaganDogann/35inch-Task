using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.News.Queries
{
    public class GetAllNewsDetails:IRequest<IDataResult<IEnumerable<NewsDetailDto>>>
    {
        public int CurrentPage { get; set; }

        public class GetAllNewsDetailsHandler : IRequestHandler<GetAllNewsDetails, IDataResult<IEnumerable<NewsDetailDto>>>
        {
            private readonly INewsRepository _newsRepository;

            public GetAllNewsDetailsHandler(INewsRepository newsRepository)
            {
                _newsRepository = newsRepository;
            }

            public async Task<IDataResult<IEnumerable<NewsDetailDto>>> Handle(GetAllNewsDetails request, CancellationToken cancellationToken)
            {
                int limit = 6;
                int skipData;

                if (request.CurrentPage == 1 || request.CurrentPage == 0)
                {
                    skipData = 0;
                }
                else
                {
                    skipData = (Math.Abs(request.CurrentPage - 1) * limit);
                }
                var totalNewsDetails = await _newsRepository.GetNewsDetailsWithPagination(limit, skipData);
               

                return new SuccessDataResult<IEnumerable<NewsDetailDto>>(totalNewsDetails," Ürünler geldi");
            }
        }
    }
}
