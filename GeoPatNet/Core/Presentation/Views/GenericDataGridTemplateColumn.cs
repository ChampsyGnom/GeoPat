using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Enums;
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
using Emash.GeoPatNet.Presentation.Converters;
using Xceed.Wpf.Toolkit;
using Emash.GeoPatNet.Infrastructure.Validations;
using Emash.GeoPatNet.Presentation.Builders;



namespace Emash.GeoPatNet.Presentation.Views
{
    public class GenericDataGridTemplateColumn : DataGridTemplateColumn
    {
        public EntityFieldInfo FieldInfo { get; private set; }            

        public GenericDataGridTemplateColumn(EntityFieldInfo fieldInfo,DataGrid dataGrid)
        {         
            this.FieldInfo = fieldInfo;            
            this.Header = this.FieldInfo.DisplayName;
            this.CellTemplate = DataGridTemplateBuilder.CreateCellTemplate(this.FieldInfo, dataGrid);
            this.CellEditingTemplate = DataGridTemplateBuilder.CreateCellEditingTemplate(this.FieldInfo, dataGrid);
           
        }
    }
}
