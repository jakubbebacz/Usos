using System;
using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Seeds
{
    public class GroupSeed
    {
        public static readonly Guid GroupId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");
        
        public static IEnumerable<Group> Seed()
        {
            return new List<Group>
            {
                new() {GroupId = GroupId, Name = "new", DegreeCourseId = DegreeCourseSeed.Start}
            };
        }
    }
}