using Emash.GeoPatNet.Infrastructure.Enums;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Utils;
using Emash.GeoPatNet.Infrastructure.Validations;
using Emash.GeoPatNet.Presentation.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit;


namespace Emash.GeoPatNet.Presentation.Builders
{
    /// <summary>
    /// Centralisation de la création des templates des colonnes
    /// </summary>
    public static class DataGridTemplateBuilder
    {
        internal static System.Windows.DataTemplate CreateCellTemplate(EntityFieldInfo entityFieldInfo,DataGrid dataGrid)
        {
            DataTemplate dataTemplate = new DataTemplate();
            FrameworkElementFactory contentControl = new FrameworkElementFactory(typeof(ContentControl));
            contentControl.SetBinding(ContentControl.ContentProperty, new Binding());
            Style contentControlStyle = new Style();
            contentControl.SetValue(ContentControl.StyleProperty, contentControlStyle);


            DataTemplate tpl = new DataTemplate();
            if (entityFieldInfo.ControlType == Infrastructure.Attributes.ControlType.Color)
            {
                FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));
                Binding binding = CreateBindingOneWay(entityFieldInfo.Path);
                binding.Converter = new StringToBrushConverter();
                grid.SetBinding(Grid.BackgroundProperty, binding);
                tpl.VisualTree = grid;
                contentControlStyle.Setters.Add(new Setter(ContentControl.ContentTemplateProperty, tpl));
                dataTemplate.VisualTree = contentControl;
            }
            else
            {
                FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBlock));
                if (entityFieldInfo.ControlType == Infrastructure.Attributes.ControlType.Pr)
                { textBox.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right); }
                textBox.SetBinding(TextBlock.TextProperty, CreateBindingOneWay(entityFieldInfo.Path));
                tpl.VisualTree = textBox;
                contentControlStyle.Setters.Add(new Setter(ContentControl.ContentTemplateProperty, tpl));
                dataTemplate.VisualTree = contentControl;
            }

            return dataTemplate;
        }

        internal static System.Windows.DataTemplate CreateCellEditingTemplate(EntityFieldInfo entityFieldInfo,DataGrid dataGrid)
        {
            DataTemplate dataTemplate = new DataTemplate();
            FrameworkElementFactory contentControl = new FrameworkElementFactory(typeof(ContentControl));
            contentControl.SetBinding(ContentControl.ContentProperty, new Binding());
            Style contentControlStyle = new Style();
            contentControlStyle.Triggers.Add(CreateTrigger(entityFieldInfo, GenericDataListState.Search, dataGrid));
            contentControlStyle.Triggers.Add(CreateTrigger(entityFieldInfo, GenericDataListState.Display, dataGrid));
            contentControlStyle.Triggers.Add(CreateTrigger(entityFieldInfo, GenericDataListState.InsertingEmpty, dataGrid));
            contentControlStyle.Triggers.Add(CreateTrigger(entityFieldInfo, GenericDataListState.Updating, dataGrid));
            contentControlStyle.Triggers.Add(CreateTrigger(entityFieldInfo, GenericDataListState.InsertingDisplay, dataGrid));
            contentControl.SetValue(ContentControl.StyleProperty, contentControlStyle);
            contentControl.AddHandler(ContentControl.GotFocusEvent, new RoutedEventHandler(OnContentControlGotFocus));
            dataTemplate.VisualTree = contentControl;
            return dataTemplate;
        }
     
     
      private static  void OnContentControlGotFocus(object sender, RoutedEventArgs e)
      {
          if (sender is DependencyObject)
          {
              DependencyObject obj = sender as DependencyObject;
              TextBox txt = VisualTreeHelper.FindChild<TextBox>(obj);
              if (txt != null)
              {
                  txt.Focus();
                  txt.SelectAll();
              }
              TextBlock textBlock = VisualTreeHelper.FindChild<TextBlock>(obj);
              if (textBlock != null)
              {
                  textBlock.Focus();
                  var bindingExpression = textBlock.GetBindingExpression(TextBlock.TextProperty);
                  if (bindingExpression != null)
                  { bindingExpression.UpdateTarget(); }

              }
              ComboBox combo = VisualTreeHelper.FindChild<ComboBox>(obj);
              if (combo != null)
              {
                  // combo.Focus();
                  // combo.IsDropDownOpen = true;
              }
          }


      }




      private static DataTrigger CreateTrigger(EntityFieldInfo entityFieldInfo, GenericDataListState state, DataGrid dataGrid)
      {
          DataTrigger dataTrigger = new DataTrigger();
          dataTrigger.Binding = CreateBindingState(state, dataGrid);
          dataTrigger.Value = state;
          dataTrigger.Setters.Add(CreateSetter(entityFieldInfo, state, dataGrid));

          return dataTrigger;
      }

      private static Setter CreateSetter(EntityFieldInfo entityFieldInfo, GenericDataListState state, DataGrid dataGrid)
      {
          Setter setter = new Setter();
          setter.Property = ContentControl.ContentTemplateProperty;
          setter.Value = CreateTemplate(entityFieldInfo, state, dataGrid);
          return setter;
      }
      private static FrameworkElementFactory CreateTemplateText(EntityFieldInfo entityFieldInfo, GenericDataListState state, DataGrid dataGrid)
      {
          FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
          textBox.SetBinding(TextBox.TextProperty, CreateBindingTwoWay(entityFieldInfo.Path));         
          return  textBox;
      }

      private static FrameworkElementFactory CreateTemplatePr(EntityFieldInfo entityFieldInfo, GenericDataListState state, DataGrid dataGrid)
      {
          FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
          textBox.SetBinding(TextBox.TextProperty, CreateBindingTwoWay(entityFieldInfo.Path));
          textBox.SetValue(TextBox.TextAlignmentProperty, TextAlignment.Right);
          return textBox;
      }

      private static FrameworkElementFactory CreateTemplateInteger(EntityFieldInfo entityFieldInfo, GenericDataListState state, DataGrid dataGrid)
      {
          FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
          textBox.SetBinding(TextBox.TextProperty, CreateBindingTwoWay(entityFieldInfo.Path));
          return textBox;
      }

      private static FrameworkElementFactory CreateTemplateDecimal(EntityFieldInfo entityFieldInfo, GenericDataListState state, DataGrid dataGrid)
      {
          FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
          textBox.SetBinding(TextBox.TextProperty, CreateBindingTwoWay(entityFieldInfo.Path));
          return textBox;
      }

      private static FrameworkElementFactory CreateTemplateDate(EntityFieldInfo entityFieldInfo, GenericDataListState state, DataGrid dataGrid)
      {
          FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));

          var column1 = new FrameworkElementFactory(typeof(ColumnDefinition));
          column1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
          var column2 = new FrameworkElementFactory(typeof(ColumnDefinition));
          column2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));

          grid.AppendChild(column1);
          grid.AppendChild(column2);


          FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
          textBox.SetBinding(TextBox.TextProperty, CreateBindingTwoWay(entityFieldInfo.Path));
          textBox.SetValue(Grid.ColumnProperty, 0);
          grid.AppendChild(textBox);

          FrameworkElementFactory datePicker = new FrameworkElementFactory(typeof(DatePicker));
          datePicker.SetValue(DatePicker.WidthProperty, 28D);
          datePicker.SetValue(Grid.ColumnProperty, 1);
          grid.AppendChild(datePicker);

          Binding bindingSelectedDate = new Binding("[" + entityFieldInfo.Path + "]");
          bindingSelectedDate.Mode = BindingMode.TwoWay;
          bindingSelectedDate.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
          bindingSelectedDate.Converter = new StringToDateConverter();
          datePicker.SetBinding(DatePicker.SelectedDateProperty, bindingSelectedDate);
          return  grid;
      }

      private static FrameworkElementFactory CreateTemplateColor(EntityFieldInfo entityFieldInfo, GenericDataListState state, DataGrid dataGrid)
      {
          FrameworkElementFactory colorPicker = new FrameworkElementFactory(typeof(ColorPicker));
          Binding binding = CreateBindingTwoWay(entityFieldInfo.Path);
          binding.Converter = new StringToColorConverter();
          colorPicker.SetBinding(ColorPicker.SelectedColorProperty, binding);
          return colorPicker;
      }

      private static FrameworkElementFactory CreateTemplateCheck(EntityFieldInfo entityFieldInfo, GenericDataListState state, DataGrid dataGrid)
      {
          FrameworkElementFactory comboBox = new FrameworkElementFactory(typeof(ComboBox));
          if (state == GenericDataListState.Search)
          { comboBox.SetValue(ComboBox.IsEditableProperty, true); }
          List<String> items = new List<string>();
          items.Add(CultureConfiguration.BooleanNullString);
          items.Add(CultureConfiguration.BooleanTrueString);
          items.Add(CultureConfiguration.BooleanFalseString);
          comboBox.SetValue(ComboBox.ItemsSourceProperty, items);
          Binding binding = new Binding();
          binding.Path = new PropertyPath("[" +entityFieldInfo.Path +"]");
          binding.Mode = BindingMode.TwoWay;
          binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
          binding.ValidatesOnDataErrors = true;
          comboBox.SetBinding(ComboBox.SelectedItemProperty, binding);
          return  comboBox;
      }

      private static FrameworkElementFactory CreateTemplateCombo(EntityFieldInfo entityFieldInfo, GenericDataListState state, DataGrid dataGrid)
      {
          String[]  items = entityFieldInfo.Path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
          FrameworkElementFactory comboBox = new FrameworkElementFactory(typeof(ComboBox));
          if (state == GenericDataListState.Search)
          { comboBox.SetValue(ComboBox.IsEditableProperty, true); }
          String comboListPath = "ComboItemsSource[" + items[items.Length - 2] + "." + items[items.Length - 1] + "]";
          Binding bindingList = new Binding(comboListPath);
          bindingList.Mode = BindingMode.OneWay;
          bindingList.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
          comboBox.SetBinding(ComboBox.ItemsSourceProperty, bindingList);
          Binding  binding = new Binding();
          binding.Path = new PropertyPath("[" + entityFieldInfo.Path + "]");
          binding.Mode = BindingMode.TwoWay;
          binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
          binding.ValidatesOnDataErrors = true;
          comboBox.SetBinding(ComboBox.SelectedItemProperty, binding);
          return  comboBox;
      }

      private static DataTemplate CreateTemplate(EntityFieldInfo entityFieldInfo, GenericDataListState state, DataGrid dataGrid)
      {
          DataTemplate dataTemplate = new DataTemplate();
        
          if (entityFieldInfo.IsNeeded == false && entityFieldInfo.IsMainTableField == false && state != GenericDataListState.Search)
          {
              return CreateCellTemplate(entityFieldInfo, dataGrid);
          }
          else
          {
              switch (entityFieldInfo .ControlType )
              {
                  case Infrastructure.Attributes.ControlType.Check :
                      dataTemplate.VisualTree = CreateTemplateCheck(entityFieldInfo, state, dataGrid);
                      break;
                      case Infrastructure.Attributes.ControlType.Color :
                      dataTemplate.VisualTree = CreateTemplateColor(entityFieldInfo, state, dataGrid);
                      break;
                      case Infrastructure.Attributes.ControlType.Date :
                      dataTemplate.VisualTree = CreateTemplateDate(entityFieldInfo, state, dataGrid);
                      break;
                      case Infrastructure.Attributes.ControlType.Decimal :
                      dataTemplate.VisualTree = CreateTemplateDecimal(entityFieldInfo, state, dataGrid);
                      break;
                      case Infrastructure.Attributes.ControlType.Integer :
                      dataTemplate.VisualTree = CreateTemplateInteger(entityFieldInfo, state, dataGrid);
                      break;
                      case Infrastructure.Attributes.ControlType.Pr :
                      dataTemplate.VisualTree = CreateTemplatePr(entityFieldInfo, state, dataGrid);
                      break;
                      case Infrastructure.Attributes.ControlType.Text :
                      dataTemplate.VisualTree = CreateTemplateText(entityFieldInfo, state, dataGrid);
                      break;
                      case Infrastructure.Attributes.ControlType.Combo:
                      dataTemplate.VisualTree = CreateTemplateCombo(entityFieldInfo, state, dataGrid);
                      break;
                      
              }
            
          }

          return dataTemplate;
      }

   

     


      private static Binding CreateBindingTwoWay(String path)
      {
          Binding binding = new Binding("[" + path + "]");
          binding.Mode = BindingMode.TwoWay;
          binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
          binding.ValidatesOnDataErrors = true;
          return binding;
      }
      private static Binding CreateBindingOneWay(string path)
      {
          Binding binding = new Binding("[" + path + "]");
          binding.Mode = BindingMode.OneWay;
          binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
          binding.ValidatesOnDataErrors = true;
          return binding;
      }

      private static Binding CreateBindingState(GenericDataListState genericDataListState, DataGrid dataGrid)
      {
          Binding binding = new Binding();
          binding.Source = dataGrid;
          binding.Path = new PropertyPath("DataContext.State");
          binding.Mode = BindingMode.OneWay;
          binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
          return binding;
      }
 
    }
}
