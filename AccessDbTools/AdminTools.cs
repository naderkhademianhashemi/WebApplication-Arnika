using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace AccessDbTools
{
    public static class AdminTools
    {
        public static string GetCnStr()
        {
            return RSRC.ClassLibrary.RSSET.CNSTR;
        }
        public static string GetSettingByField(string FieldName, string conStr)
        {
            string query = "Select * From tblSetting Where sID = 1";
            string strRet = "";
            using (var CN = new OleDbConnection())
            {
                CN.ConnectionString = conStr;
                CN.Open();
                var cmd = new OleDbCommand()
                {
                    CommandText = query,
                    Connection = CN
                };
                var RD = cmd.ExecuteReader();
                if (RD.Read() && !DBNull.Value.Equals(FieldName))
                    strRet = RD[FieldName].ToString();
                RD.Close();
                cmd.Dispose();
                CN.Close();
                return strRet;
            }
        }

        public static string GetInfoByTable(string fieldName, string tbl, string conStr)
        {
            string strRet = "";
            string Q = "Select * From " + tbl;
            using (var CN = new OleDbConnection())
            {
                CN.ConnectionString = conStr;
                CN.Open();
                var cmd = new OleDbCommand()
                {
                    CommandText = Q,
                    Connection = CN
                };
                var RD = cmd.ExecuteReader();
                if (RD.Read() && !DBNull.Value.Equals(fieldName))
                    strRet = RD[fieldName].ToString();
                RD.Close();
                cmd.Dispose();
                CN.Close();
                return strRet;
            }
        }

        public static List<Categories> GetComboList(string query, string textField, string valueField, string conStr)
        {
            var res = new List<Categories>();
            using (var CN = new OleDbConnection())
            {
                CN.ConnectionString = conStr;
                CN.Open();
                var cmd = new OleDbCommand()
                {
                    CommandText = query,
                    Connection = CN
                };
                var RD = cmd.ExecuteReader();
                while (RD.Read())
                {
                    res.Add(new Categories
                    {
                        catID = int.Parse(RD[valueField].ToString()),
                        catName = RD[textField].ToString()
                    });
                }
                RD.Close();
                cmd.Dispose();
                CN.Close();
                return res;
            }
        }

        public static List<Categories> GetComboList(string query, string textField, string valueField)
        {
            var res = new List<Categories>();
            using (var CN = new OleDbConnection())
            {
                CN.ConnectionString = GetCnStr();
                CN.Open();
                var cmd = new OleDbCommand()
                {
                    CommandText = query,
                    Connection = CN
                };
                var RD = cmd.ExecuteReader();
                while (RD.Read())
                {
                    res.Add(new Categories
                    {
                        catID = int.Parse(RD[valueField].ToString()),
                        catName = RD[textField].ToString()
                    });
                }
                RD.Close();
                cmd.Dispose();
                CN.Close();
                return res;
            }
        }
        public static string GetInfoByTable(string fieldName, string tbl)
        {
            string strRet = "";
            string Q = "Select * From " + tbl;
            using (var CN = new OleDbConnection())
            {
                CN.ConnectionString = GetCnStr();
                CN.Open();
                var cmd = new OleDbCommand()
                {
                    CommandText = Q,
                    Connection = CN
                };
                var RD = cmd.ExecuteReader();
                if (RD.Read() && !DBNull.Value.Equals(fieldName))
                    strRet = RD[fieldName].ToString();
                RD.Close();
                cmd.Dispose();
                CN.Close();
                return strRet;
            }
        }
        public static string GetSettingByField(string FieldName)
        {
            string query = "Select * From tblSetting Where sID = 1";
            string strRet = "";
            using (var CN = new OleDbConnection())
            {
                CN.ConnectionString = GetCnStr();
                CN.Open();
                var cmd = new OleDbCommand()
                {
                    CommandText = query,
                    Connection = CN
                };
                var RD = cmd.ExecuteReader();
                if (RD.Read() && !DBNull.Value.Equals(FieldName))
                    strRet = RD[FieldName].ToString();
                RD.Close();
                cmd.Dispose();
                CN.Close();
                return strRet;
            }
        }
    }
}
