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
        public async Task ReturnGuid_WhenCreateLecturer()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            var request = new LecturerRequest
            {
                DepartmentId = Guid.NewGuid(),
                CardId = "test1",
                FirstName = "test1",
                Surname = "test1",
                PhoneNumber = "test1"
            };

            var response = await _lecturerService.CreateLecturer(request);

            Assert.IsType<Guid>(response);

            var lecturer = _context.Lecturer
                .AsNoTracking()
                .Single(x => x.LecturerId == response);
            
            Assert.Equal(request.DepartmentId, lecturer.DepartmentId);
            Assert.Equal(request.CardId, lecturer.CardId);
            Assert.Equal(request.FirstName, lecturer.FirstName);
            Assert.Equal(request.Surname, lecturer.Surname);
            Assert.Equal(request.PhoneNumber, lecturer.PhoneNumber);
        }
    }
}