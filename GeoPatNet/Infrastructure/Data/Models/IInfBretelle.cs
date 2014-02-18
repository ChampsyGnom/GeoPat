using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfBretelle
    {

        Int64 AbsDeb
        {
            get;
            set;
        }
        String Extremite
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
        String Libelle
        {
            get;
            set;
        }
        String Num
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
        String Type
        {
            get;
            set;
        }


    }
}
