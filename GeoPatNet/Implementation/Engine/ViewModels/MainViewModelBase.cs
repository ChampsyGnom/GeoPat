using Emash.GeoPatNet.Engine.Infrastructure.ViewModels;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public abstract class MainViewModelBase : IMainViewModel
    {
        public DelegateCommand ExportDataCommand { get;protected set; }
        public DelegateCommand ImportDataCommand { get; protected set; }
        public DelegateCommand ExportConfigurationCommand { get; protected set; }
        public DelegateCommand ImportConfigurationDataCommand { get; protected set; }
    }
}
