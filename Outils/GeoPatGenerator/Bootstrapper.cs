using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

using Emash.GeoPat.Generator.Views;
using Emash.GeoPat.Generator.ViewModel;
namespace Emash.GeoPat.Generator
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.RegisterType(typeof(MainView), new ContainerControlledLifetimeManager());
            this.Container.RegisterType(typeof(MainViewModel), new ContainerControlledLifetimeManager());
        }
        protected override System.Windows.DependencyObject CreateShell()
        {
            return this.Container.Resolve<MainView>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            this.Container.Resolve<MainView>().Show();
        }
    }
}
