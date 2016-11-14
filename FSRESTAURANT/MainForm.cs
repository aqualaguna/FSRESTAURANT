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
        public static MySqlConnection c = new MySqlConnection("server=52.87.187.66;user id=theresa;persistsecurityinfo=True;database=restaurant;allowuservariables=True;password=theresa");
        
        #endregion
        public MainForm()
        {
            InitializeComponent();
           
            //initialize active record pattern
            try
            {
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
            eventi.MdiParent = this;
            eventi.Show(dcPanel);
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
    }
    public enum StateWindow
    {
        insert,update,delete
    }
}
