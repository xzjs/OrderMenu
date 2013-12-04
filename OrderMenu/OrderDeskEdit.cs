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
        public OrderDeskEdit()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (var dc = new DataClassesDataContext())
            {
                var query=from m in dc.Desk
                          where m.ID in
            }
        }
    }
}
