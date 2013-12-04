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
        public Reception(Worker w)
        {
            InitializeComponent();
            dgvDataBind();
        }

        public void dgvDataBind()
        {
            BasicOperation<OrderDesk> bood=new BasicOperation<OrderDesk>();
            OrderDesk od=new OrderDesk();
            dataGridView1.DataSource = bood.Select(od);
        }
    }
}
