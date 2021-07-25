using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShopApi.Entities;
using ShopApi.Model;

namespace ShopApi.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;
        
        public UserService(UserManager<UserEntity> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<LoginResponse> Authentication(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7S79jvOkEdwoRqHx"));
                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(5),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                return new LoginResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }
            
            throw new AuthenticationException("login failed");
        }

        public async Task Registration(RegisterRequest request)
        {
            var entity = _mapper.Map<UserEntity>(request);
            var result = await _userManager.CreateAsync(entity, request.Password);

            if (!result.Succeeded)
            {
                throw new AuthenticationException();
            }
        }
    }
}
