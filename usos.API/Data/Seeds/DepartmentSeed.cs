using System;
using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Seeds
{
    public class DepartmentSeed
    {
        public static readonly Guid ISGiE = Guid.Parse("3a621967-2cf7-42b1-b81a-28c1e12a54bb");
        public static readonly Guid WBiA = Guid.Parse("9607faa8-1863-4fa5-9e6e-f98e164d2d51");
        public static readonly Guid WeAiI = Guid.Parse("d4761e62-c0d2-47c8-a950-fff434553807");
        public static readonly Guid WMiBM = Guid.Parse("c785da83-165c-4fb0-9c32-96e738324944");
        public static readonly Guid WZiMK = Guid.Parse("31b8df03-86b1-4d3a-a4aa-e1ff98220e90");
        public static readonly Guid Start = Guid.Parse("7c0f6e4f-94ab-45d8-be3e-d70667559280");

        public static IEnumerable<Department> Seed()
        {
            return new List<Department>
            {
                new() {DepartmentId = ISGiE, DepartmentName = "ISGiE"},
                new() {DepartmentId = WBiA, DepartmentName = "WBiA"},
                new() {DepartmentId = WMiBM, DepartmentName = "WMiBM"},
                new() {DepartmentId = WeAiI, DepartmentName = "WEAiI"},
                new() {DepartmentId = WZiMK, DepartmentName = "WZiMK"},
                new() {DepartmentId = Start, DepartmentName = "new"},
            };
        }
    }
}