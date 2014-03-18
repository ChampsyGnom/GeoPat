using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Engine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;

namespace Emash.GeoPatNet.App.Utilisateur.ViewModels
{
    public class ProfilViewModel : GenericListViewModel<PrfProfil>
    {
        public DelegateCommand ProfilTableDataGridCellEditEndingCommand { get; set; }

        public ProfilViewModel()
        { 
            this.ProfilTableDataGridCellEditEndingCommand = new DelegateCommand (ProfilTableDataGridCellEditEndingExecute );
        }

        private void ProfilTableDataGridCellEditEndingExecute()
        {
            if (this.State == Infrastructure.Enums.GenericDataListState.Display && this.IsLocked == false)
            {
                this.DataService.DataContext.SaveChanges();
            }
        }
    }
}
