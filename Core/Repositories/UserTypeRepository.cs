﻿using System;
using System.Threading.Tasks;
using Core.Base;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Core.Repositories
{
    public class UserTypeRepository : BaseRepository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(ZeusDbContext context) : base(context)
        {
        }

        public async Task Update(UserType userType)
        {
            var userTypeToUpdate = await Get(userType.Id);

            userTypeToUpdate.Description = userType.Description;
            userTypeToUpdate.UpdatedAt = DateTime.Now;

            _context.UserTypes.Update(userTypeToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}