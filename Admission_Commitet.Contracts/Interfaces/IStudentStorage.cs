using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Models;

namespace Contracts.Interfaces
{
    /// <summary>
    /// Хранение данных
    /// </summary>
    public interface IStudentStorage
    {
        /// <summary>
        /// Получение списка студентов
        /// </summary>
        /// <returns>Неимзменяемый список студентов</returns>
        Task<IReadOnlyCollection<Student>> GetAll();

        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Успешно выполненая задача, с объектом студента</returns>
        Task<Student> Add(Student student);

        /// <summary>
        /// Изменение студента
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Успешно выполненая задача</returns>
        Task Edit(Student student);

        /// <summary>
        /// Удаление студента
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Успешно/неуспешно выполненая задача</returns>
        Task<bool> Delete(Guid id);
    }
}
