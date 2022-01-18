using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using usos.API.Application.Models.Group;
using usos.API.Entities;
using usos.API.Libraries;

namespace usos.API.Application.IServices
{
    public interface IGroupService
    {
        Task<Guid> CreateGroup(GroupRequest request);
        
        Task<IEnumerable<Guid>> AddStudentsToGroup(AddStudentsToGroupRequest request);

        Task<ResultCode> UpdateGroup(Guid groupId, GroupUpdateRequest request);

        Task<ResultCode> DeleteGroup(Guid groupId);
    }
}