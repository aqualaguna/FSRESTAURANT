using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Event
{
    public partial class InsertEvent : Form
    {
        FSRESTAURANT.MENU_RESTAURANTDataTable menudt = new FSRESTAURANT.MENU_RESTAURANTDataTable();
        FSRESTAURANT.EVENT_DETAILDataTable evdetail = new FSRESTAURANT.EVENT_DETAILDataTable();
        DataView dv;
        public InsertEvent()
        {
            InitializeComponent();
            //fill data from menu and fill the listbox
            Main.adapterMgr.MENU_RESTAURANTTableAdapter.Fill(menudt);
            lbMenu.DisplayMember = "MENU_NAME";
            lbMenu.ValueMember = "MENU_ID";
            dv = menudt.AsDataView();
            lbMenu.DataSource = dv;
        }

        
        private void btnRight2_Click(object sender, EventArgs e)
        {
            foreach (DataRowView item in dv)
            {
                FSRESTAURANT.EVENT_DETAILRow dr = evdetail.NewEVENT_DETAILRow();
                
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {

        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string key = tbSearch.Text;
            dv.RowFilter = "MENU_NAME LIKE *" + key + "* OR DESCRIPTION LIKE *" + key + "*";
        }
    }
}
