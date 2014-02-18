﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Code climat")]
    public class InfCodeClimat : IInfCodeClimat
    {
    	
        [DisplayName("Climat")]
        public virtual ICollection<InfClimat> InfClimats
        {
            get;
            set;
        }
        [DisplayName("Code")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
