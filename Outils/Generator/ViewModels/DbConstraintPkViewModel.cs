using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Generator.Models;
using System.ComponentModel;

namespace Emash.GeoPatNet.Generator.ViewModels
{
    [DisplayName("Clé primaire")]    
    public  class DbConstraintPkViewModel : DbConstraintViewModel
    {
        
        private DbPrimaryKey dbPrimaryKey;

        public DbConstraintPkViewModel(DbTable table, DbPrimaryKey dbPrimaryKey)
        {       
            this.dbPrimaryKey = dbPrimaryKey;
            this.DisplayName = "Pk " + table.DisplayName;
            this.Name = dbPrimaryKey.Name;
            this.Id = dbPrimaryKey.Id;
        }
    }
}
