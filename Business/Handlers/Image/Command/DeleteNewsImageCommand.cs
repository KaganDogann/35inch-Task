using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Image.Command
{
    public class DeleteNewsImageCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteNewsImageCommandHanadler : IRequestHandler<DeleteNewsImageCommand, IResult>
        {
            private readonly INewsImageRepository _newsImageRepository;

            public DeleteNewsImageCommandHanadler(INewsImageRepository newsImageRepository)
            {
                _newsImageRepository = newsImageRepository;
            }

            public async Task<IResult> Handle(DeleteNewsImageCommand request, CancellationToken cancellationToken)
            {
                var deletedImage = await _newsImageRepository.FirstOrDefault(c => c.Id == request.Id);

                await _newsImageRepository.RemoveAsync(deletedImage);
                await _newsImageRepository.SaveAsync();
                return new SuccessResult("Image deleted");
            }
        }
    }
}
