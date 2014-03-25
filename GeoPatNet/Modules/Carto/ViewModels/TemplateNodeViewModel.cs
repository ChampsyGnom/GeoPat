using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public abstract class TemplateNodeViewModel
    {
        public String DisplayName { get; protected set; }
        public SigNode Model { get; protected set; }
    }
}
