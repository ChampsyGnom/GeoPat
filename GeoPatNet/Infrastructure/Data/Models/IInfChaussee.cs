﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emash.GeoPatNet.Data.Infrastructure.Models
{
	
    public interface IInfChaussee
    {

        String About
        {
            get;
            set;
        }
        String Code
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
        Int64 InfLiaisonId
        {
            get;
            set;
        }
        String Libelle
        {
            get;
            set;
        }
        String Tenant
        {
            get;
            set;
        }


    }
}
