using AutoMapper;
using DentialSystem.Domain;
using DentialSystem.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DentalSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly UserManager<Paitant> userManager;
        private readonly SignInManager<Paitant> signInManager;
        private readonly IConfiguration configuration;

        public AcountController
            ( IMapper mapper,UserManager<Paitant> userManager,
              SignInManager<Paitant> signInManager,
              IConfiguration configuration
            )
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        [Route("Login/")]
        [HttpPost]
        public async Task<IActionResult> Login(PaitantLoginDTO paitantLogin)
        {
            Paitant paitant = await userManager.FindByNameAsync(paitantLogin.username);
            if (paitant != null)
            {
                var result = await signInManager.PasswordSignInAsync(paitant, paitantLogin.password, paitantLogin.RememberMe,false);
                if(result.Succeeded) 
                {
                    var id = await userManager.GetUserIdAsync(paitant);
                    return RedirectToAction("GenerateToken", new { id = id });
                }

            }
            
               return NotFound();

        }
        [Route("Register/")]
        [HttpPost]

        public async Task<IActionResult> Register(paitantRegisterDTO paitantRegister)
        {
            var paitant = mapper.Map<Paitant>(paitantRegister);
            try
            {
                var result = await userManager.CreateAsync(paitant, paitantRegister.Password);
                if(result.Succeeded)
                {
                    var id=  await userManager.GetUserIdAsync(paitant);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,paitant.UserName),
                        new Claim(ClaimTypes.NameIdentifier,id)
                    };
                     await signInManager.SignInWithClaimsAsync(paitant,false, claims);
                    return Ok(paitant);

                }
                else
                {
                    string errors = " ";
                    foreach(var error in result.Errors)
                    {
                        errors += error.Description.ToString();       
                    }
                    return BadRequest(errors);
                }

            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);

            }

        }
        [Route("Token/")]
        [HttpGet]
        public async Task<IActionResult> GenerateToken(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("SecretKey").Value);

            if (id != null)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                     new Claim(ClaimTypes.Role, "User"),
                     new Claim(ClaimTypes.NameIdentifier, id)
                    }),
                    Expires = DateTime.UtcNow.AddMonths(1),
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha384Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                var response = new
                {
                    userId = id,
                    token = tokenString
                };
                return Ok(response);
            }
            else
                return BadRequest();
        }
        [Route("LogOut/")]
        [HttpGet]
        public async Task<IActionResult>LogOut()
        {
            await signInManager.SignOutAsync();
            return Ok(); 
        }

    }
}
