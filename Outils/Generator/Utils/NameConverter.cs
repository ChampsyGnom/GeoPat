using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.Utils
{
    public static  class NameConverter
    {
        public static String TableNameToEntityName(String tableName)
        {
            List<String> items = tableName.Split("_".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList ();
            List<String> formattedItems = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ToLower().Equals("cd"))
                {
                    formattedItems.Add("Code");
                }
                else
                {
                    String formattedItem = items[i].Substring(0, 1).ToUpper() + items[i].Substring(1).ToLower();
                    formattedItems.Add(formattedItem);
                }

            }
            return String.Join("", formattedItems);
        }

        public static String ColumnNameToPropertyName(String columnName)
        {
            List<String> items = columnName.Split("_".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            List<String> formattedItems = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ToLower().Equals("cd"))
                {
                    formattedItems.Add("Code");
                }
                else
                {
                    String formattedItem = items[i].Substring(0, 1).ToUpper() + items[i].Substring(1).ToLower();
                    formattedItems.Add(formattedItem);
                }

            }
            return String.Join("", formattedItems);
        }
    }
}
