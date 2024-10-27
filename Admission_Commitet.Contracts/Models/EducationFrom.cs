using System.ComponentModel;

namespace Contracts.Models
{
    /// <summary> Формы обучения </summary>
    public enum EducationFrom
    {
        /// <summary> Очная форма обучения </summary>
        [Description("Очно")]
        fullTime = 1,

        /// <summary> Очно-заочная форма обучения </summary>
        [Description("Очно-заочно")]
        HalfTime = 2,

        /// <summary> Заочная форма обучения </summary>
        [Description("Заочно")]
        correspondence = 3,
    }
}
