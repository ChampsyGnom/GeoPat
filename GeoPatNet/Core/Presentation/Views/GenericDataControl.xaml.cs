using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Enums;
using Emash.GeoPatNet.Presentation.Converters;
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
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit;
using Emash.GeoPatNet.Infrastructure.Validations;
using Emash.GeoPatNet.Presentation.Builders;


namespace Emash.GeoPatNet.Presentation.Views
{
    /// <summary>
    /// Logique d'interaction pour GenericDataControl.xaml
    /// </summary>
    public partial class GenericDataControl : UserControl
    {
        public Boolean _isParentColumn;
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
            EntityFieldInfo fieldInfo = (from f in entityTableInfo.FieldInfos where f.Path.Equals (fieldPath) select f).FirstOrDefault();            
            Style contentControlStyle = DataControlTemplateBuilder.CreateStyle(fieldInfo, dataService,this);
            contentControl.SetValue(ContentControl.StyleProperty, contentControlStyle);
           
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
