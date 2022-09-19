
using Core.Utilities.Business;
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
    public class CreateGenreCommand: IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, IResult>
        {
            private readonly IGenreRepository _genreRepository;
           

            public CreateGenreCommandHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
              
            }

            public async Task<IResult> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
            {
               
                var addedGenre = new Genre
                {
                    Name = request.Name,
                    Id = request.Id,
                };

                IResult result=BusinessRules.Run(CheckIfGenreNameExists(addedGenre.Name));
                if (result!=null)
                {
                    return result;
                }
                await _genreRepository.AddAsync(addedGenre);
                await _genreRepository.SaveAsync();
                return new SuccessResult("Genre added");


            
            }
           private  IResult CheckIfGenreNameExists(string name)
           {

            var result = _genreRepository.GetAll(p => p.Name == name).Any();
            
            if (result)
            {
                return new ErrorResult("Genre name already exists");
            }
            return new SuccessResult();

           }
        }
      
    }
    
}
