using Framework.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Admission_Committee
{
    internal static class Extension
    {
        public static void AddEnumSourse<TCombobox, TSource>(this TCombobox target,
            TSource source)
            where TCombobox : System.Windows.Forms.ComboBox
            where TSource : Enum
        {
            var data = Enum.GetValues(source.GetType())
               .Cast<Enum>()
               .Select((e, index) => new { Value = e, Description = GetEnumDescription(e),Index = index + 1 })    
               .ToList();

            target.DataSource = data;
            target.DisplayMember = "Description";
            target.ValueMember = "Value";
        }

        public static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                 .FirstOrDefault() as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static void AddBinding<TControl, TSource>(this TControl target,
             Expression<Func<TControl, object>> targetProperty,
             TSource source,
             Expression<Func<TSource, object>> sourceProperty,
             ErrorProvider errorProvider = null)
             where TControl : Control
             where TSource : class
        {
            var targetName = GetMemberName(targetProperty);
            var sourceName = GetMemberName(sourceProperty);
            target.DataBindings.Add(new Binding(targetName, source, sourceName,
                false,
                DataSourceUpdateMode.OnPropertyChanged));
            if (errorProvider != null)
            {
                var sourcePropertyInfo = source.GetType().GetProperty(sourceName);
                var validarors = sourcePropertyInfo.GetCustomAttributes<ValidationAttribute>();
                if (validarors?.Any() == true)
                {
                    target.Validating += (sender, args) =>
                    {
                        var context = new ValidationContext(source);
                        var results = new List<ValidationResult>();
                        errorProvider.SetError(target, string.Empty);
                        if (!Validator.TryValidateObject(source, context, results, validateAllProperties: true))
                        {
                            foreach (var error in results.Where(x => x.MemberNames.Contains(sourceName)))
                            {
                                errorProvider.SetError(target, error.ErrorMessage);
                            }
                        }
                    };
                }
            }
        }
        private static string GetMemberName<TItem, TMember>(Expression<Func<TItem, TMember>> targetMember)
        {
            if (targetMember.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            if (targetMember.Body is UnaryExpression unaryExpression)
            {
                var operand = unaryExpression.Operand as MemberExpression;
                return operand.Member.Name;
            }

            throw new ArgumentException();
        }
    }
}