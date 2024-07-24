//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using mobile_store.DTOs.RegisterDto;
//using mobile_store.DTOs.UserDTO;
//using mobile_store.Models;
//using mobile_store.Services.TokenService;
//using System.Security.Cryptography;
//using System.Text;

//namespace mobile_store.Controllers
//{
//    public class UserController : BaseAPIController
//    { 
//        private readonly MobilePhoneStoreContext _context;
//        private readonly ITokenService _tokenService;
//        public UserController(MobilePhoneStoreContext context, ITokenService tokenService)
//        {
//            _context = context;
//            _tokenService = tokenService;
//        }
//        //register
//        [HttpPost]
//        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
//        {
//            if (await UserExists(registerDTO.Name)) return BadRequest("Username is taken");
//            using var hmac = new HMACSHA512();
//            var user = new User
//            {
//                Name = registerDTO.Name.ToLower(),
//                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
//                PasswordSalt = hmac.Key

//            }

//        }
//    }
//}
