using System;
using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Seeds
{
    public class SubjectSeed
    {
        public  static readonly Guid HistoryOfTownArchitecture = Guid.Parse("88ab6383-9fe4-47e5-9aa7-52a0a52cc55d");
        public  static readonly Guid DescriptiveGeometry = Guid.Parse("d23407c3-8594-402f-8e95-e239974e74f7");
        public  static readonly Guid FreehandDrawing = Guid.Parse("28c942cd-66a2-4007-b8dc-aed8f776b2d9");
        public  static readonly Guid Mathematics = Guid.Parse("5ff3f298-4349-4610-803f-17f91d810068");
        public  static readonly Guid Physics = Guid.Parse("8d3d37d4-af82-48d2-9818-b1f308a85325");
        public  static readonly Guid Chemistry = Guid.Parse("a3078198-9ed9-4158-baec-2c6ba992c1d6");
        public  static readonly Guid BasicsOfProgramming = Guid.Parse("ddb230a4-cdd3-414d-bd8e-52db3bd3dec4");
        public  static readonly Guid BasicsOfSoftwareEngineering = Guid.Parse("dec88be0-578b-43d5-9d9e-af2f03bd79f1");
        public  static readonly Guid Algorithms = Guid.Parse("097ae40d-c52b-42c3-9bcc-d8c5b02c8a34");
        public  static readonly Guid WirelessNetworks = Guid.Parse("966152e5-a646-49c5-82d6-61c4d8ecdc9a");
        public  static readonly Guid SystemSecurity = Guid.Parse("cde703b3-d378-4f1b-9d09-b6dbb6253bc0");
        public  static readonly Guid Geomathics = Guid.Parse("8d61ce92-d6fc-4b2e-a806-3fa678433f5d");
        public  static readonly Guid EngineeringGeodesy = Guid.Parse("be522d39-7c00-494f-9c95-3fc05e38fe74");
        public  static readonly Guid Cartography = Guid.Parse("6416be9d-bf6c-41cb-ba69-47bb93d3202f");
        public  static readonly Guid Biology = Guid.Parse("15ae38d1-0e9e-4e72-8b55-01683c5a9771");
        public  static readonly Guid Hydraulics = Guid.Parse("c61e69f1-1c23-46b1-b5db-9c8902128157");
        public  static readonly Guid FluidMechanics = Guid.Parse("fbf85551-47e3-41c9-a737-c5e4e38ba06e");
        public  static readonly Guid Electrotechnics = Guid.Parse("39e30cb2-36ea-4510-8ad0-715106cb676f");
        public  static readonly Guid Automation = Guid.Parse("9617d6ec-110c-4775-a86f-ac11c919db20");
        public  static readonly Guid Metrology = Guid.Parse("a93cc31b-565c-45dd-b519-7f8992d500fb");
        public  static readonly Guid DescriptiveStatistics = Guid.Parse("a1a6e2ff-5a25-41bc-8a5a-5b0512c27d12");
        public  static readonly Guid Accountancy = Guid.Parse("9027cd26-dec8-43ba-8577-1756ae4dec85");
        public  static readonly Guid Macroeconomics = Guid.Parse("db914b74-5a1c-47ab-8cba-75745e2e4799");
        
        public static IEnumerable<Subject> Seed()
        {
            return new List<Subject>
            {
                new()
                {
                    SubjectId = HistoryOfTownArchitecture, SubjectName = "Historia architektury miast", DegreeCourseId = DegreeCourseSeed.Architecture, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = DescriptiveGeometry, SubjectName = "Geometria opisowa", DegreeCourseId = DegreeCourseSeed.Architecture, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = FreehandDrawing, SubjectName = "Rysunek odręczny", DegreeCourseId = DegreeCourseSeed.Architecture, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Mathematics, SubjectName = "Matematyka", DegreeCourseId = DegreeCourseSeed.CivilEngineering, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Physics, SubjectName = "Fizyka", DegreeCourseId = DegreeCourseSeed.CivilEngineering, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Chemistry, SubjectName = "Chemia", DegreeCourseId = DegreeCourseSeed.CivilEngineering, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = BasicsOfProgramming, SubjectName = "Podstawy programowania", DegreeCourseId = DegreeCourseSeed.Informatics, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = BasicsOfSoftwareEngineering, SubjectName = "Podstawy inżynierii programowania", DegreeCourseId = DegreeCourseSeed.Informatics, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Algorithms, SubjectName = "Algorytmy", DegreeCourseId = DegreeCourseSeed.Informatics, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = WirelessNetworks, SubjectName = "Sieci bezprzewodowe", DegreeCourseId = DegreeCourseSeed.Teleinformatics, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = SystemSecurity, SubjectName = "Bezpieczeństwo systemów", DegreeCourseId = DegreeCourseSeed.Teleinformatics, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Geomathics, SubjectName = "Geomatematyka", DegreeCourseId = DegreeCourseSeed.Teleinformatics, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = EngineeringGeodesy, SubjectName = "Geodezja inżynieryjna", DegreeCourseId = DegreeCourseSeed.GeodesyAndCartography, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Cartography, SubjectName = "Kartografia", DegreeCourseId = DegreeCourseSeed.GeodesyAndCartography, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Biology, SubjectName = "Biologia", DegreeCourseId = DegreeCourseSeed.GeodesyAndCartography, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Hydraulics, SubjectName = "Hydraulika", DegreeCourseId = DegreeCourseSeed.EnvironmentalEngineering, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = FluidMechanics, SubjectName = "Mechanika płynów", DegreeCourseId = DegreeCourseSeed.EnvironmentalEngineering, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Electrotechnics, SubjectName = "Elektrotechnika", DegreeCourseId = DegreeCourseSeed.EnvironmentalEngineering, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Automation, SubjectName = "Automatyka", DegreeCourseId = DegreeCourseSeed.AutomationAndRobotics, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Metrology, SubjectName = "Metrologia", DegreeCourseId = DegreeCourseSeed.AutomationAndRobotics, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = DescriptiveStatistics, SubjectName = "Statystyka deskrypcyjna", DegreeCourseId = DegreeCourseSeed.AutomationAndRobotics, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Accountancy, SubjectName = "Rachunkowość", DegreeCourseId = DegreeCourseSeed.Economy, SubjectSemester = 1
                },
                new()
                {
                    SubjectId = Macroeconomics, SubjectName = "Makroekonomia", DegreeCourseId = DegreeCourseSeed.Economy, SubjectSemester = 1
                }
            };
        }
    }
}