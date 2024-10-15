using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Contracts.Models;

namespace Framework.Contracts.Interfaces
{
    public interface IStudentManager
    {
        Task<IReadOnlyCollection<Student>> GetAll();

        Task<Student> Add(Student student);

        Task Edit(Student student);

        Task<bool> Delete(Guid id);

        Task<IStudentStats> GetStats();
    }
}
