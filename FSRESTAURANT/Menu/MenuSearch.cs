using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FS_REST
{
    public partial class searchMenu : Form
    {
        EventChanging ChangingEvent;
        FSRESTAURANT.MENU_HEADERDataTable masterMenu;
        public searchMenu( EventChanging ChangingEvent)
        {
            InitializeComponent();
            this.ChangingEvent = ChangingEvent;
            masterMenu = ChangingEvent.masterMenu;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {//nama menu untuk mendapatkan id menu dan menampilkan harga&deskripsi di textbox melalui table
            foreach (DataRow item in masterMenu.Rows)
            {
                if (item[2].ToString() == comboBox1.GetItemText(comboBox1.SelectedItem))
                {
                    textBox1.Text = item[3].ToString();
                    //textBox2.Text=
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {//OK
            ChangingEvent.setMenuName(comboBox1.GetItemText(comboBox1.SelectedItem));
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {//cancel
            this.Close();
        }

        private void searchMenu_Load(object sender, EventArgs e)
        {
            foreach (DataRow item in masterMenu.Rows)
            {
                comboBox1.Items.Add(item[2]);
            }
        }
    }
}
