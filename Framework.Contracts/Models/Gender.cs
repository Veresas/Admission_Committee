using System.ComponentModel;

namespace Framework.Contracts.Models
{
    public enum Gender
    {

        [Description("Мужской")]
        Male = 1,

        [Description("Женский")]
        Female = 2,
    }
}
