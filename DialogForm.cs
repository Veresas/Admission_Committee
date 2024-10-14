using Framework.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admission_Committee
{
    public partial class DialogForm : Form
    {
        private Student student;
        public DialogForm(Student student = null)
        {
            this.student = new Student
            {
                Id = student.Id,
                Name = student.Name,
                Gender = student.Gender,
                BirthDay = student.BirthDay,
                Education = student.Education,
                ExamReslt = student.ExamReslt,
            };

            InitializeComponent();

            com_gender.AddEnumSourse(student.Gender);
            com_educationForm.AddEnumSourse(student.Education);

            txt_name.AddBinding(x => x.Text, this.student, x => x.Name, errorProvider1);
            com_gender.AddBinding(x => x.SelectedItem, this.student, x => x.Gender, errorProvider1);
            com_educationForm.AddBinding(x => x.SelectedItem, this.student, x => x.Education, errorProvider1);
            txt_Math.AddBinding(x => x.Text, this.student, x => x.ExamReslt.FirstOrDefault(v => v.Key == "Math"), errorProvider1);
            txt_Rus.AddBinding(x => x.Text, this.student, x => x.ExamReslt.FirstOrDefault(v => v.Key == "Rus"), errorProvider1);
            txt_IT.AddBinding(x => x.Text, this.student, x => x.ExamReslt.FirstOrDefault(v => v.Key == "IT"), errorProvider1);
            date_birtyDay.AddBinding(x => x.Value, this.student, x => x.BirthDay, errorProvider1);
        }
    }
}
