using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Lecturer
{
    public partial class LecturerServiceUnitTest
    {
        public async Task ShouldReturnLecturer_WhenGetLecturer()
        {
            var lecturerId = Guid.NewGuid();

            var lecturer = new usos.API.Entities.Lecturer
            {
                LecturerId = lecturerId,
                DepartmentId = Guid.NewGuid(),
                CardId = "test1",
                FirstName = "test1",
                Surname = "test1",
                PhoneNumber = "test1",
                Email = "test1@vp.pl"
            };
            
            await _context.Database.EnsureDeletedAsync();
            await _context.Lecturer.AddRangeAsync(lecturer);
            await _context.SaveChangesAsync();
            await _context.Database.EnsureCreatedAsync();

            var response = await _lecturerService.GetLecturer(lecturerId);
            
            Assert.Equal(lecturer.LecturerId, response.LecturerId);
            Assert.Equal(lecturer.DepartmentId, response.DepartmentId);
            Assert.Equal(lecturer.CardId, response.CardId);
            Assert.Equal(lecturer.FirstName, response.FirstName);
            Assert.Equal(lecturer.Surname, response.Surname);
            Assert.Equal(lecturer.PhoneNumber, response.PhoneNumber);
            Assert.Equal(lecturer.Email, response.Email);
        }
    }
}