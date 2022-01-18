using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using usos.API.Application.IServices.AuthHelpers;

namespace usos.API.Application.Services.AuthHelpers
{
    public class CryptService : ICryptService
    {
        private readonly IConfiguration _configuration;

        public CryptService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    
        public string EncryptPassword(string password)
        {
            return CalculateSha256(password, _configuration["Auth:Secret"]);
        }
    
        public string EncryptToken(Guid id)
        {
            var token = $"{id}+{DateTime.UtcNow.Date:dd/MM/yyyy}";
            return CalculateSha256(token, _configuration["Auth:Secret"]);
        }
    
        private static string CalculateSha256(string str, string secret)
        {
            var encoding = new ASCIIEncoding();

            var textBytes = encoding.GetBytes(str);
            var keyBytes = encoding.GetBytes(secret);

            byte[] hashBytes;

            using (var hash = new HMACSHA256(keyBytes))
            {
                hashBytes = hash.ComputeHash(textBytes);
            }

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}