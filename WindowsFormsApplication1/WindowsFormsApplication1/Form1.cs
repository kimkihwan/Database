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

                    case 4:
                        cmd.CommandText = "select loan_number"
                            + "from loan "
                            + "where amount>=1200 "
                            + "AND branch_name = 'Perryridge'";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 5:
                        cmd.CommandText = "select borrower.customer_name, borrower.loan_number, loan.amount "
                            + "from borrower, loan where borrower.loan_number = loan.loan_number";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 6:
                        cmd.CommandText = "select borrower.customer_name, borrower.loan_number, loan.amount "
                    + "from borrower, loan where loan.loan_number = borrower.loan_number "
                    + "AND loan.branch_name = 'Perryridge'";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 7:
                        cmd.CommandText = "select customer_name from customer where customer_street like '%Main%'";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 8:
                        cmd.CommandText = "select borrower.customer_name, borrower.loan_number, loan.amount "
                            + "from borrower, loan where loan.loan_number = borrower.loan_number "
                            + "AND loan.branch_name = 'Perryridge' order by borrower.customer_name ASC";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 9:
                        cmd.CommandText = "select customer_name "
                                + "from borrower "
                                + "UNION "
                                + "select customer_name "
                                + "from depositor";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 10:
                        cmd.CommandText = "select customer_name "
                            + "from borrower "
                            + "INTERSECT "
                            + "select customer_name "
                            + "from depositor";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 11:
                        cmd.CommandText = "select CUSTOMER_NAME, SUM_AMOUNT as TOTAL "
                            + "from (select borrower.customer_name CUSTOMER_NAME, sum(loan.amount) SUM_AMOUNT "
                                + "from borrower, loan "
                                + "where borrower.loan_number = loan.loan_number "
                                + "group by customer_name) "
                            + "where SUM_AMOUNT = (select max(SUM_AMOUNT) "
                                        + "from (select borrower.customer_name CUSTOMER_NAME, sum(loan.amount) SUM_AMOUNT "
                                        + "from borrower, loan "
                                        + "where borrower.loan_number = loan.loan_number "
                                        + "group by customer_name))";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 12:
                        cmd.CommandText = "select distinct customer.customer_name, customer.customer_city "
                            + "from customer,  account, depositor "
                            + "where customer.customer_city <> 'Harrison' "
                            + "AND customer.customer_city <> 'Woodside' "
                            + "AND account.balance >= 500 "
                            + "AND customer.customer_name = depositor.customer_name "
                            + "AND account.account_number = depositor.account_number";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 13:
                        cmd.CommandText = "select customer_name "
                            + "from depositor "
                            + "MINUS "
                            + "select customer_name "
                            + "from borrower";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 14:
                        cmd.CommandText = "select avg(balance) "
                            + "from account "
                            + "where branch_name = 'Perryridge'";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 15:
                        cmd.CommandText = "select branch_name, avg(balance) "
                            + "from account "
                            + "group by branch_name";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 16:
                        cmd.CommandText = "select branch_name, count(balance) "
                            + "from account "
                            + "group by branch_name";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 17:
                        cmd.CommandText = "select branch_name, avg(balance) "
                            + "from account "
                            + "group by branch_name "
                            + "having avg(balance) >= 800";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 18:
                        cmd.CommandText = "select round(avg(balance),2) "
                             + "from account ";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 19:
                        cmd.CommandText = "select CUSTOMER_NAME, avg(BALANCE) "
                            + "from (select customer.customer_name CUSTOMER_NAME, account.balance BALANCE "
                                    + "from account, depositor, customer "
                                    + "where customer.customer_city = 'Palo Alto' "
                                    + "AND customer.customer_name = depositor.customer_name "
                                    + "AND account.account_number = depositor.account_number) "
                            + "group by CUSTOMER_NAME "
                            + "having count(BALANCE) >= 2";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 20:
                        cmd.CommandText = "select distinct CUSTOMER1.customer_name, CUSTOMER2.customer_name "
                            + "from customer CUSTOMER1, customer CUSTOMER2 "
                            + "where CUSTOMER1.customer_city = CUSTOMER2.customer_city "
                            + "AND CUSTOMER1.customer_name > CUSTOMER2.customer_name";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 21:
                        cmd.CommandText = "select customer.customer_city, customer.customer_name, SUM_TABLE.SUM_AMOUNT "
                            + "from customer, (select borrower.customer_name, sum(loan.amount) SUM_AMOUNT "
                                                + "from borrower, loan "
                                                + "where borrower.loan_number = loan.loan_number "
                                                + "group by borrower.customer_name) SUM_TABLE "
                            + "where customer.customer_name = SUM_TABLE.customer_name "
                            + "AND (customer.customer_city, SUM_TABLE.SUM_AMOUNT) "
                            + "IN (select customer.customer_city, max(SUM_TABLE.SUM_AMOUNT) "
                                + "from customer, (select borrower.customer_name, sum(loan.amount) SUM_AMOUNT "
                                                    + "from borrower, loan "
                                                    + "where borrower.loan_number = loan.loan_number "
                                                    + "group by borrower.customer_name) SUM_TABLE "
                                + "where customer.customer_name = SUM_TABLE.customer_name "
                                + "group by customer.customer_city)";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 22:
                        cmd.CommandText = "select branch_name "
                            + "from branch "
                            + "where assets > all(select assets "
                                                + "from branch "
                                                + "where branch_city = 'Horseneck')";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 23:
                        cmd.CommandText = "select branch_name "
                            + "from account "
                            + "group by branch_name "
                            + "having avg(balance) >= all(select avg(balance) "
                                                        + "from account "
                                                        + "group by branch_name )";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 24:
                        cmd.CommandText = "create or replace view all_customer as select * from ("
                            + "select account.branch_name, depositor.customer_name "
                            + "from account, depositor "
                            + "where account.account_number = depositor.account_number "
                            + "UNION "
                            + "select loan.branch_name, borrower.customer_name "
                            + "from loan, borrower "
                            + "where loan.loan_number = borrower.loan_number)";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 25:
                        cmd.CommandText = "select customer_name "
                            + "from all_customer "
                            + "where branch_name = 'Perryridge'";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 26:
                        cmd.CommandText = "select branch_name, max(balance) as max_branch "
                            + "from account "
                            + "group by branch_name";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 27:
                        cmd.CommandText = "select branch_name as BIGGER_THAN_BRANCH "
                            + "from (select branch_name, sum(balance) as total "
                                    + "from account "
                                    + "group by branch_name) "
                            + "where total > (select avg(total) "
                                            + "from (select branch_name, sum(balance) as total "
                                                    + "from account "
                                                    + "group by branch_name))";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 28:
                        cmd.CommandText = "select account.account_number, depositor.customer_name, account.balance "
                            + "from account, depositor "
                            + "where account.account_number = depositor.account_number "
                            + "AND account.balance = (select max(balance) from account) "
                            + "OR (account.account_number = depositor.account_number "
                            + "AND account.balance = (select min(balance) from account))";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 29:
                        cmd.CommandText = "select loan_number, branch_name, amount, decode(trunc(amount,-3), 0, 'low', "
                                                                                    + "1000, 'medium', "
                                                                                    + "'high') decode_name "
                                                                                    + "from loan";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 30:
                        cmd.CommandText = "select customer_name ||''|| customer_street ||''|| customer_city concat_name "
                            + "from customer";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 31:
                        cmd.CommandText = "select customer_name, SUM_AMOUNT as TOT_AMOUNT "
                            + "from (select customer_name, sum(amount) SUM_AMOUNT "
                                    + "from (select borrower.customer_name CUSTOMER_NAME, loan.amount AMOUNT "
                                            + "from borrower, loan "
                                            + "where borrower.loan_number = loan.loan_number )"
                                    + "group by customer_name ) "
                            + "where SUM_AMOUNT < (select avg(SUM_AMOUNT) "
                                                + "from (select customer_name, sum(amount) SUM_AMOUNT "
                                                        + "from (select borrower.customer_name CUSTOMER_NAME, loan.amount AMOUNT "
                                                            + "from borrower, loan "
                                                            + "where borrower.loan_number = loan.loan_number )"
                                                            + "group by customer_name )) ";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 32:
                        cmd.CommandText = "delete from loan "
                            + "where amount between 1300 and 1500";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        cmd.CommandText = "select * from loan";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 33:
                        cmd.CommandText = "update account "
                            + "set balance = round(balance * 1.05, 2) "
                            + "where balance > (select avg(balance) from account ) ";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        cmd.CommandText = "select * from account";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                                rowText += "\t" + dr.GetString(i);
                            rowText += "\n";
                        }

                        this.RESULTTEXT.Text = "\n" + coluomnName + "\n" + separatingline + "\n" + rowText;
                        break;

                    case 34:
                        cmd.CommandText = "update account "
                            + "set balance = "
                                + "case "
                                    + "when balance >= 10000 "
                                    + "then round(balance * 1.06, 2) "
                                    + "else round(balance * 1.05, 2) "
                                + "end";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        cmd.CommandText = "select * from account";
                        this.SQLTEXT.Text = cmd.CommandText;
                        dr = cmd.ExecuteReader();
                        coluomnName = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            coluomnName += "\t" + dr.GetName(i);
                        separatingline = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            separatingline += "\t" + "===========";
                        rowText = "";
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
