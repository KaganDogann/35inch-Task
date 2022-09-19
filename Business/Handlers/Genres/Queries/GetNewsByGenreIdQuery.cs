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

namespace Business.Handlers.Genres.Queries
{
    public class GetNewsByGenreIdQuery:IRequest<IDataResult<IEnumerable<NewsDetailDto>>>
    {
        public int GenreId { get; set; }

        public class GetNewsByGenreIdQueryHandler : IRequestHandler<GetNewsByGenreIdQuery, IDataResult<IEnumerable<NewsDetailDto>>>
        {
            private readonly INewsRepository _newsRepository;

            public GetNewsByGenreIdQueryHandler(INewsRepository newsRepository)
            {
                _newsRepository = newsRepository;
            }

            public async Task<IDataResult<IEnumerable<NewsDetailDto>>> Handle(GetNewsByGenreIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _newsRepository.GetNewsByGenreId(request.GenreId);
                return new SuccessDataResult<IEnumerable<NewsDetailDto>>(result);
            }
        }
    }
}
