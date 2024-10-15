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

        /// <summary>
        /// Конструктор для создания хранилища данных о студентах
        /// </summary>
        public StudentStorage()
        {
            students = new List<Student>();
        }
        /// <summary>
        /// Добавление нового студента
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Task<Student> Add(Student student)
        {
            student.SumScores = student.MathScores + student.RusScores + student.ITScores;
            students.Add(student);
            return Task.FromResult(student);
        }
        /// <summary>
        /// Удаление студента по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Изменение студента
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
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
                target.SumScores = student.MathScores + student.RusScores + student.ITScores;
            }

            return Task.CompletedTask;
        }
        /// <summary>
        /// Получение списка всех объектов студентов
        /// </summary>
        /// <returns></returns>
        public Task<IReadOnlyCollection<Student>> GetAll()
            => Task.FromResult<IReadOnlyCollection<Student>>(students);

    }
}
