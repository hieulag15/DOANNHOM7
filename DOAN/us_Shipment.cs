using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class us_Shipment : UserControl
    {
        public us_Shipment()
        {
            InitializeComponent();
        }

        DataTable dtShipment = new DataTable();
        Shipment dbShipment = new Shipment();
        DataTable dtDetailShipment = new DataTable();
        Shipment dbDetailShipment = new Shipment();
        string id_shipment;

        public void LoadShipment()
        {
            try
            {
                dtShipment.Clear();
                DataSet ds = dbShipment.getShipment();
                dtShipment = ds.Tables[0];
                dgv_Shipment.DataSource = dtShipment;
            }
            catch (SqlException)
            {
                MessageBox.Show("Chưa có lô hàng nào");
            }
        }

        public void LoadDetailShipment()
        {
            try
            {
                dtDetailShipment.Clear();
                DataSet ds = dbShipment.getDetailShipment(id_shipment);
                dtDetailShipment = ds.Tables[0];
                dgv_DetailShipment.DataSource = dtDetailShipment;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không có mặt hàng nào");
            }
        }

        private void us_Shipment_Load(object sender, EventArgs e)
        {
            LoadShipment();
        }

        private void dgv_Shipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_Shipment.CurrentRow.Index;
            id_shipment = dgv_Shipment.Rows[i].Cells[4].Value.ToString();
            LoadDetailShipment();
        }

        private void btn_ThemLoHang_Click(object sender, EventArgs e)
        {
            pnl_ThemLoHang.Visible = true;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            pnl_ThemLoHang.Visible = false;
            txt_malohang.Text = "";
            txt_maNCC.Text = "";
        }
    }
}
