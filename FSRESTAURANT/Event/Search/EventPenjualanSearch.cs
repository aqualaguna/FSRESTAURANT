using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
namespace FS_REST.Event.Search
{
    public partial class EventPenjualanSearch :  DockContent
    {
        FSRESTAURANT.EVENT_PENJUALANDataTable data;
        DataView dvdata;
        public EventPenjualanSearch()
        {
            InitializeComponent();
        }

        private void EventPenjualanSearch_Load(object sender, EventArgs e)
        {
            Dictionary<long, string> sourceevent = new Dictionary<long, string>();
            DateTime now = DateTime.Now;
            foreach (FSRESTAURANT.EVENT_HEADERRow item in MainForm.FS.EVENT_HEADER)
            {
                if (item.EVENT_STATUS == "Y" || item.EVENT_START > now)
                    sourceevent.Add(item.EVENT_ID, item.EVENT_NAME);
            }
            cbEvent.DataSource = new BindingSource(sourceevent, null);
            cbEvent.DisplayMember = "Value";
            cbEvent.ValueMember = "Key";
            cbCustomer.DataSource = MainForm.FS.PELANGGAN_RESTAURANT;
            cbCustomer.DisplayMember = "PELANGGAN_NAME";
            cbCustomer.ValueMember = "PELANGGAN_ID";
            cbUser.DataSource = MainForm.FS.PEGAWAI_RESTAURANT;
            cbUser.DisplayMember = "USER_NAMA";
            cbUser.ValueMember = "USER_ID";
            dgSearch.DataSource = dvdata;
        }

        private void cbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cbEvent.SelectedValue!=null)
                {
                    KeyValuePair<long, string> temp = (KeyValuePair<long, string>)cbEvent.SelectedValue;
                 //   MessageBox.Show(temp.Key.ToString());
                    data = MainForm.adapterMgr.EVENT_PENJUALANTableAdapter.GetDataBySearchEvent(temp.Key);
                    MainForm.FS.EVENT_PENJUALAN.Merge(data);
                    MainForm.FS.EVENT_PENJUALAN.AcceptChanges();
                    dvdata = data.AsDataView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rowfilter(object sender, EventArgs e)
        {
            dvdata.RowFilter = "USER_ID='"+cbUser.SelectedValue.ToString()+"' AND PELANGGAN_ID='"+cbCustomer.SelectedValue.ToString()+"'" ;
        }

        private void dgSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Event.EventPenjualan ep = new EventPenjualan(StateWindow.update, MainForm.FS.EVENT_PENJUALAN.FindByEVENT_PENJUALAN_ID(dgSearch.CurrentRow.Cells["EVENT_PENJUALAN_ID"].Value.ToString()));
            ep.ShowDialog();
        }
    }
}
