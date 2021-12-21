using System;
using System.Threading.Tasks;
using usos.API.Application.IServices;
using usos.API.Application.Models.Lecturer;
using usos.API.Libraries;
using Microsoft.EntityFrameworkCore;

namespace usos.API.Application.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly UsosDbContext _usosDbContext;

        public LecturerService(UsosDbContext usosDbContext)
        {
            _usosDbContext = usosDbContext;
        }

        public async Task<Guid> CreateLecturer(LecturerRequest request)
        {
            var lecturer = new Entities.Lecturer
            {
                DepartmentId = request.DepartmentId,
                CardId = request.CardId,
                FirstName = request.FirstName,
                Surname = request.Surname,
                PhoneNumber = request.PhoneNumber,
                Email = request.PhoneNumber
            };

            await _usosDbContext.AddAsync(lecturer);
            await _usosDbContext.SaveChangesAsync();

            return lecturer.LecturerId;
        }

        public async Task<ResultCode> UpdateLecturer(Guid lecturerId, LecturerUpdateRequest request)
        {
            var exist = await _usosDbContext.Lecturer
                .AsNoTracking()
                .AnyAsync(x => x.LecturerId == lecturerId);

            if (!exist)
            {
                return ResultCode.NotFound;
            }

            var lecturer = await _usosDbContext.Lecturer
                .SingleAsync(x => x.LecturerId == lecturerId);

            lecturer.CardId = request.CardId;
            lecturer.FirstName = request.FirstName;
            lecturer.Surname = request.Surname;
            lecturer.Email = request.Email;
            lecturer.PhoneNumber = request.PhoneNumber;

            _usosDbContext.Update(lecturer);
            await _usosDbContext.SaveChangesAsync();

            return ResultCode.Ok;
        }

        public async Task<ResultCode> DeleteLecturer(Guid lecturerId)
        {
            var exist = await _usosDbContext.Lecturer
                .AsNoTracking()
                .AnyAsync(x => x.LecturerId == lecturerId);

            if (!exist)
            {
                return ResultCode.NotFound;
            }

            var lecturer = await _usosDbContext.Lecturer
                .SingleAsync(x => x.LecturerId == lecturerId);

            _usosDbContext.Remove(lecturer);
            await _usosDbContext.SaveChangesAsync();

            return ResultCode.Ok;
        }
    }
}