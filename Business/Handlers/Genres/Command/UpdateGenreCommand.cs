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

namespace Business.Handlers.Genres.Command
{
    public class UpdateGenreCommand: IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, IResult>
        {
            private readonly IGenreRepository _genreRepository;

            public UpdateGenreCommandHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
            }
            public async Task<IResult> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
            {
                var updatedGenre = new Genre
                {
                    Id = request.Id,
                    Name = request.Name,
                };
                await _genreRepository.UpdateAsync(updatedGenre);
                await _genreRepository.SaveAsync();
                return new SuccessResult("Update Genre");
            }
        }
    }
}
