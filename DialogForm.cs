using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using Contracts.Models;

namespace Admission_Committee
{
    public partial class DialogForm : Form
    {
        private Student student;
        private ValidStudent validStudent;

        /// <summary>
        /// Передача объекта студента, над которым проводились манипуляции
        /// </summary>
        public Student Student => student;

        /// <summary>
        /// Создает нового студента или заполняет данными переданного объекта
        /// </summary>
        /// <param name="student"></param>
        public DialogForm(Student student = null)
        {

            validStudent = student == null ? new ValidStudent()
            {
                Id = Guid.NewGuid(),
            } : new ValidStudent
            {
                Id = student.Id,
                Name = student.Name,
                Gender = student.Gender,
                BirthDay = student.BirthDay,
                Education = student.Education,
                MathScores = student.MathScores,
                ITScores = student.ITScores,
                RusScores = student.RusScores,
            };
            InitializeComponent();

            com_gender.AddEnumSourse(validStudent.Gender);
            com_educationForm.AddEnumSourse(validStudent.Education);
            com_gender.SelectedIndex = 0;

            txt_name.AddBinding(x => x.Text, validStudent, x => x.Name, errorProvider1);
            com_gender.AddBinding(x => x.SelectedValue, validStudent, x => x.Gender);
            com_educationForm.AddBinding(x => x.SelectedValue, validStudent, x => x.Education);
            txt_Math.AddBinding(x => x.Text, validStudent, x => x.MathScores, errorProvider1);
            txt_Rus.AddBinding(x => x.Text, validStudent, x => x.RusScores, errorProvider1);
            txt_IT.AddBinding(x => x.Text, validStudent, x => x.ITScores, errorProvider1);
            date_birtyDay.AddBinding(x => x.Value, validStudent, x => x.BirthDay);

        }

        private void but_accept_Click(object sender, System.EventArgs e)
        {
            var context = new ValidationContext(validStudent);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(validStudent, context, results, validateAllProperties: true);

            if (!isValid)
            {
                return;
            }

            student = new Student()
            {
                Id = validStudent.Id,
                Name = validStudent.Name,
                Gender = validStudent.Gender,
                BirthDay = validStudent.BirthDay,
                Education = validStudent.Education,
                MathScores = validStudent.MathScores,
                ITScores = validStudent.ITScores,
                RusScores = validStudent.RusScores,
            };
            DialogResult = DialogResult.OK;
        }
    }
}
