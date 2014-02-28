﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfCodeVoie
    {

        String Code
        {
            get;
            set;
        }
        String Couleur
        {
            get;
            set;
        }
        Int64 Id
        {
            get;
            set;
        }
        String Libelle
        {
            get;
            set;
        }
        Int64 Position
        {
            get;
            set;
        }
        Boolean Roulable
        {
            get;
            set;
        }


    }
}
