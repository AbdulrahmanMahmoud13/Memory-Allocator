using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Memory_Allocator
{
    public partial class Memory : Form
    {
        public Memory()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void Memory_FormClosed(object sender, FormClosedEventArgs e)
        {
            MemAllc.showed = 0;
        }


    }
}