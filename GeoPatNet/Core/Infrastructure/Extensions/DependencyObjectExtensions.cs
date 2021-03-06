﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace System.Windows
{
    public static class DependencyObjectExtensions
    {
        public static T FindChildControl<T>(this DependencyObject control) where T : DependencyObject
        {
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(control, i);
                if (child != null && child is T)
                    return child as T;
                else
                    FindChildControl<T>(child);
            }
            return null;
        }

        public static T FindChildDataContext<T>(this DependencyObject control) where T :  class
        {
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(control, i);
                if (child != null && child is FrameworkElement)
                {
                    FrameworkElement frameworkElement = child as FrameworkElement;
                    if (frameworkElement.DataContext != null && frameworkElement.DataContext is T)
                    {
                        return (T) frameworkElement.DataContext;
                    }
                    else return FindChildDataContext<T>(child);
                }
                else return FindChildDataContext<T>(child);                
            }
            return null;
        }



        public static T FindParentControl<T>(this DependencyObject control) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(control);
            while (parent != null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as T;
        }

    }
}
