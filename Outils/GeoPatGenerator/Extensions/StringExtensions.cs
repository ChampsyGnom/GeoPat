using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtensions
    {
        public static String ToCamelCase(this string str,String separator)
        {
            List<String> fragments = new List<string>();
            String[] items = str.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (String item in items)
            {
                String fragment = item.Substring (0,1).ToUpper ()+item.Substring (1).ToLower ();
                fragments.Add (fragment);
            }
            return String.Join ("",fragments );
        }
    }
}
