using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
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

namespace Business.Handlers.News.Commands
{
    public class CreateNewsCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
   

        public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, IResult>
        {
            private readonly INewsRepository _newsRepository;

            public CreateNewsCommandHandler(INewsRepository newsRepository)
            {
                _newsRepository = newsRepository;
            }
            [ValidationAspect(typeof(NewsValidator))]
            public async Task<IResult> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
            {
                var news = new TheNews
                {
                   DateTime=DateTime.Now,
                    Title = request.Title,
                    Description = request.Description,
                    GenreId = request.GenreId,
                };
                await _newsRepository.AddAsync(news);
                await _newsRepository.SaveAsync();
                return new SuccessResult("HABER EKLENDİ");

            }
        }
    }
}
