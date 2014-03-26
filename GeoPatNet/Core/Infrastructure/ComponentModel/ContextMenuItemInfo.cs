using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
namespace Emash.GeoPatNet.Infrastructure.ComponentModel
{
    public class ContextMenuItemInfo
    {
       
        public DelegateCommand Command { get;  set; }
        public String DisplayName { get; set; }
        public ObservableCollection<ContextMenuItemInfo> Items { get; set; }
        public ContextMenuItemInfo()
        {
            this.Items = new ObservableCollection<ContextMenuItemInfo>();
        }
    }
}
