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
    public partial class RoomEdit : Form
    {
        public Room room;

        public RoomEdit(Room r=null)
        {
            InitializeComponent();
            room = r;
            if(room == null)
            {
                room=new Room();
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                textBox1.Text = room.Name;
                comboBox1.SelectedItem = room.Specification;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            room.Name = textBox1.Text;
            room.Specification = comboBox1.SelectedItem.ToString();
            BasicOperation<Room> bor = new BasicOperation<Room>();
            if (room.ID == 0)
            {
                if (bor.Add(room))
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
                if (bor.Update(room))
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
