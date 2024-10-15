using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.Contracts.Interfaces;
using Framework.Contracts.Models;

namespace Admission_Committee
{
    public partial class MainForm : Form
    {
        private IStudentManager studentManager;
        private BindingSource bindingSource;
        /// <summary>
        /// Принимает управляющий класс, настривает привязку данных
        /// </summary>
        /// <param name="studentManager"></param>
        public MainForm(IStudentManager studentManager)
        {
            this.studentManager = studentManager;
            bindingSource = new BindingSource();
            InitializeComponent();

            DG_students.AutoGenerateColumns = false;
            DG_students.DataSource = bindingSource;

            DG_students.DataError += DG_students_DataError;
        }

        private void DG_students_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Отображение сообщения об ошибке
            MessageBox.Show($"Ошибка в строке {e.RowIndex + 1}, колонке {e.ColumnIndex + 1}.\nСообщение: {e.Exception.Message}", "Ошибка в DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false; // Предотвращаем выброс исключения
        }
        private async void AddBut_Click(object sender, EventArgs e)
        {
            var addForm = new DialogForm();

            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                await studentManager.Add(addForm.Student);
                bindingSource.ResetBindings(false);
                await SetStats();
            }
        }


        private async Task SetStats()
        {
            var result = await studentManager.GetStats();
            AllStudentsStatus.Text = $"Всего абетуриентов: {result.AllStudent}";
            StudentWithEnoughScoresStats.Text = $"Всего абетуриентов с суммой баллов больше 150: {result.StudentWithEnoughScores}";

        }

        private async void EditBut_Click(object sender, EventArgs e)
        {
            if (DG_students.SelectedRows.Count != 0)
            {
                var data = (Student)DG_students.Rows[DG_students.SelectedRows[0].Index].DataBoundItem;
                var editForm = new DialogForm(data);
                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                    await studentManager.Edit(editForm.Student);
                    bindingSource.ResetBindings(false);
                    await SetStats();
                }
            }
        }

        private async void DeletBut_Click(object sender, EventArgs e)
        {
            if (DG_students.SelectedRows.Count != 0)
            {
                var data = (Student)DG_students.Rows[DG_students.SelectedRows[0].Index].DataBoundItem;
                if (MessageBox.Show($"Вы действительно хотите удалить {data.Name}?", "Удаление записи", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await studentManager.Delete(data.Id);
                    bindingSource.ResetBindings(false);
                    await SetStats();
                }
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = await studentManager.GetAll();
            await SetStats();
        }

        private void DG_students_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DG_students.Columns[e.ColumnIndex].Name == "Gender")
            {
                var data = (Student)DG_students.Rows[e.RowIndex].DataBoundItem;
                var gender = data.Gender;

                e.Value = GetEnumDescription(gender);
            }

            if (DG_students.Columns[e.ColumnIndex].Name == "EducationForm")
            {
                var data = (Student)DG_students.Rows[e.RowIndex].DataBoundItem;
                var Education = data.Education;

                e.Value = GetEnumDescription(Education);
            }
        }

        private static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                 .FirstOrDefault() as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
