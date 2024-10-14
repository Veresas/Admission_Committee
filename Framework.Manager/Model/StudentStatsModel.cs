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
        public int AllStudent { get; set; }
        public int StudentWithEnoughScores { get; set; }
    }
}
