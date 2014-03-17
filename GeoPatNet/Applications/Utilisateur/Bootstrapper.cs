using Emash.GeoPatNet.Infrastructure;
using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Engine;
using Emash.GeoPatNet.App.Utilisateur.ViewModels;
using Emash.GeoPatNet.App.Utilisateur.Views;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Emash.GeoPatNet.App.Utilisateur
{
    public class Bootstrapper : EngineBootstrapper<MainViewModel, MainView>
    {
        protected override void ConfigureContainer()
        {
                       
            this.Container.RegisterType<ProfilMasterDetailView>();
            this.Container.RegisterType<UserMatserDetailView>();
            base.ConfigureContainer();
        }
        
    }
}
