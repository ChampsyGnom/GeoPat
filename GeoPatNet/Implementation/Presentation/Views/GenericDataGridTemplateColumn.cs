using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Emash.GeoPatNet.Engine.Infrastructure.Enums;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Emash.GeoPatNet.Presentation.Implementation.Views
{
    public class GenericDataGridTemplateColumn : DataGridTemplateColumn
    {
        private EntityTableInfo _entityTableInfo;
        private string _fieldPath;
        private Boolean _templateCreated;
        public GenericDataGridTemplateColumn(EntityTableInfo entityTableInfo, string fieldPath)
        {
            this._entityTableInfo = entityTableInfo;
            this._fieldPath = fieldPath;
            this._templateCreated = false;
        }

        protected override System.Windows.FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            if (this._templateCreated == false)
            {this.CreateTemplate(); }
            return base.GenerateEditingElement(cell, dataItem);
        }

        protected override System.Windows.FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            if (this._templateCreated == false)
            { this.CreateTemplate(); }
            return base.GenerateElement(cell, dataItem);
        }

        private void CreateTemplate()
        {

            this._templateCreated = true;
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityColumnInfo topProperty = dataService.GetTopParentProperty(_entityTableInfo.EntityType, _fieldPath);
            this.CellTemplate =CreateTemplateCell(dataService, topProperty);
            this.CellEditingTemplate = CreateTemplateCellEditing(dataService, topProperty);
           
        }
        private DataTemplate CreateTemplateCellEditing(IDataService dataService, EntityColumnInfo topProperty)
        {
            DataTemplate dataTemplate = new DataTemplate();
            FrameworkElementFactory contentControl = new FrameworkElementFactory(typeof(ContentControl));
            contentControl.SetBinding(ContentControl.ContentProperty, new Binding());
            Style contentControlStyle = new Style();
            contentControlStyle.Triggers.Add(CreateTrigger(dataService, topProperty, GenericDataListState.Search));
            contentControlStyle.Triggers.Add(CreateTrigger(dataService, topProperty, GenericDataListState.Display));
            contentControlStyle.Triggers.Add(CreateTrigger(dataService, topProperty, GenericDataListState.InsertingEmpty));
            contentControlStyle.Triggers.Add(CreateTrigger(dataService, topProperty, GenericDataListState.Updating));
            contentControlStyle.Triggers.Add(CreateTrigger(dataService, topProperty, GenericDataListState.InsertingDisplay));
            contentControl.SetValue(ContentControl.StyleProperty, contentControlStyle);
  

            contentControl.AddHandler(ContentControl.GotFocusEvent, new RoutedEventHandler(OnContentControlGotFocus));


           
            dataTemplate.VisualTree = contentControl;
            return dataTemplate;
        }
        private void OnContentControlGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is DependencyObject)
            {
                DependencyObject obj = sender as DependencyObject;
                TextBox txt = this.FindChild<TextBox>(obj);
                if (txt != null)
                {
                    txt.Focus();
                    txt.SelectAll();
                }
                TextBlock textBlock = this.FindChild<TextBlock>(obj);
                if (textBlock != null)
                {
                    textBlock.Focus();
                   var bindingExpression = textBlock.GetBindingExpression(TextBlock.TextProperty);
                   if (bindingExpression != null)
                   { bindingExpression.UpdateTarget(); }
                
                }
                ComboBox combo = this.FindChild<ComboBox>(obj);
                if (combo != null)
                {
                    combo.Focus();
                    combo.IsDropDownOpen = true;
                }
            }
            
            
        }
        private T FindChild<T>(DependencyObject depObj)  where T : DependencyObject
        {
            // Confirm obj is valid. 
            if (depObj == null) return null;

            // success case
            if (depObj is T)
                return depObj as T;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                //DFS
                T obj = FindChild<T>(child);

                if (obj != null)
                    return obj;
            }

            return null;
        }
        private DataTemplate CreateTemplateCell(IDataService dataService, EntityColumnInfo topProperty)
        {
            DataTemplate dataTemplate = new DataTemplate();
            FrameworkElementFactory contentControl = new FrameworkElementFactory(typeof(ContentControl));
            contentControl.SetBinding(ContentControl.ContentProperty, new Binding());
            Style contentControlStyle = new Style();           
            contentControl.SetValue(ContentControl.StyleProperty, contentControlStyle);


            DataTemplate tpl = new DataTemplate();
            FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBlock));
            if (topProperty.ControlType == Infrastructure.Attributes.ControlType.Pr)
            { textBox.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right); }
            textBox.SetBinding(TextBlock.TextProperty, this.CreateBindingOneWay(this._fieldPath));
            tpl.VisualTree = textBox;
            contentControlStyle.Setters.Add (new Setter (ContentControl.ContentTemplateProperty, tpl));            
            dataTemplate.VisualTree = contentControl;
            return dataTemplate;
        }

       
        private DataTrigger CreateTrigger(IDataService dataService, EntityColumnInfo topProperty, GenericDataListState state)
        {
            DataTrigger dataTrigger = new DataTrigger();
            dataTrigger.Binding = this.CreateBindingState(state);
            dataTrigger.Value = state;
            dataTrigger.Setters.Add(this.CreateSetter(dataService, topProperty, state));

            return dataTrigger;
        }

        private Setter CreateSetter(IDataService dataService, EntityColumnInfo topProperty, GenericDataListState state)
        {
            Setter setter = new Setter();
            setter.Property = ContentControl.ContentTemplateProperty;
            setter.Value = this.CreateTemplate(dataService, topProperty, state);
            return setter;
        }

        private DataTemplate CreateTemplate(IDataService dataService, EntityColumnInfo topProperty, GenericDataListState state)
        {
            DataTemplate dataTemplate = new DataTemplate();
            if (this._fieldPath.IndexOf(".") != -1)
            {
                String[] items = this._fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                FrameworkElementFactory comboBox = new FrameworkElementFactory(typeof(ComboBox));

                String comboListPath = "ComboItemsSource[" + items[items.Length - 2] + "." + items[items.Length - 1] + "]";
                Binding bindingList = new Binding(comboListPath);
                bindingList.Mode = BindingMode.OneWay;
                bindingList.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                comboBox.SetBinding(ComboBox.ItemsSourceProperty, bindingList);
                
                Binding binding = new Binding();
                binding.Path = new PropertyPath("["+this._fieldPath+"]");
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                binding.ValidatesOnDataErrors = true;
                comboBox.SetBinding(ComboBox.SelectedItemProperty, binding);
                dataTemplate.VisualTree = comboBox;
            }
            else
            {
                if (topProperty.PropertyType.Equals(typeof(String)))
                {
                    if (state == GenericDataListState.Search)
                    {
                        FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
               
                        textBox.SetBinding(TextBox.TextProperty, this.CreateBindingTwoWay(this._fieldPath));
                        if (topProperty.ControlType == Infrastructure.Attributes.ControlType.Pr)
                        { textBox.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right); }
                        dataTemplate.VisualTree = textBox;
                    }
                    else if (state == GenericDataListState.InsertingEmpty)
                    {
                        FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                        if (topProperty.ControlType == Infrastructure.Attributes.ControlType.Pr)
                        { textBox.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right); }
                        textBox.SetBinding(TextBox.TextProperty, this.CreateBindingTwoWay(this._fieldPath));
                        dataTemplate.VisualTree = textBox;
                    }
                    else if (state == GenericDataListState.Display)
                    {
                        FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                        if (topProperty.ControlType == Infrastructure.Attributes.ControlType.Pr)
                        { textBox.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right); }
                        textBox.SetBinding(TextBox.TextProperty, this.CreateBindingTwoWay(this._fieldPath));
                        dataTemplate.VisualTree = textBox;
                    }
                    else if (state == GenericDataListState.Updating)
                    {
                        FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                        if (topProperty.ControlType == Infrastructure.Attributes.ControlType.Pr)
                        { textBox.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right); }
                        textBox.SetBinding(TextBox.TextProperty, this.CreateBindingTwoWay(this._fieldPath));
                        dataTemplate.VisualTree = textBox;
                    }
                    else if (state == GenericDataListState.InsertingDisplay)
                    {
                        FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                        if (topProperty.ControlType == Infrastructure.Attributes.ControlType.Pr)
                        { textBox.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right); }
                        textBox.SetBinding(TextBox.TextProperty, this.CreateBindingTwoWay(this._fieldPath));
                        dataTemplate.VisualTree = textBox;
                    }

                }
            }
            
            return dataTemplate;
        }

        
        private Binding CreateBindingTwoWay(String path)
        {
            Binding binding = new Binding("["+path+"]");       
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.ValidatesOnDataErrors = true;
            return binding;
        }
        private BindingBase CreateBindingOneWay(string path)
        {
            Binding binding = new Binding("[" + path + "]");
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.ValidatesOnDataErrors = true;
            return binding;
        }

        private Binding CreateBindingState(GenericDataListState genericDataListState)
        {
            Binding binding = new Binding("State");
            binding.Source = DataGridOwner.DataContext;
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            return binding;
        }

    

        

       
    }
}
