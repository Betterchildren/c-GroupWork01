using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace ClassLibrary1
{
    class ClassTable
    {
        #region Manager表
        public static DataTable getManagerTable()
        {
            DataTable dt = new DataTable("Manager");
            #region Manager表结构
            DataColumn dc1 = new DataColumn("ID", Type.GetType("System.Int16"));
            DataColumn dc2 = new DataColumn("No", Type.GetType("System.String"));//工号
            DataColumn dc3 = new DataColumn("name", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("pwd", Type.GetType("System.String"));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            #endregion
            #region     具体数据
            DataRow dr = dt.NewRow();
            dr["ID"] = 1;
            dr["No"] = "admin";
            dr["name"] = "admin";
            dr["pwd"] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["ID"] = 5;
            dr["No"] = "2015001";
            dr["name"] = "zs";
            dr["pwd"] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow(); 
            dr["ID"] = 6;
            dr["No"] = "2015001";
            dr["name"] = "ls";
            dr["pwd"] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            #endregion
            return dt;
        }
        #endregion
        #region Data表
        public static DataTable getDataTable(string file)
        {
            DataTable dt = new DataTable("Data");
            #region Data表结构
            DataColumn dc1 = new DataColumn("DateTime", Type.GetType("System.DateTime"));
            DataColumn dc2 = new DataColumn("Temperature", Type.GetType("System.Decimal"));
            DataColumn dc3 = new DataColumn("Humidity", Type.GetType("System.Decimal"));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            #endregion
            #region 具体数据
            DataRow dr;
            StreamReader sr = new StreamReader(file,Encoding.ASCII);
            string str = sr.ReadLine();
            while (str != null)
            {
                string[] a = str.Split(',');
                dr = dt.NewRow();
                dr[0] = DateTime.Parse(a[0]);
                dr[1] = Decimal.Parse(a[1]);
                dr[2] = Decimal.Parse(a[2]);
                dt.Rows.Add(dr);
                str = sr.ReadLine();
            }
            sr.Dispose();
            #endregion
            return dt;
        }
        #endregion
    }
    
}
