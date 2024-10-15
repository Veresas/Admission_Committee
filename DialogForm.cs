﻿using Framework.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Admission_Committee
{
    public partial class DialogForm : Form
    {
        private Student student;
        /// <summary>
        /// Передача объекта студента, над которым проводились манипуляции
        /// </summary>
        public Student Student => student;
        /// <summary>
        /// Конструктор получает объект студента (или устаналивает null). При null создает пустой объект студена, иначе заполняет поля значенийми
        /// </summary>
        /// <param name="student"></param>
        public DialogForm(Student student = null)
        {

            this.student = student == null ? new Student() : new Student
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

            com_gender.AddEnumSourse(this.student.Gender);
            com_educationForm.AddEnumSourse(this.student.Education);
            com_gender.SelectedIndex = 0;

            txt_name.AddBinding(x => x.Text, this.student, x => x.Name, errorProvider1);
            com_gender.AddBinding(x => x.SelectedValue, this.student, x => x.Gender, errorProvider1);
            com_educationForm.AddBinding(x => x.SelectedValue, this.student, x => x.Education, errorProvider1);
            txt_Math.AddBinding(x => x.Text, this.student, x => x.MathScores, errorProvider1);
            txt_Rus.AddBinding(x => x.Text, this.student, x => x.RusScores, errorProvider1);
            txt_IT.AddBinding(x => x.Text, this.student, x => x.ITScores, errorProvider1);
            date_birtyDay.AddBinding(x => x.Value, this.student, x => x.BirthDay, errorProvider1);

        }

    }
}
