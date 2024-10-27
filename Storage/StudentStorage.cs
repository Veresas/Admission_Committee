using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Contracts.Models;

namespace Storege
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

        Task<Student> IStudentStorage.Add(Student student)
        {
            students.Add(student);
            return Task.FromResult(student);
        }

        Task<bool> IStudentStorage.Delete(Guid id)
        {
            var person = students.FirstOrDefault(x => x.Id == id);
            if (person != null)
            {
                students.Remove(person);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        Task IStudentStorage.Edit(Student student)
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

        Task<IReadOnlyCollection<Student>> IStudentStorage.GetAll()
            => Task.FromResult<IReadOnlyCollection<Student>>(students);
    }
}
