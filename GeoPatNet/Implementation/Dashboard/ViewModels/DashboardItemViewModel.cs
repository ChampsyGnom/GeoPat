using Emash.GeoPatNet.Data.Implementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Dashboard.Implementation.ViewModels
{
    public abstract class DashboardItemViewModel
    {
        public String DisplayName { get; set; }
        public InfDashboard Model { get; set; }
        
    }
}
