using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfCodeDec
    {

        String Code
        {
            get;
            set;
        }
        Int64 Id
        {
            get;
            set;
        }
        Int64 InfFamDecId
        {
            get;
            set;
        }
        String Libelle
        {
            get;
            set;
        }


    }
}
