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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox2.Text)
            {
                MessageBox.Show("两次输入的密码不一致");
            }
            else
            {
                button1.Enabled = true;
            }
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
    }
}
