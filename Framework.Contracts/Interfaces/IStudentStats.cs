namespace Framework.Contracts.Interfaces
{
    /// <summary>
    /// Представляет интерфеейс для статистики
    /// </summary>
    public interface IStudentStats
    {
        /// <summary>
        /// Количество всех студентов
        /// </summary>
        int AllStudent { get; }
        /// <summary>
        /// Количесто всех студентов набравших необходимое количество баллов
        /// </summary>
        int StudentWithEnoughScores { get; }
    }
}
