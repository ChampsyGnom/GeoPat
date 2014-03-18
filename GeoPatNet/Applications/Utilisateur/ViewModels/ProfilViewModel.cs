using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Engine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Emash.GeoPatNet.Infrastructure.Enums;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System.Data.Entity;

namespace Emash.GeoPatNet.App.Utilisateur.ViewModels
{
    public class ProfilViewModel : GenericListViewModel<PrfProfil>
    {

        public DelegateCommand ProfilTableCheckChangeCommand { get; private set; }

        public ProfilViewModel()
        {
            this.ProfilTableCheckChangeCommand = new DelegateCommand(ProfilTableCheckChangeExecute);
        }

        private void ProfilTableCheckChangeExecute()
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            dataService.DataContext.SaveChanges();
        }

        public override void AfterCommit(GenericDataListState state, PrfProfil model)
        {
            base.AfterCommit(state, model);
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            DbSet<PrfSchema> schemas = dataService.GetDbSet<PrfSchema>();
            DbSet<PrfTable> tables = dataService.GetDbSet<PrfTable>();
            DbSet<PrfProfil> profils = dataService.GetDbSet<PrfProfil>();
            DbSet<PrfProfilTable> profilTables = dataService.GetDbSet<PrfProfilTable>();
            if (state == GenericDataListState.InsertingEmpty || state == GenericDataListState.InsertingDisplay)
            {
                foreach (PrfTable table in model.PrfSchema.PrfTables)
                {
                    PrfProfilTable profilTable = (from pt in profilTables where pt.PrfProfilId.Equals(model.Id) && pt.PrfTableId.Equals(table.Id) select pt).FirstOrDefault();
                    if (profilTable == null)
                    {
                        profilTable = new PrfProfilTable();
                        profilTable.PrfProfilId = model.Id;
                        profilTable.PrfTableId = table.Id;
                        profilTable.Import = false;
                        profilTable.Write = false;
                        profilTables.Add(profilTable);                        
                    }
                }
                dataService.DataContext.SaveChanges();
                
            }
        }

        
    }
}
