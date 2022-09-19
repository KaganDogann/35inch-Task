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
    public  class DeleteGenreCommand: IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, IResult>
        {
            private readonly IGenreRepository _genreRepository;

            public DeleteGenreCommandHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
            }
            public async Task<IResult> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
            {
                
                var deletedGenre = await _genreRepository.FirstOrDefault(c => c.Id == request.Id);
               
                await _genreRepository.RemoveAsync(deletedGenre);
                await _genreRepository.SaveAsync();
                return new SuccessResult("Genre deleted");
            }
        }
    }
}
