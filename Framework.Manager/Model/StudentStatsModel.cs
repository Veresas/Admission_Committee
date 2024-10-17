using Framework.Contracts.Interfaces;

namespace Framework.Manager.Model
{
    /// <inheritdoc cref="IStudentStats"/>
    public class StudentStatsModel : IStudentStats
    {
        /// <inheritdoc cref="IStudentStats"/>
        public int AllStudent { get; set; }
        /// <inheritdoc cref="IStudentStats"/>
        public int StudentWithEnoughScores { get; set; }
    }
}
