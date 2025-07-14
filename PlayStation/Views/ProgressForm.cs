using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlayStation.Views
{
    public partial class ProgressForm : Form
    {
        private Form parentForm = null;
        public ProgressForm(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        public void StartDisplay(string title, string progressText)
        {
            this.Text = title;
            lblProgressText.Text = progressText;
            parentForm.UseWaitCursor = true;
            ShowDialog();
        }

        public void StopDisplay()
        {
            parentForm.UseWaitCursor = false;
            Hide();
        }
    }
}
