using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using MySql.Data.MySqlClient;
namespace FS_REST
{
    public partial class MainForm : Form
    {
        #region 
        public static FSRESTAURANT FS = new FSRESTAURANT();
        public static FSRESTAURANTTableAdapters.TableAdapterManager adapterMgr = new FSRESTAURANTTableAdapters.TableAdapterManager();
        public static MySqlConnection c =new MySqlConnection(Properties.Settings.Default.restaurantConnectionString);
        public static FSRESTAURANT.PEGAWAI_RESTAURANTRow peg;
        #endregion
        public MainForm()
        {
            InitializeComponent();
            //initialize active record pattern
            try
            {
                if(c.State==ConnectionState.Closed)
                    c.Open();
                adapterMgr.initialize(c, FS, true, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            adapterMgr.Connection = c;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //shortcut key
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void insertEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventInsert eventi = new EventInsert(StateWindow.insert,null);
            eventi.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void searchEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventSearch eventi = new EventSearch(FS.EVENT_HEADER);
            eventi.MdiParent = this;
            eventi.Show(dcPanel);
        }

        private void newTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Event.Table tb = new Event.Table();
            tb.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            peg = null;
            Login.tis.clear();
            Login.tis.Show();
        }
        public void setPegawai(FSRESTAURANT.PEGAWAI_RESTAURANTRow dr)
        {
            peg = dr;
        }
    }
    public enum StateWindow
    {
        insert,update,delete
    }
}
