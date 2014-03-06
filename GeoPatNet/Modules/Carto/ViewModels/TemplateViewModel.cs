using Emash.GeoPatNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class TemplateViewModel
    {
        public SigTemplate Model { get; private set; }

        public String DisplayName
        {
            get{ return this.Model.Libelle; }
        }
        public TemplateViewModel(SigTemplate model)
        {
            // TODO: Complete member initialization
            this.Model = model;
        }

    }
}
