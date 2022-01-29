using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Lecturer
{
    public partial class LecturerServiceUnitTest
    {
        [Fact]
        public async Task ShouldDeleteUser_WhenDelete()
        {
            var lecturerId = Guid.NewGuid();

            var lecturers = new[]
            {
                new usos.API.Entities.Lecturer
                {
                    LecturerId = lecturerId,
                    DepartmentId = Guid.NewGuid(),
                    CardId = "test1",
                    FirstName = "test1",
                    Surname = "test1",
                    PhoneNumber = "test1",
                    Email = "test1@vp.pl"
                },
                new usos.API.Entities.Lecturer
                {
                    LecturerId = Guid.NewGuid(),
                    DepartmentId = Guid.NewGuid(),
                    CardId = "test2",
                    FirstName = "test2",
                    Surname = "test2",
                    PhoneNumber = "test2",
                    Email = "test2@vp.pl"
                }
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.Lecturer.AddRangeAsync(lecturers);
            await _context.SaveChangesAsync();
            await _context.Database.EnsureCreatedAsync();

            await _lecturerService.DeleteLecturer(lecturerId);

            var response = _context.Lecturer
                .AsNoTracking()
                .SingleOrDefault(x => x.LecturerId == lecturerId);
            
            Assert.Null(response);
        }
    }
}