using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Emash.GeoPatNet.Generator.Views;
using Emash.GeoPatNet.Generator.ViewModels;
using Emash.GeoPatNet.Generator.Services;
namespace Emash.GeoPatNet.Generator
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            this.Container.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<MainView>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<SerializationService>(new ContainerControlledLifetimeManager());
            //this.Container.RegisterType(
        }
        protected override System.Windows.DependencyObject CreateShell()
        {
            return this.Container.Resolve<MainView>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            System.Windows.Application.Current.MainWindow = this.Container.Resolve<MainView>();
            System.Windows.Application.Current.MainWindow.Show();
        }
    }
}
