using System;

namespace usos.API.Application.Models.Group
{
    public class GroupPaginationResponse
    {
        public Guid GroupId { get; set; }

        public Guid DegreeCourseId { get; set; }

        public string Name { get; set; }

        public int Term { get; set; }
    }
}