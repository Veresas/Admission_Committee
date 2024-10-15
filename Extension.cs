using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace Admission_Committee
{
    internal static class Extension
    {
        /// <summary>
        /// Заполнение Combobox значениями переданного Enum
        /// <typeparam name="TCombobox"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="target"></param>
        /// <param name="source"></param>
        public static void AddEnumSourse<TCombobox, TSource>(this TCombobox target,
            TSource source)
            where TCombobox : System.Windows.Forms.ComboBox
            where TSource : Enum
        {
            var data = Enum.GetValues(source.GetType())
               .Cast<Enum>()
               .Select((e) => new { Value = e, Description = GetEnumDescription(e) })
               .ToList();

            target.DataSource = data;
            target.DisplayMember = "Description";
            target.ValueMember = "Value";

            target.SelectedIndex = 0;
        }

        private static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                 .FirstOrDefault() as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
        /// <summary>
        /// Связывание элемента блока управления и значения ресурса
        /// <typeparam name="TControl"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="target"></param>
        /// <param name="targetProperty"></param>
        /// <param name="source"></param>
        /// <param name="sourceProperty"></param>
        /// <param name="errorProvider"></param>
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
