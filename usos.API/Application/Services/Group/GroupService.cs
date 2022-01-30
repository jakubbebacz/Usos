using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.IServices;
using usos.API.Application.Models.Group;
using usos.API.Entities;
using usos.API.Libraries;

namespace usos.API.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly UsosDbContext _usosDbContext;

        public GroupService(UsosDbContext usosDbContext)
        {
            _usosDbContext = usosDbContext;
        }
        
        public async Task<Guid> CreateGroup(GroupRequest request)
        {
            var group = new Group
            {
                DegreeCourseId = request.DegreeCourseId,
                Name = request.Name.Trim(),
                Term = request.Term
            };

            await _usosDbContext.AddAsync(group);
            await _usosDbContext.SaveChangesAsync();

            return group.GroupId;
        }

        public async Task<IEnumerable<Guid>> AddStudentsToGroup(AddStudentsToGroupRequest request)
        {
            var group = await _usosDbContext.Group.FirstOrDefaultAsync(x => x.GroupId == request.GroupId);

            if (group == null)
            {
                throw new Exception("Group was not found");
            }
            
            foreach (var studentId in request.StudentsId)
            {
                var student = await _usosDbContext.Student.FirstOrDefaultAsync(x => x.StudentId == studentId);
                
                if (student == null)
                {
                    throw new Exception("Student was not found");
                }
                
                student.GroupId = group.GroupId;
                student.Semester = group.Term;
            }

            await _usosDbContext.SaveChangesAsync();
            return group.Students.Select(x => x.StudentId);
        }

        public async Task<ResultCode> UpdateGroup(Guid groupId, GroupUpdateRequest request)
        {
            var exist = await _usosDbContext.Group
                .AsNoTracking()
                .AnyAsync(x => x.GroupId == groupId);

            if (!exist)
            {
                return ResultCode.NotFound;
            }

            var group = await _usosDbContext.Group
                .SingleAsync(x => x.GroupId == groupId);

            group.Name = request.Name.Trim();
            group.Term = request.Term;

            _usosDbContext.Update(group);
            await _usosDbContext.SaveChangesAsync();

            return ResultCode.Ok;
        }

        public async Task<ResultCode> DeleteGroup(Guid groupId)
        {
            var exist = await _usosDbContext.Group
                .AsNoTracking()
                .AnyAsync(x => x.GroupId == groupId);

            if (exist == false)
            {
                return ResultCode.NotFound;
            }

            var group = await _usosDbContext.Group
                .SingleAsync(x => x.GroupId == groupId);

            _usosDbContext.Remove(group);
            await _usosDbContext.SaveChangesAsync();

            return ResultCode.Ok;
        }
    }
}