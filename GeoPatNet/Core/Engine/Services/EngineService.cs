using Emash.GeoPatNet.Engine.ViewModels;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Engine.Services
{
    public class EngineService : IEngineService
    {
        public IDialogService DialogService { get; private set; }

        public EngineService(IDialogService dialogService)
        {
            this.DialogService = dialogService;
        }
        public T1 ShowAddDialog<T1>() where T1 : class, new()
        {
            GenericListViewModel<T1> vmList = new GenericListViewModel<T1>();
           
            GenericDataFormView view = new GenericDataFormView();
            view.DataContext = vmList;
            view.ShowDataToolBar = false;
            view.ShowRecordPosition = false;
            view.ShowSlider = false;
            vmList.LockUnlockCommand.Execute();
            vmList.InsertCommand.Execute();
            Nullable<Boolean> result = this.DialogService.ShowDialog(view);
            
            return null;
        }


        public T1 ShowEditDialog<T1>(T1 model) where T1 : class, new()
        {
            return null;
        }
    }
}
