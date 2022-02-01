using System;
using System.Data.Entity;
using System.Threading.Tasks;
using usos.API.Application.IServices;
using usos.API.Application.IServices.AuthHelpers;
using usos.API.Application.Models;
using usos.API.Entities;
using usos.API.Globals;
using usos.API.Seeds;

namespace usos.API.Application.Services
{
    public class DeaneryWorkerService : IDeaneryWorkerService
    {
        private readonly UsosDbContext _usosDbContext;
        private readonly IEmailService _emailService;

        public DeaneryWorkerService(UsosDbContext usosDbContext, IEmailService emailService)
        {
            _usosDbContext = usosDbContext;
            _emailService = emailService;
        }

        public async Task<Guid> CreateDeaneryWorker(DeaneryWorkerRequest request)
        {
            var deaneryWorker = new DeaneryWorker
            {
                CardId = request.CardId,
                RoleId = RoleSeed.DeaneryWorker,
                FirstName = request.FirstName,
                Surname = request.Surname,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Password = string.Empty,
                IsPasswordChangeRequired = true
            };

            await _usosDbContext.AddAsync(deaneryWorker);
            await _usosDbContext.SaveChangesAsync();
            
            await _emailService.SendEmailWithSetPasswordUrl(deaneryWorker.Email, "Welcome!", deaneryWorker.DeaneryWorkerId);
            
            return deaneryWorker.DeaneryWorkerId;
        }

        public async Task UpdateDeaneryWorker(Guid deaneryWorkerId, DeaneryWorkerRequest request)
        {
            await _usosDbContext.DeaneryWorker
                .AsNoTracking()
                .IsAnyRuleAsync(x => x.DeaneryWorkerId == deaneryWorkerId);
            var deaneryWorker = await _usosDbContext.DeaneryWorker.SingleAsync(x => x.DeaneryWorkerId == deaneryWorkerId);

            deaneryWorker.CardId = request.CardId?.Trim();
            deaneryWorker.FirstName = request.FirstName?.Trim();
            deaneryWorker.Surname = request.Surname?.Trim();
            deaneryWorker.PhoneNumber = request.PhoneNumber?.Trim();
            deaneryWorker.Email = request.Email?.Trim();

            await _usosDbContext.SaveChangesAsync();
        }

        public async Task DeleteDeaneryWorker(Guid deaneryWorkerId)
        {
            await _usosDbContext.DeaneryWorker
                .AsNoTracking()
                .IsAnyRuleAsync(x => x.DeaneryWorkerId == deaneryWorkerId);
            var deaneryWorker = await _usosDbContext.DeaneryWorker.SingleAsync(x => x.DeaneryWorkerId == deaneryWorkerId);

            _usosDbContext.DeaneryWorker.Remove(deaneryWorker);
            await _usosDbContext.SaveChangesAsync();
        }
    }
}