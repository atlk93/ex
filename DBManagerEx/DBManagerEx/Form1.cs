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
        
        private void mnuMigration_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            string buf = sr.ReadLine();      // 첫번째 Line에는 각 Column의 Header Text가 들어가 있다
            string[] sArr = buf.Split(',');  // ........ ','로 구분
            for(int i=0;i<sArr.Length;i++)
            {
                dataGrid.Columns.Add(sArr[i], sArr[i]);
            }
            while (true)
            {
                buf = sr.ReadLine();
                if (buf == null) break;
                sArr = buf.Split(',');  // string array
                dataGrid.Rows.Add(sArr);    // Rows.Add ,mmethod의 4번째오버로드
            }
            sr.Close();
        }

        private void mnuSaveCSV_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            string buf = "";
            for(int i=0;i<dataGrid.ColumnCount;i++)
            {
                buf += dataGrid.Columns[i].HeaderText;
                if (i < dataGrid.ColumnCount - 1) buf += ",";
            }
            sw.Write(buf+"\r\n");

            for(int k=0;k<dataGrid.RowCount;k++)
            {
                buf = "";
                for (int i = 0; i < dataGrid.ColumnCount; i++)
                {
                    buf += dataGrid.Rows[k].Cells[i].Value;
                    if (i < dataGrid.ColumnCount - 1) buf += ",";
                }
                sw.Write(buf + "\r\n");
            }
            sw.Close();
        }
    }
}
