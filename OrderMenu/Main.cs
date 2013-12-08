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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BasicOperation<Worker> bow = new BasicOperation<Worker>();
                Worker w = new Worker();
                w.ID = Convert.ToInt32(textBox1.Text);
                w = bow.Select(w).First();

                if (w.Pwd == DataHelper.md5(textBox2.Text))
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    switch (w.Profession)
                    {
                        case "厨师":
                            Cook c = new Cook(w);
                            c.ShowDialog();
                            break;
                        case "服务员":
                            Waiter wa = new Waiter(w);
                            wa.ShowDialog();
                            break;
                        case "管理员":
                            Admin a = new Admin(w);
                            a.ShowDialog();
                            break;
                        case "前台":
                            Reception r = new Reception(w);
                            r.ShowDialog();
                            break;
                        default:
                            return;
                    }
                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("用户名错误");
            }
            
            
        }
    }
}
