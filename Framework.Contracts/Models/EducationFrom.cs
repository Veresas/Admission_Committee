using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Contracts.Models
{
    public enum EducationFrom
    {
        [Description("Очно")]
        fullTime = 1,
        
        [Description("Очно-заочно")]
        HalfTime = 2,

        [Description("Заочно")]
        correspondence = 3,
        
    }
}
