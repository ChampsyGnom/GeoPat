﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using Emash.GeoPatNet.Presentation.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Code climat")]
    [TableName("INF_CD_CLIMAT")]
    [SchemaName("INF")]
    public class InfCodeClimat : IInfCodeClimat
    {
    	
        [DisplayName("Climats")]
        public virtual ICollection<InfClimat> InfClimats
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_CLIMAT__CODE")]
        [UniqueKey("INF_CD_CLIMAT_UK_REF")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_CLIMAT__ID")]
        [PrimaryKey("INF_CD_CLIMAT_PK")]
        [ForeignKeyAttribute("INF_CD_CLIMAT__INF_CLIMAT","JOIN_o791")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_CLIMAT__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


    }
}
