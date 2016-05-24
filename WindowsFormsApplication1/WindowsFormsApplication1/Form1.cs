using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PSTR_Click(object sender, EventArgs e)
        {

        }

        private void SQLTEXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void QUERYBTN_Click(object sender, EventArgs e)
        {
            try
            {
                string oradb = "Data Source="
                    + "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=dblab.sogang.ac.kr)(PORT=1521)))"
                    + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DBU2016)));"
                    + "User Id=db20101611;Password=unesco11;";

                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                OracleDataReader dr;
                int result;

                int pn = (int)this.PNUM.Value;

                switch (pn)
                {
                    case 1:
                        cmd.CommandText =
                            "create table branch("
                            + "branch_name varchar(20) CONSTRAINT branch_pk PRIMARY KEY NOT NULL,"
                            + " branch_city varchar(20),"
                            + " assets number"
                            + ")";
                        this.SQLTEXT.Text = cmd.CommandText;
                        result = cmd.ExecuteNonQuery();
                        this.RESULTTEXT.Text = "BRANCH 테이블이 생성되었습니다";
                        break;
                    case 2:
                        cmd.CommandText = "insert into branch values ('Brighton', 'Brooklyn', 7100000)";
                        this.SQLTEXT.Text = cmd.CommandText;
                        result = cmd.ExecuteNonQuery();
                        this.RESULTTEXT.Text = "BRANCH 테이블에 ('Brighton', 'Brooklyn', 7100000)를 삽입했습니다.";

                        cmd.CommandText = "insert into branch values ('Downtown', 'Brooklyn', 9000000)";
                        this.SQLTEXT.Text += "\n" + cmd.CommandText;
                        result = cmd.ExecuteNonQuery();
                        this.RESULTTEXT.Text += "\n" + "BRANCH 테이블에 ('Downtown', 'Brooklyn', 9000000)를 삽입했습니다";

                        cmd.CommandText = "insert into branch values ('Mianus', 'Horseneck', 4000000)";
                        this.SQLTEXT.Text += "\n" + cmd.CommandText;
                        result = cmd.ExecuteNonQuery();
                        this.RESULTTEXT.Text += "\n" + "BRANCH 테이블에 ('Mianus', 'Horseneck', 4000000)를 삽입했습니다";

                        cmd.CommandText = "insert into branch values ('North Town', 'Rye', 3700000)";
                        this.SQLTEXT.Text += "\n" + cmd.CommandText;
                        result = cmd.ExecuteNonQuery();
                        this.RESULTTEXT.Text += "\n" + "BRANCH 테이블에 ('North Town', 'Rye', 3700000)를 삽입했습니다";

                        cmd.CommandText = "insert into branch values ('Perryridge', 'Horesneck', 1700000)";
                        this.SQLTEXT.Text += "\n" + cmd.CommandText;
                        result = cmd.ExecuteNonQuery();
                        this.RESULTTEXT.Text += "\n" + "BRANCH 테이블에 ('Perryridge', 'Horesneck', 1700000)를 삽입했습니다";

                        cmd.CommandText = "insert into branch values ('Pownal', 'Benninghton', 300000)";
                        this.SQLTEXT.Text += "\n" + cmd.CommandText;
                        result = cmd.ExecuteNonQuery();
                        this.RESULTTEXT.Text += "\n" + "BRANCH 테이블에 ('Pownal', 'Benninghton', 300000)를 삽입했습니다";

                        cmd.CommandText = "insert into branch values ('Redwood', 'Palo Alto', 2100000)";
                        this.SQLTEXT.Text += "\n" + cmd.CommandText;
                        result = cmd.ExecuteNonQuery();
                        this.RESULTTEXT.Text += "\n" + "BRANCH 테이블에 ('Redwood', 'Palo Alto', 2100000)를 삽입했습니다";

                        cmd.CommandText = "insert into branch values ('Round Hill', 'Horseneck', 8000000)";
                        this.SQLTEXT.Text += "\n" + cmd.CommandText;
                        result = cmd.ExecuteNonQuery();
                        this.RESULTTEXT.Text += "\n" + "BRANCH 테이블에 ('Round Hill', 'Horseneck', 8000000)를 삽입했습니다";

                        break;

                    case 3:
                        cmd.CommandText = "select distinct branch_name from branch";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        string coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        string separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        string rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 35:
                        cmd.CommandText = "drop table branch";
                        this.SQLTEXT.Text = cmd.CommandText;
                        result = cmd.ExecuteNonQuery();
                        this.RESULTTEXT.Text = "BRANCH 테이블을 삭제 하였습니다";
                        break;
                }

                conn.Dispose();
            }
            catch (Exception ex)
            {
                this.RESULTTEXT.Text = ex.ToString();
            }
        }

        private void RESULTTEXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void PNUM_ValueChanged(object sender, EventArgs e)
        {
            int num = (int)this.PNUM.Value;

            switch (num)
            {
                case 1:
                    this.PSTR.Text = "1. 다음 ER 다이어그램을 Oracle DBMS에 입력하시오 (create)";
                    break;
                case 2:
                    this.PSTR.Text = "2. 다음 데이터를 입력하시오 (insert)";
                    break;
                case 3:
                    this.PSTR.Text = "3. 중복되지 않은 모든 지점들의 이름을 구하라 (distinct)";
                    break;
                case 35:
                    this.PSTR.Text = "35. 지금가지 생성된 View와 릴레이션을 삭제하라 (drop)";
                    break;
                default:
                    this.PSTR.Text = "";
                    break;
            }
        }
    }
}
