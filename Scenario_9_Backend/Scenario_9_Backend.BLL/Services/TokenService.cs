﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace Scenario_9_Backend.BLL.Services
{

        public class TokenService : ITokenService
        {
            private readonly IConfiguration configuration;

            public TokenService(IConfiguration configuration)
            {
                this.configuration = configuration;
            }
            public async Task<string> CreateToken(ApplicationUser user, UserManager<ApplicationUser> userManager)
            {
                var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
            }; // Private Claims (UserDefined)

                var userRoles = await userManager.GetRolesAsync(user);

                foreach (var role in userRoles)
                    authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));


                var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));

                var token = new JwtSecurityToken(

                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(double.Parse(configuration["JWT:DurationInDays"])),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }
