﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Base;
using Core.DTO;
using Core.Helpers;
using Core.Interfaces;
using Data.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User AddMatriculaToStudent(User user)
        {
            string matricula = null;
            var lastUser = _unitOfWork.UserRepository.GetAll();
            if (lastUser.Any())
            {
                matricula = lastUser.Last().Matricula;
            }

            user.Matricula = MatriculaHelper.Generator(matricula);
            return user;
        }

        public User Authenticate(AuthenticationDTO model)
        {
            model.Password = PasswordHelper.HashPassword(model.Password);
            var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(u =>
                (u.Matricula == model.EmailOrMatricula || u.Email == model.EmailOrMatricula) &&
                u.Password == model.Password);

            if (user == null)
            {
                return null;
            }

            var userWithToken = GetUserWithToken(user);
            return userWithToken;
        }

        private User GetUserWithToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("MyLoginSecretWorldThatHasMoreThanTwoHundredAndFiftySix");
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var userDTO = UserDTO.FromEntity(user);

            var token = tokenHandler.CreateToken(tokenDescriptor);
            userDTO.Token = tokenHandler.WriteToken(token);

            return userDTO;
        }
    }
}