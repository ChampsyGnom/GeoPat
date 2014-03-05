using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Engine.ViewModels
{
    public class CustomDisplayViewModel<M> where M : new()
    {
        public ObservableCollection<CustomDisplayablePropertyViewModel> VisibleFields { get; private set; }
        public ObservableCollection<CustomDisplayableEntityViewModel<M>> Entities { get; private set; }

        public CustomDisplayViewModel(List<String> fieldPaths)
        {
            this.VisibleFields = new ObservableCollection<CustomDisplayablePropertyViewModel>();
            this.Entities = new ObservableCollection<CustomDisplayableEntityViewModel<M>>();

            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(typeof(M));
            List<EntityTableInfo> parentTables = new List<EntityTableInfo>();
            List<String> basicFieldPaths = dataService.GetTableFieldPaths(tableInfo);

            List<EntityColumnInfo> parentColumnInfos = new List<EntityColumnInfo>();
            foreach (String fieldPath in fieldPaths)
            {
                if (fieldPath.IndexOf(".") == -1)
                {
                    EntityColumnInfo columnInfo = (from c in tableInfo.ColumnInfos where c.PropertyName.Equals(fieldPath) select c).FirstOrDefault();
                    CustomDisplayablePropertyViewModel vm = new CustomDisplayablePropertyViewModel();
                    vm.DisplayName = columnInfo.DisplayName;
                    vm.FieldPath = fieldPath;
                    this.VisibleFields.Add(vm);
                  
                }
                else
                {
                    if (basicFieldPaths.Contains(fieldPath))
                    {
                        EntityColumnInfo columnInfo = dataService.GetTopColumnInfo(typeof(M), fieldPath);
                        CustomDisplayablePropertyViewModel vm = new CustomDisplayablePropertyViewModel();
                        vm.DisplayName = columnInfo.TableInfo.DisplayName;
                        vm.FieldPath = fieldPath;
                        this.VisibleFields.Add(vm);                      
                        parentTables.Add(columnInfo.TableInfo);
                        parentColumnInfos.Add(columnInfo);
                    }
                    else
                    {
                        EntityColumnInfo columnInfo = dataService.GetTopColumnInfo(typeof(M), fieldPath);
                        CustomDisplayablePropertyViewModel vm = new CustomDisplayablePropertyViewModel();
                        vm.DisplayName = columnInfo.TableInfo.DisplayName + " - " + columnInfo.DisplayName;
                        vm.FieldPath = fieldPath;
                        this.VisibleFields.Add(vm);
                        parentTables.Add(columnInfo.TableInfo);
                        parentColumnInfos.Add(columnInfo);
                    }

                   
                   
                    
                }
            }
            parentTables = (from t in parentTables orderby t.DisplayName select t).ToList();

            foreach (EntityTableInfo parentTableInfo in parentTables)
            {
                CustomDisplayableEntityViewModel<M> vmEntity = new CustomDisplayableEntityViewModel<M>();
                vmEntity.DisplayName = parentTableInfo.DisplayName;
                foreach (EntityColumnInfo columnInfo in parentTableInfo.ColumnInfos)
                {
                    if (!parentColumnInfos.Contains(columnInfo) && columnInfo.PrimaryKeyName == null && columnInfo.ControlType != ControlType.None)
                    {
                        CustomDisplayablePropertyViewModel vm = new CustomDisplayablePropertyViewModel();
                        vm.DisplayName = columnInfo.TableInfo.DisplayName + " - " + columnInfo.DisplayName;
                        String path = dataService.GetPath(columnInfo.TableInfo, tableInfo) + "." + columnInfo.PropertyName;
                        vm.FieldPath = path;
                        vmEntity.Fields.Add(vm);
                    
                    }
                }
                this.Entities.Add(vmEntity);
            }
        }
    }
}
