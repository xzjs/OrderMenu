using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrderMenu
{
    public partial class PwdEdit : Form
    {
        public Worker worker;
        public PwdEdit(Worker w)
        {
            InitializeComponent();
            worker = w;
            label2.Text = w.ID.ToString();
            label4.Text = w.Name;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (DataHelper.md5(textBox1.Text) == worker.Pwd)
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
            else
            {
                MessageBox.Show("原密码错误");
            }
        }
    }
}
