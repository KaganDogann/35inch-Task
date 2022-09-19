using Core.Utilities.Helpers.FileHelper;
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
    public class CreateNewsImageCommand :IRequest<IResult>
    {
        public int Id { get; set; }
        public int TheNewsId { get; set; }
        public string ImagePath { get; set; }

        public class CreateNewsImageCommandHandler : IRequestHandler<CreateNewsImageCommand, IResult>
        {
            private readonly INewsImageRepository _newsImageRepository;
            private readonly IFileHelper _fileHelper;


            public CreateNewsImageCommandHandler(INewsImageRepository newsImageRepository, IFileHelper fileHelper)
            {
                _newsImageRepository = newsImageRepository;
                _fileHelper = fileHelper;
            }

            public async Task<IResult> Handle(CreateNewsImageCommand request, CancellationToken cancellationToken)
            {
                var addedNewsImage = new NewsImage
                {
                    Id = request.Id,
                    ImagePath = request.ImagePath,
                    TheNewsId = request.TheNewsId,
                    DateTime=DateTime.Now
                };
                await _newsImageRepository.AddAsync(addedNewsImage);
                await _newsImageRepository.SaveAsync();
                return new SuccessResult("Image Eklendi");

            }
        }
    }
}
