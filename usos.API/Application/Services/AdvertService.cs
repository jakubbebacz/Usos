using System;
using System.Threading.Tasks;
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
    }
}