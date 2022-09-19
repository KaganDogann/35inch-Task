using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Genres.Queries
{
    public class GetByIdGenreQuery : IRequest<IDataResult<Genre>>
    {
        public int Id { get; set; }

        public class GetByIdGenreQueryHandler : IRequestHandler<GetByIdGenreQuery, IDataResult<Genre>>
        {
            private readonly IGenreRepository _genreRepository;

            public GetByIdGenreQueryHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
            }
            public async Task<IDataResult<Genre>> Handle(GetByIdGenreQuery request, CancellationToken cancellationToken)
            {
                var getByIdGenre = await _genreRepository.GetAsync(c => c.Id == request.Id);

                return new SuccessDataResult<Genre>(getByIdGenre);
            }
        }
    }
}
