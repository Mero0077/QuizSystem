//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using QuizSystem.Models;
//using QuizSystem.Repositories;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace QuizSystem.Controllers.Account
//{
//    [Route("api/[controller]")]

//    [ApiController]
//    public class AccountController : ControllerBase
//    {
//        private GeneralRepository<Choice> _generalrepository;
//        private UserManager<ApplicationUser> _usermanager;
//        private JwtOptions _jwtOptions;
//        public AccountController(UserManager<ApplicationUser> userManager, JwtOptions jwtOptions)
//        {
//            _generalrepository = new GeneralRepository<Choice>();
//            _usermanager = userManager;
//            _jwtOptions = jwtOptions;
//        }
//        [HttpPost("Register")]
//        public async Task<bool> Register(Register register)
//        {
//            var IfUserExists = await _usermanager.FindByEmailAsync(register.Email);
//            if (IfUserExists != null) return false;

//            var user = new ApplicationUser()
//            {
//                Email = register.Email,
//                UserName = register.Email,
//                UniqueName = register.UserName

//            };
//            var result = await _usermanager.CreateAsync(user, register.Password);
//            if (result.Succeeded)
//            {
//                //  await  _usermanager.AddToRoleAsync(user, "student");
//                return true;
//            }
//            return false;
//        }

//        [HttpPost("Login")]
//        public async Task<bool> Login(Login login)
//        {
//            var UserExists = await _usermanager.FindByEmailAsync(login.username);
//            if (UserExists == null) return false;

//            bool IsPassCorrect = await _usermanager.CheckPasswordAsync(UserExists, login.Password);
//            if (!IsPassCorrect) return false;
//            var accessToken = GenerateToken(UserExists);
//            return true;
//        }
//        private string GenerateToken(ApplicationUser user)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var claims = new List<Claim>
//            {
//                //new Claim(ClaimTypes.NameIdentifier, user.Id),
//                new Claim("nameid", user.Id),
//                new Claim(ClaimTypes.Email, user.Email),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//            };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SigninKey));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(claims),
//                Expires = DateTime.UtcNow.AddHours(2),
//                SigningCredentials = creds,
//                Issuer = _jwtOptions.Issuer,
//                Audience = _jwtOptions.Audience
//            };

//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);

//        }
//    }
//}
