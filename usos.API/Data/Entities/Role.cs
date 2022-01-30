using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class Role
    {
        public Guid RoleId { get; set; }
    
        public string RoleName { get; set; }
        
        public virtual ICollection<Student> Students { get; set; }
        
        public virtual ICollection<DeaneryWorker> DeaneryWorkers { get; set; }
        
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        
        public virtual ICollection<Rector> Rector { get; set; }
    }
}