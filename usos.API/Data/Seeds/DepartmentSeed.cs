using System;
using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Seeds
{
    public class DepartmentSeed
    {
        public static readonly Guid ISGiE = Guid.NewGuid();
        public static readonly Guid WBiA = Guid.NewGuid();
        public static readonly Guid WeAiI = Guid.NewGuid();
        public static readonly Guid WMiBM = Guid.NewGuid();
        public static readonly Guid WZiMK = Guid.NewGuid();

        public static IEnumerable<Department> Seed()
        {
            return new List<Department>
            {
                new() {DepartmentId = ISGiE, DepartmentName = "ISGiE"},
                new() {DepartmentId = WBiA, DepartmentName = "WBiA"},
                new() {DepartmentId = WMiBM, DepartmentName = "WMiBM"},
                new() {DepartmentId = WeAiI, DepartmentName = "WEAiI"},
                new() {DepartmentId = WZiMK, DepartmentName = "WZiMK"},
            };
        }
    }
}