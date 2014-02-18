using Emash.GeoPatNet.Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.ViewModels
{
    public class GeneratorSqlPostgreViewModel : ViewModelBase
    {
        private Project _project;
        public String SqlPath { get; set; }
        public GeneratorSqlPostgreViewModel(Project project)
        {
            // TODO: Complete member initialization
            this._project = project;
        }

    }
}
