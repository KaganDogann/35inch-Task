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
    public class DeleteNewsCommand:IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, IResult>
        {
            private readonly INewsRepository _newsRepository;

            public DeleteNewsCommandHandler(INewsRepository newsRepository)
            {
                _newsRepository = newsRepository;
            }
            public async Task<IResult> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
            {
                var deletedNews = await _newsRepository.FirstOrDefault(c => c.Id == request.Id); ;
                await _newsRepository.RemoveAsync(deletedNews);
                await _newsRepository.SaveAsync();
                return new SuccessResult("Deleted News");
            }
        }
    }
}
