using System;
using System.Threading.Tasks;
using usos.API.Application.Models;

namespace usos.API.Application.IServices
{
    public interface IStudentService
    {
        Task<Guid> CreateStudent(StudentRequest request);

        Task UpdateStudent(Guid studentId, StudentRequest request);

        Task DeleteStudent(Guid studentId);
    }
}