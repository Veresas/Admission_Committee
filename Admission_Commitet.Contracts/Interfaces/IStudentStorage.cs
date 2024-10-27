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
        /// Получение списка <see cref="Student"/>
        /// </summary>
        /// <returns>Неимзменяемый список студентов</returns>
        Task<IReadOnlyCollection<Student>> GetAll();

        /// <summary>
        /// Добавление <see cref="Student"/>
        /// </summary>
        Task<Student> Add(Student student);

        /// <summary>
        /// Изменение <see cref="Student"/>
        /// </summary>
        Task Edit(Student student);

        /// <summary>
        /// Удаление <see cref="Student"/>
        /// </summary>
        Task<bool> Delete(Guid id);
    }
}
