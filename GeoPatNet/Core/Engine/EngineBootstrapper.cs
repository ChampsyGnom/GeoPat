using Emash.GeoPatNet.Infrastructure.ViewModels;
using Emash.GeoPatNet.Infrastructure.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using System.Diagnostics;

using Emash.GeoPatNet.Infrastructure.Services;



using Xceed.Wpf.AvalonDock;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.RegionAdapters;
using Xceed.Wpf.AvalonDock.Layout;

using Emash.GeoPatNet.Engine.ViewModels;
using Emash.GeoPatNet.Engine.Services;
using Microsoft.Practices.Prism.Events;
using Emash.GeoPatNet.Infrastructure.Events;
using Emash.GeoPatNet.Infrastructure.Models;



namespace Emash.GeoPatNet.Engine
{
    public class EngineBootstrapper<VM, V> : UnityBootstrapper
        where VM : IMainViewModel 
        where V : Window,IMainView
       
    {
        public int MaxIntializeTimeout { get; protected set; }
        private Task _moduleInitializerTask;
        public EngineBootstrapper()
        {
            this.MaxIntializeTimeout = 200;
        }
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);            
            String modulePath = System.IO.Path.Combine(appStartPath, "Resources\\Modules");
            if (!System.IO.Directory.Exists(modulePath))
            { System.IO.Directory.CreateDirectory(modulePath); }
           this.ModuleCatalog = new DirectoryModuleCatalog() { ModulePath = System.IO.Path.Combine(appStartPath, "Resources\\Modules") };
           
            
        }
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            if (mappings == null) return null;

            // Add custom mappings
            mappings.RegisterMapping(typeof(DockingManager), ServiceLocator.Current.GetInstance<DockingManagerRegionAdapter>());
            mappings.RegisterMapping(typeof(LayoutAnchorable), ServiceLocator.Current.GetInstance<AnchorableRegionAdapter>());
            return mappings;

        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.RegisterType<IMainViewModel, VM>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IMainView,V>(new ContainerControlledLifetimeManager ());
            this.Container.RegisterType<IDataImportViewModel, DataImportViewModel>();
            this.Container.RegisterType<IEngineService, EngineService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<ITranslateService, TranslateService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IProviderConfigurationViewModel, ProviderConfigurationViewModel>();
            this.Container.RegisterType<IProviderConfigurationCreateViewModel, ProviderConfigurationCreateViewModel>();
            this.Container.RegisterType<IProviderConfigurationLoginViewModel, ProviderConfigurationLoginViewModel>();
           
        }


        protected override void InitializeShell()
        {
            base.InitializeShell();
            System.Windows.Application.Current.MainWindow = this.Container.Resolve<V>();
            
        }


        protected override System.Windows.DependencyObject CreateShell()
        {
            V mainView = this.Container.Resolve<V>();
            return mainView;
        }
        public virtual void InitializeApplication()
        {
        }
        protected override void InitializeModules()
        {
           
            base.InitializeModules();
            this.Container.Resolve<ISplashService>().ShowSplash();
         
            IDataService dataService = this.Container.Resolve<IDataService>();


            IReperageService reperageService = this.Container.TryResolve<IReperageService>();
            IDashboardService dashBoardService = this.Container.TryResolve<IDashboardService>();
            ICartoService cartoService = this.Container.TryResolve<ICartoService>();
            ITranslateService translateService = this.Container.TryResolve<ITranslateService>();
            IDocumentService documentService = this.Container.TryResolve<IDocumentService>();
            IDialogService dialogService = this.Container.TryResolve<IDialogService>();

            ServiceLocator.Current.GetInstance<IEventAggregator>().GetEvent<SplashEvent>().Publish("Chargement de la configuration ... ");
            dataService.LoadProviderConfiguration();
            if (dataService.ProviderConfiguration.DefaultItem == null)
            {this.Container.Resolve<ISplashService>().SplashUserAction = Infrastructure.Enums.SplashUserAction.ChooseDatabase;}


            Task taskWaitingUserAction = this.Container.Resolve<ISplashService>().CreateTaskWaitingUserAction(1000);
            taskWaitingUserAction.Start();
            taskWaitingUserAction.Wait();
            if (this.Container.Resolve<ISplashService>().SplashUserAction == Infrastructure.Enums.SplashUserAction.Exit)
            {
                this.Container.Resolve<ISplashService>().CloseSplash();
                this.Container.Resolve<V>().Close();
                System.Windows.Application.Current.Shutdown();
                return;
            }
            bool exit = false;
            if (this.Container.Resolve<ISplashService>().SplashUserAction == Infrastructure.Enums.SplashUserAction.ChooseDatabase)
            {
               
                while (!exit)
                {
                    Window window = dialogService.CreateDialog("ProviderConfigurationRegion", "Choix de la base de données");
                    Nullable<Boolean> result = window.ShowDialog();
                    if (result.HasValue && result.Value == true)
                    {
                        if (dataService.ProviderConfiguration.DefaultItem != null)
                        {exit = true; break;}
                    }
                    else
                    {
                        this.Container.Resolve<ISplashService>().CloseSplash();
                        this.Container.Resolve<V>().Close();
                        System.Windows.Application.Current.Shutdown();
                        return;
                    }
                }
            }
            string login = "postgres";
            string passord = dataService.ProviderConfiguration.GetPasswordForLogin(dataService.ProviderConfiguration.DefaultItem , login);
            bool connected = false;
            exit = false;
            while (!connected && !exit)
            {
                if (dataService.ProviderConfiguration.TryConnect(login, passord))
                { connected = true; }
                else
                {
                    ProviderConfigurationLoginViewModel vm = new ProviderConfigurationLoginViewModel();
                    Window window = dialogService.CreateDialog("ProviderConfigurationLoginRegion", "Connexion",vm);
                    vm.Login = login;
                    vm.Password = passord;
                    Nullable<Boolean> result = window.ShowDialog();
                    if (result.HasValue && result.Value == true)
                    {

                        login = vm.Login;
                        passord = vm.Password;
                    }
                    else exit = true;

                }
            }
            if (exit)
            {
                this.Container.Resolve<ISplashService>().CloseSplash();
                this.Container.Resolve<V>().Close();
                System.Windows.Application.Current.Shutdown();
                return;
            }
            dataService.ProviderConfiguration.SetLoginPassword(dataService.ProviderConfiguration.DefaultItem, login, passord);

            Console.WriteLine(dataService.ProviderConfiguration.DefaultItem);

            dataService.Initialize(login);
             
            if (translateService != null)
            { translateService.Initialize(); }

            if (dashBoardService != null)
            { dashBoardService.Initialize(); }

            if (reperageService != null)
            { reperageService.Initialize(); }

            if (cartoService != null)
            { cartoService.Initialize(); }

            if (documentService != null)
            { documentService.Initialize(); }

            this.InitializeApplication();
            this.Container.Resolve<ISplashService>().CloseSplash();
            this.Container.Resolve<V>().Show();
          
                   
              
            
            
            
        }

       
    }
}
