using Microsoft.EntityFrameworkCore;
using ProjectFiado.Data;
using ProjectFiado.Models;
using ProjectFiado.Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFiado.Repository.Repository
{
    public class UserRepository : IUser
    {
        private readonly FiadoDBContext _dbContext;

        public UserRepository( FiadoDBContext dBContext)
        {
            _dbContext = dBContext;
        }


        public async Task<UserModel> CreateUser(UserModel user)
        {
            await _dbContext.users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> GetById(int id)
        {
            var userId = await _dbContext.users.FirstOrDefaultAsync(x=> x.Id == id);
            if (userId == null)
            {
                throw new KeyNotFoundException("erro ao encontrar id");
            }
            return userId;
        }

        public async Task<UserModel> PermitirAcesso(int id)
        {
            var userModelId = await _dbContext.users.FirstOrDefaultAsync(x=> x.Id==id);

            if (userModelId == null)
            {
                throw new KeyNotFoundException("não encontrado");
            }


            if(userModelId.Status == Domain.Enum.Status.Deactivate)
            {
                userModelId.Status = Domain.Enum.Status.Ativate;

                await _dbContext.SaveChangesAsync();

            }
            return userModelId;

        }

        public async Task<UserModel> RemoverAcesso(int id)
        {
            var userModelId = await _dbContext.users.FirstOrDefaultAsync(x => x.Id == id);

            if (userModelId == null)
            {
                throw new KeyNotFoundException("não encontrado");
            }


            if (userModelId.Status == Domain.Enum.Status.Ativate)
            {
                userModelId.Status = Domain.Enum.Status.Deactivate;

                await _dbContext.SaveChangesAsync();

            }
            return userModelId;
        }

        public async Task<UserModel> UpdateUser(int id, UserModel user)
        {
            var existingUser = await _dbContext.users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            existingUser.Name = user.Name;
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.role = user.role; 
            existingUser.Status = user.Status; 
            
            existingUser.LastAlterationName = user.LastAlterationName;
            existingUser.LastModificationDate = DateTime.Now;
            
            await _dbContext.SaveChangesAsync();

            return existingUser;
        }
    }
}
