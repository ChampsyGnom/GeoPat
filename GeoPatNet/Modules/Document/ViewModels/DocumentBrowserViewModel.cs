using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Reflection;
using System.Data.Entity;
using System.Reflection;
namespace Emash.GeoPatNet.Modules.Document.ViewModels
{
    public class DocumentBrowserViewModel
    {
        private IDataService DataService { get; set; }
        public ObservableCollection<DocumentCodeViewModel> Codes { get;private  set; }
        private Type ModelType { get;  set; }
     
        public DocumentBrowserViewModel(Type modelType, Object entityModel)
        {
            this.ModelType = modelType;
            this.DataService = ServiceLocator.Current.GetInstance<IDataService>();
            this.Codes = new ObservableCollection<DocumentCodeViewModel>();
            EntityTableInfo entityTableInfo = this.DataService.GetEntityTableInfo(this.ModelType);
            PropertyInfo propModelId = modelType.GetProperty("Id");
            Int64 modelId = (Int64)propModelId.GetValue(entityModel);
            String entityTableName = entityTableInfo.TableName.ToLower();

            String camelSchemaName = entityTableInfo.SchemaInfo.SchemaName.Substring(0, 1).ToUpper() + entityTableInfo.SchemaInfo.SchemaName.Substring(1).ToLower();
            DbSet setCodeDoc = this.DataService.GetDbSet(camelSchemaName + "CodeDoc");
            
            PropertyInfo propCode = setCodeDoc.ElementType.GetProperty("Code");
            PropertyInfo propPath = setCodeDoc.ElementType.GetProperty("Path");
            PropertyInfo propLibelle = setCodeDoc.ElementType.GetProperty("Libelle");
            PropertyInfo propId = setCodeDoc.ElementType.GetProperty("Id");
            foreach (Object item in setCodeDoc)
            {
                DocumentCodeViewModel vm = new DocumentCodeViewModel();
                vm.Code = propCode.GetValue(item).ToString();
                vm.Libelle = propLibelle.GetValue(item).ToString();
                vm.Path = propPath.GetValue(item).ToString();
                vm.Id = (Int64)propId.GetValue(item);
                this.Codes.Add(vm);
            }

            DbSet setDoc = this.DataService.GetDbSet(camelSchemaName + "Doc");
        }
    }
}
