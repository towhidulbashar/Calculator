//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Calculator.Resource;
//using Calculator.Service;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Calculator.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AccountController : ControllerBase
//    {
//        private readonly IAccountService accountService;

//        public AccountController(IAccountService accountService)
//        {
//            this.accountService = accountService;
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginResource loginResource)
//        {
//            try
//            {
//                //throw new Exception("Test exception", new Exception("My Inner exception"));
//                var signinResult = await accountService.SignIn(loginResource);
//                if (!signinResult.Succeeded)
//                    return Unauthorized();
//                var signInResult = await accountService.GetSignedInUser(loginResource.UserName);
//                return Ok(signInResult);
//            }
//            catch (Exception exception)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError);
//            }
//        }


//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody]CreateApplicationUserResource user)
//        {
//            try
//            {
//                var identityResult = await accountService.CreateUser(user);
//                if (identityResult.Succeeded)
//                    return Ok();
//                else
//                    return BadRequest(identityResult.Errors);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex);
//            }
//        }
//    }
//}