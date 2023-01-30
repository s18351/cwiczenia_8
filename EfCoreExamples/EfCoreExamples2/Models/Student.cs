using System;
using System.Collections.Generic;

#nullable disable

namespace EfCoreExamples2.Models
{
    public partial class Student
    {
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int? IdStatus { get; set; }

        public virtual Status IdStatusNavigation { get; set; }
    }
}
