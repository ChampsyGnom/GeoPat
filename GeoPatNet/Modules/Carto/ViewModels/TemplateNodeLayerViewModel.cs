using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Controls;
using Emash.GeoPatNet.Data.Models;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class TemplateNodeLayerViewModel : TemplateNodeViewModel
    {

        public List<IMapLayer> Layers { get; private set; }
        public TemplateNodeLayerViewModel(SigNode model)
        {
            // TODO: Complete member initialization
            this.Model = model;
            this.DisplayName = model.Libelle;
            this.Layers = new List<IMapLayer>();
        }

        internal void CreateLayers()
        {
            
        }
    }
}
