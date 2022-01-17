using System;
using System.Threading.Tasks;
using usos.API.Application.Models;
using usos.API.Application.Models.Lecturer;
using usos.API.Libraries;

namespace usos.API.Application.IServices
{
    public interface ILecturerService
    {

        Task<PaginationResponse<LecturerPaginationResponse>> GetLecturers(LecturerPaginationRequest request);

        Task<LecturerResponse> GetLecturer(Guid lecturerId);

        Task<Guid> CreateLecturer(LecturerRequest request);

        Task<ResultCode> UpdateLecturer(Guid lecturerId, LecturerUpdateRequest request);

        Task<ResultCode> DeleteLecturer(Guid lecturerId);
    }
}