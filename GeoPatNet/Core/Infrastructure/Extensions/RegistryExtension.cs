using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Win32 
{
    public static class RegistryExtension
    {
        public static void Clear(this RegistryKey source)
        {
            String[] names = source.GetSubKeyNames ();
            foreach (String name in names)
            {source.DeleteSubKeyTree(name);}
        }
        public static RegistryKey OpenOrCreateKey(this RegistryKey source,String name)
        {
            RegistryKey result = null;
            List<String> names = (from s in source.GetSubKeyNames() select s.ToUpper ()).ToList ();
            bool find = false;
            foreach (String s in names)
            {
                if (s.Equals(name))
                { find = true; }
            }
            if (!find)
            { result = source.CreateSubKey(name); }
            else
            { result = source.OpenSubKey(name,true); }
            return result;
        }

        public static RegistryKey OpenOrCreateCompanyKey(this RegistryKey source)
        {
            RegistryPermission f = new RegistryPermission(RegistryPermissionAccess.AllAccess, "HKEY_LOCAL_MACHINE\\SOFTWARE");
            RegistryKey keySoftware = source.OpenOrCreateKey("SOFTWARE");
            AssemblyCompanyAttribute companyAttribute = System.Reflection.Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute)).FirstOrDefault() as AssemblyCompanyAttribute;
            RegistryKey keyCompany = keySoftware.OpenOrCreateKey(companyAttribute.Company);
            return keyCompany;
        }
    }
}
