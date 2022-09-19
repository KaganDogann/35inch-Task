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

namespace Business.Handlers.Image.Queries
{
    public class GetListNewsImageQuery: IRequest<IDataResult<IEnumerable<NewsImage>>>
    {
        public class GetListNewsImageQueryHandler : IRequestHandler<GetListNewsImageQuery, IDataResult<IEnumerable<NewsImage>>>
        {
            private readonly INewsImageRepository _newsImageRepository;

            public GetListNewsImageQueryHandler(INewsImageRepository newsImageRepository)
            {
                _newsImageRepository = newsImageRepository;
            }
            public async Task<IDataResult<IEnumerable<NewsImage>>> Handle(GetListNewsImageQuery request, CancellationToken cancellationToken)
            {
                var getListImage = await _newsImageRepository.GetAllAsync();
                return new SuccessDataResult< IEnumerable < NewsImage >> (getListImage);
            }
        }
    }
}
