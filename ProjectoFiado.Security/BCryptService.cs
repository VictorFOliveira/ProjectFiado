using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFiado.Security
{
    public class BCryptService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashesPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashesPassword);
        }
    }
}
