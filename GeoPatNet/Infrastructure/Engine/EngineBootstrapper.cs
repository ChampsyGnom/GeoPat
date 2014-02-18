using Emash.GeoPatNet.Engine.Infrastructure.ViewModels;
using Emash.GeoPatNet.Engine.Infrastructure.Views;
using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using System.Diagnostics;
using Emash.GeoPatNet.Presentation.Implentation.Views;
using Emash.GeoPatNet.Data.Infrastructure.Services;

namespace Emash.GeoPatNet.Engine.Infrastructure
{
    public class EngineBootstrapper<VM, V> : UnityBootstrapper
        where VM : IMainViewModel 
        where V : Window,IMainView
       
    {
        public int MaxIntializeTimeout { get; protected set; }
        private Task _splashTask;
        public EngineBootstrapper()
        {
            this.MaxIntializeTimeout = 3000;
        }
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            this.ModuleCatalog = new DirectoryModuleCatalog() { ModulePath = System.IO.Path.Combine(appStartPath, "Resources\\Modules") };
        }
       
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.RegisterType<IMainViewModel, VM>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IMainView,V>(new ContainerControlledLifetimeManager ());
            
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
            System.Windows.Application.Current.MainWindow = this.Container.Resolve<V>();
            
        }


        protected override System.Windows.DependencyObject CreateShell()
        {
            V mainView = this.Container.Resolve<V>();
            System.Windows.Threading.Dispatcher dispatcher = System.Windows.Application.Current.Dispatcher;
            SplashView splashView = new SplashView();
            splashView.Show();
            this._splashTask = new Task(new Action(delegate()
            {
                System.Threading.Thread.Sleep(this.MaxIntializeTimeout);
                dispatcher.Invoke(new Action(delegate()
                {
                    splashView.Close();
                    mainView.Show();
                }));
            }));
            return mainView;
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            this._splashTask.Start();
            IDataService dataService = this.Container.TryResolve<IDataService>();
            if (dataService != null)
            { dataService.Initialize("HOST=127.0.0.1;PORT=5432;DATABASE=aio;USER ID=postgres;PASSWORD=Emash21;PRELOADREADER=true;"); }
        }
    }
}
