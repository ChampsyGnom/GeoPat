using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Reflection;

namespace Emash.GeoPatNet.Modules.Stat.ViewModels
{
    public class StatFieldViewModel
    {
        public EntityColumnInfo TopColumnInfo { get; set; }
        public EntityColumnInfo BottomColumnInfo { get; set; }
        public String DisplayName { get; set; }
        public String FieldPath { get; set; }
    }
}
