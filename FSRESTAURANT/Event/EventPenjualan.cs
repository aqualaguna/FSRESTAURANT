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
    public partial class EventPenjualan : Form
    {
        FSRESTAURANT.EVENT_PENJUALANRow eprow;
        FSRESTAURANT.EVENT_PENJUALAN_DETAILDataTable data;
        DataView dvpil;
        string condition = "";
        public EventPenjualan()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void btnBook_Click(object sender, EventArgs e)
        {

        }

        private void btnRight2_Click(object sender, EventArgs e)
        {

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

        private void EventPenjualan_Load(object sender, EventArgs e)
        {
            // init data
            Dictionary<long, string> sourceevent = new Dictionary<long, string>();
            DateTime now = DateTime.Now;
            foreach(FSRESTAURANT.EVENT_HEADERRow item in MainForm.FS.EVENT_HEADER)
            {
                if (item.EVENT_STATUS == "Y" || item.EVENT_START>now)
                    sourceevent.Add(item.EVENT_ID, item.EVENT_NAME);
            }
            cbEvent.DataSource = new BindingSource(sourceevent, null);
            cbEvent.DisplayMember = "Value";
            cbEvent.ValueMember = "Key";
            cbCustomer.DataSource = MainForm.FS.PELANGGAN_RESTAURANT;
            cbCustomer.DisplayMember = "PELANGGAN_NAME";
            cbCustomer.ValueMember = "PELANGGAN_ID";
            dvpil = MainForm.FS.EVENT_DETAIL.AsDataView();
        }

        private void cbEvent_SelectedValueChanged(object sender, EventArgs e)
        {
            condition = "EVENT_ID = " + cbEvent.SelectedValue.ToString();
            dvpil.RowFilter = condition;
        }
        
    }
}
