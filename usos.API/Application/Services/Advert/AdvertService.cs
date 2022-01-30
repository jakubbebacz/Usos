using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.IServices;
using usos.API.Application.Models;
using usos.API.Entities;
using usos.API.Extensions;
using usos.API.Globals;

namespace usos.API.Application.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly UsosDbContext _usosDbContext;

        public AdvertService(UsosDbContext usosDbContext)
        {
            _usosDbContext = usosDbContext;
        }

        public async Task<PaginationResponse<AdvertPaginationResponse>> GetAdverts(PaginationRequest request)
        {
            var query = _usosDbContext.Advert.AsNoTracking();
            query = query.OrderByRequest(request.SortBy, request.SortDir);
            
            return new PaginationResponse<AdvertPaginationResponse>
            {
                List = await query.Skip(request.Skip)
                    .Take(request.Take)
                    .Select(x => new AdvertPaginationResponse
                    {
                        AdvertId = x.AdvertId,
                        Title = x.Title,
                        Note = x.Note,
                        Date = x.Date
                    }).ToListAsync(),
                TotalCount = await query.CountAsync()
            };
        }

        public async Task<Guid> CreateAdvert(AdvertRequest request)
        {
            var advert = new Advert
            {
                DeaneryWorkerId = request.DeaneryWorkerId,
                Title = request.Title,
                Note = request.Note,
                Date = Convert.ToDateTime(request.Date)
            };
            
            await _usosDbContext.AddAsync(advert);
            await _usosDbContext.SaveChangesAsync();
            return advert.AdvertId;
        }

        public async Task UpdateAdvert(Guid advertId, AdvertRequest request)
        {
            await _usosDbContext.Advert
                .AsNoTracking()
                .IsAnyRuleAsync(x => x.AdvertId == advertId);
            var advert = await _usosDbContext.Advert.SingleAsync(x => x.AdvertId == advertId);

            advert.DeaneryWorkerId = request.DeaneryWorkerId;
            advert.Title = request.Title;
            advert.Note = request.Note;
            advert.Date = DateTime.Parse(request.Date);

            await _usosDbContext.SaveChangesAsync();
        }
        
        public async Task DeleteAdvert(Guid advertId)
        {
            await _usosDbContext.Advert
                .AsNoTracking()
                .IsAnyRuleAsync(x => x.AdvertId == advertId);
            var advert = await _usosDbContext.Advert.SingleAsync(x => x.AdvertId == advertId);
            
            _usosDbContext.Advert.Remove(advert);
            await _usosDbContext.SaveChangesAsync();
        }
    }
}