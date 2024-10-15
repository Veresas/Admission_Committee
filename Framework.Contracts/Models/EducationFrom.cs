using System.ComponentModel;

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
