using MySql.Data.MySqlClient;
namespace FS_REST
{


    partial class FSRESTAURANT
    {
    }
}

namespace FS_REST.FSRESTAURANTTableAdapters {
    
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
            MENU_HEADERTableAdapter = new MENU_HEADERTableAdapter();
            PELANGGAN_RESTAURANTTableAdapter = new PELANGGAN_RESTAURANTTableAdapter();
            PEGAWAI_RESTAURANTTableAdapter = new PEGAWAI_RESTAURANTTableAdapter();
            //set connection
            EVENT_BOOKINGTableAdapter.Connection = c;
            EVENT_DETAILTableAdapter.Connection = c;
            EVENT_HEADERTableAdapter.Connection = c;
            EVENT_PENJUALANTableAdapter.Connection = c;
            EVENT_PENJUALAN_DETAILTableAdapter.Connection = c;
            EVENT_TABLETableAdapter.Connection = c;
            MENU_HEADERTableAdapter.Connection = c;
            PELANGGAN_RESTAURANTTableAdapter.Connection = c;
            PEGAWAI_RESTAURANTTableAdapter.Connection = c;
            //set clearBeforeFill
            EVENT_BOOKINGTableAdapter.ClearBeforeFill = clearBeforeFill;
            EVENT_DETAILTableAdapter.ClearBeforeFill = clearBeforeFill;
            EVENT_HEADERTableAdapter.ClearBeforeFill = clearBeforeFill;
            EVENT_PENJUALANTableAdapter.ClearBeforeFill = clearBeforeFill;
            EVENT_PENJUALAN_DETAILTableAdapter.ClearBeforeFill = clearBeforeFill;
            EVENT_TABLETableAdapter.ClearBeforeFill = clearBeforeFill;
            MENU_HEADERTableAdapter.ClearBeforeFill = clearBeforeFill;
            PELANGGAN_RESTAURANTTableAdapter.ClearBeforeFill = clearBeforeFill;
            PEGAWAI_RESTAURANTTableAdapter.ClearBeforeFill = clearBeforeFill;
            if (fillOrNot)
            {
                try { EVENT_HEADERTableAdapter.Fill(dSet.EVENT_HEADER); } catch { }
                try { EVENT_DETAILTableAdapter.Fill(dSet.EVENT_DETAIL); } catch { }
                try { EVENT_BOOKINGTableAdapter.Fill(dSet.EVENT_BOOKING); } catch { }
                try { EVENT_TABLETableAdapter.Fill(dSet.EVENT_TABLE); } catch { }
                try { MENU_HEADERTableAdapter.Fill(dSet.MENU_HEADER); } catch { }
                try { PELANGGAN_RESTAURANTTableAdapter.Fill(dSet.PELANGGAN_RESTAURANT); } catch { }
                try { PEGAWAI_RESTAURANTTableAdapter.Fill(dSet.PEGAWAI_RESTAURANT); } catch { }
            }
        }
    }
    public partial class EVENT_HEADERTableAdapter {
    }
}
