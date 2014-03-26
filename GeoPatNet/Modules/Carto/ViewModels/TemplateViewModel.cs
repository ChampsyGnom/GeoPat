using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.ComponentModel;
namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class TemplateViewModel
    {
        public ObservableCollection<ContextMenuItemInfo> ContextMenuInfos { get; private set; }
        public Int64 Id { get;private  set; }
        public String DisplayName { get; private set; }
        public ObservableCollection<TemplateNodeViewModel> Nodes { get; private set; }

        public TemplateViewModel(SigTemplate templateItem)
        {
            this.Id = templateItem.Id;
            this.DisplayName = templateItem.Libelle;
            this.Nodes = new ObservableCollection<TemplateNodeViewModel>();
            this.ContextMenuInfos = new ObservableCollection<ContextMenuItemInfo>();

        }
    }
}
