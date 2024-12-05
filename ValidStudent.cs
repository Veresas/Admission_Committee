using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Models;

namespace Admission_Committee
{
    internal class ValidStudent : Student
    {
        /// <summary>
        /// Уникальный индетификатор студента
        /// </summary>
        public new Guid Id { get; set; }

        /// <summary>
        /// Имя студента
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public new string Name { get; set; }

        /// <summary>
        /// Пол студента
        /// </summary>
        [Required]
        public new Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения студента
        /// </summary>
        public new DateTime BirthDay { get; set; } = new DateTime(2000, 1, 1);

        /// <summary>
        /// Форма обучения
        /// </summary>
        [Required]
        public new EducationFrom Education { get; set; }

        /// <summary>
        /// Результаты экзаменов по математике
        /// </summary>
        [Range(0, double.MaxValue)]
        public new int MathScores { get; set; }

        /// <summary>
        /// Результаты экзаменов по русскому языку
        /// </summary>
        [Range(0, double.MaxValue)]
        public new int RusScores { get; set; }

        /// <summary>
        /// Результаты экзаменов по информатике
        /// </summary>
        [Range(0, double.MaxValue)]
        public new int ITScores { get; set; }
    }
}
