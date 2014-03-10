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
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.ViewModels;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Extensions;
namespace Emash.GeoPatNet.Presentation.Views
{
    /// <summary>
    /// Logique d'interaction pour GenericDataGridView.xaml
    /// </summary>
    public partial class GenericDataGridView : UserControl
    {
        public IEnumerable<String> FieldPaths
        {
            get { return (IEnumerable<String>)GetValue(FieldPathsProperty); }
            set { SetValue(FieldPathsProperty, value); }
        }

        public static readonly DependencyProperty FieldPathsProperty =
            DependencyProperty.Register("FieldPaths", typeof(IEnumerable<String>), typeof(GenericDataGridView), new PropertyMetadata(new PropertyChangedCallback(OnFieldPathsChange)));



        public GenericDataGridView()
        {
           
            this.DataContextChanged += GenericDataGridView_DataContextChanged;
            InitializeComponent();
            BindingOperations.SetBinding(this, GenericDataGridView.FieldPathsProperty, new Binding("FieldPaths"));
            BindingOperations.SetBinding(dataGrid, DataGrid.ItemsSourceProperty, new Binding("ItemsView"));
            this.dataGrid.GotFocus += dataGrid_GotFocus;
            this.dataGrid.BeginningEdit += dataGrid_BeginningEdit;
            this.dataToolBar.GotFocus += dataToolBar_GotFocus;
            this.dataToolBar.cancelButton.Click += cancelButton_Click;
            this.dataToolBar.commitbutton.Click += commitbutton_Click;
          

            
        }

        void dataGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            Point pos =  Mouse.GetPosition(this.dataGrid);
            IInputElement hit =   dataGrid.InputHitTest(pos);
            DependencyObject hitDependencyObject = hit as DependencyObject;
            if (hitDependencyObject != null)
            {
                DataGridCell cell = hitDependencyObject.FindParentControl<DataGridCell>();
                if (cell != null)
                {
                    Console.WriteLine(cell);

                }
            }
          
            
        }

        private void DebugTree(DependencyObject obj)
        {
            Console.WriteLine(obj);
            DependencyObject  parent = VisualTreeHelper.GetParent(obj);
            if (parent != null)
            { this.DebugTree(parent); }
           
        }

       

        

        void commitbutton_Click(object sender, RoutedEventArgs e)
        {
            Keyboard.ClearFocus();
            this.dataGrid.CommitEdit();
            this.dataToolBar.Focus();
        }

        void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Keyboard.ClearFocus();
            this.dataGrid.CommitEdit();
            this.dataToolBar.Focus();
        }

        void dataToolBar_GotFocus(object sender, RoutedEventArgs e)
        {
            Keyboard.ClearFocus();
            this.dataGrid.CommitEdit();
            this.dataToolBar.Focus();
        }

        void dataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (this.DataContext != null && e.Row.DataContext != null)
            {
                if (this.DataContext is IRowEditableList && e.Row.DataContext is IRowEditableItem)
                {
                    IRowEditableList rowEditableList = this.DataContext as IRowEditableList;
                    IRowEditableItem rowEditableItem = e.Row.DataContext as IRowEditableItem;
                    if (!rowEditableList.CanEdit(rowEditableItem))
                    { e.Cancel = true; }

                }
            }
           
        }

        void dataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                // Starts the Edit on the row;
                DataGrid grd = (DataGrid)sender;
                grd.BeginEdit(e);
                Control control = GetFirstChildByType<Control>(e.OriginalSource as DataGridCell);
                if (control != null)
                {
                    control.Focus();
                }
            }
        }
        private T GetFirstChildByType<T>(DependencyObject prop) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(prop); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild((prop), i) as DependencyObject;
                if (child == null)
                    continue;

                T castedProp = child as T;
                if (castedProp != null)
                    return castedProp;

                castedProp = GetFirstChildByType<T>(child);

                if (castedProp != null)
                    return castedProp;
            }
            return null;
        }

        void GenericDataGridView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.CreateColumns();
        }

        private static void OnFieldPathsChange(DependencyObject source, DependencyPropertyChangedEventArgs arg)
        {
            if (source != null && source is GenericDataGridView)
            {
                GenericDataGridView genericDataGridView = source as GenericDataGridView;
                genericDataGridView.OnFieldPathsChange(arg.OldValue as IEnumerable <String>,arg.NewValue as IEnumerable <String>); 
              
            }
        }


        private void OnFieldPathsChange(IEnumerable<String> fieldPathsOld,IEnumerable<String> fieldPathsNew)
        {
            if (fieldPathsOld != null && fieldPathsOld is ObservableCollection<String>)
            {
                (fieldPathsOld as ObservableCollection<String>).CollectionChanged -= OnFieldPathsCollectionChanged;
            }
            if (fieldPathsNew != null &&  fieldPathsNew is ObservableCollection<String>)
            {
                (fieldPathsNew as ObservableCollection<String>).CollectionChanged += OnFieldPathsCollectionChanged;
            }
            this.CreateColumns();
        }

        void OnFieldPathsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.CreateColumns();
        }

        private void CreateColumns()
        {
            if (this.DataContext != null)
            {
                if (this.DataContext.GetType().IsGenericType )
                {
                    Type[] genericTypes = this.DataContext.GetType().GetGenericArguments();
                    if (genericTypes.Length == 1)
                    {
                        Type modelType = genericTypes[0];
                        this.CreateColumns(this.FieldPaths, modelType);
                    }
                }

               
            }
        }

        private void CreateColumns(IEnumerable<string> fieldPaths, Type modelType)
        {
            
            dataGrid.Columns.Clear();
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();

            EntityTableInfo entityTableInfo = dataService.GetEntityTableInfo(modelType);
            if (fieldPaths != null && modelType != null && entityTableInfo != null)
            {
               
                foreach (String fieldPath in fieldPaths)
                {
                    EntityFieldInfo fieldInfo = (from f in entityTableInfo.FieldInfos where f.Path.Equals(fieldPath) select f).FirstOrDefault();
                    if (fieldInfo != null)
                    {
                        GenericDataGridTemplateColumn column = new GenericDataGridTemplateColumn(fieldInfo, dataGrid);
                        dataGrid.Columns.Add(column);
                    }
                }
            }
          
           
            
            
        }
       
    }
}
