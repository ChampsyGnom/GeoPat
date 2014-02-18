using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfBifurcation
    {

        String Info
        {
            get;
            set;
        }
        Nullable<DateTime> DateMs
        {
            get;
            set;
        }
        Int64 AbsDeb
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
        Int64 InfCodeBifurcationId
        {
            get;
            set;
        }
        String NumExploit
        {
            get;
            set;
        }
        String Nom
        {
            get;
            set;
        }


    }
}
