using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;

        private readonly ITokenService _token;
        private readonly IMapper _mapper;

        public AccountController(DataContext context, ITokenService tokenService, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _token = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<userDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest(("Username is taken"));

            var user = _mapper.Map<AppUser>(registerDto);
            
            using var hmac = new HMACSHA512();

            user.Username = registerDto.Username.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            user.PasswordSalt = hmac.Key;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new userDto
            {
                Username = user.Username,
                Token = _token.GenerateToken(user),
                KnownAs = user.KnownAs
            };
        }
        
        [HttpPost("registerquery")]
        public async Task<ActionResult<userDto>> RegisterQuery([FromQuery] RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest(("Username is taken"));
            
            using var hmac = new HMACSHA512();
            
            var user = new AppUser
            {
                Username = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new userDto
            {
                Username = user.Username,
                Token = _token.GenerateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<userDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.Username == loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new userDto
            {
                Username = user.Username,
                Token = _token.GenerateToken(user),
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
                KnownAs = user.KnownAs
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.Username == username.ToLower());
        }
    }
}