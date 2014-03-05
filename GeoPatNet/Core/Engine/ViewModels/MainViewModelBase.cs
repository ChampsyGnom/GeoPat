using Emash.GeoPatNet.Infrastructure.ViewModels;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.Prism.Events;
using Emash.GeoPatNet.Infrastructure.Events;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Views;
using Microsoft.Practices.Prism.Regions;
using System.Reflection;
using Emash.GeoPatNet.Presentation.Implementation.Views;

using Microsoft.Practices.Unity;
using System.Windows;
using System.Windows.Controls;
using Emash.GeoPatNet.Infrastructure.Capability;
namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public abstract class MainViewModelBase : IMainViewModel
    {
        public DelegateCommand ExportDataCommand { get;protected set; }
        public DelegateCommand ImportDataCommand { get; protected set; }
        public DelegateCommand ExportConfigurationCommand { get; protected set; }
        public DelegateCommand ImportConfigurationDataCommand { get; protected set; }
        public DelegateCommand SwapActiveViewCommand { get; protected set; }

        public DelegateCommand CustomFilterActiveViewCommand { get; protected set; }
        public DelegateCommand CustomSortActiveViewCommand { get; protected set; }
        public DelegateCommand CustomDisplayActiveViewCommand { get; protected set; }



        private Object _activeContent;

        public Object ActiveContent
        {
            get { return _activeContent; }
            set { _activeContent = value; this.RaiseCommandChanges(); }
        }
   
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
            this.SwapActiveViewCommand = new DelegateCommand(SwapActiveView, CanSwapActiveView);
            this.CustomFilterActiveViewCommand = new DelegateCommand(CustomFilterActiveView, CanCustomFilterActiveView);
            this.CustomSortActiveViewCommand = new DelegateCommand(CustomSortActiveView, CanCustomSortActiveView);
            this.CustomDisplayActiveViewCommand = new DelegateCommand(CustomDisplayActiveView, CanCustomDisplayActiveView);
        }

        private Boolean CanCustomFilterActiveView()
        { 
            return (
            this.ActiveContent != null && 
            this.ActiveContent is FrameworkElement && 
            (ActiveContent as FrameworkElement).DataContext != null && 
            (ActiveContent as FrameworkElement).DataContext is ICustomFilterable);
        }

        private void CustomFilterActiveView()
        {  ((ActiveContent as FrameworkElement).DataContext as ICustomFilterable).ShowCustomFilter(); }

        private Boolean CanCustomSortActiveView()
        {
            return (
               this.ActiveContent != null &&
               this.ActiveContent is FrameworkElement &&
               (ActiveContent as FrameworkElement).DataContext != null &&
               (ActiveContent as FrameworkElement).DataContext is ICustomSortable);
        }

        private void CustomSortActiveView()
        { ((ActiveContent as FrameworkElement).DataContext as ICustomSortable).ShowCustomSort(); }

        private Boolean CanCustomDisplayActiveView()
        {
            return (
              this.ActiveContent != null &&
              this.ActiveContent is FrameworkElement &&
              (ActiveContent as FrameworkElement).DataContext != null &&
              (ActiveContent as FrameworkElement).DataContext is ICustomDisplay);
        }

        private void CustomDisplayActiveView()
        { ((ActiveContent as FrameworkElement).DataContext as ICustomDisplay).ShowCustomDisplay(); }

        protected virtual void RaiseCommandChanges()
        {
            this.SwapActiveViewCommand.RaiseCanExecuteChanged();
            this.ImportDataCommand.RaiseCanExecuteChanged();
            this.CustomDisplayActiveViewCommand.RaiseCanExecuteChanged();
            this.CustomFilterActiveViewCommand.RaiseCanExecuteChanged();
            this.CustomSortActiveViewCommand.RaiseCanExecuteChanged();

        }
        private Boolean CanSwapActiveView()
        {
            return (this.ActiveContent != null && ActiveContent is ISawpableView);
        }

        private void SwapActiveView()
        {
            if (this.ActiveContent != null && ActiveContent is ISawpableView)
            {
                (ActiveContent as ISawpableView).SwapView();
            }
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
            List<Control> views = this.GetEntityViews(tableInfo);          
            swapRegionView.Configure(detailsRegionManager, views.ToArray());
            region.Activate(swapRegionView);
            swapRegionView.SwapView();
        }

        public virtual List<Control> GetEntityViews(EntityTableInfo tableInfo)
        {
            List<Control> views = new List<Control>();
            views.Add(new GenericDataGridView());
            views.Add(new GenericDataFormView());         
            return views;
        }

        private void ImportDataExecute()
        {
            IDialogService dialogService = _container.Resolve<IDialogService>();
            Window window = dialogService.CreateDialog("DataImportRegion","Importer des données");
            Nullable<Boolean> result = window.ShowDialog();
        }
    }
}
