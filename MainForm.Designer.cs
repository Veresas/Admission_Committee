﻿namespace Admission_Committee
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddBut = new System.Windows.Forms.ToolStripButton();
            this.EditBut = new System.Windows.Forms.ToolStripButton();
            this.DeletBut = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.AllStudentsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.StudentWithEnoughScoresStats = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EducationForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoresMath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoresRus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoresIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumScores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1026, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBut,
            this.EditBut,
            this.DeletBut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1026, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddBut
            // 
            this.AddBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddBut.Image = ((System.Drawing.Image)(resources.GetObject("AddBut.Image")));
            this.AddBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddBut.Name = "AddBut";
            this.AddBut.Size = new System.Drawing.Size(29, 24);
            this.AddBut.Text = "toolStripButton1";
            // 
            // EditBut
            // 
            this.EditBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditBut.Image = ((System.Drawing.Image)(resources.GetObject("EditBut.Image")));
            this.EditBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditBut.Name = "EditBut";
            this.EditBut.Size = new System.Drawing.Size(29, 24);
            this.EditBut.Text = "toolStripButton2";
            // 
            // DeletBut
            // 
            this.DeletBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeletBut.Image = ((System.Drawing.Image)(resources.GetObject("DeletBut.Image")));
            this.DeletBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeletBut.Name = "DeletBut";
            this.DeletBut.Size = new System.Drawing.Size(29, 24);
            this.DeletBut.Text = "toolStripButton3";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AllStudentsStatus,
            this.StudentWithEnoughScoresStats});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1026, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // AllStudentsStatus
            // 
            this.AllStudentsStatus.Name = "AllStudentsStatus";
            this.AllStudentsStatus.Size = new System.Drawing.Size(116, 20);
            this.AllStudentsStatus.Text = "AllStudentsStats";
            this.AllStudentsStatus.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // StudentWithEnoughScoresStats
            // 
            this.StudentWithEnoughScoresStats.Name = "StudentWithEnoughScoresStats";
            this.StudentWithEnoughScoresStats.Size = new System.Drawing.Size(102, 20);
            this.StudentWithEnoughScoresStats.Text = "EnoughScores";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentName,
            this.Gender,
            this.BirthDay,
            this.EducationForm,
            this.ScoresMath,
            this.ScoresRus,
            this.ScoresIT,
            this.SumScores});
            this.dataGridView1.Location = new System.Drawing.Point(0, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1026, 363);
            this.dataGridView1.TabIndex = 3;
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "ФИО";
            this.StudentName.MinimumWidth = 6;
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            this.StudentName.Width = 125;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Пол";
            this.Gender.MinimumWidth = 6;
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Width = 125;
            // 
            // BirthDay
            // 
            this.BirthDay.HeaderText = "Дата рождения";
            this.BirthDay.MinimumWidth = 6;
            this.BirthDay.Name = "BirthDay";
            this.BirthDay.ReadOnly = true;
            this.BirthDay.Width = 125;
            // 
            // EducationForm
            // 
            this.EducationForm.HeaderText = "Форма обученя";
            this.EducationForm.MinimumWidth = 6;
            this.EducationForm.Name = "EducationForm";
            this.EducationForm.ReadOnly = true;
            this.EducationForm.Width = 125;
            // 
            // ScoresMath
            // 
            this.ScoresMath.HeaderText = "Баллы по математике";
            this.ScoresMath.MinimumWidth = 6;
            this.ScoresMath.Name = "ScoresMath";
            this.ScoresMath.ReadOnly = true;
            this.ScoresMath.Width = 125;
            // 
            // ScoresRus
            // 
            this.ScoresRus.HeaderText = "Баллы по русскому";
            this.ScoresRus.MinimumWidth = 6;
            this.ScoresRus.Name = "ScoresRus";
            this.ScoresRus.ReadOnly = true;
            this.ScoresRus.Width = 125;
            // 
            // ScoresIT
            // 
            this.ScoresIT.HeaderText = "Баллы по информатике";
            this.ScoresIT.MinimumWidth = 6;
            this.ScoresIT.Name = "ScoresIT";
            this.ScoresIT.ReadOnly = true;
            this.ScoresIT.Width = 125;
            // 
            // SumScores
            // 
            this.SumScores.HeaderText = "Всего баллов";
            this.SumScores.MinimumWidth = 6;
            this.SumScores.Name = "SumScores";
            this.SumScores.ReadOnly = true;
            this.SumScores.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Приемная комиссия";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddBut;
        private System.Windows.Forms.ToolStripButton EditBut;
        private System.Windows.Forms.ToolStripButton DeletBut;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel AllStudentsStatus;
        private System.Windows.Forms.ToolStripStatusLabel StudentWithEnoughScoresStats;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn EducationForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoresMath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoresRus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoresIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumScores;
    }
}
