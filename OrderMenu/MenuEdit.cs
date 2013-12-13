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
    public partial class MenuEdit : Form
    {
        public Menu menu;

        public MenuEdit(Menu m=null)
        {
            InitializeComponent();
            try
            {
                menu = m;
                using (var dc = new DataClassesDataContext())
                {
                    var query = from n in dc.Menu
                                group n by n.Style;
                    List<string> l = new List<string>();
                    foreach (var item in query)
                    {
                        l.Add(item.Key);
                    }
                    comboBox1.DataSource = l;
                }
                if (menu == null)
                {
                    menu = new Menu();
                }
                else
                {
                    textBox1.Text = menu.Name;
                    textBox2.Text = menu.Price.ToString();
                    
                    comboBox1.SelectedItem = menu.Style;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu.Name = textBox1.Text;
            menu.Price =Convert.ToDecimal( textBox2.Text);
            if (comboBox1.Text != null)
            {
                menu.Style = comboBox1.Text;
            }
            else
            {
                menu.Style = comboBox1.SelectedItem.ToString();
            }
            BasicOperation<Menu> bom = new BasicOperation<Menu>();
            if (menu.ID == 0)
            {
                if (bom.Add(menu))
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
                if (bom.Update(menu))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
        }

        private void MenuEdit_Load(object sender, EventArgs e)
        {
            

        }

        
    }
}
