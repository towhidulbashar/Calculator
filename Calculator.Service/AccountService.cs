//using AutoMapper;
//using Calculator.Domain;
//using Calculator.Repository.Infrastructure;
//using Calculator.Resource;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace Calculator.Service
//{
//    public interface IAccountService
//    {
//        Task<SignInResult> SignIn(LoginResource loginResource);
//        Task<LoginResponse> GetSignedInUser(string userName);
//        Task<IdentityResult> CreateUser(CreateApplicationUserResource createApplicationUserResource);
//    }
//    public class AccountService : IAccountService
//    {
//        private readonly AppSettings appSettings;
//        private readonly IUnitOfWork unitOfWork;
//        private readonly IMapper mapper;

//        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSettings> appSettings)
//        {
//            this.appSettings = appSettings.Value;
//            this.unitOfWork = unitOfWork;
//            this.mapper = mapper;
//        }

//        public async Task<SignInResult> SignIn(LoginResource loginResource)
//        {
//            var signinResult = await unitOfWork.SignInManager.PasswordSignInAsync(loginResource.UserName, loginResource.Password, isPersistent: false, lockoutOnFailure: false);
//            await unitOfWork.CompleteAsync();
//            return signinResult;
//        }

//        public async Task<LoginResponse> GetSignedInUser(string userName)
//        {
//            ApplicationUser user = await unitOfWork.UserManager.FindByNameAsync(userName);
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new Claim[]
//                {
//                    new Claim(ClaimTypes.Name, user.Id.ToString())
//                }),
//                Expires = DateTime.UtcNow.AddDays(7),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };
//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            var tokenString = tokenHandler.WriteToken(token);
//            await unitOfWork.CompleteAsync();

//            return new LoginResponse
//            {
//                Id = user.Id,
//                UserName = user.UserName,
//                Token = tokenString
//            };
//        }
//        public async Task<IdentityResult> CreateUser(CreateApplicationUserResource createApplicationUserResource)
//        {
//            var applicationUser = mapper.Map<CreateApplicationUserResource, ApplicationUser>(createApplicationUserResource);
//            var createresult = await unitOfWork.UserManager.CreateAsync(applicationUser, createApplicationUserResource.Password);
//            await unitOfWork.CompleteAsync();
//            return createresult;
//        }
//    }
//}
