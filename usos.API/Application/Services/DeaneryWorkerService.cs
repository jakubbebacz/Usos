using System;
using System.Data.Entity;
using System.Threading.Tasks;
using usos.API.Application.IServices;
using usos.API.Application.Models;
using usos.API.Entities;

namespace usos.API.Application.Services
{
    public class DeaneryWorkerService : IDeaneryWorkerService
    {
        private readonly UsosDbContext _usosDbContext;
        
        public DeaneryWorkerService(UsosDbContext usosDbContext)
        {
            _usosDbContext = usosDbContext;
        }

        public async Task<Guid> CreateDeaneryWorker(DeaneryWorkerRequest request)
        {
            var deaneryWorker = new DeaneryWorker
            {
                CardId = request.CardId,
                FirstName = request.FirstName,
                Surname = request.Surname,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };

            await _usosDbContext.AddAsync(deaneryWorker);
            await _usosDbContext.SaveChangesAsync();
            return deaneryWorker.DeaneryWorkerId;
        }

        public async Task UpdateDeaneryWorker(Guid deaneryWorkerId, DeaneryWorkerRequest request)
        {
            var deaneryWorker = await _usosDbContext.DeaneryWorker
                    .FirstOrDefaultAsync(x => x.DeaneryWorkerId == deaneryWorkerId);

            if (deaneryWorker == null)
            {
                throw new Exception("Deanery worker was not found");
            }

            deaneryWorker.CardId = request.CardId?.Trim();
            deaneryWorker.FirstName = request.FirstName?.Trim();
            deaneryWorker.Surname = request.Surname?.Trim();
            deaneryWorker.PhoneNumber = request.PhoneNumber?.Trim();
            deaneryWorker.Email = request.Email?.Trim();

            await _usosDbContext.SaveChangesAsync();
        }

        public async Task DeleteDeaneryWorker(Guid deaneryWorkerId)
        {
            var deaneryWorker = await _usosDbContext.DeaneryWorker
                .FirstOrDefaultAsync(x => x.DeaneryWorkerId == deaneryWorkerId);

            if (deaneryWorker == null)
            {
                throw new Exception("Deanery worker was not found");
            }

            _usosDbContext.DeaneryWorker.Remove(deaneryWorker);
        }
    }
}