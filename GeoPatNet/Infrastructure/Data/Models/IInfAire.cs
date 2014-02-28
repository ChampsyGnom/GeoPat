using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfAire
    {

        Nullable<Boolean> Bilaterale
        {
            get;
            set;
        }
        String Observ
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
        Nullable<Boolean> DemiTour
        {
            get;
            set;
        }
        Int64 Id
        {
            get;
            set;
        }
        Int64 InfCodeAireId
        {
            get;
            set;
        }
        Int64 InfChausseeId
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
        Nullable<Boolean> Passerelle
        {
            get;
            set;
        }


    }
}
