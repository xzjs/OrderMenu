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
    public partial class MenuList : Form
    {
        private DataClassesDataContext dc = new DataClassesDataContext();
        BasicOperation<OrderDesk> bood = new BasicOperation<OrderDesk>();
        OrderDesk od = new OrderDesk();
        private int ID;

        public MenuList(int id)
        {
            InitializeComponent();
            ID = id;
            var query = from n in dc.DeskMenu
                        where (n.OrderDeskID == id) && (n.Status == "已上")
                        select new
                        {
                            n.ID,
                            n.Menu.Name,
                            n.Menu.Price
                        };
            dataGridView1.DataSource = query;
            double? total = 0;
            foreach (var item in query)
            {
                total += item.Price;
            }
            label2.Text = total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            od.ID = ID;
            if (bood.Delete(od))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }
    }
}
