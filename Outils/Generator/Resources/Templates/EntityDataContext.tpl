using @NameSpace.Models;
using @NameSpaceInfrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
namespace @NameSpace
{
    public class DataContext : IDataContext
    {
	    public DataContext(DbConnection connection)
            : base(connection)
        {
        
        }

@Properties

    }
}
