using System;

namespace usos.API.Application.IServices.AuthHelpers
{
    public interface ICryptService
    {
        string EncryptPassword(string password);
    
        string EncryptToken(Guid id);
    }
}