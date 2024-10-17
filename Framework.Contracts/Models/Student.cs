using System;
using System.ComponentModel.DataAnnotations;

namespace Framework.Contracts.Models
{
    public class Student
    {
        /// <summary>
        /// Уникальный индетификатор студента
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Поле имени студента
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        /// <summary>
        /// Пол студента
        /// </summary>
        [Required]
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения студента
        /// </summary>
        public DateTime BirthDay { get; set; } = new DateTime(2000, 1, 1);
        /// <summary>
        /// Форма обучения
        /// </summary>
        [Required]
        public EducationFrom Education { get; set; }
        /// <summary>
        /// Результаты экзаменов по математике
        /// </summary>
        [Range(0, double.MaxValue)]
        public int MathScores { get; set; }
        /// <summary>
        /// Результаты экзаменов по русскому языку
        /// </summary>
        [Range(0, double.MaxValue)]
        public int RusScores { get; set; }
        /// <summary>
        /// Результаты экзаменов по информатике
        /// </summary>
        [Range(0, double.MaxValue)]
        public int ITScores { get; set; }

    }
}
