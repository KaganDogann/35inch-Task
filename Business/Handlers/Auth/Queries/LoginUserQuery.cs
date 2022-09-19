using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Auth.Queries
{
    public class LoginUserQuery : IRequest<IDataResult<AccessToken>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, IDataResult<AccessToken>>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;


            public LoginUserQueryHandler(IUserRepository userRepository, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
            }


            public async Task<IDataResult<AccessToken>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                var userToCheck = _userRepository.FirstOrDefault(u => u.Email == request.Email);

                if (userToCheck.Result!=null)
                {
                    return new ErrorDataResult<AccessToken>("kulklanıcı bulunamadı");
                }

                if (!HashingHelper.VerifyPasswordHash(request.Password, userToCheck.Result.PasswordHash, userToCheck.Result.PasswordSalt))
                {
                    return new ErrorDataResult<AccessToken>("yanlkış şifre");
                }

                var claims = _userRepository.GetClaims(userToCheck.Result);

                var accessToken = _tokenHelper.CreateToken(userToCheck.Result, claims);
                

                return new SuccessDataResult<AccessToken>(accessToken,"Token Oluşturuldu");
            }
        }
    }
}
