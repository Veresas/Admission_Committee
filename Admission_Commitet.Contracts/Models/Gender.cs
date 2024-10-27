using System.ComponentModel;

namespace Contracts.Models
{
    /// <summary> Список гендеров </summary>
    public enum Gender
    {
        /// <summary> Мужской пол </summary>
        [Description("Мужской")]
        Male = 1,

        /// <summary> Женский пол </summary>
        [Description("Женский")]
        Female = 2,
    }
}
