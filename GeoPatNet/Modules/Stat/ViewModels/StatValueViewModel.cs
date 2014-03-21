using Emash.GeoPatNet.Infrastructure.Symbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Modules.Stat.ViewModels
{
    public class StatValueViewModel
    {
        public Symbology Symbology { get; set; }
        public Object IndependentValue
        {
            get
            {
                return this.Symbology.DisplayName;
            }
        }
        public Double DependentValue
        {
            get
            {
                double result = 33;


                return result;
            }
        }
    }
}
