using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Models;

namespace Contracts.Interfaces
{
    /// <summary>
    /// Управления данными
    /// </summary>
    public interface IStudentManager
    {
        /// <summary>
        /// Получение всех <see cref="Student"/> из <see cref="IStudentStorage"/>
        /// </summary>
        Task<IReadOnlyCollection<Student>> GetAll();

        /// <summary>
        /// Добваление новых <see cref="Student"/> в <see cref="IStudentStorage"/>
        /// </summary>
        Task<Student> Add(Student student);

        /// <summary>
        /// Изменение существующего <see cref="Student"/> в <see cref="IStudentStorage"/>
        /// </summary>
        Task Edit(Student student);

        /// <summary>
        /// Удаление <see cref="Student"/> из <see cref="IStudentStorage"/>
        /// </summary>
        Task<bool> Delete(Guid id);

        /// <summary>
        /// Получение <see cref="IStudentStats"/>
        /// </summary>
        Task<IStudentStats> GetStats();
    }
}
