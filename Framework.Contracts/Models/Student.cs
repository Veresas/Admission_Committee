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
        [Required]
        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; } = new DateTime(2000, 1, 1);
        [Required]
        public EducationFrom Education { get; set; }
        public int MathScores {  get; set; }
        public int RusScores { get; set; }
        public int ITScores { get; set; }
        public int SumScores => MathScores + RusScores + ITScores;
    }
}
