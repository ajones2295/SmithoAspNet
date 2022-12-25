using AutoMapper;
using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.DataModels;
using Models.IdentityModels;
using Models.UtilityModels;
using Models.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUnitOfWork unitOfWork, DatabaseContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetMyProfile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMyProfile()
        {
            ApiUser apiUser = new();
            var user = "test@test.com";
            //var user = User.Identity?.Name;
            var profile = await _unitOfWork.ApplicationUser.GetUserByEmail(user);
            apiUser.Name = profile.Name;
            apiUser.Email = profile.Email;
            apiUser.PhoneNumber = profile.PhoneNumber;

            return Ok(apiUser);
        }

        [HttpGet("GetUserByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            if (email == null || email == "")
            {
                return NotFound();
            }
            return Ok(await _unitOfWork.ApplicationUser.GetUserByEmail(email));
        }

        [HttpGet("GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserById(string userId)
        {
            if (userId == null || userId == "")
            {
                return NotFound();
            }
            return Ok(await _unitOfWork.ApplicationUser.GetUserById(userId));
        }

        [HttpGet("GetUserByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserByName(string name)
        {
            if (name == null || name == "")
            {
                return NotFound();
            }
            return Ok(await _unitOfWork.ApplicationUser.GetUserByName(name));
        }

        [HttpGet("GetUserByPhoneNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserByPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null || phoneNumber == "")
            {
                return NotFound();
            }
            return Ok(await _unitOfWork.ApplicationUser.GetUserByPhoneNumber(phoneNumber));
        }

        [HttpGet("GetUserByUserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserByUserName(string userNmme)
        {
            if (userNmme == null || userNmme == "")
            {
                return NotFound();
            }
            return Ok(await _unitOfWork.ApplicationUser.GetUserByUserName(userNmme));
        }



        //[HttpGet("GetUserInfoByEmail")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> GetUserInfoByEmail(string? email)
        //{
        //    if (email == null || email == "")
        //    {
        //        return NotFound();
        //    }
        //    var user = await _userManager.FindByEmailAsync(email);
        //    return Ok(user);
        //}

        //[HttpGet("GetUserInfoByUserName")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> GetUserInfoByUserName(string? userName)
        //{
        //    if (userName == null || userName == "")
        //    {
        //        return NotFound();
        //    }
        //    var user = await _userManager.FindByNameAsync(userName);
        //    return Ok(user);
        //}

        //[HttpGet("GetUserInfoByLogin")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> GetUserInfoByLogin(string? email, string key)
        //{
        //    if (email == null || email == "")
        //    {
        //        return NotFound();
        //    }
        //    var user = await _userManager.FindByLoginAsync(email, key);
        //    return Ok(user);
        //}

        //[HttpPut("UpdateUserInfo")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> UpdateUserInfo([FromBody] ApiUser apiUser)
        //{
        //    if (apiUser == null)
        //    {
        //        return NotFound();
        //    }

        //    //ApplicationUser userUpdateMap = _mapper.Map<ApplicationUser>(apiUser);
        //    var id = User.Identity.Name;
        //    ApplicationUser user = _mapper.Map<ApplicationUser>(await _userManager.FindByEmailAsync(id));
        //    user.Name = apiUser.Name;
        //    user.PhoneNumber = apiUser.PhoneNumber;
        //    user.Email = apiUser.Email;
        //    user.Bio = apiUser.Bio;
        //    user.Location = apiUser.Location;
        //    await _userManager.UpdateAsync(user);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        [Route("UpdateName")]
        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateName(string name)
        {
            if (name == null || name == "")
            {
                return BadRequest();
            }
            var user = User.Identity?.Name;
            await _unitOfWork.ApplicationUser.UpdateName(user, name);
            return NoContent();
        }

        [Route("UpdateUserName")]
        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateUserName(string userName)
        {
            if (userName == null || userName == "")
            {
                return BadRequest();
            }
            var user = User.Identity?.Name;
            await _unitOfWork.ApplicationUser.UpdateUserName(user, userName);
            return NoContent();
        }

        [Route("UpdateEmail")]
        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateEmail(string email)
        {
            if (email == null || email == "")
            {
                return BadRequest();
            }
            var user = User.Identity?.Name;
            await _unitOfWork.ApplicationUser.UpdateEmail(user, email);
            return NoContent();
        }

        [Route("UpdatePhoneNumber")]
        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> UpdatePhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null || phoneNumber == "")
            {
                return BadRequest();
            }
            var user = User.Identity?.Name;
            await _unitOfWork.ApplicationUser.UpdatePhoneNumber(user, phoneNumber);
            return NoContent();
        }



        [HttpDelete("DeleteUserInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUserInfo(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return NoContent();
        }

        [Route("Token/{userName}/{password}")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(string userName, string password)
        {
            // string username = "@test.com", string password = "Pass1234!", string grant_type = "password"
            if (await IsValidUsernameAndPassword(userName, password))
            {
                return new ObjectResult(await GenerateToken(userName));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] ApiRegister newUser)
        {
            _logger.LogInformation($"Registration attempt for {newUser.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = new ApplicationUser { UserName = newUser.Email, Email = newUser.Email, Name = newUser.Name, DateCreated = DateTime.Now };
                user.UserName = newUser.Email;
                var result = await _userManager.CreateAsync(user, newUser.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest($"User registration failed.");
                }
                /*await _userManager.AddToRolesAsync(user, newUser.)*/;
                // send registration confirmation email
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

        private async Task<bool> IsValidUsernameAndPassword(string username, string password)
        {
            var user = await _userManager.FindByEmailAsync(username);
            return await _userManager.CheckPasswordAsync(user, password);
        }
        private async Task<dynamic> GenerateToken(string username)
        {
            var user = await _userManager.FindByEmailAsync(username);
            var roles = from ur in _context.UserRoles
                        join r in _context.Roles on ur.RoleId equals r.Id
                        where ur.UserId == user.Id
                        select new { ur.UserId, ur.RoleId, r.Name };
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKeyIsSecretSoDoNotTell")),
                            SecurityAlgorithms.HmacSha256)), new JwtPayload(claims));
            var output = new
            {
                UserName = username,
                Expires = token.ValidTo,
                //Claims = token.Claims,
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
            };
            return output;
        }
    }
}