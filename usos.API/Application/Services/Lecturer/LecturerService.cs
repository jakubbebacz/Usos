using System;
using System.Linq;
using System.Threading.Tasks;
using usos.API.Application.IServices;
using usos.API.Application.Models.Lecturer;
using usos.API.Libraries;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.Models;
using usos.API.Extensions;

namespace usos.API.Application.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly UsosDbContext _usosDbContext;

        public LecturerService(UsosDbContext usosDbContext)
        {
            _usosDbContext = usosDbContext;
        }

        public async Task<PaginationResponse<LecturerPaginationResponse>> GetLecturers(LecturerPaginationRequest request)
        {
            var query = _usosDbContext.Lecturer.AsNoTracking();
            
            if (!string.IsNullOrWhiteSpace(request.Phrase))
            {
                query = query.Where(x =>
                    (x.FirstName.ToLower() + " " + x.Surname.ToLower()).Contains(request.Phrase.ToLower())
                    || x.Email.Contains(request.Phrase));
            }

            if (request.DepartmentId != null)
            {
                query = query.Where(x => x.DepartmentId == request.DepartmentId);
            }

            query = query.OrderByRequest(request.SortBy, request.SortDir);

            return new PaginationResponse<LecturerPaginationResponse>
            {
                List = await query.Skip(request.Skip)
                    .Take(request.Take)
                    .Select(x => new LecturerPaginationResponse
                    {
                        LecturerId = x.LecturerId,
                        FirstName = x.FirstName,
                        Surname = x.Surname,
                        Email = x.Email,
                    })
                    .ToListAsync(),
                TotalCount = await query.CountAsync()
            };
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