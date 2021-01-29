using BryceResortPatrol.Common.Models;
using BryceResortPatrol.Common.Models.Configuration;
using BryceResortPatrol.Common.Repositories.Interfaces;
using BryceResortPatrol.Common.Services.Helpers;
using BryceResortPatrol.Common.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BryceResortPatrol.Common.Services
{
    public sealed class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository userRepository;
        private readonly Config config;
        public AuthenticateService(
            IUserRepository userRepository,
            Config config)
        {
            this.userRepository = userRepository;
            this.config = config;
        }

        public string GetLoginToken(User user)
        {
            if (IsValid(user))
            {
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config.Salt));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: this.config.BaseUrl,
                    audience: this.config.BaseUrl,
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(this.config.TokenTimeOutMinutes),
                    signingCredentials: signingCredentials);

                return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            }

            var message = $"Username: {user.Username} is not an authorized user.";
            throw new UnauthorizedAccessException(message);
        }

        private bool IsValid(User user)
        {
            var storedUser = this.userRepository.GetUser(user.Username);
            return storedUser != null && HashHelper.CompareHash(storedUser.Hash, user.Password, this.config.Salt);
        }
    }
}
