using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Emash.GeoPatNet.Engine.Infrastructure.Enums;
using Emash.GeoPatNet.Presentation.Implementation.Converters;
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
    /// Logique d'interaction pour GenericDataControl.xaml
    /// </summary>
    public partial class GenericDataControl : UserControl
    {
        public String FieldPath
        {
            get { return (String)GetValue(FieldPathProperty); }
            set { SetValue(FieldPathProperty, value); }
        }

        public static readonly DependencyProperty FieldPathProperty =
            DependencyProperty.Register("FieldPath", typeof(String), typeof(GenericDataControl), new PropertyMetadata(new PropertyChangedCallback(OnFieldPathChange)));

        private static void OnFieldPathChange(DependencyObject source, DependencyPropertyChangedEventArgs arg)
        {
            if (source != null && source is GenericDataControl)
            {
                GenericDataControl genericDataControl = source as GenericDataControl;
                genericDataControl.OnFieldPathChange(arg.OldValue as String, arg.NewValue as String);

            }
        }

        private void OnFieldPathChange(string oldPath, string newPath)
        {
            this.UpdateTemplate();
        }

        private void UpdateTemplate()
        {
            if (this.DataContext != null)
            {
                if (this.DataContext.GetType().IsGenericType)
                {
                    Type[] genericTypes = this.DataContext.GetType().GetGenericArguments();
                    if (genericTypes.Length == 1)
                    {
                        Type modelType = genericTypes[0];
                        this.UpdateTemplate(this.FieldPath, modelType);
                    }
                }


            }
        }
        // Il faut pouvoir céer des multi triggers 
        private void UpdateTemplate(string fieldPath, Type modelType)
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo entityTableInfo = dataService.GetEntityTableInfo(modelType);
            EntityColumnInfo topProperty = dataService.GetTopColumnInfo(modelType, fieldPath);
            Style contentControlStyle = new Style();

            contentControlStyle.Triggers.Add(CreateTrigger(fieldPath,dataService, topProperty, GenericDataListState.Search));


            DataTemplate tpl = new DataTemplate();
            FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
            textBox.SetBinding(TextBox.TextProperty, this.CreateBindingOneWay(this.FieldPath));
            textBox.SetValue(TextBox.IsReadOnlyProperty, true);
            tpl.VisualTree = textBox;

           

            contentControlStyle.Setters.Add(new Setter(ContentControl.ContentTemplateProperty, tpl));
            contentControl.SetValue(ContentControl.StyleProperty, contentControlStyle);
        }

        private TriggerBase CreateTrigger(string fieldPath, IDataService dataService, EntityColumnInfo topProperty, GenericDataListState state)
        {
            DataTrigger dataTrigger = new DataTrigger();
            dataTrigger.Binding = this.CreateBindingState();
            dataTrigger.Value = state;
            dataTrigger.Setters.Add(this.CreateSetter(fieldPath,dataService, topProperty, state));

            return dataTrigger;
        }

        private SetterBase CreateSetter(string fieldPath, IDataService dataService, EntityColumnInfo topProperty, GenericDataListState state)
        {
            Setter setter = new Setter();
            setter.Property = ContentControl.ContentTemplateProperty;
            setter.Value = this.CreateTemplate(fieldPath,dataService, topProperty, state);
            return setter;
        }

        private DataTemplate CreateTemplate(string fieldPath, IDataService dataService, EntityColumnInfo topProperty, GenericDataListState state)
        {
            DataTemplate dataTemplate = new DataTemplate();
            if (fieldPath.IndexOf(".") != -1)
            {
                if (state == GenericDataListState.Search)
                {
                    String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    FrameworkElementFactory comboBox = new FrameworkElementFactory(typeof(ComboBox));
                    comboBox.SetValue(ComboBox.IsEditableProperty, true);
                    String comboListPath = "ItemsView.CurrentItem.ComboItemsSource[" + items[items.Length - 2] + "." + items[items.Length - 1] + "]";
                    Binding bindingList = new Binding(comboListPath);
                    bindingList.Mode = BindingMode.OneWay;
                    bindingList.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    comboBox.SetBinding(ComboBox.ItemsSourceProperty, bindingList);
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath("ItemsView.CurrentItem[" + fieldPath + "]");
                    binding.Mode = BindingMode.TwoWay;
                    binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    binding.ValidatesOnDataErrors = true;
                    comboBox.SetBinding(ComboBox.SelectedItemProperty, binding);
                    dataTemplate.VisualTree = comboBox;
                }
              
            }
            else
            {
               
                
                    if (topProperty.PropertyType.Equals(typeof(DateTime)) || topProperty.PropertyType.Equals(typeof(Nullable<DateTime>)))
                    {
                        if (state == GenericDataListState.Search)
                        {
                            FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));

                            var column1 = new FrameworkElementFactory(typeof(ColumnDefinition));
                            column1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
                            var column2 = new FrameworkElementFactory(typeof(ColumnDefinition));
                            column2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));

                            grid.AppendChild(column1);
                            grid.AppendChild(column2);

                            FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                            textBox.SetBinding(TextBox.TextProperty, this.CreateBindingTwoWay(fieldPath));
                            textBox.SetValue(Grid.ColumnProperty, 0);
                            grid.AppendChild(textBox);

                            FrameworkElementFactory datePicker = new FrameworkElementFactory(typeof(DatePicker));
                            datePicker.SetValue(DatePicker.WidthProperty, 28D);
                            datePicker.SetValue(Grid.ColumnProperty, 1);
                            grid.AppendChild(datePicker);

                            Binding bindingSelectedDate = new Binding("ItemsView.CurrentItem[" + fieldPath + "]");
                            bindingSelectedDate.Mode = BindingMode.TwoWay;
                            bindingSelectedDate.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                            bindingSelectedDate.Converter = new StringToDateConverter();
                            datePicker.SetBinding(DatePicker.SelectedDateProperty, bindingSelectedDate);


                            
                            dataTemplate.VisualTree = grid;
                        }
                        

                    }
                    else if (topProperty.PropertyType.Equals(typeof(String)) || topProperty.PropertyType.Equals(typeof(Int64)) || topProperty.PropertyType.Equals(typeof(Nullable<Int64>)) || topProperty.PropertyType.Equals(typeof(Double)) || topProperty.PropertyType.Equals(typeof(Nullable<Double>)))
                    {
                        if (state == GenericDataListState.Search)
                        {
                            FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));

                            textBox.SetBinding(TextBox.TextProperty, this.CreateBindingTwoWay(fieldPath));
                            if (topProperty.ControlType == Infrastructure.Attributes.ControlType.Pr)
                            { textBox.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right); }
                            dataTemplate.VisualTree = textBox;
                        }
                        else if (state == GenericDataListState.InsertingEmpty)
                        {
                            FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                            if (topProperty.ControlType == Infrastructure.Attributes.ControlType.Pr)
                            { textBox.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right); }
                            textBox.SetBinding(TextBox.TextProperty, this.CreateBindingTwoWay(fieldPath));
                            dataTemplate.VisualTree = textBox;
                        }
                        else if (state == GenericDataListState.Display)
                        {
                            FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                            if (topProperty.ControlType == Infrastructure.Attributes.ControlType.Pr)
                            { textBox.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right); }
                            textBox.SetBinding(TextBox.TextProperty, this.CreateBindingTwoWay(fieldPath));
                            dataTemplate.VisualTree = textBox;
                        }
                        else if (state == GenericDataListState.Updating)
                        {
                            FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                            if (topProperty.ControlType == Infrastructure.Attributes.ControlType.Pr)
                            { textBox.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right); }
                            textBox.SetBinding(TextBox.TextProperty, this.CreateBindingTwoWay(fieldPath));
                            dataTemplate.VisualTree = textBox;
                        }
                        else if (state == GenericDataListState.InsertingDisplay)
                        {
                            FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
                            if (topProperty.ControlType == Infrastructure.Attributes.ControlType.Pr)
                            { textBox.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right); }
                            textBox.SetBinding(TextBox.TextProperty, this.CreateBindingTwoWay(fieldPath));
                            dataTemplate.VisualTree = textBox;
                        }

                    }
                

            }

            return dataTemplate;

        }
        private Binding CreateBindingTwoWay(String path)
        {
            Binding binding = new Binding("ItemsView.CurrentItem[" + path + "]");
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.ValidatesOnDataErrors = true;
            return binding;
        }
        private Binding CreateBindingState()
        {
            Binding binding = new Binding("State");
            binding.Source = this.DataContext;
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            return binding;
        }

        private Binding CreateBindingIsLocked()
        {
            Binding binding = new Binding("IsLocked");
            binding.Source = this.DataContext;
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            return binding;
        }

        private BindingBase CreateBindingOneWay(string fieldPath)
        {
            Binding binding = new Binding("ItemsView.CurrentItem[" + fieldPath + "]");
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.ValidatesOnDataErrors = true;
            return binding;
        }

        public GenericDataControl()
        {
            InitializeComponent();
            this.DataContextChanged += GenericDataControl_DataContextChanged;
        }

        void GenericDataControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.UpdateTemplate();
        }
    }
}
