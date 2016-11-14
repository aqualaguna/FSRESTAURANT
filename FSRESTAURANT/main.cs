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
namespace Form_Event
{
    public partial class Main : Form
    {
        #region 
        InsertEvent InsertEvent;
        ChangingEvent ChangingEvent;
        DisplayEvent Display;
        public static FSRESTAURANT FS = new FSRESTAURANT();
        public static FSRESTAURANTTableAdapters.TableAdapterManager adapterMgr = new FSRESTAURANTTableAdapters.TableAdapterManager();
        public static MySqlConnection c = new MySqlConnection("server=52.87.187.66;user id=theresa;persistsecurityinfo=True;database=restaurant;allowuservariables=True;password=theresa");
        #endregion
        public Main()
        {
            InitializeComponent();
            try
            {
                c.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            adapterMgr.Connection = c;
        }

        private void insertEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region dml
            ////insert
            //FSRESTAURANT.EVENT_BOOKINGDataTable dt = new FSRESTAURANT.EVENT_BOOKINGDataTable();
            //FSRESTAURANT.EVENT_BOOKINGRow dr = dt.NewEVENT_BOOKINGRow();
            //dr.BOOKING_START = DateTime.Now;
            //dr.BOOKING_STOP = DateTime.Now.AddDays(1);
            //dr.BOOKING_UPPAYMENT = 100;
            //dr.EVENT_PENJUALAN_ID = "test";
            //dr.TABLE_ID = "ha001";
            //dt.AddEVENT_BOOKINGRow(dr);
            //adapterMgr.EVENT_BOOKINGTableAdapter.Update(dt);
            //dt.AcceptChanges();
            ////
            ////update

            //dr = dt.FindByTABLE_ID("ha001");
            //dr.BOOKING_START = DateTime.Now;
            //dr.BOOKING_STOP = DateTime.Now.AddDays(1);
            //dr.BOOKING_UPPAYMENT = 100;
            //dr.EVENT_PENJUALAN_ID = "test";
            //dt.AddEVENT_BOOKINGRow(dr);
            //adapterMgr.EVENT_BOOKINGTableAdapter.Update(dt);
            //dt.AcceptChanges();
            ////
            ////delete
            //dt.FindByTABLE_ID("ha001").Delete();
            //adapterMgr.EVENT_BOOKINGTableAdapter.Update(dt);
            //dt.AcceptChanges();
            ////
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InsertEvent insert = new InsertEvent();
            insert.Show();
        }
    }
}
