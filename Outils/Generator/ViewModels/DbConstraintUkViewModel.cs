using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Generator.Models;

namespace Emash.GeoPatNet.Generator.ViewModels
{
    [DisplayName("Clé unique")]    
    public class DbConstraintUkViewModel : DbConstraintViewModel
    {
        private Models.DbUniqueKey uk;

        public DbConstraintUkViewModel(DbTable table, DbUniqueKey uk)
        {
            // TODO: Complete member initialization
            this.uk = uk;
            this.DisplayName = "Uk " + table.DisplayName ;
            this.Name = uk.Name;
            this.Id = uk.Id;
        }
    }
}
