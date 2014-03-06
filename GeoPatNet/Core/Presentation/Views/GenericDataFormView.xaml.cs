﻿using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Emash.GeoPatNet.Presentation.Views
{
    /// <summary>
    /// Logique d'interaction pour GenericDataFormView.xaml
    /// </summary>
    public partial class GenericDataFormView : UserControl
    {

        public Boolean ShowDataToolBar
        {
            get { return (Boolean)GetValue(ShowDataToolBarProperty); }
            set { SetValue(ShowDataToolBarProperty, value); }
        }

        public static readonly DependencyProperty ShowDataToolBarProperty = DependencyProperty.Register("ShowDataToolBar", typeof(Boolean), typeof(GenericDataFormView), new PropertyMetadata(true));






        public Boolean ShowRecordPosition
        {
            get { return (Boolean)GetValue(ShowRecordPositionProperty); }
            set { SetValue(ShowRecordPositionProperty, value); }
        }

        public static readonly DependencyProperty ShowRecordPositionProperty =  DependencyProperty.Register("ShowRecordPosition", typeof(Boolean), typeof(GenericDataFormView), new PropertyMetadata(true));




        public Boolean ShowSlider
        {
            get { return (Boolean)GetValue(ShowSliderProperty); }
            set { SetValue(ShowSliderProperty, value); }
        }

        public static readonly DependencyProperty ShowSliderProperty =  DependencyProperty.Register("ShowSlider", typeof(Boolean), typeof(GenericDataFormView), new PropertyMetadata(true));



        public IEnumerable<String> FieldPaths
        {
            get { return (IEnumerable<String>)GetValue(FieldPathsProperty); }
            set { SetValue(FieldPathsProperty, value); }
        }

        public static readonly DependencyProperty FieldPathsProperty =
            DependencyProperty.Register("FieldPaths", typeof(IEnumerable<String>), typeof(GenericDataFormView), new PropertyMetadata(new PropertyChangedCallback(OnFieldPathsChange)));

        private static void OnFieldPathsChange(DependencyObject source, DependencyPropertyChangedEventArgs arg)
        {
            if (source != null && source is GenericDataFormView)
            {
                GenericDataFormView genericDataFormView = source as GenericDataFormView;
                genericDataFormView.OnFieldPathsChange(arg.OldValue as IEnumerable<String>, arg.NewValue as IEnumerable<String>);

            }
        }

        private void OnFieldPathsChange(IEnumerable<String> fieldPathsOld, IEnumerable<String> fieldPathsNew)
        {
            if (fieldPathsOld != null && fieldPathsOld is ObservableCollection<String>)
            {
                (fieldPathsOld as ObservableCollection<String>).CollectionChanged -= OnFieldPathsCollectionChanged;
            }
            if (fieldPathsNew != null && fieldPathsNew is ObservableCollection<String>)
            {
                (fieldPathsNew as ObservableCollection<String>).CollectionChanged += OnFieldPathsCollectionChanged;
            }
            this.CreateControls();
        }
        void OnFieldPathsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.CreateControls();
        }
        private void CreateControls()
        {
            if (this.DataContext != null)
            {
                if (this.DataContext.GetType().IsGenericType)
                {
                    Type[] genericTypes = this.DataContext.GetType().GetGenericArguments();
                    if (genericTypes.Length == 1)
                    {
                        Type modelType = genericTypes[0];
                        this.CreateControls(this.FieldPaths, modelType);
                    }
                }


            }
           
        }

        private void CreateControls(IEnumerable<string> fieldPaths, Type modelType)
        {
            int controlPerColumn = 10;
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo entityTableInfo = dataService.GetEntityTableInfo(modelType);
            if (fieldPaths != null && modelType != null && entityTableInfo != null)
            {
                gridControls.Children.Clear();
                gridControls.ColumnDefinitions.Clear();
                gridControls.RowDefinitions.Clear();
              

                int nbCol = (int) Math.Floor((double)fieldPaths.Count() / (double)controlPerColumn) +1;
               
                for (int j = 0; j < controlPerColumn; j++)
                {
                    RowDefinition rowDef = new RowDefinition();
                    rowDef.Height = new GridLength(24, GridUnitType.Auto);
                    gridControls.RowDefinitions.Add(rowDef);
                }
                for (int i = 0; i < nbCol; i++)
                {
                    ColumnDefinition colDefLibelle = new ColumnDefinition();
                    colDefLibelle.Width = new GridLength(10, GridUnitType.Auto);
                    ColumnDefinition colDefControl = new ColumnDefinition();
                    colDefControl.Width = new GridLength(10, GridUnitType.Star);
                    gridControls.ColumnDefinitions.Add(colDefLibelle);
                    gridControls.ColumnDefinitions.Add(colDefControl);
                }
                int columnIndex = 0;
                int rowIndex = 0;
                foreach (String fieldPath in fieldPaths)
                {
                    EntityColumnInfo columnInfo = (from c in entityTableInfo.ColumnInfos where c.PropertyName.Equals(fieldPath) select c).FirstOrDefault();
                    GenericDataLabel genericDataLabel = new Views.GenericDataLabel();
                    genericDataLabel.SetValue(Grid.ColumnProperty, columnIndex);
                    genericDataLabel.SetValue(Grid.RowProperty, rowIndex);
                    genericDataLabel.FieldPath = fieldPath;
                    genericDataLabel.DataContext = this.DataContext;
                    gridControls.Children.Add(genericDataLabel);

                    GenericDataControl genericDataControl = new GenericDataControl();
                    genericDataControl.SetValue(Grid.ColumnProperty, columnIndex + 1);
                    genericDataControl.SetValue(Grid.RowProperty, rowIndex);
                    genericDataControl.FieldPath = fieldPath;
                    genericDataControl.DataContext = this.DataContext;
                    gridControls.Children.Add(genericDataControl);

                    
                    rowIndex++;
                    if (rowIndex > 9)
                    {
                        rowIndex = 0;
                        columnIndex += 2;
                    }

                }
            }
        }

        public GenericDataFormView()
        {
            InitializeComponent();
            this.DataContextChanged += GenericDataFormView_DataContextChanged;
            BindingOperations.SetBinding(this.gridControls, Grid.DataContextProperty, new Binding());
            BindingOperations.SetBinding(this, GenericDataFormView.FieldPathsProperty, new Binding("FieldPaths"));
            

        }

        void GenericDataFormView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.CreateControls();
        }
    }
}
