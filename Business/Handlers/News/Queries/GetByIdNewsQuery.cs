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

namespace Business.Handlers.News.Queries
{
    public class GetByIdNewsQuery :IRequest<IDataResult<TheNews>>
    {
        public int Id { get; set; }

        public class GetByIdNewsQueryHandler : IRequestHandler<GetByIdNewsQuery, IDataResult<TheNews>>
        {
            private readonly INewsRepository _newsRepository;

            public GetByIdNewsQueryHandler(INewsRepository newsRepository)
            {
                _newsRepository = newsRepository;
            }

            public async Task<IDataResult<TheNews>> Handle(GetByIdNewsQuery request, CancellationToken cancellationToken)
            {
                var getByIdNews=await _newsRepository.GetAsync(c => c.Id == request.Id);
                return new SuccessDataResult<TheNews>(getByIdNews);

            }
        }
    }
}
