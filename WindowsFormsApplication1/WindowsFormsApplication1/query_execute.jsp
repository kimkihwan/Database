<%@ page import="java.sql.*"%>
<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=EUC-KR">
<title>Query Result</title>
</head>
<body>
	<div align="center">
		<%
			String param = request.getParameter("sql");
			if(param == null){
				out.println("Wrong Parameter!!");
			}
			int num = Integer.parseInt(param);
			
			Class.forName("oracle.jdbc.driver.OracleDriver");
			Connection Conn = DriverManager.getConnection(
				"jdbc:oracle:thin:@dbmaroon.sogang.ac.kr:1521:DBU2015",
				"DB20101662","920201");
			Statement stmt = Conn.createStatement();
			String sql;
			ResultSet rs;
			ResultSetMetaData rsmd;
			
			switch (num){
			case 1:
				sql = "CREATE TABLE branch("
						+ "branch_name varchar(20) CONSTRAINT bran_pk PRIMARY KEY NOT NULL, "
						+ "branch_city varchar(20), " + "assets number" + ")";
				rs = stmt.executeQuery(sql);
				
				sql = "CREATE TABLE customer("
						+ "customer_name varchar(20) CONSTRAINT customer_pk PRIMARY KEY NOT NULL, "
						+ "customer_street varchar(20), "
						+ "customer_city varchar(20)" + ")";
				rs = stmt.executeQuery(sql);
				
				sql = "CREATE TABLE account("
						+ "account_number varchar(20) CONSTRAINT account_pk PRIMARY KEY NOT NULL, "
						+ "branch_name varchar(20),"
						+ "balance number"
						+ ")";
				rs = stmt.executeQuery(sql);
					
				sql = "alter table account add FOREIGN KEY (branch_name) REFERENCES branch(branch_name) ON DELETE CASCADE";
				rs = stmt.executeQuery(sql);
					
				sql = "CREATE TABLE depositor("
						+ "customer_name varchar(20),"
						+ "account_number varchar(20)"
						+ ")";
				rs = stmt.executeQuery(sql);
				
				sql = "alter table depositor add FOREIGN KEY (customer_name) REFERENCES customer(customer_name) ON DELETE CASCADE";
				rs = stmt.executeQuery(sql);
				sql = "alter table depositor add FOREIGN KEY (account_number) REFERENCES account(account_number) ON DELETE CASCADE";
				rs = stmt.executeQuery(sql);
				
				sql = "CREATE TABLE loan("
						+ "loan_number varchar(20) CONSTRAINT loan_pk PRIMARY KEY NOT NULL, "
						+ "branch_name varchar(20),"
						+ "amount number" 
						+ ")";
				rs = stmt.executeQuery(sql);
				
				sql = "alter table loan add FOREIGN KEY (branch_name) REFERENCES branch(branch_name) ON DELETE CASCADE ";
				rs = stmt.executeQuery(sql);
				
				sql = "CREATE TABLE borrower("
						+ "customer_name varchar(20),"
						+ "loan_number varchar(20)"
						+ ")";
				rs = stmt.executeQuery(sql);
				sql = "alter table borrower add FOREIGN KEY (customer_name) REFERENCES customer(customer_name) ON DELETE CASCADE ";
				rs = stmt.executeQuery(sql);
				sql = "alter table borrower add FOREIGN KEY (loan_number) REFERENCES loan(loan_number) ON DELETE CASCADE";
				rs = stmt.executeQuery(sql);

				sql = "select tname from tab";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;	
		
			case 2:
				sql = "INSERT INTO branch (branch_name, branch_city, assets) VALUES ('Brighton', 'Brooklyn', 7100000)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO branch (branch_name, branch_city, assets) VALUES ('Downtown', 'Brooklyn', 9000000)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO branch (branch_name, branch_city, assets) VALUES ('Mianus', 'Horseneck', 400000)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO branch (branch_name, branch_city, assets) VALUES ('North Town', 'Rye', 3700000)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO branch (branch_name, branch_city, assets) VALUES ('Perryridge', 'Horseneck', 1700000)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO branch (branch_name, branch_city, assets) VALUES ('Pownal', 'Benninghton', 300000)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO branch (branch_name, branch_city, assets) VALUES ('Redwood', 'Palo Alto', 2100000)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO branch (branch_name, branch_city, assets) VALUES ('Round Hill', 'Horseneck', 8000000)";
				rs = stmt.executeQuery(sql);
				
				sql = "INSERT INTO account (account_number, branch_name, balance) VALUES ('A-101', 'Downtown', 500)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO account (account_number, branch_name, balance) VALUES ('A-102', 'Perryridge', 400)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO account (account_number, branch_name, balance) VALUES ('A-201', 'Brighton', 900)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO account (account_number, branch_name, balance) VALUES ('A-215', 'Mianus', 700)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO account (account_number, branch_name, balance) VALUES ('A-217', 'Brighton', 750)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO account (account_number, branch_name, balance) VALUES ('A-222', 'Redwood', 700)";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO account (account_number, branch_name, balance) VALUES ('A-305', 'Round Hill', 350)";
				rs = stmt.executeQuery(sql);

				sql = "INSERT INTO customer (customer_name, customer_street, customer_city) VALUES ('Adams', 'Spring', 'Pittsfield')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO customer (customer_name, customer_street, customer_city) VALUES ('Brooks', 'Senator', 'Brooklyn')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO customer (customer_name, customer_street, customer_city) VALUES ('Curry', 'North', 'Rye')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO customer (customer_name, customer_street, customer_city) VALUES ('Glenn', 'Sand Hill', 'Woodside')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO customer (customer_name, customer_street, customer_city) VALUES ('Green', 'Walnut', 'Stamford')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO customer (customer_name, customer_street, customer_city) VALUES ('Hayes', 'Main', 'Harrison')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO customer (customer_name, customer_street, customer_city) VALUES ('Johnson', 'Alma', 'Palo Alto')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO customer (customer_name, customer_street, customer_city) VALUES ('Jones', 'Main', 'Harrison')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO customer (customer_name, customer_street, customer_city) VALUES ('Lindsay', 'Park', 'Pittsfield')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO customer (customer_name, customer_street, customer_city) VALUES ('Smith', 'North', 'Rye')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO customer (customer_name, customer_street, customer_city) VALUES ('Turner', 'Putnam', 'Stamford')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO customer (customer_name, customer_street, customer_city) VALUES ('Williams', 'Nassau', 'Princeton')";
				rs = stmt.executeQuery(sql);
				
				sql = "INSERT INTO DEPOSITOR (customer_name, account_number) VALUES ('Hayes', 'A-102')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO DEPOSITOR (customer_name, account_number) VALUES ('Johnson', 'A-101')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO DEPOSITOR (customer_name, account_number) VALUES ('Johnson', 'A-201')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO DEPOSITOR (customer_name, account_number) VALUES ('Jones', 'A-217')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO DEPOSITOR (customer_name, account_number) VALUES ('Lindsay', 'A-222')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO DEPOSITOR (customer_name, account_number) VALUES ('Smith', 'A-215')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO DEPOSITOR (customer_name, account_number) VALUES ('Turner', 'A-305')";
				rs = stmt.executeQuery(sql);
				
				sql = "INSERT INTO loan (loan_number, branch_name, amount) VALUES ('L-11', 'Round Hill', '900')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO loan (loan_number, branch_name, amount) VALUES ('L-14', 'Downtown', '1500')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO loan (loan_number, branch_name, amount) VALUES ('L-15', 'Perryridge', '1500')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO loan (loan_number, branch_name, amount) VALUES ('L-16', 'Perryridge', '1300')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO loan (loan_number, branch_name, amount) VALUES ('L-17', 'Downtown', '1000')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO loan (loan_number, branch_name, amount) VALUES ('L-23', 'Redwood', '2000')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO loan (loan_number, branch_name, amount) VALUES ('L-93', 'Mianus', '500')";
				rs = stmt.executeQuery(sql);
				
				sql = "INSERT INTO borrower (customer_name, loan_number) VALUES ('Adams', 'L-16')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO borrower (customer_name, loan_number) VALUES ('Curry', 'L-93')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO borrower (customer_name, loan_number) VALUES ('Hayes', 'L-15')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO borrower (customer_name, loan_number) VALUES ('Johnson', 'L-14')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO borrower (customer_name, loan_number) VALUES ('Jones', 'L-17')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO borrower (customer_name, loan_number) VALUES ('Smith', 'L-11')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO borrower (customer_name, loan_number) VALUES ('Smith', 'L-23')";
				rs = stmt.executeQuery(sql);
				sql = "INSERT INTO borrower (customer_name, loan_number) VALUES ('Williams', 'L-17')";
				rs = stmt.executeQuery(sql);
				
				sql = "select * from account";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();

		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;	
				
			case 3:
				sql = "select distinct branch_name from branch";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
					
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;	
		
			case 4:
				sql = "select loan_number "
					+ "from loan "
					+ "where amount>=1200 "
					+ "AND branch_name = 'Perryridge'";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;	
			
			case 5:
				sql = "select borrower.customer_name, borrower.loan_number, loan.amount "
					+ "from borrower, loan where borrower.loan_number = loan.loan_number";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 6:
				sql = "select borrower.customer_name, borrower.loan_number, loan.amount "
					+ "from borrower, loan where loan.loan_number = borrower.loan_number "
					+ "AND loan.branch_name = 'Perryridge'";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;	
		
			case 7:
				sql = "select customer_name from customer where customer_street like '%Main%'";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;	
		
			case 8:
				sql = "select borrower.customer_name, borrower.loan_number, loan.amount "
					+ "from borrower, loan where loan.loan_number = borrower.loan_number "
					+ "AND loan.branch_name = 'Perryridge' order by borrower.customer_name ASC";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;	
		
			case 9:
				sql = "select customer_name "
					+ "from borrower "
					+ "UNION "
					+ "select customer_name "
					+ "from depositor";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;	
		
			case 10:
				sql = "select customer_name "
					+ "from borrower "
					+ "INTERSECT "
					+ "select customer_name "
					+ "from depositor";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;	
		
			case 11:
				sql = "select CUSTOMER_NAME, SUM_AMOUNT as TOTAL "
					+ "from (select borrower.customer_name CUSTOMER_NAME, sum(loan.amount) SUM_AMOUNT "
							+ "from borrower, loan "
							+ "where borrower.loan_number = loan.loan_number "
							+ "group by customer_name) "
					+ "where SUM_AMOUNT = (select max(SUM_AMOUNT) "
										+ "from (select borrower.customer_name CUSTOMER_NAME, sum(loan.amount) SUM_AMOUNT "
										+ "from borrower, loan "
										+ "where borrower.loan_number = loan.loan_number "
										+ "group by customer_name))"; 
				
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;	
		
			case 12:
				sql = "select distinct customer.customer_name, customer.customer_city "
					+ "from customer,  account, depositor "
					+ "where customer.customer_city <> 'Harrison' "
					+ "AND customer.customer_city <> 'Woodside' "
					+ "AND account.balance >= 500 "
					+ "AND customer.customer_name = depositor.customer_name "
					+ "AND account.account_number = depositor.account_number";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 13:
				sql = "select customer_name "
					+ "from depositor "
					+ "MINUS "
					+ "select customer_name "
					+ "from borrower";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 14:
				sql = "select avg(balance) "
					+ "from account "
					+ "where branch_name = 'Perryridge'";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 15:
				sql = "select branch_name, avg(balance) "
					+ "from account "
					+ "group by branch_name";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 16:
				sql = "select branch_name, count(balance) "
					+ "from account "
					+ "group by branch_name";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 17:
				sql = "select branch_name, avg(balance) "
					+ "from account "
					+ "group by branch_name "
					+ "having avg(balance) >= 800";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 18:
				sql = "select round(avg(balance),2) "
					+ "from account ";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 19:
				sql = "select CUSTOMER_NAME, avg(BALANCE) "
					+ "from (select customer.customer_name CUSTOMER_NAME, account.balance BALANCE "
							+ "from account, depositor, customer "
							+ "where customer.customer_city = 'Palo Alto' "
							+ "AND customer.customer_name = depositor.customer_name "
							+ "AND account.account_number = depositor.account_number) "
					+ "group by CUSTOMER_NAME "
					+ "having count(BALANCE) >= 2";
					
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 20: 
				sql = "select distinct CUSTOMER1.customer_name, CUSTOMER2.customer_name " 
					+ "from customer CUSTOMER1, customer CUSTOMER2 " 
					+ "where CUSTOMER1.customer_city = CUSTOMER2.customer_city " 
					+ "AND CUSTOMER1.customer_name > CUSTOMER2.customer_name";
					
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 21: 
				sql = "select customer.customer_city, customer.customer_name, SUM_TABLE.SUM_AMOUNT " 
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
				
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 22:
				sql = "select branch_name "
					+ "from branch "
					+ "where assets > all(select assets "
										+ "from branch "
										+ "where branch_city = 'Horseneck')";
					
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 23:
				sql = "select branch_name "
					+ "from account "
					+ "group by branch_name "
					+ "having avg(balance) >= all(select avg(balance) "
												+ "from account "
												+ "group by branch_name )";
					
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 24:
				sql = "create or replace view all_customer as select * from ("
					+ "select account.branch_name, depositor.customer_name "
					+ "from account, depositor "
					+ "where account.account_number = depositor.account_number "
					+ "UNION "
					+ "select loan.branch_name, borrower.customer_name "
					+ "from loan, borrower "
					+ "where loan.loan_number = borrower.loan_number)";
				rs = stmt.executeQuery(sql);
				
				sql = "select * from all_customer";
				rs = stmt.executeQuery(sql);
				
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 25:
				sql = "select customer_name "
					+ "from all_customer "
					+ "where branch_name = 'Perryridge'";
				rs = stmt.executeQuery(sql);				
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 26:
				sql = "select branch_name, max(balance) as max_branch "
					+ "from account "
					+ "group by branch_name";
					
				rs = stmt.executeQuery(sql);				
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 27:
					sql = "select branch_name as BIGGER_THAN_BRANCH "
						+ "from (select branch_name, sum(balance) as total "
								+ "from account "
								+ "group by branch_name) "
						+ "where total > (select avg(total) "
										+ "from (select branch_name, sum(balance) as total "
												+ "from account "
												+ "group by branch_name))";
					
					rs = stmt.executeQuery(sql);				
					rsmd = rs.getMetaData();
			%>
			
			<b>Result of <font color="red"><%=sql %></font></b><br>
			<br>
			<table width="50%" border="1" cellpadding="2" cellspacing="0"
				bordercolor="black">
				<tr>
					<%
						for(int i=0;i<rsmd.getColumnCount();i++){
					%>
					<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
					<%
						}
					%>
				</tr>
			<%
				while(rs.next()){
			%>
			<tr>	
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><%=rs.getString(i+1)%></td>
				<%
					}
				%>
			</tr>
			<%
				}
			%>	
			</table>
			
			<%
				break;
			
			case 28:
				sql = "select account.account_number, depositor.customer_name, account.balance "
					+ "from account, depositor "
					+ "where account.account_number = depositor.account_number "
					+ "AND account.balance = (select max(balance) from account) "
					+ "OR (account.account_number = depositor.account_number "
					+ "AND account.balance = (select min(balance) from account))";
				rs = stmt.executeQuery(sql);				
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 29:
				sql = "select loan_number, branch_name, amount, decode(trunc(amount,-3), 0, 'low', "
																					+ "1000, 'medium', "
																					+ "'high') decode_name "
					+ "from loan";
				
				rs = stmt.executeQuery(sql);				
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 30:
				sql = "select customer_name ||''|| customer_street ||''|| customer_city concat_name "
					+ "from customer";
				
				rs = stmt.executeQuery(sql);				
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 31:
				sql = "select customer_name, SUM_AMOUNT as TOT_AMOUNT "
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
					
			
				rs = stmt.executeQuery(sql);				
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 32:
				sql = "delete from loan "
					+ "where amount between 1300 and 1500";
		
				rs = stmt.executeQuery(sql);				
				
				sql = "select * from loan";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 33:
				sql = "update account "
					+ "set balance = round(balance * 1.05, 2) "
					+ "where balance > (select avg(balance) from account ) ";
		
				rs = stmt.executeQuery(sql);				
				
				sql = "select * from account";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 34:
				sql = "update account "
					+ "set balance = "
						+ "case "
							+ "when balance >= 10000 "
							+ "then round(balance * 1.06, 2) "
							+ "else round(balance * 1.05, 2) "
						+ "end";
		
				rs = stmt.executeQuery(sql);				
				
				sql = "select * from account";
				rs = stmt.executeQuery(sql);
				rsmd = rs.getMetaData();
		%>
		
		<b>Result of <font color="red"><%=sql %></font></b><br>
		<br>
		<table width="50%" border="1" cellpadding="2" cellspacing="0"
			bordercolor="black">
			<tr>
				<%
					for(int i=0;i<rsmd.getColumnCount();i++){
				%>
				<td><font color="Red"><%=rsmd.getColumnName(i+1)%></font></td>
				<%
					}
				%>
			</tr>
		<%
			while(rs.next()){
		%>
		<tr>	
			<%
				for(int i=0;i<rsmd.getColumnCount();i++){
			%>
			<td><%=rs.getString(i+1)%></td>
			<%
				}
			%>
		</tr>
		<%
			}
		%>	
		</table>
		
		<%
			break;
		
			case 35:
				sql = "drop view all_customer";
				rs = stmt.executeQuery(sql);
				sql = "drop table depositor";
				rs = stmt.executeQuery(sql);
				sql = "drop table account";
				rs = stmt.executeQuery(sql);
				sql = "drop table borrower";
				rs = stmt.executeQuery(sql);
				sql = "drop table loan";
				rs = stmt.executeQuery(sql);
				sql = "drop table branch";
				rs = stmt.executeQuery(sql);
				sql = "drop table customer";
				rs = stmt.executeQuery(sql);
				sql = "purge recyclebin";
				rs = stmt.executeQuery(sql);			
				
				out.println("성공");
				break;
		
			}
			stmt.close();
			Conn.close();
		%>
	</div>
</body>
</html>