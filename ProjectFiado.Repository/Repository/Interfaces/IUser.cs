using ProjectFiado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFiado.Repository.Repository.Interfaces
{
    public interface IUser
    {
        Task<UserModel> CreateUser(UserModel user);
        Task<UserModel> UpdateUser(int id, UserModel user);
        Task<UserModel> GetById(int id);
        Task<UserModel> RemoverAcesso(int id);
        Task<UserModel> PermitirAcesso(int id);
    }
}
