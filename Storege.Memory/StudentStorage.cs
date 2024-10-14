using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Contracts;
using Framework.Contracts.Models;
using Framework.Contracts.Interfaces;

namespace Storege.Memory
{
    public class StudentStorage : IStudentStorage
    {

        private List<Student> students;

        public StudentStorage()
        {
            students = new List<Student>();
        }

        public Task<Student> Add(Student student)
        {
            students.Add(student);
            return Task.FromResult(student);
        }

        public Task<bool> Delete(Guid id)
        {
            var person = students.FirstOrDefault(x => x.Id == id);
            if (person != null)
            {
                students.Remove(person);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task Edit(Student student)
        {
            var target = students.FirstOrDefault(x => x.Id == student.Id);
            if (student != null)
            {
                target.Name = student.Name;
                target.Gender = student.Gender;
                target.BirthDay = student.BirthDay;
                target.Education = student.Education;
                target.MathScores = student.MathScores;
                target.ITScores = student.ITScores;
                target.RusScores = student.RusScores;
            }

            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<Student>> GetAll()
            => Task.FromResult<IReadOnlyCollection<Student>>(students);

    }
}
