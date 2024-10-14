using Framework.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
