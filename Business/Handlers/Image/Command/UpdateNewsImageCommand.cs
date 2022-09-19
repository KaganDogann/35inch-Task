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

namespace Business.Handlers.Image.Command
{
    public class UpdateNewsImageCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public class UpdateNewsImageCommandHandler : IRequestHandler<UpdateNewsImageCommand, IResult>
        {
            private readonly INewsImageRepository _newsImageRepository;

            public UpdateNewsImageCommandHandler(INewsImageRepository newsImageRepository)
            {
                _newsImageRepository = newsImageRepository;
            }
            public async Task<IResult> Handle(UpdateNewsImageCommand request, CancellationToken cancellationToken)
            {
                var updatedImage = new NewsImage
                {
                    Id = request.Id,
                    ImagePath = request.ImagePath,
                    DateTime = DateTime.Now
                };

                await _newsImageRepository.UpdateAsync(updatedImage);
                await _newsImageRepository.SaveAsync();
                return new SuccessResult("Image updated");
            }
        }
    }
}
