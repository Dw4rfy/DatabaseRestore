using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRestore
{
    public class SQLLoginModeHelper
    {
        private RegistryKey GetKey(string path, RegistryView rv)
        {
            return RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, rv)?.OpenSubKey(path);
        }

        private RegistryKey GetKey(RegistryView rv)
        {
            return GetKey(@"SOFTWARE\Microsoft\Microsoft SQL Server", rv);
        }

        private List<RegistryKey> GetBaseRegistryKeys()
        {
            var list = new List<RegistryKey>();
            var key = GetKey(RegistryView.Registry64);
            if (key != null)
                list.Add(key);

            key = GetKey(RegistryView.Registry32);
            if (key != null)
                list.Add(key);
            return list;
        }

        public bool ChangeLoginMode(int loginMode)
        {
            foreach (var baseKey in GetBaseRegistryKeys())
            {
                foreach (string keyName in baseKey.GetSubKeyNames())
                {
                    if (!keyName.Contains("MSSQL"))
                        continue;
                    try
                    {
                        SetKeyValue(loginMode, keyName + @"\MSSQLServer", baseKey);
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void SetKeyValue(int val, string path, RegistryKey baseKey)
        {
            var key = baseKey.OpenSubKey(path, true);
            if (key == null)
                return;
            key.SetValue("LoginMode", val);
        }
    }
}
