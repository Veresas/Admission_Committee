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
            InitializeComponent();
        }
    }
}
