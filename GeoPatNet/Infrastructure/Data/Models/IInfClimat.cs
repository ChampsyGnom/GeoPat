using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfClimat
    {

        String Info
        {
            get;
            set;
        }
        Int64 AbsDeb
        {
            get;
            set;
        }
        Int64 AbsFin
        {
            get;
            set;
        }
        Int64 Id
        {
            get;
            set;
        }
        Int64 InfCodeClimatId
        {
            get;
            set;
        }
        Int64 InfChausseeId
        {
            get;
            set;
        }


    }
}
