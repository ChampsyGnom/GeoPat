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
using Emash.GeoPatNet.Engine.Infrastructure.ViewModels;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;
namespace Emash.GeoPatNet.Presentation.Implementation.Views
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
                    if (fieldPath.IndexOf(".") == -1)
                    {
                        DataGridTemplateColumn column = new DataGridTemplateColumn();
                        EntityColumnInfo columnInfo = (from c in entityTableInfo.ColumnInfos where c.PropertyName.Equals (fieldPath ) select c).FirstOrDefault();
                        column.Header = columnInfo.DisplayName;
                        dataGrid.Columns.Add(column);
                    }
                    else
                    { }
                }
            }
        }
       
    }
}
