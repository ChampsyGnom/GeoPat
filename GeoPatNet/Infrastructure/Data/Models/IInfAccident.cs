using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfAccident
    {

        Int64 Annee
        {
            get;
            set;
        }
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
        Int64 Mois
        {
            get;
            set;
        }
        Nullable<Int64> Nb
        {
            get;
            set;
        }
        Nullable<Int64> NbMois
        {
            get;
            set;
        }


    }
}
