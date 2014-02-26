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
        public DashboardItemViewModel DashboardItem { get; set; }
        public String DisplayName { get; set; }
        public DelegateCommand<Object> Command { get; set; }
    }
}
