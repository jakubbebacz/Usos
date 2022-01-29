using System;
using System.Linq;
using System.Threading.Tasks;
using usos.API.Application.Models;
using usos.API.Application.Models.Lecturer;
using Xunit;

namespace UnitTests.Lecturer
{
    public partial class LecturerServiceUnitTest
    {
        [Fact]
        public async Task ShouldReturnLecturers_WhenGetAll()
        {
            var lecturers = new[]
            {
                new usos.API.Entities.Lecturer
                {
                    DepartmentId = Guid.NewGuid(),
                    CardId = "as332d",
                    FirstName = "test1",
                    Surname = "test1",
                    PhoneNumber = "111222333",
                    Email = "test1@vp.pl"
                },
                new usos.API.Entities.Lecturer
                {
                    DepartmentId = Guid.NewGuid(),
                    CardId = "test2",
                    FirstName = "test2",
                    Surname = "test2",
                    PhoneNumber = "444555666",
                    Email = "test2@vp.pl"
                }
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.Lecturer.AddRangeAsync(lecturers);
            await _context.SaveChangesAsync();
            await _context.Database.EnsureCreatedAsync();

            var response = await _lecturerService.GetLecturers(new LecturerPaginationRequest
            {
                SortBy = "FirstName"
            });

            Assert.IsType<PaginationResponse<LecturerPaginationResponse>>(response);
            
            Assert.Equal(lecturers[0].LecturerId, response.List.ToList()[0].LecturerId);
            Assert.Equal(lecturers[0].FirstName, response.List.ToList()[0].FirstName);
            Assert.Equal(lecturers[0].Surname, response.List.ToList()[0].Surname);
            Assert.Equal(lecturers[0].Email, response.List.ToList()[0].Email);
        }
    }
}