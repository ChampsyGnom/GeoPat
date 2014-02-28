﻿using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Emash.GeoPatNet.Presentation.Implementation.Views
{
    /// <summary>
    /// Logique d'interaction pour GenericDataLabel.xaml
    /// </summary>
    public partial class GenericDataLabel : UserControl
    {
        public String FieldPath
        {
            get { return (String)GetValue(FieldPathProperty); }
            set { SetValue(FieldPathProperty, value); }
        }

        public static readonly DependencyProperty FieldPathProperty =
            DependencyProperty.Register("FieldPath", typeof(String), typeof(GenericDataLabel), new PropertyMetadata(new PropertyChangedCallback(OnFieldPathChange)));
       
        private static void OnFieldPathChange(DependencyObject source, DependencyPropertyChangedEventArgs arg)
        {
            if (source != null && source is GenericDataLabel)
            {
                GenericDataLabel genericDataGridView = source as GenericDataLabel;
                genericDataGridView.OnFieldPathChange(arg.OldValue as String, arg.NewValue as String);

            }
        }

        private void OnFieldPathChange(string oldPath, string newPath)
        {
            this.UpdateLabel();
        }

        private void UpdateLabel()
        {
            if (this.DataContext != null)
            {
                if (this.DataContext.GetType().IsGenericType)
                {
                    Type[] genericTypes = this.DataContext.GetType().GetGenericArguments();
                    if (genericTypes.Length == 1)
                    {
                        Type modelType = genericTypes[0];
                        this.UpdateLabel(this.FieldPath, modelType);
                    }
                }


            }
        }

        private void UpdateLabel(string fieldPath, Type modelType)
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo entityTableInfo = dataService.GetEntityTableInfo(modelType);
            if (fieldPath.IndexOf(".") == -1)
            {
               EntityColumnInfo columnInfo =  dataService.GetTopColumnInfo(modelType, fieldPath);
               txtLabel.Text = columnInfo.DisplayName + " : ";

            }
            else
            {
                EntityColumnInfo columnInfo = dataService.GetTopColumnInfo(modelType, fieldPath);
                txtLabel.Text = columnInfo.TableInfo.DisplayName  + " : ";
            }
        }

        public GenericDataLabel()
        {
            InitializeComponent();
            BindingOperations.SetBinding(this, GenericDataLabel.DataContextProperty, new Binding("ItemsView.CurrentItem"));
            this.DataContextChanged += GenericDataLabel_DataContextChanged;
            
        }

        void GenericDataLabel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.UpdateLabel();
        }
    }
}