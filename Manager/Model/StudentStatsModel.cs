using Contracts.Interfaces;

namespace Manager.Model
{
    /// <inheritdoc cref="IStudentStats"/>
    public class StudentStatsModel : IStudentStats
    {
        public int AllStudent { get; set; }

        public int StudentWithEnoughScores { get; set; }
    }
}
