using KoiOrderingSystem.Common;
using KoiOrderingSystem.Data;
using KoiOrderingSystem.Data.Models;
using KoiOrderingSystem.Service.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KoiOrderingSystem.Service
{
    public interface IUserService
    {
        Task<IBusinessResult> Login(string usernameOrEmail, string password);
    }
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly DateTime _expirationTime = Const.ExpirationLogin;
        private readonly IConfiguration configuration;

        public UserService(IConfiguration _configuration)
        {
            _unitOfWork ??= new UnitOfWork();
            configuration = _configuration;

        }
        public async Task<IBusinessResult> Login(string usernameOrEmail, string password)
        {
            var user = await _unitOfWork.UserRepository.FindByEmailOrUsername(usernameOrEmail);

            //check username 
            if (user == null) return new BusinessResult(Const.FAIL_READ_CODE, "Not find this account");


            //check password
            if (!password.ToLower().Equals(user.Password.ToLower()))
                return new BusinessResult(Const.FAIL_READ_CODE, "Not match password");

            var (token, expiration) = CreateToken(user);

            return new BusinessResult(Const.SUCCESS_READ_CODE, "Login success", new { token, expiration });

        }

        private (string token, string expiration) CreateToken(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.Expiration, new DateTimeOffset(_expirationTime).ToUnixTimeSeconds().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration.GetSection("JWT:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


            var token = new JwtSecurityToken(
                claims: claims,
                expires: _expirationTime,
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return (jwt, _expirationTime.ToString("o")); // Trả về token và thời gian hết hạn
        }
    }
}
