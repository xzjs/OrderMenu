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

        private void button1_Click(object sender, EventArgs e)
        {
            BasicOperation<Worker> bow = new BasicOperation<Worker>();
            worker.Pwd = DataHelper.md5(textBox2.Text);
            if (bow.Update(worker))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
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
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
