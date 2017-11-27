using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Test
{
    public partial class TransparentForm : Form
    {
        public static TransparentForm transparent { get; set; }
        public static TransparentForm waitForm { get; set; }
        //private static Thread t;
        public static Form parent { get; set; }

        public TransparentForm()
        {
            InitializeComponent();
        }

        public static TransparentForm Get()
        {
            if (transparent == null)
            {
                transparent = new TransparentForm();
            }
            return transparent;
        }

        public static void Wait()
        {
            if (waitForm == null)
            {
                waitForm = new TransparentForm();
                waitForm.pictureBox1.Visible = true;
                bool formOpen = false;
                foreach(Form frm in Application.OpenForms)
                {
                    if (frm == waitForm)
                    {
                        formOpen = true;
                    }
                }
                if (!formOpen)
                {
                    waitForm.ShowDialog();
                }
                waitForm.pictureBox1.Visible = false;
            }
        }

        public static void Reset()
        {
            transparent = null;
            waitForm = null;
        }

        public void Delete()
        {
            transparent = null;
            waitForm = null;
        }

        private void TransparentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (parent != null)
            {
                parent.Activate();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
        }
    }
}
