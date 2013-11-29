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
    public partial class WorkerEdit : Form
    {
        public Worker worker;

        public WorkerEdit(Worker w=null)
        {
            InitializeComponent();
            worker = w;
            if (worker == null)
            {
                button2.Enabled = false;
                worker = new Worker();
            }
            else
            {
                textBox1.Text = worker.Name.ToString();
                comboBox1.SelectedItem = worker.Profession;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                worker.Pwd = DataHelper.md5("1");
                MessageBox.Show("密码初始化为1");
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            worker.Name = textBox1.Text;
            worker.Profession = comboBox1.SelectedItem.ToString();
            BasicOperation<Worker> bow = new BasicOperation<Worker>();
            if (worker.ID == 0)
            {
                if (bow.Add(worker))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
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
}
