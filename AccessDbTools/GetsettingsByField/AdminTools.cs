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

        
    }
}
