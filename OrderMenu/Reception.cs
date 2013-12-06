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

        public Reception(Worker w)
        {
            InitializeComponent();
            dgvDataBind();
            worker = w;
        }

        public void dgvDataBind()
        {
            BasicOperation<OrderDesk> bood=new BasicOperation<OrderDesk>();
            OrderDesk od=new OrderDesk();
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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperation<OrderDesk> bood = new BasicOperation<OrderDesk>();
            OrderDesk od = new OrderDesk();
            od.ID = id;
            od = bood.Select(od).SingleOrDefault();
            if (bood.Delete(od))
            {
                dgvDataBind();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PwdEdit pw = new PwdEdit(worker);
            pw.ShowDialog();
        }

        private void PayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuList ml = new MenuList(id);
            ml.ShowDialog();
        }  
    }
}
