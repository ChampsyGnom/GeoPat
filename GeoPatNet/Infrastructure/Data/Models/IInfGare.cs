using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfGare
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
        Int64 InfCodeGareId
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
        Nullable<Int64> NbSortie
        {
            get;
            set;
        }
        Nullable<Int64> NbEntree
        {
            get;
            set;
        }
        Nullable<Int64> NbMixte
        {
            get;
            set;
        }
        Nullable<Int64> NbTsa
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
