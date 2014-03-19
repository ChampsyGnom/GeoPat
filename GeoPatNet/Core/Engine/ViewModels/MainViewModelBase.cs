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
using Emash.GeoPatNet.Presentation.Views;

using Microsoft.Practices.Unity;
using System.Windows;
using System.Windows.Controls;
using Emash.GeoPatNet.Infrastructure.Capability;
using System.ComponentModel;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;
namespace Emash.GeoPatNet.Engine.ViewModels
{
    public abstract class MainViewModelBase : IMainViewModel,INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        public DelegateCommand ExportDataCommand { get;protected set; }
        public DelegateCommand ImportDataCommand { get; protected set; }
        public DelegateCommand ExportConfigurationCommand { get; protected set; }
        public DelegateCommand ImportConfigurationDataCommand { get; protected set; }
        public DelegateCommand SwapActiveViewCommand { get; protected set; }
        public DelegateCommand ShowDocumentCommand { get; protected set; }
        public DelegateCommand CustomFilterActiveViewCommand { get; protected set; }
        public DelegateCommand CustomSortActiveViewCommand { get; protected set; }
        public DelegateCommand CustomDisplayActiveViewCommand { get; protected set; }
        public DelegateCommand ShowCartoCommand { get; protected set; }
        public DelegateCommand<DocumentClosingEventArgs> DocumentClosingCommand { get; protected set; }
        public DelegateCommand<DocumentClosedEventArgs> DocumentClosedCommand { get; protected set; }

        
        public DelegateCommand ShowStatCommand { get; protected set; }

        private Object _activeContent;

        public Object ActiveContent
        {
            get { return _activeContent; }
            set 
            { 
                _activeContent = value; 
                this.RaiseCommandChanges(); 
                this.RaisePropertyChanged("ActiveContent"); 
            }
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
            this.ShowStatCommand = new DelegateCommand(ShowStatExecute, CanShowStat);
            this.ShowCartoCommand = new DelegateCommand(ShowCartoExecute);
            this.DocumentClosingCommand = new DelegateCommand<DocumentClosingEventArgs>(DocumentClosingExecute);
            this.DocumentClosedCommand = new DelegateCommand<DocumentClosedEventArgs>(DocumentClosedExecute);
            this.ShowDocumentCommand = new DelegateCommand(ShowDocumentExectue, CanShowDocumentExectue);
        }

        private void DocumentClosedExecute(DocumentClosedEventArgs arg)
        {
            // Avalon Dock desactive les view quand on les ferme mais ne les retire pas du région manager .... 
            // certainement pour les recycler
            if (arg.Document != null && arg.Document is LayoutDocument)
            {
                LayoutDocument document = arg.Document as LayoutDocument;
                if (document.Content != null)
                {
                    IRegion region = this._regionManager.Regions["TabRegion"];
                    if (region.Views.Contains(document.Content))
                    {region.Remove(document.Content);}
                    if (document.Content is IDisposable)
                    {(document.Content as IDisposable).Dispose(); }
                    GC.SuppressFinalize(document.Content);
                }
            }
        }


        private void DocumentClosingExecute(DocumentClosingEventArgs arg)
        {
            // eventuellement des cancel
        }

        private void ShowCartoExecute()
        {
            this._container.Resolve<ICartoService>().ShowCarto();
        }


        private void ShowDocumentExectue()
        {
            ((ActiveContent as FrameworkElement).DataContext as IDocumentable).ShowDocument();
        }

        private Boolean CanShowDocumentExectue()
        {
            return (
                 this.ActiveContent != null &&
                 this.ActiveContent is FrameworkElement &&
                 (ActiveContent as FrameworkElement).DataContext != null &&
                 (ActiveContent as FrameworkElement).DataContext is IDocumentable);
        }

        public void ShowStatExecute()
        {
            ((ActiveContent as FrameworkElement).DataContext as IStatable).ShowStat();
        }




        public Boolean  CanShowStat()
        {
            return (
                  this.ActiveContent != null &&
                  this.ActiveContent is FrameworkElement &&
                  (ActiveContent as FrameworkElement).DataContext != null &&
                  (ActiveContent as FrameworkElement).DataContext is IStatable);
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
            this.ShowStatCommand.RaiseCanExecuteChanged();
            this.ShowDocumentCommand.RaiseCanExecuteChanged();

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
