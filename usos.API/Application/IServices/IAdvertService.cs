using System;
using System.Threading.Tasks;
using usos.API.Application.Models;

namespace usos.API.Application.IServices
{
    public interface IAdvertService
    {
        Task<Guid> CreateAdvert(AdvertRequest request);
        
        Task UpdateAdvert(Guid advertId, AdvertRequest request);

        Task DeleteAdvert(Guid advertId);
    }
}