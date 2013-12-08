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
    public partial class Waiter : Form
    {
        public int id;
        private Worker worker;
        private DeskMenu dm = new DeskMenu();
        private Menu m = new Menu();
        private BasicOperation<DeskMenu> bodm = new BasicOperation<DeskMenu>();
        private BasicOperation<Menu> bom = new BasicOperation<OrderMenu.Menu>();
        private DataClassesDataContext dc = new DataClassesDataContext();
        private DataGridViewCellEventArgs dgvcea = new DataGridViewCellEventArgs(0, 0);

        public Waiter(Worker w)
        {
            InitializeComponent();
            cb1_databind();
            cb2_databind();
            dgv_databind();
            worker = w;
            this.Text += w.Name;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            int i = cb1_databind();
            if (i > 0)
            {
                comboBox1.DroppedDown = true;
            }
        }

        public int cb1_databind()
        {
            var query = from n in dc.Menu
                        where n.Name.Contains(comboBox1.Text)
                        select n.Name;
            comboBox1.DataSource = query;
            return query.Count();
        }

        public void cb2_databind()
        {
            var query = from n in dc.OrderDesk
                        select n.DeskID;
            comboBox2.DataSource = query;
        }

        public void dgv_databind()
        {
            var query = from n in dc.DeskMenu
                        where n.DeskID == Convert.ToInt32(comboBox2.SelectedItem)
                        select new
                        {
                            n.ID,
                            n.Menu.Name,
                            n.Status
                        };
            dataGridView1.DataSource = query;
            dataGridView1.Columns[0].HeaderText = "编号";
            dataGridView1.Columns[1].HeaderText = "菜名";
            dataGridView1.Columns[2].HeaderText = "状态";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_databind();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dm.MenuID = bom.Vlookup(m, comboBox1.SelectedItem.ToString()).SingleOrDefault().ID;
            dm.DeskID = Convert.ToInt32(comboBox2.SelectedItem);
            dm.WorkerID = worker.ID;
            dm.Status = "未上";
            dm.CookStatus = "已上";
            List<int?> li = (from n in dc.WorkerMenu
                             where n.MenuID == dm.MenuID
                             select n.WorkerID).ToList();
            if (li.Count() > 0)
            {
                Random r = new Random();
                dm.CookID = li.ElementAt(r.Next(li.Count()));
                if (bodm.Add(dm))
                {
                    dgv_databind();
                    dm = new DeskMenu();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
                MessageBox.Show("当前没有厨师会做此菜");
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkDgvClick();
            dm.ID = id;
            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() != "已上")
            {
                if (bodm.Delete(dm))
                {
                    dgv_databind();
                }
                else
                {
                    MessageBox.Show("退订失败");
                    dm = new DeskMenu();
                }
            }
            else
            {
                MessageBox.Show("已上菜不可退");
            }
        }

        private void servingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkDgvClick();
            dm.ID = id;
            dm = bodm.Select(dm).SingleOrDefault();
            dm.Status = "已上";
            if (bodm.Update(dm))
            {
                dgv_databind();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PwdEdit pe = new PwdEdit(worker);
            pe.ShowDialog();
        }

        public void checkDgvClick()
        {
            if (id == 0)
            {
                dataGridView1_CellClick(1, dgvcea);
            }
        }
    }
}
