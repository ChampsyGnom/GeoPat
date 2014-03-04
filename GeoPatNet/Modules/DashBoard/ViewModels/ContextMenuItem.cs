using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Dashboard.Implementation.ViewModels
{
    public  class ContextMenuItem
    {
        public List<ContextMenuItem> Items { get;private  set; }
        public DashboardItemViewModel DashboardItem { get; set; }
        public String DisplayName { get; set; }
        public DelegateCommand Command { get; set; }

        public ContextMenuItem()
        {
            this.Items = new List<ContextMenuItem>();
        }
    }
}
