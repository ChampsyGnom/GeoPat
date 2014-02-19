using Emash.GeoPatNet.Atom.Infrastructure.Services;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Dashboard.Implementation.Services
{
    public class DashboardService : IDashboardService
    {
        private IDataService _dataService;
        public DashboardService(IDataService dataService)
        {
            this._dataService = dataService;
           
        }
        public void Initialize()
        {
            DbSet<IInfCodeDashboard> datasCodeDashboard = _dataService.GetDbSet<IInfCodeDashboard>();
            if ((from d in datasCodeDashboard where d.Code == "TABLE" select d).Count() == 0)
            {
                IInfCodeDashboard codeTable = _dataService.CreateItem<IInfCodeDashboard>();
                codeTable.Code = "TABLE";
                codeTable.Libelle = "Table de la base de donnée";
                datasCodeDashboard.Add(codeTable);
            }
            if ((from d in datasCodeDashboard where d.Code == "FOLDER" select d).Count() == 0)
            { }
            IQueryable<IInfDashboard> datasDashboard = _dataService.GetDbSet<IInfDashboard>();
            Console.WriteLine(datasDashboard.ToString());
        }
    }
}
