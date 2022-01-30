using System;
using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Seeds
{
    public static class RoleSeed
    {
        public const string StudentId = "7301ada3-6464-45c7-0000-0847cba6bc63";
        public const string DeaneryWorkerId = "7301ada3-6464-45c7-0001-0847cba6bc64";
        public const string LecturerId = "7301ada3-6464-45c7-0002-0847cba6bc65";
        public const string RectorId = "7301ada3-6464-45c7-0002-0847cba6bc66";
 
        public readonly static Guid Student = Guid.Parse(StudentId);
        public readonly static Guid DeaneryWorker = Guid.Parse(DeaneryWorkerId);
        public readonly static Guid Lecturer = Guid.Parse(LecturerId);
        public readonly static Guid Rector = Guid.Parse(RectorId);
  
        public static IEnumerable<Role> Seed()
        {
            return new List<Role>
            {
                new Role { RoleId = Student, RoleName = "Student" },
                new Role { RoleId = DeaneryWorker, RoleName = "DeaneryWorker" },
                new Role { RoleId = Lecturer, RoleName = "Lecturer" },
                new Role { RoleId = Rector, RoleName = "Rector" },
            };
        }
    }
}