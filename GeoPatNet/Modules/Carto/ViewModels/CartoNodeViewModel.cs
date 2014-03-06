using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public abstract class CartoNodeViewModel
    {
        public SigNode Model { get; private set; }

        public CartoNodeViewModel(SigNode model)
        {
            this.Model = model;
        }
    }
}
