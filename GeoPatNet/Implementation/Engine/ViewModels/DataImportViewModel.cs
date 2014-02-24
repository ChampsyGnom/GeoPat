using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Engine.Infrastructure.ViewModels;

namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class DataImportViewModel : IDataImportViewModel
    {
        public String Title { get; set; }


        public DataImportViewModel()
        {
            this.Title = "Importer des données";
        }
    }
}
