using System;
using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Seeds
{
    public class DegreeCourseSeed
    {
        public static readonly Guid Architecture = Guid.Parse("217393b2-365e-48b3-a19f-d57579d7af22");
        public static readonly Guid CivilEngineering = Guid.Parse("db4c85d3-e6e8-47f9-b1c1-4c65363abf23");
        public static readonly Guid Informatics = Guid.Parse("54336ed5-cd60-4195-9ee6-b07b1e75cfa2");
        public static readonly Guid Teleinformatics = Guid.Parse("12faf566-464e-4e15-8864-526d5deeaac5");
        public static readonly Guid GeodesyAndCartography = Guid.Parse("fe1d979b-0111-4c5a-bf5c-ce233c9abb9d");
        public static readonly Guid EnvironmentalEngineering = Guid.Parse("8f915c86-b60d-493c-8f38-f2a3ce618a88");
        public static readonly Guid AutomationAndRobotics = Guid.Parse("06477e73-56c1-44b8-946e-04d8bece2fd3");
        public static readonly Guid Economy = Guid.Parse("6108aca7-e412-41cb-bb1e-02c1784b5c09");
        public static readonly Guid Start = Guid.Parse("f7491277-0a07-49bb-b2fe-82987be9bfa7");

        public static IEnumerable<DegreeCourse> Seed()
        {
            return new List<DegreeCourse>
            {
                new() {DegreeCourseId = Architecture, DegreeCourseName = "Architektura", DepartmentId = DepartmentSeed.WBiA},
                new() {DegreeCourseId = CivilEngineering, DegreeCourseName = "Budownictwo", DepartmentId = DepartmentSeed.WBiA},
                new() {DegreeCourseId = Informatics, DegreeCourseName = "Informatyka", DepartmentId = DepartmentSeed.WeAiI},
                new() {DegreeCourseId = Teleinformatics, DegreeCourseName = "Teleinformatyka", DepartmentId = DepartmentSeed.WeAiI},
                new() {DegreeCourseId = GeodesyAndCartography, DegreeCourseName = "Geodezja i kartografia", DepartmentId = DepartmentSeed.ISGiE},
                new() {DegreeCourseId = EnvironmentalEngineering, DegreeCourseName = "Inżynieria środowiska", DepartmentId = DepartmentSeed.ISGiE},
                new() {DegreeCourseId = AutomationAndRobotics, DegreeCourseName = "Automatyka i robotyka", DepartmentId = DepartmentSeed.WMiBM},
                new() {DegreeCourseId = Economy, DegreeCourseName = "Ekonomia", DepartmentId = DepartmentSeed.WZiMK},
                new() {DegreeCourseId = Start, DegreeCourseName = "new", DepartmentId = DepartmentSeed.Start},
            };
        }
    }
}