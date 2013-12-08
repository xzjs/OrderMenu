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
    public partial class Cook : Form
    {
        private Worker worker = new Worker();
        private DataClassesDataContext dc = new DataClassesDataContext();
        private BasicOperation<WorkerMenu> bowm = new BasicOperation<WorkerMenu>();
        private WorkerMenu wm = new WorkerMenu();
        private BasicOperation<Menu> bom = new BasicOperation<Menu>();
        private Menu m = new Menu();
        private BasicOperation<DeskMenu> bodm = new BasicOperation<DeskMenu>();
        private DeskMenu dm = new DeskMenu();

        public Cook(Worker w)
        {
            InitializeComponent();
            worker = w;
            InitListBox();
            this.Text += w.Name;
            dgvBind();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PwdEdit pe = new PwdEdit(worker);
            pe.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wm.MenuID = bom.Vlookup(m, listBox1.SelectedItem.ToString()).SingleOrDefault().ID;
            wm.WorkerID = worker.ID;
            if (bowm.Add(wm))
            {
                InitListBox();
                wm = new WorkerMenu();
            }
            else
            {
                MessageBox.Show("添加错误");
            }
        }

        public void InitListBox()
        {
            var query = (from n in dc.WorkerMenu
                         where n.WorkerID == worker.ID
                         select n.Menu.Name).ToList();
            var query1 = from n in dc.Menu
                         where !(query.Contains(n.Name))
                         select n.Name;
            listBox1.DataSource = query1;
            listBox2.DataSource = query;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wm.ID = (from n in dc.WorkerMenu
                     where n.Menu.Name == listBox2.SelectedItem.ToString()
                     select n.ID).SingleOrDefault();
            if (bowm.Delete(wm))
            {
                InitListBox();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        public void dgvBind()
        {
            dataGridView1.DataSource = from n in dc.DeskMenu
                                       where (n.CookID == worker.ID) && (n.CookStatus == "未做")
                                       select new
                                       {
                                           n.ID,
                                           n.Menu.Name,
                                           n.CookStatus
                                       };
            dataGridView1.Columns[0].HeaderText = "编号";
            dataGridView1.Columns[1].HeaderText = "菜名";
            dataGridView1.Columns[2].HeaderText = "状态";
        }

        private void completeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            dm.ID=id;
            dm = bodm.Select(dm).SingleOrDefault();
            dm.CookStatus = "已做";
            if (bodm.Update(dm))
            {
                dgvBind();
                dm = new DeskMenu();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
    }
}
