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
        public EntityFieldInfo Field { get; set; }
        public String DisplayName
        {
            get {
                return this.Field.DisplayName;
            }
        }
       
    }
}
