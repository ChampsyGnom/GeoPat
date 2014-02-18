using @NameSpace.Models;
using @NameSpaceInfrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
namespace @NameSpace
{
    public class DataContext : IDataContext
    {
	    private DbModelBuilder _modelBuilder;
        public override DbModelBuilder ModelBuilder
        {
            get { return _modelBuilder; }
        }

@Properties	   
        
	    public DataContext(DbConnection connection)
            : base(connection)
        {
        
        }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
            this._modelBuilder = modelBuilder;
@ModelBuilder
        }



    }
}
