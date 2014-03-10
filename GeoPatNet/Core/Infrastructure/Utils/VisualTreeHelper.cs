using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Emash.GeoPatNet.Infrastructure.Utils
{
    public static class VisualTreeHelper
    {
        public static T FindChild<T>(DependencyObject depObj) where T : DependencyObject
        {
            // Confirm obj is valid. 
            if (depObj == null) return null;

            // success case
            if (depObj is T)
                return depObj as T;

            for (int i = 0; i < System.Windows.Media.VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = System.Windows.Media.VisualTreeHelper.GetChild(depObj, i);

                //DFS
                T obj = FindChild<T>(child);

                if (obj != null)
                    return obj;
            }

            return null;
        }
    }
}
