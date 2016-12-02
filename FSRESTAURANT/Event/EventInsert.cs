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
namespace FS_REST
{
    public partial class EventInsert : DockContent
    {
        FSRESTAURANT.MENU_HEADERDataTable menudt = new FSRESTAURANT.MENU_HEADERDataTable();
        FSRESTAURANT.EVENT_DETAILDataTable evdetail = new FSRESTAURANT.EVENT_DETAILDataTable();
        FSRESTAURANT.EVENT_HEADERRow eheader;
        DataView dv,dvdetail;
        long eventid;
        StateWindow state;
        public EventInsert(StateWindow state,FSRESTAURANT.EVENT_HEADERRow header)
        {
            this.state = state;
            eheader = header;
            InitializeComponent();
            //fill data from menu and fill the listbox
            MainForm.adapterMgr.MENU_HEADERTableAdapter.Fill(menudt);
            lbMenu.DisplayMember = "MENU_NAME";
            lbMenu.ValueMember = "MENU_ID";
            dv = menudt.AsDataView();
            lbMenu.DataSource = dv;
            dv.Sort = "MENU_ID";
            switch (state)
            {
                case StateWindow.insert:
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
                case StateWindow.update:
                    btnInsert.Enabled = false;
                    tbNama.Text = header.EVENT_NAME;
                    dtStart.Value = header.EVENT_START;
                    dtStop.Value = header.EVENT_STOP;
                    tbDescription.Text = header.DESCRIPTION;
                    nmCapacity.Value = header.EVENT_HEAD_LIMIT;
                    evdetail = new FSRESTAURANT.EVENT_DETAILDataTable() ;
                    foreach (FSRESTAURANT.EVENT_DETAILRow item in eheader.GetEVENT_DETAILRows())
                    {
                        evdetail.ImportRow(item);
                    }
                    break;
                default:
                    break;
            }
            evdetail.EVENT_IDColumn.AllowDBNull = true;
            DataColumn dc = new DataColumn("NAMA MENU", typeof(string));
            evdetail.Columns.Add(dc);
            dvdetail = evdetail.AsDataView();
            dgEventDetail.DataSource = evdetail;
        }

        
        private void btnRight2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            
                foreach (DataRowView item in dv)
                {
                    try
                    {
                        FSRESTAURANT.EVENT_DETAILRow dr = evdetail.NewEVENT_DETAILRow();
                        dr.MENU_ID = item["MENU_ID"].ToString();
                        dr.EVENT_PRICE = Convert.ToDecimal(item["MENU_PRICE"]);
                        dr["NAMA MENU"] = item["MENU_NAME"].ToString();
                        evdetail.AddEVENT_DETAILRow(dr);
                    }
                    catch 
                    {
                      flag = true;
                    }
                }
            if (flag)
            {
                MessageBox.Show("item already exists!");
            }
           
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            try
            {
                FSRESTAURANT.EVENT_DETAILRow dr = evdetail.NewEVENT_DETAILRow();
                DataRowView[] drv = dv.FindRows(lbMenu.SelectedValue);
                dr.MENU_ID = drv[0]["MENU_ID"].ToString();
                dr.EVENT_PRICE = Convert.ToDecimal(drv[0]["MENU_PRICE"]);
                dr["NAMA MENU"] = drv[0]["MENU_NAME"].ToString();
                evdetail.AddEVENT_DETAILRow(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            dgEventDetail.Rows.Remove(dgEventDetail.CurrentRow);
        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            evdetail.Rows.Clear();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string key = tbSearch.Text;
            dv.RowFilter = "MENU_NAME LIKE '%" + key + "%' OR DESCRIPTION LIKE '%" + key + "%'";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                formValidation();
                eventid =(long) MainForm.adapterMgr.EVENT_HEADERTableAdapter.nextId();
                MainForm.adapterMgr.EVENT_HEADERTableAdapter.InsertQuery(tbNama.Text, dtStart.Value, dtStop.Value, nmCapacity.Value, tbDescription.Text);
                foreach (FSRESTAURANT.EVENT_DETAILRow item in evdetail)
                {
                    item.EVENT_ID = eventid;
                }
                syncToDatabase();
                MessageBox.Show("insert Success!");
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
                if (state == StateWindow.insert)
                {
                    MainForm.adapterMgr.EVENT_HEADERTableAdapter.Fill(MainForm.FS.EVENT_HEADER);
                }
                else
                {
                    MainForm.adapterMgr.EVENT_HEADERTableAdapter.Update(MainForm.FS.EVENT_HEADER);

                }
                MainForm.FS.EVENT_DETAIL.Merge(evdetail);
                MainForm.adapterMgr.EVENT_DETAILTableAdapter.Update(MainForm.FS.EVENT_DETAIL);
                MainForm.FS.EVENT_DETAIL.AcceptChanges();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void formValidation()
        {
            bool flag = false;
            if (tbNama.Text=="")
            {
                epevent.SetError(tbNama, "required");
                flag = true;
            }
            if(dtStop.Value < dtStart.Value)
            {
                epevent.SetError(dtStart, "value start harus lebih kecil!");
                epevent.SetError(dtStop, "value stop harus lebih besar!");
                flag = true;
            }
            if(evdetail.Rows.Count==0)
            {
                epevent.SetError(dgEventDetail, "harus ada item!");
                flag = true;
            }
            if(flag)
                throw new FormValidationFailException("Format ada yang salah!");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            eheader.EVENT_STATUS = "N";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                formValidation();
                eheader.EVENT_NAME = tbNama.Text;
                eheader.EVENT_START = dtStart.Value;
                eheader.EVENT_STOP = dtStop.Value;
                eheader.EVENT_HEAD_LIMIT = nmCapacity.Value;
                eheader.DESCRIPTION = tbDescription.Text;
                syncToDatabase();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
