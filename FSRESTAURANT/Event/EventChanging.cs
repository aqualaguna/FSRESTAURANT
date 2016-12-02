using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace FS_REST
{
    public partial class EventChanging : Form
    {
        FSRESTAURANT FS;
        FSRESTAURANTTableAdapters.TableAdapterManager adapterMgr;
        public static MySqlConnection connect;
        FSRESTAURANT.EVENT_HEADERDataTable masterEventHeader;
        FSRESTAURANT.EVENT_DETAILDataTable masterEventDetail;
        public FSRESTAURANT.MENU_HEADERDataTable masterMenu;

        string  menuID;
        long eventID;
        searchMenu search;
        public EventChanging()
        {
            InitializeComponent();
            eventID = 0;
            menuID = "";
            FS = new FSRESTAURANT();
            adapterMgr = new FSRESTAURANTTableAdapters.TableAdapterManager();

            connect = new MySqlConnection("server=52.87.187.66;user id=theresa;persistsecurityinfo=True;database=restaurant;allowuservariables=True;password=theresa");
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            adapterMgr.Connection = connect;

        }

        private void button1_Click(object sender, EventArgs e)
        {//search
            search = new searchMenu(this);
            search.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {//update
            FSRESTAURANT.EVENT_DETAILRow edRow = masterEventDetail.FindByEVENT_IDMENU_ID(eventID, menuID);
            edRow.EVENT_PRICE = Convert.ToDecimal(textBox3.Text);
            edRow.MENU_ID = getMenuID(textBox2.Text);
            edRow.EVENT_PRICE = Convert.ToDecimal(textBox3.Text);
            masterEventDetail.AddEVENT_DETAILRow(edRow);
            adapterMgr.EVENT_DETAILTableAdapter.Update(masterEventDetail);
            masterEventDetail.AcceptChanges();

            FSRESTAURANT.EVENT_HEADERRow ehRow = masterEventHeader.FindByEVENT_ID(eventID);
            ehRow.EVENT_NAME = textBox1.Text;
            ehRow.EVENT_START = dateTimePicker1.Value;
            ehRow.EVENT_STOP = dateTimePicker2.Value;
            ehRow.EVENT_HEAD_LIMIT = numericUpDown1.Value;
            ehRow.EVENT_HEAD_COUNT = numericUpDown1.Value;
            masterEventHeader.AddEVENT_HEADERRow(ehRow);
            adapterMgr.EVENT_HEADERTableAdapter.Update(masterEventHeader);
            masterEventHeader.AcceptChanges();

            refreshMasterEventHeader();
            refreshMasterEventDetail();

            clear();
        }

        private void EventChanging_Load(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button1.Enabled = button2.Enabled = button3.Enabled = true;
                showData(listBox1.GetItemText(listBox1.SelectedItem));

            }
            else
            {
                button1.Enabled = button2.Enabled = button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {//delete
            masterEventDetail.FindByEVENT_IDMENU_ID(eventID, menuID).Delete();//Object reference not set to an instance of an object.
            adapterMgr.EVENT_DETAILTableAdapter.Update(masterEventDetail);
            masterEventDetail.AcceptChanges();

            masterEventHeader.FindByEVENT_ID(eventID).Delete();
            adapterMgr.EVENT_HEADERTableAdapter.Update(masterEventHeader);
            masterEventHeader.AcceptChanges();

            refreshMasterEventHeader();
            refreshMasterEventDetail();

            clear();
        }
        public void refreshMasterEventHeader()
        {
            masterEventHeader = new FSRESTAURANT.EVENT_HEADERDataTable();
            adapterMgr.EVENT_HEADERTableAdapter.Fill(masterEventHeader);

            foreach (DataRow item in masterEventHeader.Rows)
            {
                listBox1.Items.Add(item[1]);
            }
        }

        public void refreshMasterEventDetail()
        {
            masterEventDetail = new FSRESTAURANT.EVENT_DETAILDataTable();
            adapterMgr.EVENT_DETAILTableAdapter.Fill(masterEventDetail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventName">event name</param>
        public void showData(string eventName)
        {
            foreach (FSRESTAURANT.EVENT_HEADERRow item in masterEventHeader.Rows)
            {
                if (eventName == item.EVENT_NAME)
                {
                    eventID = item.EVENT_ID;
                    textBox1.Text = item[1].ToString();

                    dateTimePicker1.Value = (DateTime)item[2];
                    dateTimePicker2.Value = (DateTime)item[3];

                    numericUpDown1.Value = Convert.ToInt32(item[6]);
                    //textBox4.Text = item[7].ToString();
                    break;
                }
            }
            foreach (FSRESTAURANT.EVENT_DETAILRow item in masterEventDetail.Rows)
            {
                if (eventID == item.EVENT_ID)
                {
                    menuID = item.MENU_ID;
                    textBox3.Text = item.EVENT_PRICE.ToString();
                    break;
                }
            }
          
        }

        public string getMenuID(string menuName)
        {
            foreach (DataRow item in masterMenu.Rows)
            {
                if (menuName == item[2].ToString())
                {
                    return item[0].ToString();
                }
            }
            return "";
        }
        /// <summary>
        /// make textbox, numericUpDown, dateTimePicker, listBox.SelectedIndex to default value
        /// </summary>
        public void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            numericUpDown1.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            listBox1.SelectedIndex = -1;
        }

        public void setMenuName(string menuName)
        {
            textBox2.Text = menuName;
        }
    }
}
