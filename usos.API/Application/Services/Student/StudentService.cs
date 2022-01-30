using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.IServices;
using usos.API.Application.IServices.AuthHelpers;
using usos.API.Application.Models;
using usos.API.Entities;
using usos.API.Extensions;
using usos.API.Globals;
using usos.API.Seeds;

namespace usos.API.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly UsosDbContext _usosDbContext;
        private readonly IEmailService _emailService;

        public StudentService(UsosDbContext usosDbContext, IEmailService emailService)
        {
            _usosDbContext = usosDbContext;
            _emailService = emailService;
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

            if (request.GroupId != null)
            {
                query = query.Where(x => x.GroupId == request.GroupId);
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
                        IndexNumber = x.IndexNumber,
                        GroupId = x.GroupId
                    })
                    .ToListAsync(),
                TotalCount = await query.CountAsync()
            };
        }

        public async Task<IEnumerable<string>> GetStudentSubjects(Guid studentId)
        {
            await _usosDbContext.Student
                .AsNoTracking()
                .IsAnyRuleAsync(x => x.StudentId == studentId);
            var student = await _usosDbContext.Student.SingleAsync(x => x.StudentId == studentId);

            var degreeCourseId = await _usosDbContext.Group
                .AsNoTracking()
                .Where(x => x.GroupId == student.GroupId)
                .Select(x => x.DegreeCourseId).SingleAsync();

            var subjects = _usosDbContext.Subject
                .AsNoTracking()
                .Where(x => x.DegreeCourseId == degreeCourseId)
                .Select(x => x.SubjectName);

            return subjects;
        }

        public async Task<List<StudentMarksResponse>> GetStudentMarks(Guid studentId)
        {
            await _usosDbContext.Student
                .AsNoTracking()
                .IsAnyRuleAsync(x => x.StudentId == studentId);
            var student = await _usosDbContext.Student.SingleAsync(x => x.StudentId == studentId);

            var dgId = await _usosDbContext.Group
                .Where(x => x.GroupId == student.GroupId)
                .Select(x => x.DegreeCourseId)
                .SingleAsync();

            var subjects = await _usosDbContext.Subject
                .Where(x => x.SubjectSemester == student.Semester && x.DegreeCourseId == dgId).ToListAsync();

            var response = new List<StudentMarksResponse>();

            foreach (var subject in subjects)
            {
                var result = 0.00m;
                var marks = _usosDbContext.StudentSubject
                    .Where(x => x.StudentId == studentId && x.SubjectId == subject.SubjectId).Select(x => x.Mark);
                if (await marks.AnyAsync())
                {
                    var finalMark = await marks.AverageAsync();
                    var x = Convert.ToDecimal(finalMark);
                    var i = (int) decimal.Truncate(x);
                    var first2DecimalPlaces = (int)(x % 1) * 100;
                    result = first2DecimalPlaces switch
                    {
                        < 26 => i,
                        < 76 => Convert.ToDecimal(i + 0.5),
                        _ => i + 1
                    };
                }

                response.Add(new StudentMarksResponse
                {
                    SubjectName = subject.SubjectName,
                    Mark = result
                });
            }
            
            return response;
        }

        public async Task<StudentResponse> GetStudent(Guid studentId)
        {
            await _usosDbContext.Student
                .AsNoTracking()
                .IsAnyRuleAsync(x => x.StudentId == studentId);
            var student = await _usosDbContext.Student.SingleAsync(x => x.StudentId == studentId);

            return new StudentResponse
            {
                StudentId = student.StudentId,
                Email = student.Email,
                FirstName = student.FirstName,
                Surname = student.Surname,
                GroupId = student.GroupId,
                IndexNumber = student.IndexNumber
            };
        }

        public async Task<Guid> CreateStudent(StudentRequest request)
        {
            var student = new Student
            {
                FirstName = request.FirstName,
                RoleId = RoleSeed.Student,
                Surname = request.Surname,
                GroupId = GroupSeed.GroupId,
                Email = request.Email,
                IndexNumber = request.IndexNumber,
                Password = string.Empty,
                IsPasswordChangeRequired = true
            };

            await _usosDbContext.AddAsync(student);
            await _usosDbContext.SaveChangesAsync();
            
            await _emailService.SendEmailWithSetPasswordUrl(student.Email, "Welcome!", student.StudentId);
            
            return student.StudentId;
        }

        public async Task<Guid> AddMark(StudentMarksRequest request)
        {
            var mark = new StudentSubject
            {
                StudentId = request.StudentId,
                SubjectId = request.SubjectId,
                Mark = request.Mark
            };
            
            await _usosDbContext.AddAsync(mark);
            await _usosDbContext.SaveChangesAsync();

            return mark.StudentSubjectId;
        }

        public async Task UpdateStudent(Guid studentId, StudentRequest request)
        {
            await _usosDbContext.Student
                .AsNoTracking()
                .IsAnyRuleAsync(x => x.StudentId == studentId);
            var student = await _usosDbContext.Student.SingleAsync(x => x.StudentId == studentId);

            student.FirstName = request.FirstName;
            student.Surname = request.Surname;
            student.Email = request.Email;
            student.IndexNumber = request.IndexNumber;

            await _usosDbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(Guid studentId)
        {
            await _usosDbContext.Student
                .AsNoTracking()
                .IsAnyRuleAsync(x => x.StudentId == studentId);
            var student = await _usosDbContext.Student.SingleAsync(x => x.StudentId == studentId);

            _usosDbContext.Student.Remove(student);
            await _usosDbContext.SaveChangesAsync();
        }
    }
}