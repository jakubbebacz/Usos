using System;
using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Seeds
{
    public class DegreeCourseSeed
    {
        public static readonly Guid Architecture = Guid.NewGuid();
        public static readonly Guid ComputerScience = Guid.NewGuid();
        
        public static IEnumerable<DegreeCourse> Seed()
        {
            return new List<DegreeCourse>
            {
                new() {DegreeCourseId = Architecture, DegreeCourseName = "Architecture", DepartmentId = DepartmentSeed.WBiA},
                new() {DegreeCourseId = ComputerScience, DegreeCourseName = "ComputerScience", DepartmentId = DepartmentSeed.WeAiI}
            };
        }
    }
}