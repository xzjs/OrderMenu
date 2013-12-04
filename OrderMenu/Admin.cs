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
        public string radioselect;

        public Admin(Worker w)
        {
            InitializeComponent();
            worker = w;
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (radioselect)
            {
                case "成员管理":
                    BasicOperation<Worker> bow = new BasicOperation<Worker>();
                    Worker w = new Worker();
                    dataGridView1.DataSource = bow.Vlookup(w, textBox1.Text);
                    break;
                case "菜单管理":
                    BasicOperation<Menu> bom = new BasicOperation<Menu>();
                    Menu m = new Menu();
                    dataGridView1.DataSource = bom.Vlookup(m, textBox1.Text);
                    break;
                case "房间管理":
                    BasicOperation<Room> bor = new BasicOperation<Room>();
                    Room r = new Room();
                    dataGridView1.DataSource = bor.Vlookup(r, textBox1.Text);
                    break;
                case "餐桌管理":
                    BasicOperation<Desk> bod = new BasicOperation<Desk>();
                    Desk d = new Desk();
                    List<Desk> ld=bod.Vlookup(d, textBox1.Text);
                    break;
                default:
                    break;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            switch (radioselect)
            {
                case "成员管理":
                    WorkerEdit we = new WorkerEdit();
                    we.ShowDialog();
                    break;
                case "菜单管理":
                    MenuEdit me = new MenuEdit();
                    me.ShowDialog();
                    break;
                case "房间管理":
                    RoomEdit re = new RoomEdit();
                    re.ShowDialog();
                    break;
                case "餐桌管理":
                    DeskEdit de = new DeskEdit();
                    de.ShowDialog();
                    break;
                default:
                    break;
            }

        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (radioselect)
            {
                case "成员管理":
                    BasicOperation<Worker> bow = new BasicOperation<Worker>();
                    Worker w = new Worker();
                    w.ID = id;
                    w = bow.Select(w).SingleOrDefault();
                    WorkerEdit we = new WorkerEdit(w);
                    we.ShowDialog();
                    break;
                case "菜单管理":
                    BasicOperation<Menu> bom = new BasicOperation<Menu>();
                    Menu m = new Menu();
                    m.ID = id;
                    m = bom.Select(m).SingleOrDefault();
                    MenuEdit me = new MenuEdit(m);
                    me.ShowDialog();
                    break;
                case "房间管理":
                    BasicOperation<Room> bor = new BasicOperation<Room>();
                    Room r = new Room();
                    r.ID = id;
                    r = bor.Select(r).SingleOrDefault();
                    RoomEdit re = new RoomEdit(r);
                    re.ShowDialog();
                    break;
                case "餐桌管理":
                    BasicOperation<Desk> bod = new BasicOperation<Desk>();
                    Desk d = new Desk();
                    d.ID = id;
                    d = bod.Select(d).SingleOrDefault();
                    DeskEdit de = new DeskEdit(d);
                    de.ShowDialog();
                    break;
                default:
                    break;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
        }

        private void DeleteWorkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (radioselect)
            {
                case "成员管理":
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
                    break;
                case "菜单管理":
                    BasicOperation<Menu> bom = new BasicOperation<Menu>();
                    Menu m = new Menu();
                    m.ID = id;
                    m = bom.Select(m).SingleOrDefault();
                    if (bom.Delete(m))
                    {
                        MessageBox.Show("删除成功");
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                    break;
                case "房间管理":
                    BasicOperation<Room> bor = new BasicOperation<Room>();
                    Room r = new Room();
                    r.ID = id;
                    r = bor.Select(r).SingleOrDefault();
                    if (bor.Delete(r))
                    {
                        MessageBox.Show("删除成功");
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                    break;
                case "餐桌管理":
                    BasicOperation<Desk> bod = new BasicOperation<Desk>();
                    Desk d = new Desk();
                    d.ID = id;
                    d = bod.Select(d).SingleOrDefault();
                    if (bod.Delete(d))
                    {
                        MessageBox.Show("删除成功");
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                    break;
                default:
                    break;
            }

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                radioselect = rb.Text;
                EventArgs i = new EventArgs();
                button1_Click(1, i);
            }
        }

        private void DataGridViewHeader()
        {
            switch (radioselect)
            {
                case "成员管理":
                    dataGridView1.Columns[0].HeaderText = "员工号";
                    dataGridView1.Columns[1].HeaderText = "姓名";
                    dataGridView1.Columns[2].HeaderText = "职务";
                    break;
                case "菜单管理":
                    dataGridView1.Columns[0].HeaderText = "菜编号";
                    dataGridView1.Columns[1].HeaderText = "菜名";
                    dataGridView1.Columns[2].HeaderText = "价格";
                    dataGridView1.Columns[3].HeaderText = "菜系";
                    break;
                case "房间管理":
                    dataGridView1.Columns[0].HeaderText = "房间号";
                    dataGridView1.Columns[1].HeaderText = "房间名";
                    dataGridView1.Columns[2].HeaderText = "房间规格";
                    break;
                case "餐桌管理":
                    dataGridView1.Columns[0].HeaderText = "桌号";
                    dataGridView1.Columns[1].HeaderText = "房间";
                    dataGridView1.Columns[2].HeaderText = "人数";
                    dataGridView1.Columns[3].HeaderText = "服务员";
                    break;
                default:
                    break;
            }
        }
    }
}
