using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseRestore
{
    class SqlHelper
    {
        public enum LogicNameTypes
        {
            MainLogicName,
            LogLogicName
        }

        public static Dictionary<LogicNameTypes, string> FindLogicNames(SqlConnection con, string backupFilePath)
        {
            Dictionary<LogicNameTypes, string> dic = new Dictionary<LogicNameTypes, string>();
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = $@"RESTORE FILELISTONLY FROM DISK = N'{backupFilePath}'";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(reader.GetOrdinal("TYPE")) == "D")
                            dic.Add(LogicNameTypes.MainLogicName, reader.GetString(reader.GetOrdinal("LogicalName")));
                        else
                            dic.Add(LogicNameTypes.LogLogicName, reader.GetString(reader.GetOrdinal("LogicalName")));
                    }
                }
            }
            return dic;
        }

        public static bool DBDoesExist(SqlConnection con, string restoreName)
        {
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = @"SELECT name FROM sys.sysdatabases";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(reader.GetOrdinal("name")) == restoreName)
                            return true;
                    }
                }
            }
            return false;
        }

        public static bool IsSAEnabled(SqlConnection con)
        {
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = @"SELECT name, is_disabled FROM sys.server_principals where name = 'SA'";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        if (reader.GetBoolean(reader.GetOrdinal("is_disabled")) == false)
                            return true;
                }
            }
            return false;
        }

        public static string FindDataFolderPath(SqlConnection con)
        {
            var sql = "select InstanceDefaultDataPath = serverproperty('InstanceDefaultDataPath')";
            string dataFolderPath = null;
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = sql;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        dataFolderPath = reader.GetString(reader.GetOrdinal("InstanceDefaultDataPath"));
                }
            }
            return dataFolderPath;
        }

        public static string CheckSqlLoginMode(SqlConnection con)
        {
            var sql = "EXEC master.sys.xp_loginconfig 'login mode'";
            string sqlLoginMode = null;
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = sql;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        sqlLoginMode = reader.GetString(reader.GetOrdinal("config_value"));
                }
            }
            return sqlLoginMode;
        }
    }
}
