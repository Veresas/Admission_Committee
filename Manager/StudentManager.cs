using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Contracts.Models;
using Manager.Model;
using Microsoft.Extensions.Logging;

namespace Manager
{
    /// <inheritdoc cref="IStudentManager"/>
    public class StudentManager : IStudentManager
    {
        private ILogger logger;
        private IStudentStorage storage;

        /// <inheritdoc cref="IStudentManager"/>
        public StudentManager(IStudentStorage storage, ILogger log)
        {
            this.storage = storage;
            logger = log;
        }

        Task<IReadOnlyCollection<Student>> IStudentManager.GetAll()
            => storage.GetAll();
        Task<Student> IStudentManager.Add(Student student)
            => storage.Add(student);

        Task IStudentManager.Edit(Student student)
            => storage.Edit(student);

        Task<bool> IStudentManager.Delete(Guid id)
            => storage.Delete(id);

        async Task<IStudentStats> IStudentManager.GetStats()
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
