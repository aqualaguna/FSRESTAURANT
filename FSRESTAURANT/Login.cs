using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace FS_REST
{
    public partial class Login : Form
    {
       
        public static Login tis;
        public Login()
        {
            InitializeComponent();
            tis = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();
            
            var r = MainForm.FS.PEGAWAI_RESTAURANT.Where(x => x.USER_NAMA == tbUsername.Text && x.USER_PASSWORD == tbPass.Text).ToArray();
            int dr = r.Count();
            if(dr==1)
            {
                m.setPegawai(MainForm.FS.PEGAWAI_RESTAURANT.FindByUSER_ID(r[0].USER_ID));
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("username atau password salah!");
            }
        }
        public void clear()
        {
            tbPass.Clear();
            tbUsername.Clear();
        }
    }
}
