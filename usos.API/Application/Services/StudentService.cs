using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.IServices;
using usos.API.Application.Models;
using usos.API.Entities;
using usos.API.Extensions;

namespace usos.API.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly UsosDbContext _usosDbContext;

        public StudentService(UsosDbContext usosDbContext)
        {
            _usosDbContext = usosDbContext;
        }

        public async Task<PaginationResponse<StudentPaginationResponse>> GetStudents(StudentPaginationRequest request)
        {
            var query = _usosDbContext.Student.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Phrase))
            {
                query = query.Where(x =>
                    (x.FirstName.ToLower() + " " + x.Surname.ToLower()).Contains(request.Phrase.ToLower())
                    || x.Email.Contains(request.Phrase));
            }

            query = query.OrderByRequest(request.SortBy, request.SortDir);

            return new PaginationResponse<StudentPaginationResponse>
            {
                List = await query.Skip(request.Skip)
                    .Take(request.Take)
                    .Select(x => new StudentPaginationResponse
                    {
                        StudentId = x.StudentId,
                        FirstName = x.FirstName,
                        Surname = x.Surname,
                        GroupId = x.GroupId,
                        Email = x.Email,
                        IndexNumber = x.IndexNumber
                    })
                    .ToListAsync(),
                TotalCount = await query.CountAsync()
            };
        }

        public async Task<Guid> CreateStudent(StudentRequest request)
        {
            var student = new Student
            {
                FirstName = request.FirstName,
                Surname = request.Surname,
                Email = request.Email,
                IndexNumber = request.IndexNumber
            };

            await _usosDbContext.AddAsync(student);
            await _usosDbContext.SaveChangesAsync();
            return student.StudentId;
        }

        public async Task UpdateStudent(Guid studentId, StudentRequest request)
        {
            var student = await _usosDbContext.Student
                .FirstOrDefaultAsync(x => x.StudentId == studentId);

            if (student == null)
            {
                throw new Exception("Deanery worker was not found");
            }
        }

        public async Task DeleteStudent(Guid studentId)
        {
            var student = await _usosDbContext.Student
                .FirstOrDefaultAsync(x => x.StudentId == studentId);

            if (student == null)
            {
                throw new Exception("Deanery worker was not found");
            }

            _usosDbContext.Student.Remove(student);
        }
    }
}