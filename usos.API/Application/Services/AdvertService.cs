using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.IServices;
using usos.API.Application.Models;
using usos.API.Entities;

namespace usos.API.Application.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly UsosDbContext _usosDbContext;

        public AdvertService(UsosDbContext usosDbContext)
        {
            _usosDbContext = usosDbContext;
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
            var advert = await _usosDbContext.Advert
                .FirstOrDefaultAsync(x => x.AdvertId == advertId);

            if (advert == null)
            {
                throw new Exception("Deanery worker was not found");
            }

            advert.DeaneryWorkerId = request.DeaneryWorkerId;
            advert.Title = request.Title;
            advert.Note = request.Note;
            advert.Date = DateTime.Parse(request.Date);

            await _usosDbContext.SaveChangesAsync();
        }
        
        public async Task DeleteAdvert(Guid advertId)
        {
            var advert = await _usosDbContext.Advert
                .FirstOrDefaultAsync(x => x.AdvertId == advertId);

            if (advert == null)
            {
                throw new Exception("Deanery worker was not found");
            }

            _usosDbContext.Advert.Remove(advert);
        }
    }
}