using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectTelegraphicTransfer
{
    public partial class UCPage3 : UserControl
    {
        public UCPage3()
        {
            InitializeComponent();
        }

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                lb_Aname.Text = _name;
            }
        }

        private string _address;
        public string address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                lbl_adress.Text = _address;
            }
        }

        private string _Bname;
        public string Bname
        {
            get
            {
                return _Bname;
            }
            set
            {
                _Bname = value;
                lbl_bname.Text = _Bname;
            }
        }

        private string _baaddress;
        public string baaddress
        {
            get
            {
                return _baaddress;
            }
            set
            {
                _baaddress = value;
                lbl_Baddress1.Text =  _baaddress;
            }
        }

        private string _bbaddress;
        public string bbaddress
        {
            get
            {
                return _bbaddress;
            }
            set
            {
                _bbaddress = value;
                lbl_Baddress2.Text =  _bbaddress;
            }
        }

        private string _purposeb;
        public string purposeb
        {
            get
            {
                return _purposeb;
            }
            set
            {
                _purposeb = value;
                lbl_purpose1.Text = _purposeb;
            }
        }

        private string _InNo;
        public string InNo
        {
            get
            {
                return _InNo;
            }
            set
            {
                _InNo = value;
                Lbl_bin.Text = _InNo;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UCPage3_Load(object sender, EventArgs e)
        {
            lb_Aname.Text = _name;
            lb_name.Text = _address;
            lbl_bname.Text = _Bname;
            lbl_Baddress1.Text = _baaddress;
            lbl_Baddress2.Text = _bbaddress;
            lbl_purpose1.Text = _purposeb;
            Lbl_bin.Text = _InNo;
        }



        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel25_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
