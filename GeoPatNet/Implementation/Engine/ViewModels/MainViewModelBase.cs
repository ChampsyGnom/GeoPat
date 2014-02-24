﻿using Emash.GeoPatNet.Engine.Infrastructure.ViewModels;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.Prism.Events;
using Emash.GeoPatNet.Data.Infrastructure.Events;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Presentation.Infrastructure.Views;
using Microsoft.Practices.Prism.Regions;
using System.Reflection;
using Emash.GeoPatNet.Presentation.Implementation.Views;
using Emash.GeoPatNet.Presentation.Infrastructure.Services;
using Microsoft.Practices.Unity;
using System.Windows;
namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public abstract class MainViewModelBase : IMainViewModel
    {
        public DelegateCommand ExportDataCommand { get;protected set; }
        public DelegateCommand ImportDataCommand { get; protected set; }
        public DelegateCommand ExportConfigurationCommand { get; protected set; }
        public DelegateCommand ImportConfigurationDataCommand { get; protected set; }
        public Object ActiveContent { get; set; }
   
        private IEventAggregator _eventAggregator;
        private IRegionManager _regionManager;
        private IUnityContainer _container;
        public MainViewModelBase(IEventAggregator eventAggregator, IRegionManager regionManager,IUnityContainer container)
        {
           
            this._eventAggregator = eventAggregator;
            this._regionManager = regionManager;
            this._container = container;
            this._eventAggregator.GetEvent<OpenEntityEvent>().Subscribe(OpenEntityTable);
            this.ImportDataCommand = new DelegateCommand(ImportDataExecute);
        }

        private void OpenEntityTable(EntityTableInfo tableInfo)
        { 
            Console.WriteLine ("Open "+tableInfo.DisplayName );
            SwapRegionView swapRegionView = new SwapRegionView();
            Object viewModel =  Activator.CreateInstance ( typeof(GenericListViewModel<>).MakeGenericType(new Type[] { tableInfo.EntityType  }));
            swapRegionView.DataContext = viewModel;
            IRegion region = this._regionManager.Regions["TabRegion"];
            IRegionManager detailsRegionManager = region.Add(swapRegionView, null, true);
            IRegion regionContent = detailsRegionManager.Regions["SwapableRegion"];
            List<Object> views = new List<object>();
            views.Add(new GenericDataGridView());
            views.Add(new GenericDataFormView());
            swapRegionView.Configure(detailsRegionManager, views.ToArray());
            region.Activate(swapRegionView);
            swapRegionView.SwapView();
        }

        private void ImportDataExecute()
        {
            IDialogService dialogService = _container.Resolve<IDialogService>();
            Window window = dialogService.CreateDialog("DataImportRegion","Importer des données");
            Nullable<Boolean> result = window.ShowDialog();
        }
    }
}
