using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Contracts.Interfaces
{
    public interface IStudentStats
    {
        int AllStudent {  get; }
        int StudentWithEnoughScores { get; }
    }
}
