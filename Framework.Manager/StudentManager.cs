using Framework.Contracts.Interfaces;
using Framework.Contracts.Models;
using Framework.Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Manager
{
    public class StudentManager : IStudentManager
    {
        private IStudentStorage storage;

        public StudentManager(IStudentStorage storage)
        {
            this.storage = storage;
        }

        public async Task<IReadOnlyCollection<Student>> GetAll() 
            => await storage.GetAll();

        public async Task<Student> Add(Student student)
            => await storage.Add(student);

        public async Task Edit(Student student)
            => await storage.Edit(student);

        public async Task<bool> Delete(Guid id)
            => await storage.Delete(id);

        public async Task<IStudentStats> GetStats()
        {
            var result = await storage.GetAll();
            return new StudentStatsModel
            {
                AllStudent = result.Count,
                StudentWithEnoughScores = result.Where(x => x.MathScores + x.RusScores + x.ITScores == 150).Count(),
            };
        }
    }

}