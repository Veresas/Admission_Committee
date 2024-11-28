using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Stopwatch stopwatch;

        /// <inheritdoc cref="IStudentManager"/>
        public StudentManager(IStudentStorage storage, ILogger log)
        {
            stopwatch = new Stopwatch();
            this.storage = storage;
            logger = log;
        }

        Task<IReadOnlyCollection<Student>> IStudentManager.GetAll()
        {
            stopwatch.Restart();

            var getAll = storage.GetAll();

            stopwatch.Stop();
            logger.LogInformation("Получения всех студентов: {1} мс", stopwatch.ElapsedMilliseconds);

            return getAll;
        }
        Task<Student> IStudentManager.Add(Student student)
        {
            stopwatch.Restart();

            var add = storage.Add(student);

            stopwatch.Stop();
            logger.LogInformation("Добавление студента {id} : {elapsedTime} мс. {@Per}",
                                                            student.Id,
                                                            stopwatch.ElapsedMilliseconds, student);
            return add;
        }

        Task IStudentManager.Edit(Student student)
        {
            stopwatch.Restart();

            var edit = storage.Edit(student);

            stopwatch.Stop();
            logger.LogInformation("Изменение студента с индетификаторм {0}: {1} мс", student.Id, stopwatch.ElapsedMilliseconds);

            return edit;
        }

        Task<bool> IStudentManager.Delete(Guid id)
        {
            stopwatch.Restart();

            var delete = storage.Delete(id);

            stopwatch.Stop();

            if (delete.Result == true)
            {
                logger.LogInformation("Удаление студента с индетификаторм {0}: {1} мс - успешно", id, stopwatch.ElapsedMilliseconds);
            }
            else
            {
                logger.LogInformation("Удаление студента с индетификаторм {0}: {1} мс - ошибка удаления", id, stopwatch.ElapsedMilliseconds);

            }

            return delete;
        }

        async Task<IStudentStats> IStudentManager.GetStats()
        {
            stopwatch.Restart();

            var result = await storage.GetAll();

            stopwatch.Stop();
            logger.LogInformation("Получение всей статистики: {0} мс", stopwatch.ElapsedMilliseconds);


            return new StudentStatsModel
            {
                AllStudent = result.Count,
                StudentWithEnoughScores = result.Where(x => x.MathScores + x.RusScores + x.ITScores >= 150).Count(),
            };
        }
    }
}
