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
    public partial class Reception : Form
    {
        public int id;
        public Worker worker;
        private DataGridViewCellEventArgs dgvce;
        private DataClassesDataContext dc = new DataClassesDataContext();

        public Reception(Worker w)
        {
            InitializeComponent();
            dgvDataBind();
            worker = w;
            this.Text += w.Name;
        }

        public void dgvDataBind()
        {
            BasicOperation<OrderDesk> bood = new BasicOperation<OrderDesk>();
            OrderDesk od = new OrderDesk();
            dataGridView1.DataSource = bood.Select(od);
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[0].HeaderText = "编号";
            dataGridView1.Columns[1].HeaderText = "桌号";
            dataGridView1.Columns[2].HeaderText = "订餐时间";
            dataGridView1.Columns[3].HeaderText = "客户名称";
            dataGridView1.Columns[4].HeaderText = "客户电话";
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderDeskEdit ode = new OrderDeskEdit();
            ode.ShowDialog();
            dgvDataBind();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperation<OrderDesk> bood = new BasicOperation<OrderDesk>();
            OrderDesk od = new OrderDesk();
            dataGridView1_CellClick(1, dgvce);
            od.ID = id;
            od = bood.Select(od).SingleOrDefault();
            if (id == 0)
            {
                MessageBox.Show("请选择退订项目");
            }
            else if ((from m in dc.DeskMenu
                      where m.OrderDeskID == od.ID
                      select m).Count() == 0)
            {
                if (bood.Delete(od))
                {
                    dgvDataBind();
                    od = new OrderDesk();
                    id = 0;
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            else
            {
                MessageBox.Show("已上菜，不可退订");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PwdEdit pw = new PwdEdit(worker);
            pw.ShowDialog();
        }

        private void PayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1_CellClick(1, dgvce);
            if (id > 0)
            {
                MenuList ml = new MenuList(id);
                ml.ShowDialog();
                dgvDataBind();
            }
        }
    }
}
