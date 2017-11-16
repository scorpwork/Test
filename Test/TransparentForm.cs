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
    public partial class TransparentForm : Form
    {
        public static TransparentForm transparent { get; set; }

        /*~TransparentForm()
        {
            transparent = null;
        }*/

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

        public void Delete()
        {
            transparent = null;
        }


    }
}
