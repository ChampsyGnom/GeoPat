using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfAmenagement
    {

        String Info
        {
            get;
            set;
        }
        Nullable<Int64> Cout
        {
            get;
            set;
        }
        DateTime DateDeb
        {
            get;
            set;
        }
        Nullable<DateTime> DateFin
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
        Int64 InfCodeAmenagementId
        {
            get;
            set;
        }


    }
}
