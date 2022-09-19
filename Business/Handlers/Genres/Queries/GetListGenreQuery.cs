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
    public class GetListGenreQuery: IRequest<IDataResult<IEnumerable<Genre>>>
    {
        public class GetListGenreQueryHandler : IRequestHandler<GetListGenreQuery,IDataResult<IEnumerable<Genre>>>
        {
            private readonly IGenreRepository _genreRepository;

            public GetListGenreQueryHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
            }

            public async  Task<IDataResult<IEnumerable<Genre>>> Handle(GetListGenreQuery request, CancellationToken cancellationToken)
            {
                var getAllGenre = await _genreRepository.GetAllAsync();
                return new SuccessDataResult<IEnumerable<Genre>>(getAllGenre);
            }
        }
    }
}
