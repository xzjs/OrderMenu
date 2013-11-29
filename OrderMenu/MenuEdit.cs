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
            menu = m;
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

        private void button1_Click(object sender, EventArgs e)
        {
            menu.Name = textBox1.Text;
            menu.Price =Convert.ToDouble( textBox2.Text);
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
    }
}
