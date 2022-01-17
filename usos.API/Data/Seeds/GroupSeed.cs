using System;
using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Seeds
{
    public class GroupSeed
    {
        public static readonly Guid GroupId = Guid.Parse("60638ce5-7039-4021-b9a9-c04248a82b16");
        
        public static IEnumerable<Group> Seed()
        {
            return new List<Group>
            {
                new() {GroupId = GroupId, Name = "new", DegreeCourseId = DegreeCourseSeed.Start}
            };
        }
    }
}