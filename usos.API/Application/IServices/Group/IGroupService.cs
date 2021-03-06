using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using usos.API.Application.Models;
using usos.API.Application.Models.Group;
using usos.API.Entities;
using usos.API.Libraries;

namespace usos.API.Application.IServices
{
    public interface IGroupService
    {
        Task<PaginationResponse<GroupPaginationResponse>> GetGroups(GroupPaginationRequest request);
        
        Task<Guid> CreateGroup(GroupRequest request);
        
        Task<Guid> AddStudentToGroup(AddStudentsToGroupRequest request);

        Task<ResultCode> UpdateGroup(Guid groupId, GroupUpdateRequest request);

        Task<ResultCode> DeleteGroup(Guid groupId);
    }
}