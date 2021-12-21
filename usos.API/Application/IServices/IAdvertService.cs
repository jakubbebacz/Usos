using System;
using System.Threading.Tasks;
using usos.API.Application.Models;

namespace usos.API.Application.IServices
{
    public interface IAdvertService
    {
        Task<Guid> CreateAdvert(AdvertRequest request);
    }
}