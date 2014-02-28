using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfAireParking
    {

        Int64 Id
        {
            get;
            set;
        }
        Nullable<Int64> InfAireId
        {
            get;
            set;
        }
        Nullable<Int64> InfCodePlaceId
        {
            get;
            set;
        }
        Nullable<Int64> NbPlace
        {
            get;
            set;
        }


    }
}
