using System;
using System.Collections.Generic;
using System.Text;
using static BCrypt.Net.BCrypt;

namespace Services
{
   public class CryptoService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(string passwordCandidate, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(passwordCandidate, hashPassword);
        }
    }
}
