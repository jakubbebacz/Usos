using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.Models.Lecturer;
using Xunit;

namespace UnitTests.Lecturer
{
    public partial class LecturerServiceUnitTest
    {
        [Fact]
        public async Task ShouldChangeLecturer_WhenUpdateLecturer()
        {
            var lecturerId = Guid.NewGuid();

            var lecturer = new usos.API.Entities.Lecturer
            {
                LecturerId = lecturerId,
                DepartmentId = Guid.NewGuid(),
                FirstName = "test1",
                Surname = "test1",
                Email = "test1"
            };
            
            await _context.Database.EnsureDeletedAsync();
            await _context.Lecturer.AddRangeAsync(lecturer);
            await _context.SaveChangesAsync();

            var request = new LecturerUpdateRequest
            {
                FirstName = "test2",
                Surname = "test2",
                Email = "test2"
            };

            await _lecturerService.UpdateLecturer(lecturerId, request);

            var updatedStudent = _context.Lecturer
                .AsNoTracking()
                .Single(x => x.LecturerId == lecturerId);
            
            Assert.Equal(request.FirstName, updatedStudent.FirstName);
            Assert.Equal(request.Surname, updatedStudent.Surname);
            Assert.Equal(request.Email, updatedStudent.Email);
        }
    }
}