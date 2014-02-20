using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfDashboard
    {

        Int64 Id
        {
            get;
            set;
        }
        Nullable<Int64> IdParent
        {
            get;
            set;
        }
        Int64 InfCodeDashboardId
        {
            get;
            set;
        }
        String Libelle
        {
            get;
            set;
        }
        Int64 Ordre
        {
            get;
            set;
        }


    }
}
