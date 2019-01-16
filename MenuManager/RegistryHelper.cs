using Microsoft.Win32;
using System;
using System.Security.AccessControl;

namespace MenuManager
{
    public static class RegisteryExtension
    {
        public static RegistryKey OpenSubKey(this RegistryKey _, string name)
        {
            return _.OpenSubKey(name, RegistryRights.ChangePermissions);
        }
    }

    internal class RegistryHelper
    {
        #region CONSTRUCTORS

        public RegistryHelper(string programName)
        {
            baseRegistry = Registry.LocalMachine;
            subKey = string.Concat("SOFTWARE\\", programName, "\\");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="baseRegistry">Sample: Registry.LocalMachine</param>
        /// <param name="subKey">Sample: "SOFTWARE\\[program_name]\\"</param>
        public RegistryHelper(RegistryKey baseRegistry, string subKey)
        {
            this.baseRegistry = baseRegistry;
            this.subKey = subKey;
        }

        #endregion CONSTRUCTORS

        #region PROPERTIES

        private string subKey;

        public string SubKey
        {
            get => subKey;
            set => subKey = value;
        }

        private RegistryKey baseRegistry;

        public RegistryKey RegistryKey
        {
            get => baseRegistry;
            set => baseRegistry = value;
        }

        private Exception error;
        public Exception Error => error;

        #endregion PROPERTIES

        public object Read(string keyName)
        {
            try
            {
                error = null;
                RegistryKey key = baseRegistry.OpenSubKey(subKey);
                if (key != null)
                {
                    return key.GetValue(keyName);
                }
            }
            catch (Exception e)
            {
                error = e;
            }
            return null;
        }

        public bool Write(string keyName, object value)
        {
            try
            {
                error = null;
                RegistryKey key = baseRegistry.CreateSubKey(subKey);
                key.SetValue(keyName, value);
                return true;
            }
            catch (Exception e)
            {
                error = e;
            }
            return false;
        }

        private void Test()
        {
            // Registry.CurrentUser.
        }

        public bool DeleteKey(string keyName)
        {
            try
            {
                error = null;
                RegistryKey key = baseRegistry.CreateSubKey(subKey);
                if (key != null)
                {
                    key.DeleteValue(keyName);
                }
                return true;
            }
            catch (Exception e)
            {
                error = e;
            }
            return false;
        }

        public bool DeleteSubKeyTree()
        {
            try
            {
                error = null;
                RegistryKey key = baseRegistry.OpenSubKey(subKey);
                if (key != null)
                {
                    baseRegistry.DeleteSubKeyTree(subKey);
                }
                return true;
            }
            catch (Exception e)
            {
                error = e;
            }
            return false;
        }

        public int SubKeyCount()
        {
            try
            {
                error = null;
                RegistryKey key = baseRegistry.OpenSubKey(subKey);
                if (key != null)
                {
                    return key.SubKeyCount;
                }
            }
            catch (Exception e)
            {
                error = e;
            }
            return 0;
        }

        public int ValueCount()
        {
            try
            {
                error = null;
                RegistryKey key = baseRegistry.OpenSubKey(subKey);
                if (key != null)
                {
                    return key.ValueCount;
                }
            }
            catch (Exception e)
            {
                error = e;
            }
            return 0;
        }
    }
}
