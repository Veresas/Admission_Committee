using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Contracts.Interfaces;
using Framework.Contracts.Models;

namespace Storege.Memory
{
    /// <inheritdoc cref="IStudentStorage"/>
    public class StudentStorage : IStudentStorage
    {

        private List<Student> students;

        /// <inheritdoc cref="IStudentStorage"/>
        public StudentStorage()
        {
            students = new List<Student>();
        }
        /// <inheritdoc cref="IStudentStorage"/>
        public Task<Student> Add(Student student)
        {
            students.Add(student);
            return Task.FromResult(student);
        }
        /// <inheritdoc cref="IStudentStorage"/>
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
        /// <inheritdoc cref="IStudentStorage"/>
        public Task Edit(Student student)
        {
            var target = students.FirstOrDefault(x => x.Id == student.Id);
            if (target != null)
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
        /// <inheritdoc cref="IStudentStorage"/>
        public Task<IReadOnlyCollection<Student>> GetAll()
            => Task.FromResult<IReadOnlyCollection<Student>>(students);

    }
}
