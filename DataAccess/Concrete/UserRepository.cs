using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserRepository : EfEntityRepositoryBase<User, NewsDbContext>, IUserRepository
    {
        public UserRepository(NewsDbContext context) : base(context)
        {
        }

        public List<OperationClaim> GetClaims(User user)
        {
            
                var result = from operationClaim in Context.OperationClaims
                             join userOperationClaim in Context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            
        }
    }
}
