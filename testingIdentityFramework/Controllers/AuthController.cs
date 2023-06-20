using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace testingIdentityFramework.Controllers
{
    [ApiController]
    [Route("testing")]
    public class AuthController : ControllerBase
    {
        public readonly UserManager<IdentityUser> _userManager;

        public readonly RoleManager<IdentityRole> _roleManager;

        public readonly ILogger<AuthController> _logger;

        public readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<AuthController> logger)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._logger = logger;
            this._configuration = configuration;
        }

        [HttpGet("GetAllRoles")]
        public IActionResult GetRoles()
        {
            var roles = this._roleManager.Roles.ToList();
            return Ok(roles);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRoles(string name)
        {
            var roleExist = await this._roleManager.RoleExistsAsync(name);
            if (!roleExist)
            {
                var roleResult = await this._roleManager.CreateAsync(new IdentityRole { Name = name });
                if (roleResult.Succeeded)
                {
                    return Ok("Role created");
                }
                else
                {
                    return BadRequest("Role creation failed");
                }
            }
            return BadRequest("Role already exists");
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await this._userManager.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string email, string roleName)
        {
            //check if user exists
            var user = await this._userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            var role = await this._roleManager.RoleExistsAsync(roleName);
            if (!role)
            {
                return BadRequest("Role not found");
            }

            var result = await this._userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                return Ok("User added to role");
            }

            return BadRequest("failed");
        }

        [HttpGet("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string email)
        {
            //check if user exists
            var user = await this._userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return BadRequest("User not found");
            }

            var role = await this._userManager.GetRolesAsync(user);
            if(role.Count() == 0)
            {
                return BadRequest("User has no roles");
            }
            return Ok(role);
        }

        [HttpPost("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string email, string roleName)
        {
            //check if user exists
            var user = await this._userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            var role = await this._roleManager.RoleExistsAsync(roleName);
            if (!role)
            {
                return BadRequest("Role not found");
            }

            var result = await this._userManager.RemoveFromRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                return Ok("User removed from role");
            }
            return BadRequest("failed");

        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            //chaeck if user already exists
            var user = await this._userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                //check password and confirm password
                if(model.Password != model.ConfirmPassword)
                {
                    return BadRequest("Passwords didn't match");
                }

                //create new user
                var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };
                var userResult = await this._userManager.CreateAsync(newUser, model.Password);
                if (userResult.Succeeded)
                {
                    await this.AddUserToRole(newUser.Email, "AppUser");
                    var token = this.GenerateToken(newUser);
                    return Ok(token);
                }
                else
                {
                    return BadRequest(userResult.Errors);
                }
            }

            return BadRequest("User already exists");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await this._userManager.FindByEmailAsync(model.Username);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            var checkPassword = await this._userManager.CheckPasswordAsync(user, model.Password);
            if (!checkPassword)
            {
                return BadRequest("Wrong password");
            }

            var token = this.GenerateToken(user);
            
            return Ok(token);
        }

        [NonAction]
        public string GenerateToken(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "AppUser")
            };

            var token = new JwtSecurityToken(notBefore: DateTime.UtcNow,
                            expires: DateTime.UtcNow.AddMinutes(20),
                            claims: claims,
                            signingCredentials: credentials
                            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
