using dbtoc.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace dbtoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogincontroller : ControllerBase
    {
        public readonly organizationContext _context;
        public readonly IConfiguration _config;
        

        public UserLogincontroller(organizationContext context, IConfiguration config)
        {
            this._context = context;
            _config = config;
        }

        [HttpPost,Route("signup")]
        public async Task<IActionResult>StoreUserDetails([FromBody] UserLogin user)
        {
            await _context.UserLogins.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost,Route("login")]
        public IActionResult LoginUser([FromBody] UserLogin user)
        {
            if (IsUserExist(user.Username)) {
                if (IsUserAuthenticated(user.Username,user.Password)) {
                    try {
                        var claims = new[]
                        { new Claim(ClaimTypes.NameIdentifier,user.Username)};
                        var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("appsetting:Token").Value));
                        var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256Signature);
                        var tokendescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(claims),
                            Expires = DateTime.Now.AddMinutes(10),
                            SigningCredentials = signinCredentials
                        };
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var Token = tokenHandler.CreateToken(tokendescriptor);
                        return Ok(new { token = tokenHandler.WriteToken(Token) });
                    }
                    catch(Exception e)
                    {
                        return BadRequest(e.StackTrace);
                    }
                    }
                else { return Unauthorized("password is incorrect"); }
                }
            else { return NotFound("user doesnt exist"); }
        }

        private bool IsUserExist(string username)
        {
            bool result = _context.UserLogins.Any(a => a.Username == username);
            return result;
        }

        private bool IsUserAuthenticated(string username, string password)
        {
            string pwd = _context.UserLogins.Where(w => w.Username == username).Select(s => s.Password).First().ToString();
            if (pwd.Equals(password))
            { return true;
            }
            else { return false; } }
        }
    }

