using MySql.Data.MySqlClient;
namespace FS_REST
{


    public partial class FSRESTAURANT
    {
        partial class EVENT_DETAILDataTable
        {
            public void deleteByEventId(long id)
            {
                foreach (EVENT_DETAILRow item in this.Rows)
                {
                    if (item.EVENT_ID == id)
                    {
                        item.Delete();
                    }
                }
            }
            public EVENT_DETAILDataTable findById(long id)
            {
                EVENT_DETAILDataTable dt = new EVENT_DETAILDataTable();
                foreach (EVENT_DETAILRow item in this.Rows)
                {
                    if (item.EVENT_ID == id)
                    {
                        dt.AddEVENT_DETAILRow(item);
                    }
                }
                return dt;
            }
        }
    }
}

namespace FS_REST.FSRESTAURANTTableAdapters
{
    public partial class TableAdapterManager
    {
        public void initialize(MySqlConnection c, FSRESTAURANT dSet, bool fillOrNot, bool clearBeforeFill)
        {
            //instacing object
            EVENT_BOOKINGTableAdapter = new EVENT_BOOKINGTableAdapter();
            EVENT_DETAILTableAdapter = new EVENT_DETAILTableAdapter();
            EVENT_HEADERTableAdapter = new EVENT_HEADERTableAdapter();
            EVENT_PENJUALANTableAdapter = new EVENT_PENJUALANTableAdapter();
            EVENT_PENJUALAN_DETAILTableAdapter = new EVENT_PENJUALAN_DETAILTableAdapter();
            EVENT_TABLETableAdapter = new EVENT_TABLETableAdapter();
            MENU_RESTAURANTTableAdapter = new MENU_RESTAURANTTableAdapter();
            //set connection
            EVENT_BOOKINGTableAdapter.Connection = c;
            EVENT_DETAILTableAdapter.Connection = c;
            EVENT_HEADERTableAdapter.Connection = c;
            EVENT_PENJUALANTableAdapter.Connection = c;
            EVENT_PENJUALAN_DETAILTableAdapter.Connection = c;
            EVENT_TABLETableAdapter.Connection = c;
            MENU_RESTAURANTTableAdapter.Connection = c;
            //set clearBeforeFill
            EVENT_BOOKINGTableAdapter.ClearBeforeFill = clearBeforeFill;
            EVENT_DETAILTableAdapter.ClearBeforeFill = clearBeforeFill;
            EVENT_HEADERTableAdapter.ClearBeforeFill = clearBeforeFill;
            EVENT_PENJUALANTableAdapter.ClearBeforeFill = clearBeforeFill;
            EVENT_PENJUALAN_DETAILTableAdapter.ClearBeforeFill = clearBeforeFill;
            EVENT_TABLETableAdapter.ClearBeforeFill = clearBeforeFill;
            MENU_RESTAURANTTableAdapter.ClearBeforeFill = clearBeforeFill;
            if(fillOrNot)
            {
                try { EVENT_HEADERTableAdapter.Fill(dSet.EVENT_HEADER); } catch { }
                try { EVENT_DETAILTableAdapter.Fill(dSet.EVENT_DETAIL); } catch { }
                try { EVENT_BOOKINGTableAdapter.Fill(dSet.EVENT_BOOKING); } catch { }
                try { EVENT_TABLETableAdapter.Fill(dSet.EVENT_TABLE); } catch { }
                try { MENU_RESTAURANTTableAdapter.Fill(dSet.MENU_RESTAURANT); } catch { }
            }
        }
    }
}
