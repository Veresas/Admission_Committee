using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Contracts.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public EducationFrom Education { get; set; }
        public Dictionary<string, int> ExamReslt { get; set; }

    }
}
