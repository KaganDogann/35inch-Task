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
    public class UpdateNewsCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, IResult>
        {
            private readonly INewsRepository _newsRepository;

            public UpdateNewsCommandHandler(INewsRepository newsRepository)
            {
                _newsRepository = newsRepository;
            }
            public async Task<IResult> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
            {
                var updatedNews = new TheNews
                {
                    DateTime = DateTime.Now,
                    Title = request.Title,
                    Description = request.Description,
                    GenreId = request.GenreId,
                };
                await _newsRepository.UpdateAsync(updatedNews);
                await _newsRepository.SaveAsync();
                return new SuccessResult("News Güncellendi");

            }
        }
    }
}
