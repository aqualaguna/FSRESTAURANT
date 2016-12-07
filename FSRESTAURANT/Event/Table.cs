using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FS_REST.Event
{
    public partial class Table : Form
    {
        public Table()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                FSRESTAURANT.EVENT_TABLERow dr = MainForm.FS.EVENT_TABLE.NewEVENT_TABLERow();
                dr.TABLE_ID = MainForm.adapterMgr.EVENT_TABLETableAdapter.autogen().ToString();
                dr.TABLE_CAPACITY = nmCapacity.Value;
                dr.TABLE_STATUS = "free";
                dr.TABLE_NAME = tbName.Text;
                dr.TABLE_PRICE = Convert.ToDecimal(tbPrice.Text);
                MainForm.FS.EVENT_TABLE.AddEVENT_TABLERow(dr);
                syncToDatabase();
                MessageBox.Show("sukses!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void syncToDatabase()
        {
            try
            {
                MainForm.adapterMgr.EVENT_TABLETableAdapter.Update(MainForm.FS.EVENT_TABLE);
                MainForm.FS.EVENT_TABLE.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
