using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Enums;
using Emash.GeoPatNet.Infrastructure.Reflection;

namespace Emash.GeoPatNet.Modules.Stat.ViewModels
{
   
    public class StatFieldViewModel
    {
        public EntityFieldInfo Field { get; set; }
        public StatFieldPart Part { get; set; }

        public StatFieldViewModel()
        {
            this.Part = StatFieldPart.All;
        }

        public String DisplayName
        {
            get {
                if (this.Part == StatFieldPart.All)
                { return this.Field.DisplayName; }
                else if (this.Part == StatFieldPart.Year)
                { return "Année de "+this.Field.DisplayName; }
                return this.Field.DisplayName;
            }
        }
       
    }
}
