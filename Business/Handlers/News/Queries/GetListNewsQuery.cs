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
    public class GetListNewsQuery:IRequest<IDataResult<IEnumerable<TheNews>>>
    {
        public class GetListNewsQueryHandler : IRequestHandler<GetListNewsQuery, IDataResult<IEnumerable<TheNews>>>
        {
            private readonly INewsRepository _newsRepository;

            public GetListNewsQueryHandler(INewsRepository newsRepository)
            {
                _newsRepository = newsRepository;
            }
            public async Task<IDataResult<IEnumerable<TheNews>>> Handle(GetListNewsQuery request, CancellationToken cancellationToken)
            {
                var getListNews = await _newsRepository.GetAllAsync();
                return new SuccessDataResult<IEnumerable<TheNews>>(getListNews);
            }
        }
    }
}
