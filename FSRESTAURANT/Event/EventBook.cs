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
    public partial class EventBook : Form
    {
        FSRESTAURANT.EVENT_PENJUALANRow eprow;
        FSRESTAURANT.EVENT_BOOKINGDataTable dtbook;
        FSRESTAURANT.EVENT_TABLEDataTable dttable;
        Dictionary<string,string> source = new Dictionary<string, string>();
        decimal uppayment = 0;
        public decimal UpPayment
        {
            get { return uppayment; }
        }
        public EventBook(FSRESTAURANT.EVENT_PENJUALANRow eprow)
        {
            if (eprow == null)
                throw new ArgumentNullException();
            this.eprow = eprow;
            InitializeComponent();
            //init value 
            dttable = MainForm.FS.EVENT_TABLE;
            dtbook = MainForm.FS.EVENT_BOOKING;
            foreach (FSRESTAURANT.EVENT_TABLERow item in dttable)
            {
                source.Add(item.TABLE_NAME, item.TABLE_ID);
            }
        }

        private void EventBook_Load(object sender, EventArgs e)
        {
          
        }

        

        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < cbTable.Items.Count; i++)
                {
                    bool st = cbTable.GetItemChecked(i);

                    if (st)
                    {
                        string name = cbTable.Items[i].ToString();
                        Console.WriteLine(name);
                        FSRESTAURANT.EVENT_BOOKINGRow dr = MainForm.FS.EVENT_BOOKING.NewEVENT_BOOKINGRow();
                        dr.BOOKING_START = date.Value+timeStart.Value.TimeOfDay;
                        dr.BOOKING_STOP = date.Value + timeStop.Value.TimeOfDay;
                        dr.EVENT_PENJUALAN_ID = eprow.EVENT_PENJUALAN_ID;
                        dr.TABLE_ID = source[name];
                        MainForm.FS.EVENT_BOOKING.AddEVENT_BOOKINGRow(dr);
                        uppayment+= dttable.FindByTABLE_ID(source[name]).TABLE_PRICE;
                    }
                }
                syncToDatabase();
                MessageBox.Show("Booking sukses");
                Event.Report.Book p = new Report.Book();
                Report.PrintPreview pp = new Report.PrintPreview(p, MainForm.FS);
                pp.setParam("PENJUALAN_ID", eprow.EVENT_PENJUALAN_ID);
                pp.setReport();
                pp.ShowDialog();
                
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
                MainForm.adapterMgr.EVENT_BOOKINGTableAdapter.Update(MainForm.FS.EVENT_BOOKING);
                MainForm.FS.EVENT_BOOKING.AcceptChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
         //   MessageBox.Show("Test");
        }

        private void formValidation()
        {
            bool flag = false;
            if(timeStart.Value >timeStop.Value)
            {
                epbook.SetError(timeStop, "harus lebih besar");
                epbook.SetError(timeStart, "harus lebih kecil");
                flag = true;
            }
            if(date.Value<DateTime.Today)
            {
                epbook.SetError(date, "harus lebih besar dari hari ini!");
                flag = true;
            }
            if (flag)
                throw new FormValidationFailException("format ada yang salah!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                epbook.Clear();
                formValidation();
                cbTable.Items.Clear();
                //var revdic = source.Reverse();
                DateTime now = DateTime.Now;
                foreach(FSRESTAURANT.EVENT_TABLERow item in dttable)
                {
                    
                    var select = from booking in dtbook
                                 where booking.TABLE_ID == item.TABLE_ID
                                       && (booking.BOOKING_START.Date >= date.Value.Date && booking.BOOKING_STOP.Date <= date.Value.Date)
                                       && !(booking.BOOKING_START.TimeOfDay >= timeStart.Value.TimeOfDay && booking.BOOKING_STOP.TimeOfDay <= timeStart.Value.TimeOfDay)
                                       && !(booking.BOOKING_START.TimeOfDay >= timeStop.Value.TimeOfDay && booking.BOOKING_STOP.TimeOfDay <= timeStop.Value.TimeOfDay)
                                 select new { table_id = booking.TABLE_ID, start = booking.BOOKING_START, stop = booking.BOOKING_STOP };
                   
                    if (select.Count() == 0)
                        cbTable.Items.Add(item.TABLE_NAME);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
public static class Extension
{
    public static Dictionary<TValue, TKey> Reverse<TKey, TValue>(this IDictionary<TKey, TValue> source)
    {
        var dictionary = new Dictionary<TValue, TKey>();
        foreach (var entry in source)
        {
            if (!dictionary.ContainsKey(entry.Value))
                dictionary.Add(entry.Value, entry.Key);
        }
        return dictionary;
    }
}
