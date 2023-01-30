using System;
using System.Collections.Generic;

#nullable disable

namespace EfCoreExamples2.Models
{
    public partial class Status
    {
        public Status()
        {
            Students = new HashSet<Student>();
        }

        public int IdStatus { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
