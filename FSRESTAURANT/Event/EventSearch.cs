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
    public partial class EventSearch : DockContent
    {
        FSRESTAURANT.EVENT_HEADERDataTable dt;
        List<CalendarItem> _items = new List<CalendarItem>();
        public EventSearch(FSRESTAURANT.EVENT_HEADERDataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            DockContent dc = new DockContent();
            dc.Controls.Add(monthView1);
            monthView1.Dock = DockStyle.Fill;
            dc.DockPanel = dockPanel1;
            dc.DockState = DockState.DockLeftAutoHide;
            dockPanel1.AllowEndUserDocking = false;
            dockPanel1.ActiveAutoHideContent = dc;
            dockPanel1.Controls.Add(EventCalendar);
            dockPanel1.Dock = DockStyle.Fill;
            EventCalendar.Dock = DockStyle.Fill;
            foreach (FSRESTAURANT.EVENT_HEADERRow item in dt)
            {
                TimeSpan ts = item.EVENT_STOP.Subtract(item.EVENT_START);
                CalendarItem ci = new CalendarItem(EventCalendar, item.EVENT_START, ts, item.EVENT_NAME);
                ci.Tag = item.EVENT_ID.ToString();
                if (item.EVENT_STATUS == "Y")
                    ci.ApplyColor(Color.LightGreen);
                else
                {
                    if(item.EVENT_STOP<DateTime.Now)
                        ci.ApplyColor(Color.Black);
                    else
                        ci.ApplyColor(Color.DarkCyan);
                }

                _items.Add(ci);
            }
            PlaceItems();

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

        private void splitContainer1_Panel1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void splitContainer1_Panel1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EventCalendar.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
            }
            catch 
            {
            }
        }

        private void EventCalendar_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            PlaceItems();
        }

        private void EventCalendar_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            EventInsert evin = new EventInsert(StateWindow.update, MainForm.FS.EVENT_HEADER.FindByEVENT_ID(Convert.ToInt64(e.Item.Tag)));
            evin.ShowDialog();
        }
    }
}
