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
using System.Windows.Forms.Calendar;
namespace FS_REST
{
    public partial class EventSearchBook : DockContent
    {
        FSRESTAURANT.EVENT_BOOKINGDataTable dt;
        FSRESTAURANT.EVENT_TABLEDataTable et;
        List<CalendarItem> _items = new List<CalendarItem>();
        public EventSearchBook(FSRESTAURANT.EVENT_BOOKINGDataTable dt,FSRESTAURANT.EVENT_TABLEDataTable et)
        {
            InitializeComponent();
            this.dt = dt;
            this.et = et;
            DockContent dc = new DockContent();
            dc.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            dc.DockPanel = dockPanel1;
            dc.DockState = DockState.DockLeftAutoHide;
            dockPanel1.AllowEndUserDocking = false;
            dockPanel1.ActiveAutoHideContent = dc;
            dockPanel1.Controls.Add(EventCalendar);
            dockPanel1.Dock = DockStyle.Fill;
            EventCalendar.Dock = DockStyle.Fill;
            EventCalendar.SetViewRange(DateTime.Now, DateTime.Now);
            listTable.DataSource = et;
            listTable.DisplayMember = "TABLE_NAME";
            listTable.ValueMember = "TABLE_ID";
        }
        private void PlaceItems()
        {
            foreach (CalendarItem item in _items)
            {
                if (EventCalendar.ViewIntersects(item))
                {
                    EventCalendar.Items.Add(item);
                }
            }
        }
        private void displayEvent_SizeChanged(object sender, EventArgs e)
        {
           
        }

        private void displayEvent_Load(object sender, EventArgs e)
        {
            
        }

    

        private void EventCalendar_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            PlaceItems();
        }

        private void EventCalendar_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            Event.EventPenjualan ep = new Event.EventPenjualan(StateWindow.update, dt.FindByEVENT_BOOKING_ID(Convert.ToInt64(e.Item.Tag)).EVENT_PENJUALANRow);
            ep.ShowDialog();
        }

        private void EventCalendar_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            _items.Remove(e.Item);
            dt.FindByEVENT_BOOKING_ID(Convert.ToInt64(e.Item.Tag)).Delete();
            MainForm.adapterMgr.EVENT_BOOKINGTableAdapter.Update(dt);
            dt.AcceptChanges();
        }

        private void listTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventCalendar.Items.Clear();
            _items.Clear();
            foreach (FSRESTAURANT.EVENT_BOOKINGRow item in dt)
            {
                try
                {
                    if (listTable.SelectedValue.ToString()==item.TABLE_ID)
                    {
                        TimeSpan ts = item.BOOKING_STOP.Subtract(item.BOOKING_START);
                        CalendarItem ci = new CalendarItem(EventCalendar, item.BOOKING_START, ts, MainForm.FS.EVENT_PENJUALAN.FindByEVENT_PENJUALAN_ID(item.EVENT_PENJUALAN_ID).PELANGGAN_RESTAURANTRow.PELANGGAN_NAME);
                        ci.Tag = item.EVENT_BOOKING_ID;
                        _items.Add(ci);
                        ci.ForeColor = Color.Crimson;
                        ci.ApplyColor(Color.Chocolate);
                    }
                }
                catch 
                {
                }
            }
            PlaceItems();
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            if (monthView1.SelectionEnd.Subtract(monthView1.SelectionStart).Days <= 70)
                EventCalendar.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
        }

        private void EventCalendar_Scroll(object sender, ScrollEventArgs e)
        {
            e.NewValue = e.OldValue + 100;
        }
    }
}
