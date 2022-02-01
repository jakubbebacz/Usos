using System;
using usos.API.Entities;

namespace usos.API.Application.Models.Group
{
    public class AddStudentsToGroupRequest
    {
        public Guid GroupId { get; set; }
        
        public Guid StudentId { get; set; }
    }
}