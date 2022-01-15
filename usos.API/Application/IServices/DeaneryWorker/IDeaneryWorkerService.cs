using System;
using System.Threading.Tasks;
using usos.API.Application.Models;

namespace usos.API.Application.IServices
{
    public interface IDeaneryWorkerService
    {
        Task<Guid> CreateDeaneryWorker(DeaneryWorkerRequest request);

        Task UpdateDeaneryWorker(Guid deaneryWorkerId, DeaneryWorkerRequest request);

        Task DeleteDeaneryWorker(Guid deaneryWorkerId);
    }
}