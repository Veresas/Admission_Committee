using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Contracts.Models;
using Manager.Model;

namespace Manager
{
    /// <inheritdoc cref="IStudentManager"/>
    public class StudentManager : IStudentManager
    {
        private IStudentStorage storage;

        /// <inheritdoc cref="IStudentManager"/>
        public StudentManager(IStudentStorage storage)
        {
            this.storage = storage;
        }

        /// <inheritdoc cref="IStudentManager"/>
        public Task<IReadOnlyCollection<Student>> GetAll()
            => storage.GetAll();

        /// <inheritdoc cref="IStudentManager"/>
        public Task<Student> Add(Student student)
            => storage.Add(student);

        /// <inheritdoc cref="IStudentManager"/>
        public Task Edit(Student student)
            => storage.Edit(student);

        /// <inheritdoc cref="IStudentManager"/>
        public Task<bool> Delete(Guid id)
            => storage.Delete(id);

        /// <inheritdoc cref="IStudentManager"/>
        public async Task<IStudentStats> GetStats()
        {
            var result = await storage.GetAll();
            return new StudentStatsModel
            {
                AllStudent = result.Count,
                StudentWithEnoughScores = result.Where(x => x.MathScores + x.RusScores + x.ITScores >= 150).Count(),
            };
        }
    }
}
