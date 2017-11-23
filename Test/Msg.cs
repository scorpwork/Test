using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Msg : Form
    {
        private static TransparentForm msgTransporent { get; set; }
        private static Form parentForm { get; set; }
        public Msg()
        {
            InitializeComponent();
        }

        public static void Show(Form parent, string header, string text)
        {
            parentForm = parent;
            msgTransporent = new TransparentForm();
            msgTransporent.Show();
            Msg msg = new Msg();
            msg.SetTopLevel(true);
            msg.headerLabel.Text = header;
            msg.textLabel.Text = text;
            msg.ShowDialog();
        }

        private void Msg_FormClosed(object sender, FormClosedEventArgs e)
        {
            msgTransporent.Close();
            parentForm.Activate();
        }

        private void closeBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
