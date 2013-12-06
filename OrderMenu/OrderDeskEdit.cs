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
    public partial class OrderDeskEdit : Form
    {
        public int id = 0;

        public OrderDeskEdit()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                using (var dc = new DataClassesDataContext())
                {
                    var query = from m in dc.Desk
                                where (!(from n in dc.OrderDesk
                                         where n.Time != comboBox1.SelectedItem.ToString()
                                         select n.DeskID).Contains(m.ID)) && (m.Num >= numericUpDown1.Value) && (m.Room.Specification == comboBox2.SelectedItem.ToString())
                                select new
                                {
                                    m.ID,
                                    m.Num,
                                    m.Room.Name
                                };
                    dataGridView1.DataSource = query.ToList();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    if (id != 0)
                    {
                        BasicOperation<OrderDesk> bood = new BasicOperation<OrderDesk>();
                        OrderDesk od = new OrderDesk();
                        od.Time = comboBox1.SelectedItem.ToString();
                        od.DeskID = id;
                        od.ClientName = textBox1.Text;
                        od.ClientPhone = textBox2.Text;
                        if (bood.Add(od))
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
                        MessageBox.Show("请选择桌号");
                    }
                }
                else
                {
                    MessageBox.Show("请填写客户电话");
                }
            }
            else
            {
                MessageBox.Show("请填写客户名");
            }
        }
    }
}
