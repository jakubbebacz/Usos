using System;
using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Seeds
{
    public class DegreeCourseSeed
    {
        public static readonly Guid Architecture = Guid.NewGuid();
        public static readonly Guid CivilEngineering = Guid.NewGuid();
        public static readonly Guid Electromobility = Guid.NewGuid();
        public static readonly Guid Electrotechnics = Guid.NewGuid();
        public static readonly Guid PowerEngineering = Guid.NewGuid();
        public static readonly Guid Informatics = Guid.NewGuid();
        public static readonly Guid Teleinformatics = Guid.NewGuid();
        public static readonly Guid GeodesyAndCartography = Guid.NewGuid();
        public static readonly Guid EnvironmentalEngineering = Guid.NewGuid();
        public static readonly Guid RenewableEnergySources = Guid.NewGuid();
        public static readonly Guid AutomationAndRobotics = Guid.NewGuid();
        public static readonly Guid MechanicalEngineering = Guid.NewGuid();
        public static readonly Guid Economy = Guid.NewGuid();
        public static readonly Guid Logistics = Guid.NewGuid();
        
        public static IEnumerable<DegreeCourse> Seed()
        {
            return new List<DegreeCourse>
            {
                new() {DegreeCourseId = Architecture, DegreeCourseName = "Architektura", DepartmentId = DepartmentSeed.WBiA},
                new() {DegreeCourseId = CivilEngineering, DegreeCourseName = "Budownictwo", DepartmentId = DepartmentSeed.WBiA},
                new() {DegreeCourseId = Electromobility, DegreeCourseName = "Elektromobilność", DepartmentId = DepartmentSeed.WeAiI},
                new() {DegreeCourseId = Electrotechnics, DegreeCourseName = "Elektrotechnika", DepartmentId = DepartmentSeed.WeAiI},
                new() {DegreeCourseId = PowerEngineering, DegreeCourseName = "Energetyka", DepartmentId = DepartmentSeed.WeAiI},
                new() {DegreeCourseId = Informatics, DegreeCourseName = "Informatyka", DepartmentId = DepartmentSeed.WeAiI},
                new() {DegreeCourseId = Teleinformatics, DegreeCourseName = "Teleinformatyka", DepartmentId = DepartmentSeed.WeAiI},
                new() {DegreeCourseId = GeodesyAndCartography, DegreeCourseName = "Geodezja i kartografia", DepartmentId = DepartmentSeed.ISGiE},
                new() {DegreeCourseId = EnvironmentalEngineering, DegreeCourseName = "Inżynieria środowiska", DepartmentId = DepartmentSeed.ISGiE},
                new() {DegreeCourseId = RenewableEnergySources, DegreeCourseName = "Odnawialne źródła energii", DepartmentId = DepartmentSeed.ISGiE},
                new() {DegreeCourseId = AutomationAndRobotics, DegreeCourseName = "Automatyka i robotyka", DepartmentId = DepartmentSeed.WMiBM},
                new() {DegreeCourseId = MechanicalEngineering, DegreeCourseName = "Mechanika i budowa maszyn", DepartmentId = DepartmentSeed.WMiBM},
                new() {DegreeCourseId = Economy, DegreeCourseName = "Ekonomia", DepartmentId = DepartmentSeed.WZiMK},
                new() {DegreeCourseId = Logistics, DegreeCourseName = "Logistyka", DepartmentId = DepartmentSeed.WZiMK},
            };
        }
    }
}