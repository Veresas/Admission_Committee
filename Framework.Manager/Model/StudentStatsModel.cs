using Framework.Contracts.Interfaces;

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
