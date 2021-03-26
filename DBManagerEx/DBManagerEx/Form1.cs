using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBManagerEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCom = new SqlCommand();

        private void mnuNew_Click(object sender, EventArgs e)
        {
            dataGrid.Rows.Clear();          // db에서 클리어는 row먼저, 생성은 column먼저
            dataGrid.Columns.Clear();

            sbPanel1.Text = "DB File name";
            sbPanel2.Text = "Table List";
            sbPanel2.DropDownItems.Clear();
            sbPanel3.Text = "Initialized";

            sqlConn.Close();
        }
        //수정수정수정
        private void mnuMigration_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            string buf = sr.ReadLine();      // 첫번째 Line에는 각 Column의 Header Text가 들어가 있다
            string[] sArr = buf.Split(',');  // ........ ','로 구분
        }
    }
}
