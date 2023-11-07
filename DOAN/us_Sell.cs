using DOAN.BTN_CONTROLS;
using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class us_Sell : UserControl
    {
        Product product = new Product();
        Bill bill = new Bill();
        Detail_Bill detail_Bill = new Detail_Bill();
        public string eid;
        private bool hasChanges = false;

        public us_Sell()
        {
            InitializeComponent();
        }

        private void us_Sell_Load(object sender, EventArgs e)
        {
            Panel_Product.Controls.Clear();
            product.getProductList(Panel_Product, Panel_ProductPay);

            Panel_ProductPay.ControlAdded += Panel_ProductPay_ControlAdded;
        }

        void loadTotalMoney()
        {
            Decimal total = 0;
            foreach (UserControl userControl in Panel_ProductPay.Controls)
            {
                // Kiểm tra nếu UserControl là kiểu của UserControl bạn đã tạo
                if (userControl is us_Product_Pay)
                {
                    us_Product_Pay yourUserControl = (us_Product_Pay)userControl;
                    total += + Decimal.Parse(yourUserControl.ItemPrice.ToString()) * Decimal.Parse(yourUserControl.ItemQuantity.ToString());
                }

            }
            txt_TotalMoney.Text = total.ToString();
        }

        private void Panel_ProductPay_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is us_Product_Pay usProductPay)
            {
                usProductPay.ContentChanged += ItemContentChanged;
            }
            loadTotalMoney();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hasChanges)
            {
                // Đặt lại cờ
                hasChanges = false;
            }
        }


        private void ItemContentChanged(object sender, EventArgs e)
        {
            // Đánh dấu rằng có sự thay đổi
            hasChanges = true;

            // Thực hiện hành động khi có sự thay đổi
            loadTotalMoney();
        }

        private void txt_TotalMoney_TextChanged(object sender, EventArgs e)
        {
            txt_ThanhTien.Text = (Decimal.Parse(txt_TotalMoney.Text) - Decimal.Parse(txt_KhuyenMai.Text)).ToString();
        }

        private void txt_KhuyenMai_TextChanged(object sender, EventArgs e)
        {
            Decimal sale;
            if (txt_KhuyenMai.Text.Length == 0)
            {
                sale = 0;
            }
            else
            {
                sale = Decimal.Parse(txt_KhuyenMai.Text);
            }
            txt_ThanhTien.Text = (Decimal.Parse(txt_TotalMoney.Text) - sale).ToString();
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            string b_id = bill.CreateAutoID();
            try
            {
                bill.addBill(b_id.Trim(), Convert.ToDateTime(DateTime.Now), (decimal)Convert.ToDouble(txt_ThanhTien.Text.Trim()), (decimal)Convert.ToDouble(txt_KhuyenMai.Text.Trim()), txt_SoDienThoai.Text.Trim(), eid.Trim());
                foreach (UserControl userControl in Panel_ProductPay.Controls)
                {
                    // Kiểm tra nếu UserControl là kiểu của UserControl bạn đã tạo
                    if (userControl is us_Product_Pay)
                    {
                        us_Product_Pay yourUserControl = (us_Product_Pay)userControl;
                        detail_Bill.addDetailBill(b_id.Trim(), yourUserControl.ItemID.ToString().Trim(), (int)Convert.ToInt64(yourUserControl.ItemQuantity.ToString().Trim()));
                    }

                }
                MessageBox.Show("Them bill thanh cong");
            }
            catch
            {
                MessageBox.Show("Them bill that bai");
            }
        }
    }
}
