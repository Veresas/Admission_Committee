using Framework.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Manager.Model
{
    public class StudentStatsModel : IStudentStats
    {
        /// <summary>
        /// Поле статистики о всех студентах
        /// </summary>
        public int AllStudent { get; set; }
        /// <summary>
        /// Поле статистике о всех студентах набравщих необходимое количество баллов
        /// </summary>
        public int StudentWithEnoughScores { get; set; }
    }
}
