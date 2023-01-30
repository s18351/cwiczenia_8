using System.Collections.Generic;

namespace EfCoreExamples.Models
{
    public partial class Status
    {
        public int IdStatus { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

