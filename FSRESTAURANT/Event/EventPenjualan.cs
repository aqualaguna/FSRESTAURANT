using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using MySql.Data.MySqlClient;
namespace FS_REST.Event
{
    public partial class EventPenjualan : DockContent
    {
        FSRESTAURANT.EVENT_PENJUALANDataTable dataep;
        FSRESTAURANT.EVENT_PENJUALANRow eprow;
        FSRESTAURANT.EVENT_PENJUALAN_DETAILDataTable data,temp;
        DataView dvpil;
        string condition = "";
        StateWindow state;
        decimal uppayment = 0;
        public EventPenjualan(StateWindow state,FSRESTAURANT.EVENT_PENJUALANRow epr)
        {
            dataep = new FSRESTAURANT.EVENT_PENJUALANDataTable();
            InitializeComponent();
            this.state = state;
            eprow = epr;
            data = new FSRESTAURANT.EVENT_PENJUALAN_DETAILDataTable();
            temp = new FSRESTAURANT.EVENT_PENJUALAN_DETAILDataTable();
            lblUp.Text = uppayment.ToString("N2");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            MySqlTransaction trans = MainForm.c.BeginTransaction();
            try
            {
                MainForm.adapterMgr.EVENT_PENJUALANTableAdapter.Transaction = trans;
                MainForm.adapterMgr.EVENT_PENJUALAN_DETAILTableAdapter.Transaction = trans;
                if(eprow ==null)
                    eprow = dataep.NewEVENT_PENJUALANRow();
                eprow.EVENT_ID = Convert.ToInt64(cbEvent.SelectedValue.ToString());
                eprow.TOTAL = Convert.ToDecimal( data.Compute("SUM(SUBTOTAL)",""));
                eprow.EVENT_PENJUALAN_ID = MainForm.adapterMgr.EVENT_PENJUALANTableAdapter.autogen().ToString();
                eprow.USER_ID = MainForm.peg.USER_ID;
                eprow.PELANGGAN_ID = cbCustomer.SelectedValue.ToString();
                dataep.AddEVENT_PENJUALANRow(eprow);
                MainForm.adapterMgr.EVENT_PENJUALANTableAdapter.Update(dataep);
                //trans.Commit();
                foreach(FSRESTAURANT.EVENT_PENJUALAN_DETAILRow item in data)
                {
                    item.EVENT_PENJUALAN_ID = eprow.EVENT_PENJUALAN_ID;
                }
                
                MainForm.adapterMgr.EVENT_PENJUALAN_DETAILTableAdapter.Update(data);
                MessageBox.Show("insert sukses");
                trans.Commit();
                syncToDatabase();
                Event.Report.EventJual p = new Report.EventJual();
                Report.PrintPreview pp = new Report.PrintPreview(p, MainForm.FS);
                pp.setParam("PENJUALAN_ID", eprow.EVENT_PENJUALAN_ID);
                pp.setReport();
                pp.ShowDialog();
                reverseState();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                dataep.Clear();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                trans.Dispose();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                eprow.TOTAL = Convert.ToDecimal(data.Compute("SUM(SUBTOTAL)", ""));
                MainForm.FS.EVENT_PENJUALAN_DETAIL.Merge(data);
                syncToDatabase();
                MessageBox.Show("update sukses");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                eprow.Delete();
                foreach(FSRESTAURANT.EVENT_PENJUALAN_DETAILRow item in data)
                {
                    item.Delete();
                }
                MainForm.FS.EVENT_PENJUALAN_DETAIL.Merge(data);
                syncToDatabase();
                MessageBox.Show("delete sukses");
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
                MainForm.FS.EVENT_PENJUALAN.Merge(dataep);
                MainForm.FS.EVENT_PENJUALAN.AcceptChanges();
                MainForm.FS.EVENT_PENJUALAN_DETAIL.Merge(data);
                MainForm.FS.EVENT_PENJUALAN_DETAIL.AcceptChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                EventBook evbook = new EventBook(eprow);
                evbook.ShowDialog();
                uppayment += evbook.UpPayment;
                lblUp.Text = uppayment.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRight2_Click(object sender, EventArgs e)
        {
            string message = "";
            foreach(FSRESTAURANT.EVENT_PENJUALAN_DETAILRow item in temp)
            {
                try
                {
                    data.ImportRow(item);
                }
                catch (Exception ex) 
                {
                    message = ex.Message;
                }
            }
            if (message != "") MessageBox.Show(message);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            try
            {

                string[] key = lbPil.SelectedValue.ToString().Split('-');
                data.ImportRow(temp.FindByEVENT_PENJUALAN_IDEVENT_IDMENU_ID("", Convert.ToInt64(key[0]), key[1]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            dgDetail.Rows.Remove(dgDetail.CurrentRow);
        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            data.Clear();
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
            var rs = (from evendetail in MainForm.FS.EVENT_DETAIL.AsEnumerable()
                     join menu in MainForm.FS.MENU_HEADER.AsEnumerable() on evendetail.MENU_ID equals menu.MENU_ID 
                     into item_grp_join
                    from itemgrp in item_grp_join
                     select new { eventid = evendetail.EVENT_ID, menuid = evendetail.MENU_ID,menuprice =evendetail.EVENT_PRICE,menuname= itemgrp.MENU_NAME });
            data.Columns.Add(new DataColumn("MENU_NAME"));
            data.Columns.Add("SUBTOTAL", typeof(decimal), "PRICE*QTY");
            temp.Columns.Add(new DataColumn("MENU_NAME"));
            temp.Columns.Add(new DataColumn("TABLE_KEY"));
            foreach (var item in rs)
            {
                FSRESTAURANT.EVENT_PENJUALAN_DETAILRow dr = temp.NewEVENT_PENJUALAN_DETAILRow();
                dr.EVENT_ID = item.eventid;
                dr.PRICE = item.menuprice;
                dr.EVENT_PENJUALAN_ID = "";
                dr.MENU_ID = item.menuid;
                dr["MENU_NAME"] = item.menuname;
                dr["TABLE_KEY"] = item.eventid+"-"+item.menuid;
                dr.QTY = 1;
                temp.AddEVENT_PENJUALAN_DETAILRow(dr);
            }
            dvpil = temp.AsDataView();
            lbPil.DataSource = dvpil;
            lbPil.DisplayMember = "MENU_NAME";
            lbPil.ValueMember = "TABLE_KEY";
            dgDetail.DataSource = data;
            switch (state)
            {
                case StateWindow.insert:
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnBook.Enabled = false;
                    break;
                case StateWindow.update:
                    btnInsert.Enabled = false;
                    foreach (FSRESTAURANT.EVENT_PENJUALAN_DETAILRow item in MainForm.adapterMgr.EVENT_PENJUALAN_DETAILTableAdapter.GetDataById(eprow.EVENT_PENJUALAN_ID))
                    {
                        data.ImportRow(item);
                    }
                    cbCustomer.SelectedValue = eprow.PELANGGAN_ID;
                    cbEvent.SelectedValue = eprow.EVENT_ID;
                    cbCustomer.Enabled = false;
                    cbEvent.Enabled = false;
                    break;
            }
        }
        private void reverseState()
        {
            if (state == StateWindow.insert) state = StateWindow.update;
            else state = StateWindow.insert;
            btnDelete.Enabled =
            btnUpdate.Enabled =
            btnBook.Enabled = true;
            btnInsert.Enabled = cbCustomer.Enabled = cbEvent.Enabled= false;
        }
        private void dgDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            lblTotal.Text = ((decimal)data.Compute("SUM(SUBTOTAL)", "")).ToString("N2");
        }

        private void cbEvent_SelectedValueChanged(object sender, EventArgs e)
        {
            if(dvpil!=null)
            {
                condition = "EVENT_ID = " + cbEvent.SelectedValue.ToString();
                dvpil.RowFilter = condition;
            }
        }
        

    }
}
