using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class GenericPropertyDescriptor<M> : PropertyDescriptor   
    {
        public override string DisplayName
        {
            get
            {
                if (this.fieldPath.IndexOf(".") != -1)
                {
                    return this.ColumnInfo.TableInfo.DisplayName;
                }
                else
                {
                    return this.ColumnInfo.DisplayName;
                }
            }
        }
       
        private string fieldPath;
        public EntityColumnInfo ColumnInfo { get; set; }
        public EntityTableInfo MainTableInfo { get; set; }
      
        public GenericPropertyDescriptor(string fieldPath)
            : base("[" + fieldPath+"]", null)  
        {
         
            this.fieldPath = fieldPath;
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            this.MainTableInfo = dataService.GetEntityTableInfo(typeof(M));
            this.ColumnInfo = dataService.GetTopColumnInfo(typeof(M), fieldPath);
           
        }

        public override object GetEditor(Type editorBaseType)
        {
            Object result = base.GetEditor(editorBaseType);
            return result;
        }
        public override bool CanResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override Type ComponentType
        {
            get { throw new NotImplementedException(); }
        }

        public override object GetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override bool IsReadOnly
        {
            get { return false; ; }
        }

        public override Type PropertyType
        {
            get 
            {
                return typeof(String);                
            }
        }

        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object component, object value)
        {
            throw new NotImplementedException();
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
