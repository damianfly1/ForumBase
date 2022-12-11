using Application.DTOs.User;
using Application.Services;
using AutoMapper;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IUserService _usersService;
        public UsersController(UserManager<User> userManager,
            IMapper mapper,
            ITokenService tokenService,
            IUserService usersService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
            _usersService = usersService;
        }

        [HttpPost("registration")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            await _userManager.AddToRoleAsync(user, "User");
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);

            if (user == null || user.IsBanned || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

            var signingCredentials = _tokenService.GetSigningCredentials();
            var claims = await _tokenService.GetClaims(user);
            var tokenOptions = _tokenService.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }

        [HttpGet("{idOrName}")]
        [ProducesResponseType(typeof(UserResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get([FromRoute] string idOrName)
        {
            try
            {
                var user = await _usersService.Get(idOrName);
                return Ok(user);
            }
            catch (ApplicationException) { return NotFound(); }
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(IReadOnlyCollection<UserResponseDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                IReadOnlyCollection<UserResponseDto> dtos = _mapper.Map<IReadOnlyCollection<UserResponseDto>>(users);
                return Ok(dtos);
            }
            catch (ApplicationException) { return NotFound(); }
        }

        [HttpPost("{id:guid}/avatar"), DisableRequestSizeLimit]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Upload([FromRoute] string id)
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            try
            {
                var url = await _usersService.UploadAvatar(file, id, HttpContext.User.Identity.Name);
                return Ok(url);
            }
            catch (ApplicationException e)
            {
                if (e.Message == "NOT FOUND") return NotFound();
                if (e.Message == "NOT AUTHORIZED") return StatusCode(403);
                else return (IActionResult)e;
            }
        }

        [HttpDelete("{id:guid}/avatar")]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> DeleteAvatar([FromRoute] string id)
        {
            try
            {
                await _usersService.DeleteAvatar(id, HttpContext.User.Identity.Name);
                return NoContent();
            }
            catch (ApplicationException e)
            {
                if (e.Message == "NOT FOUND") return NotFound();
                if (e.Message == "NOT AUTHORIZED") return StatusCode(403);
                else return (IActionResult)e;
            }
        }

        [HttpPost("{id:guid}/role")]
        [Authorize(Roles="Administrator")]
        [ProducesResponseType(typeof(UserResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> SetRole([FromRoute] string id, string role)
        {
            try
            {
                var result = await _usersService.SetRole(id, role);
                return Ok(result);
            }
            catch (ApplicationException) { return NotFound(); }
        }
    }
}

