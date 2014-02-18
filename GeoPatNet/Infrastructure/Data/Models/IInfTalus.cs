using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfTalus
    {

        Int64 AbsDeb
        {
            get;
            set;
        }
        Nullable<Int64> AbsFin
        {
            get;
            set;
        }
        Nullable<Double> Hauteur
        {
            get;
            set;
        }
        Int64 Id
        {
            get;
            set;
        }
        Int64 InfChausseeId
        {
            get;
            set;
        }
        Int64 InfCodeTalusId
        {
            get;
            set;
        }


    }
}
