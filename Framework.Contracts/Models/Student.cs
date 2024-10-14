using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Contracts.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public EducationFrom Education { get; set; }
        public Dictionary<string, int> ExamReslt { get; set; }

    }
}
