﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Code sensibilité")]
    [TableName("INF_CD_SENSIBLE")]
    [SchemaName("INF")]
    public class InfCodeSensible : IInfCodeSensible
    {
    	
        [DisplayName("Sensibilités")]
        public virtual ICollection<InfSensible> InfSensibles
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_SENSIBLE__CODE")]
        [UniqueKey("INF_CD_SENSIBLE_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_SENSIBLE__ID")]
        [PrimaryKey("INF_CD_SENSIBLE_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_SENSIBLE__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
