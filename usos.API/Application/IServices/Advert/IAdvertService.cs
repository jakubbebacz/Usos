using System;
using System.Threading.Tasks;
using usos.API.Application.Models;

namespace usos.API.Application.IServices
{
    public interface IAdvertService
    {
        Task<PaginationResponse<AdvertPaginationResponse>> GetAdverts(PaginationRequest request);

        Task<Guid> CreateAdvert(AdvertRequest request);
        
        Task UpdateAdvert(Guid advertId, AdvertRequest request);

        Task DeleteAdvert(Guid advertId);
    }
}