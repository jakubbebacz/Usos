using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using usos.API.Application.Models;

namespace usos.API.Application.IServices
{
    public interface IStudentService
    {
        Task<PaginationResponse<StudentPaginationResponse>> GetStudents(StudentPaginationRequest request);

        Task<StudentSubjectsResponse> GetStudentSubjects(Guid studentId);

        Task<IEnumerable<double>> GetStudentMarks(Guid studentId);

        Task<StudentResponse> GetStudent(Guid studentId);

        Task<Guid> CreateStudent(StudentRequest request);

        Task<Guid> AddMark(StudentMarksRequest request);

        Task UpdateStudent(Guid studentId, StudentRequest request);

        Task DeleteStudent(Guid studentId);
    }
}