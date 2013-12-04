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
    public partial class DeskEdit : Form
    {
        public Desk desk;

        public DeskEdit(Desk d = null)
        {
            InitializeComponent();
            desk = d;
            using (var dc = new DataClassesDataContext())
            {
                var query = (from n in dc.Room
                             select n.ID).ToList();
                comboBox1.DataSource = query;
            }
            if (desk == null)
            {
                desk = new Desk();
            }
            else
            {
                //textBox1.Text = desk.Num.ToString();
                numericUpDown1.Value = Convert.ToDecimal(desk.Num);
                comboBox1.SelectedItem = desk.RoomID;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            desk.RoomID = Convert.ToInt32(comboBox1.SelectedItem);
            desk.Num = Convert.ToInt32(numericUpDown1.Value);
            BasicOperation<Desk> bod = new BasicOperation<Desk>();
            if (desk.ID == 0)
            {
                if (bod.Add(desk))
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
                if (bod.Update(desk))
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
