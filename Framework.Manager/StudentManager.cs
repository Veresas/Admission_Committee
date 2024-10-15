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
        /// <summary>
        /// Передача хранилища в управление
        /// </summary>
        /// <param name="storage"></param>
        public StudentManager(IStudentStorage storage)
        {
            this.storage = storage;
        }
        /// <summary>
        /// Запрос из хранилища всех эдементов
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<Student>> GetAll()
            => await storage.GetAll();
        /// <summary>
        /// Добавление нового объекта в хранилище
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> Add(Student student)
            => await storage.Add(student);
        /// <summary>
        /// Изменение объекта в хранилище
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task Edit(Student student)
            => await storage.Edit(student);
        /// <summary>
        /// Удаление объекта из хранилища по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id)
            => await storage.Delete(id);
        /// <summary>
        /// Получение данных о статистике по всем элементам хранилища
        /// </summary>
        /// <returns></returns>
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
