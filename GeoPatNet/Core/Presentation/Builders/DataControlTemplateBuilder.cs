using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Emash.GeoPatNet.Infrastructure.Attributes;
using Emash.GeoPatNet.Infrastructure.Enums;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Validations;
using Emash.GeoPatNet.Presentation.Converters;
using Xceed.Wpf.Toolkit;

namespace Emash.GeoPatNet.Presentation.Builders
{
    public class DataControlTemplateBuilder
    {

        internal static Style CreateStyle(EntityFieldInfo fieldInfo,IDataService dataService,FrameworkElement element)
        {
            Style style = new Style();
            style.Triggers.Add(DataControlTemplateBuilder.CreateTrigger(fieldInfo, dataService, GenericDataListState.Search, null, element));
            style.Triggers.Add(DataControlTemplateBuilder.CreateTrigger(fieldInfo, dataService, GenericDataListState.Display, true, element));
            style.Triggers.Add(DataControlTemplateBuilder.CreateTrigger(fieldInfo, dataService, GenericDataListState.Display, false, element));

            style.Triggers.Add(DataControlTemplateBuilder.CreateTrigger(fieldInfo, dataService, GenericDataListState.InsertingDisplay, false, element));
            style.Triggers.Add(DataControlTemplateBuilder.CreateTrigger(fieldInfo, dataService, GenericDataListState.InsertingEmpty, false, element));
            return style;
        }

        private static TriggerBase CreateTrigger(EntityFieldInfo fieldInfo, IDataService dataService, GenericDataListState state, Nullable<Boolean> isLocked, FrameworkElement element)
        {
            TriggerBase trigger = null;
            if (isLocked.HasValue)
            {
                MultiDataTrigger multiDataTrigger = new MultiDataTrigger();
                Condition conditionState = new Condition();
                conditionState.Binding = CreateBindingState(element);
                conditionState.Value = state;
                multiDataTrigger.Conditions.Add(conditionState);
                Condition conditionIsLocked = new Condition();
                conditionIsLocked.Binding = CreateBindingIsLocked(element);
                conditionIsLocked.Value = isLocked.Value;
                multiDataTrigger.Conditions.Add(conditionIsLocked);
                multiDataTrigger.Setters.Add(DataControlTemplateBuilder.CreateSetter(fieldInfo, dataService, state, isLocked, element));
                trigger = multiDataTrigger;
            }
            else
            {
                DataTrigger dataTrigger = new DataTrigger();
                dataTrigger.Binding = DataControlTemplateBuilder.CreateBindingState(element);
                dataTrigger.Value = state;
                dataTrigger.Setters.Add(DataControlTemplateBuilder.CreateSetter(fieldInfo, dataService, state, isLocked, element));
                trigger = dataTrigger;
            }


            return trigger;
        }
       

        private static SetterBase CreateSetter(EntityFieldInfo fieldInfo, IDataService dataService, GenericDataListState state, bool? isLocked, FrameworkElement element)
        {
            Setter setter = new Setter();
            setter.Property = ContentControl.ContentTemplateProperty;
            setter.Value = DataControlTemplateBuilder.CreateTemplate(fieldInfo, dataService,  state, isLocked,element);
            return setter;
        }

