using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfCodePosit
    {

        Int64 Id
        {
            get;
            set;
        }
        Nullable<Int64> Ordre
        {
            get;
            set;
        }
        Int64 Position
        {
            get;
            set;
        }


    }
}
