using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Contracts.Models
{
    /// <summary> Представление абитуриента </summary>
    public class Student
    {
        /// <summary>
        /// Уникальный индетификатор студента
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя студента
        /// </summary>
        [DisplayName("Имя")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        /// <summary>
        /// Пол студента
        /// </summary>
        [Required]
        [DisplayName("Гендер")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения студента
        /// </summary>
        [DisplayName("День рождения")]
        public DateTime BirthDay { get; set; } = new DateTime(2000, 1, 1);

        /// <summary>
        /// Форма обучения
        /// </summary>
        [Required]
        [DisplayName("Форма обучения")]
        public EducationFrom Education { get; set; }

        /// <summary>
        /// Результаты экзаменов по математике
        /// </summary>
        [Range(0, 100)]
        [DisplayName("Балл за математику")]
        public int MathScores { get; set; }

        /// <summary>
        /// Результаты экзаменов по русскому языку
        /// </summary>
        [Range(0, 100)]
        [DisplayName("Балл за русский язык")]
        public int RusScores { get; set; }

        /// <summary>
        /// Результаты экзаменов по информатике
        /// </summary>
        [Range(0, 100)]
        [DisplayName("Балл за IT")]
        public int ITScores { get; set; }
    }
}