        private static object CreateTemplate(EntityFieldInfo fieldInfo, IDataService dataService, GenericDataListState state, bool? isLocked, FrameworkElement element)
        {
            if (isLocked.HasValue)
            {
                if (isLocked.Value == true)
                {
                    if (state == GenericDataListState.Deleting)
                    {
                        return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService,element);
                    }
                    else if (state == GenericDataListState.Display)
                    {
                        return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element);
                    }
                    else if (state == GenericDataListState.InsertingDisplay)
                    {
                        if (fieldInfo.IsNeeded == false && fieldInfo.IsMainTableField == false)
                        { return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element); }
                        else
                        { return DataControlTemplateBuilder.CreateTemplateEdit(fieldInfo, dataService, element); }           

                    }
                    else if (state == GenericDataListState.InsertingEmpty)
                    {
                        if (fieldInfo.IsNeeded == false && fieldInfo.IsMainTableField == false)
                        { return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element); }                      
                        else
                        { return DataControlTemplateBuilder.CreateTemplateEdit(fieldInfo, dataService, element); }           
                    }
                    else if (state == GenericDataListState.Search)
                    {
                        return DataControlTemplateBuilder.CreateTemplateSearch(fieldInfo, dataService, element);            
                    }
                    else if (state == GenericDataListState.Updating)
                    {
                        if (fieldInfo.IsNeeded == false && fieldInfo.IsMainTableField == false)
                        { return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element); }               
                        else
                        { return DataControlTemplateBuilder.CreateTemplateEdit(fieldInfo, dataService, element); }           
                    }
                }
                else
                {
                    if (state == GenericDataListState.Deleting)
                    {
                        return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element);               
                    }
                    else if (state == GenericDataListState.Display)
                    {
                        if (fieldInfo.IsNeeded == false && fieldInfo.IsMainTableField == false)
                        { return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element); }               
                        else
                        { return DataControlTemplateBuilder.CreateTemplateEdit(fieldInfo, dataService, element); }               
                    }
                    else if (state == GenericDataListState.InsertingDisplay)
                    {
                        if (fieldInfo.IsNeeded == false && fieldInfo.IsMainTableField == false)
                        { return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element); }               
                        else
                        { return DataControlTemplateBuilder.CreateTemplateEdit(fieldInfo, dataService, element); }               
                    }
                    else if (state == GenericDataListState.InsertingEmpty)
                    {
                        if (fieldInfo.IsNeeded == false && fieldInfo.IsMainTableField == false)
                        { return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element); }               
                        else
                        { return DataControlTemplateBuilder.CreateTemplateEdit(fieldInfo, dataService, element); }               
                    }
                    else if (state == GenericDataListState.Search)
                    {
                        return CreateTemplateSearch(fieldInfo, dataService, element);   
                    }
                    else if (state == GenericDataListState.Updating)
                    {
                        if (fieldInfo.IsNeeded == false && fieldInfo.IsMainTableField == false)
                        { return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element); }               
                        else
                        { return DataControlTemplateBuilder.CreateTemplateEdit(fieldInfo, dataService, element); }               
                    }
                }
            }
            else
            {
                if (state == GenericDataListState.Deleting)
                {
                    return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element);                
                }
                else if (state == GenericDataListState.Display)
                {
                    return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element);             
                }
                else if (state == GenericDataListState.InsertingDisplay)
                {
                    if (fieldInfo.IsNeeded == false && fieldInfo.IsMainTableField == false)
                    { return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element); }
                    else
                    { return DataControlTemplateBuilder.CreateTemplateEdit(fieldInfo, dataService, element); }            
                }
                else if (state == GenericDataListState.InsertingEmpty)
                {
                    if (fieldInfo.IsNeeded == false && fieldInfo.IsMainTableField == false)
                    { return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element); }
                    else
                    { return DataControlTemplateBuilder.CreateTemplateEdit(fieldInfo, dataService, element); }            
                }
                else if (state == GenericDataListState.Search)
                {
                    return DataControlTemplateBuilder.CreateTemplateSearch(fieldInfo, dataService, element);   
                }
                else if (state == GenericDataListState.Updating)
                {
                    if (fieldInfo.IsNeeded == false && fieldInfo.IsMainTableField == false)
                    { return DataControlTemplateBuilder.CreateTemplateDisplay(fieldInfo, dataService, element); }
                    else
                    { return DataControlTemplateBuilder.CreateTemplateEdit(fieldInfo, dataService, element); }            
                }
            }


            return null;

        }

        private static DataTemplate CreateTemplateSearch(EntityFieldInfo fieldInfo, IDataService dataService, FrameworkElement element)
        {
            Type propertyType = null;
            DataTemplate dataTemplate = new DataTemplate();
            if ( fieldInfo.ColumnInfo != null)
            { propertyType = fieldInfo.ColumnInfo.PropertyType;}
           
            if (fieldInfo.ParentColumnInfo != null)
            { propertyType = fieldInfo.ParentColumnInfo.PropertyType; }
            if (fieldInfo.ControlType == ControlType.Combo)
            {
                String[] items = fieldInfo.Path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                FrameworkElementFactory comboBox = new FrameworkElementFactory(typeof(ComboBox));
                comboBox.SetValue(ComboBox.HeightProperty, 22D);
                String comboListPath = "ItemsView.CurrentItem.ComboItemsSource[" + items[items.Length - 2] + "." + items[items.Length - 1] + "]";
                Binding bindingList = new Binding(comboListPath);
                bindingList.Mode = BindingMode.OneWay;
                bindingList.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                comboBox.SetBinding(ComboBox.ItemsSourceProperty, bindingList);
                comboBox.SetValue(ComboBox.IsEditableProperty, true);
                Binding binding = new Binding();
                binding.Path = new PropertyPath("ItemsView.CurrentItem[" + fieldInfo.Path + "]");
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                binding.ValidatesOnDataErrors = true;
                comboBox.SetBinding(ComboBox.SelectedItemProperty, binding);
                dataTemplate.VisualTree = comboBox;
            }

            else if (fieldInfo.ControlType == Infrastructure.Attributes.ControlType.Color)
                {
                    FrameworkElementFactory colorPicker = new FrameworkElementFactory(typeof(ColorPicker));
                    Binding binding = CreateBindingTwoWay(fieldInfo.Path);
                    colorPicker.SetValue(ColorPicker.MinHeightProperty, 22D);
                    binding.Converter = new StringToColorConverter();
                    colorPicker.SetBinding(ColorPicker.SelectedColorProperty, binding);
                    dataTemplate.VisualTree = colorPicker;
                }
            else if (fieldInfo.ControlType == Infrastructure.Attributes.ControlType.Check)
                {
                    FrameworkElementFactory comboBox = new FrameworkElementFactory(typeof(ComboBox));
                    comboBox.SetValue(ComboBox.IsEditableProperty, true);
                    List<String> items = new List<string>();
                    items.Add(CultureConfiguration.BooleanNullString);
                    items.Add(CultureConfiguration.BooleanTrueString);
                    items.Add(CultureConfiguration.BooleanFalseString);
                    comboBox.SetValue(ComboBox.ItemsSourceProperty, items);
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath("ItemsView.CurrentItem[" + fieldInfo.Path + "]");
                    binding.Mode = BindingMode.TwoWay;
                    binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    binding.ValidatesOnDataErrors = true;
                    comboBox.SetBinding(ComboBox.SelectedItemProperty, binding);
                    dataTemplate.VisualTree = comboBox;
                }
            else if (propertyType.Equals(typeof(DateTime)) || propertyType.Equals(typeof(Nullable<DateTime>)))
                {
                    FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));
                    grid.SetValue(Grid.HeightProperty, 22D);
                    var column1 = new FrameworkElementFactory(typeof(ColumnDefinition));
                    column1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
                    var column2 = new FrameworkElementFactory(typeof(ColumnDefinition));
                    column2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));

                    grid.AppendChild(column1);
                    grid.AppendChild(column2);

                    FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                    textBox.SetBinding(TextBox.TextProperty, CreateBindingTwoWay(fieldInfo.Path));
                    textBox.SetValue(Grid.ColumnProperty, 0);
                    grid.AppendChild(textBox);

                    FrameworkElementFactory datePicker = new FrameworkElementFactory(typeof(DatePicker));
                    datePicker.SetValue(DatePicker.WidthProperty, 28D);
                    datePicker.SetValue(Grid.ColumnProperty, 1);
                    grid.AppendChild(datePicker);

                    Binding bindingSelectedDate = new Binding("ItemsView.CurrentItem[" + fieldInfo.Path + "]");
                    bindingSelectedDate.Mode = BindingMode.TwoWay;
                    bindingSelectedDate.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    bindingSelectedDate.Converter = new StringToDateConverter();
                    datePicker.SetBinding(DatePicker.SelectedDateProperty, bindingSelectedDate);
                    dataTemplate.VisualTree = grid;



                }
            else if (propertyType.Equals(typeof(String)) || propertyType.Equals(typeof(Int64)) || propertyType.Equals(typeof(Nullable<Int64>)) || propertyType.Equals(typeof(Double)) || propertyType.Equals(typeof(Nullable<Double>)))
                {
                    FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                    textBox.SetValue(TextBox.MinHeightProperty, 22D);
                    textBox.SetBinding(TextBox.TextProperty, CreateBindingTwoWay(fieldInfo.Path));
                    dataTemplate.VisualTree = textBox;
                }
            
            return dataTemplate;
        }

        
       


        private static DataTemplate CreateTemplateEdit(EntityFieldInfo fieldInfo, IDataService dataService, FrameworkElement element)
        {

            DataTemplate dataTemplate = new DataTemplate();
            Type propertyType = fieldInfo.ColumnInfo.PropertyType;
            if (fieldInfo.ParentColumnInfo != null)
            {propertyType = fieldInfo.ParentColumnInfo.PropertyType;}

            if (fieldInfo.ControlType == ControlType.Combo)
            {
                String[] items = fieldInfo.Path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                FrameworkElementFactory comboBox = new FrameworkElementFactory(typeof(ComboBox));
                String comboListPath = "ItemsView.CurrentItem.ComboItemsSource[" + items[items.Length - 2] + "." + items[items.Length - 1] + "]";
                comboBox.SetValue(ComboBox.HeightProperty, 22D);
                Binding bindingList = new Binding(comboListPath);
                bindingList.Mode = BindingMode.OneWay;
                bindingList.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                comboBox.SetBinding(ComboBox.ItemsSourceProperty, bindingList);
                Binding binding = new Binding();
                binding.Path = new PropertyPath("ItemsView.CurrentItem[" + fieldInfo.Path + "]");
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                binding.ValidatesOnDataErrors = true;
                comboBox.SetBinding(ComboBox.SelectedItemProperty, binding);
                dataTemplate.VisualTree = comboBox;
            }

            else if (fieldInfo.ControlType == Infrastructure.Attributes.ControlType.Color)
                {
                    FrameworkElementFactory colorPicker = new FrameworkElementFactory(typeof(ColorPicker));
                    Binding binding = CreateBindingTwoWay(fieldInfo.Path);
                    colorPicker.SetValue(ColorPicker.MinHeightProperty, 22D);
                    binding.Converter = new StringToColorConverter();
                    colorPicker.SetBinding(ColorPicker.SelectedColorProperty, binding);
                    dataTemplate.VisualTree = colorPicker;
                }
            else if (fieldInfo.ControlType == Infrastructure.Attributes.ControlType.Check)
                {
                    FrameworkElementFactory comboBox = new FrameworkElementFactory(typeof(ComboBox));
                    comboBox.SetValue(ComboBox.IsEditableProperty, false);
                    List<String> items = new List<string>();
                    items.Add(CultureConfiguration.BooleanNullString);
                    items.Add(CultureConfiguration.BooleanTrueString);
                    items.Add(CultureConfiguration.BooleanFalseString);
                    comboBox.SetValue(ComboBox.ItemsSourceProperty, items);
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath("ItemsView.CurrentItem[" + fieldInfo.Path + "]");
                    binding.Mode = BindingMode.TwoWay;
                    binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    binding.ValidatesOnDataErrors = true;
                    comboBox.SetBinding(ComboBox.SelectedItemProperty, binding);
                    dataTemplate.VisualTree = comboBox;
                }
            else if (propertyType.Equals(typeof(String)) || propertyType.Equals(typeof(Int64)) || propertyType.Equals(typeof(Nullable<Int64>)) || propertyType.Equals(typeof(Double)) || propertyType.Equals(typeof(Nullable<Double>)))
                {
                    FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                    textBox.SetValue(TextBox.MinHeightProperty, 22D);
                    textBox.SetBinding(TextBox.TextProperty, CreateBindingTwoWay(fieldInfo.Path));

                    dataTemplate.VisualTree = textBox;

                }
            else if (propertyType.Equals(typeof(DateTime)) || propertyType.Equals(typeof(Nullable<DateTime>)))
                {

                    FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));
                    grid.SetValue(Grid.HeightProperty, 22D);
                    var column1 = new FrameworkElementFactory(typeof(ColumnDefinition));
                    column1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
                    var column2 = new FrameworkElementFactory(typeof(ColumnDefinition));
                    column2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
                    grid.AppendChild(column1);
                    grid.AppendChild(column2);
                    FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                    textBox.SetBinding(TextBox.TextProperty, CreateBindingTwoWay(fieldInfo.Path));
                    textBox.SetValue(Grid.ColumnProperty, 0);
                    grid.AppendChild(textBox);
                    FrameworkElementFactory datePicker = new FrameworkElementFactory(typeof(DatePicker));
                    datePicker.SetValue(DatePicker.WidthProperty, 28D);
                    datePicker.SetValue(Grid.ColumnProperty, 1);
                    grid.AppendChild(datePicker);
                    Binding bindingSelectedDate = new Binding("ItemsView.CurrentItem[" + fieldInfo.Path + "]");
                    bindingSelectedDate.Mode = BindingMode.TwoWay;
                    bindingSelectedDate.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    bindingSelectedDate.Converter = new StringToDateConverter();
                    datePicker.SetBinding(DatePicker.SelectedDateProperty, bindingSelectedDate);
                    dataTemplate.VisualTree = grid;
                }

            
            return dataTemplate;
        }

       


        private static DataTemplate CreateTemplateDisplay(EntityFieldInfo fieldInfo, IDataService dataService, FrameworkElement element)
        {
            
            if (fieldInfo.ControlType == ControlType.Color)
            {
                DataTemplate dataTemplate = new DataTemplate();
                FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));
                grid.SetValue(TextBox.MinHeightProperty, 22D);
                grid.SetValue(TextBox.MinWidthProperty, 64D);
                Binding binding = CreateBindingOneWay(fieldInfo.Path);
                binding.Converter = new StringToBrushConverter();
                grid.SetBinding(Grid.BackgroundProperty, binding);               
                dataTemplate.VisualTree = grid;
                return dataTemplate;
            }
            else
            {
                DataTemplate dataTemplate = new DataTemplate();
                FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                textBox.SetValue(TextBox.MinHeightProperty, 22D);
                textBox.SetBinding(TextBox.TextProperty, CreateBindingOneWay(fieldInfo.Path));
                textBox.SetValue(TextBox.IsReadOnlyProperty, true);
                dataTemplate.VisualTree = textBox;
                if (fieldInfo.IsMainTableField == false && fieldInfo.IsNeeded == false)
                {textBox.SetValue(TextBox.BackgroundProperty, Brushes.LightGray);}
                return dataTemplate;
            }

        }

        private static Binding CreateBindingTwoWay(String path)
        {
            Binding binding = new Binding("ItemsView.CurrentItem[" + path + "]");
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.ValidatesOnDataErrors = true;
            return binding;
        }
        private static Binding CreateBindingState(FrameworkElement element)
        {
            Binding binding = new Binding("State");
            binding.Source = element.DataContext;
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            return binding;
        }

        private static Binding CreateBindingIsLocked(FrameworkElement element)
        {
            Binding binding = new Binding("IsLocked");
            binding.Source = element.DataContext;
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            return binding;
        }

        private static Binding CreateBindingOneWay(string fieldPath)
        {
            Binding binding = new Binding("ItemsView.CurrentItem[" + fieldPath + "]");
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.ValidatesOnDataErrors = true;
            return binding;
        }
    }
}
