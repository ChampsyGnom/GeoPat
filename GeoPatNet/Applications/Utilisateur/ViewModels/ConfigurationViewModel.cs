using Emash.GeoPatNet.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Data.Models;
using System.Data.Entity;
namespace Emash.GeoPatNet.App.Utilisateur.ViewModels
{
    public class ConfigurationViewModel
    {
        public IDataService  DataService {get;private set;}
        public ObservableCollection<PrfSchema> Schemas { get; private set; }
        public ConfigurationViewModel(IDataService dataService)
        {
            this.DataService = dataService;
            this.Schemas = new ObservableCollection<PrfSchema>();
            DbSet<PrfSchema> schemas = dataService.GetDbSet<PrfSchema>();
            foreach (PrfSchema schema in schemas)
            { this.Schemas.Add(schema); }
        }
    }
}
