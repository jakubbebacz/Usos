using System;
using System.Threading.Tasks;

namespace usos.API.Application.IServices.AuthHelpers
{
    public interface IEmailService
    {
        Task SendEmailWithSetPasswordUrl(string receiver, string subject, Guid userId);
    }
}