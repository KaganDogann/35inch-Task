using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.News.Queries
{
    public class GetNewsTotalPageQuery : IRequest<IDataResult<decimal>>
    {
        public class GetNewsTotalPageQueryHandler : IRequestHandler<GetNewsTotalPageQuery, IDataResult<decimal>>
        {
            private readonly INewsRepository _newsRepository;

            public GetNewsTotalPageQueryHandler(INewsRepository movieRepository)
            {
                _newsRepository = movieRepository;
            }

            public async Task<IDataResult<decimal>> Handle(GetNewsTotalPageQuery request, CancellationToken cancellationToken)
            {
                var movies = await _newsRepository.GetNewsDetails();
                decimal countOfMovies = movies.Count;
                decimal newValue = countOfMovies / 12;

                var totalPage = Math.Ceiling(newValue);

                return new SuccessDataResult<decimal>(totalPage);
            }
        }
    }
}
