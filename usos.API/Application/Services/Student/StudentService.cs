using System;
using System.Collections.Generic;
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
                        Email = x.Email,
                        IndexNumber = x.IndexNumber
                    })
                    .ToListAsync(),
                TotalCount = await query.CountAsync()
            };
        }

        public async Task<StudentSubjectsResponse> GetStudentSubjects(Guid studentId)
        {
            var student = await _usosDbContext.Student.FirstOrDefaultAsync(x => x.StudentId == studentId);

            if (student == null)
            {
                throw new Exception("Student was not found");
            }
            
            var subjects = student.StudentSubjects.Select(x => x.Subject);
            return new StudentSubjectsResponse
            {
                Subjects = subjects.ToList()
            };
        }

        public async Task<IEnumerable<double[]>> GetStudentMarks(Guid studentId)
        {
            var student = await _usosDbContext.Student.FirstOrDefaultAsync(x => x.StudentId == studentId);
            
            if (student == null)
            {
                throw new Exception("Student was not found");
            }

            var marks = student.StudentSubjects.Select(x => x.Marks);
            return marks;
        }

        public async Task<Guid> CreateStudent(StudentRequest request)
        {
            var student = new Student
            {
                FirstName = request.FirstName,
                Surname = request.Surname,
                GroupId = Guid.Parse("93449994-de91-4cbf-b78f-6b4302b8b07f"),
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
                throw new Exception("Student was not found");
            }

            student.FirstName = request.FirstName;
            student.Surname = request.Surname;
            student.Email = request.Email;

            await _usosDbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(Guid studentId)
        {
            var student = await _usosDbContext.Student
                .FirstOrDefaultAsync(x => x.StudentId == studentId);

            if (student == null)
            {
                throw new Exception("Student was not found");
            }

            _usosDbContext.Student.Remove(student);
            await _usosDbContext.SaveChangesAsync();
        }
    }
}