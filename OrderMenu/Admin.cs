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
    public partial class Admin : Form
    {
        public Worker worker = new Worker();
        public int id;

        public Admin(Worker w)
        {
            InitializeComponent();
            worker = w;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“orderDBDataSet2.Menu”中。您可以根据需要移动或删除它。
            this.menuTableAdapter.Fill(this.orderDBDataSet2.Menu);
            // TODO: 这行代码将数据加载到表“orderDBDataSet.Worker”中。您可以根据需要移动或删除它。
            this.workerTableAdapter.Fill(this.orderDBDataSet.Worker);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = WorkerHelper.Vlookup(textBox1.Text);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            WorkerEdit we = new WorkerEdit();
            we.ShowDialog();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperation<Worker> bow=new BasicOperation<Worker>();
            Worker w=new Worker();
            w.ID=id;
            w=bow.Select(w).SingleOrDefault();
            WorkerEdit we = new WorkerEdit(w);
            we.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void AddMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEdit me = new MenuEdit();
            me.ShowDialog();
        }

        private void UpdateMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DeleteWorkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperation<Worker> bow = new BasicOperation<Worker>();
            Worker w = new Worker();
            w.ID = id;
            w = bow.Select(w).SingleOrDefault();
            if (bow.Delete(w))
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

    }
}
