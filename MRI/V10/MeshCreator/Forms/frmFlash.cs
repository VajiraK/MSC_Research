using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MeshCreator
{
    public partial class frmFlash : Form
    {
        private int m_count = 0;
        //---------------------------------------------------------------------------
        public frmFlash()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------------
        public void UpdateDisplay(string t)
        {
            m_count++;
            if ((m_count%5)==0)
            {
                lblNum.Text = t;
                Application.DoEvents();
            }
            
        }
        //---------------------------------------------------------------------------
        private void frmFlash_Load(object sender, EventArgs e)
        {

        }
    }
}
