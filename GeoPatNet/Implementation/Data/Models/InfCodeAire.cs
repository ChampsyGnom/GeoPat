﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using Emash.GeoPatNet.Presentation.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Type Aires")]
    [TableName("INF_CD_AIRE")]
    [SchemaName("INF")]
    public class InfCodeAire : IInfCodeAire
    {
    	
        [DisplayName("Airess")]
        public virtual ICollection<InfAire> InfAires
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_AIRE__CODE")]
        [UniqueKey("INF_CD_AIRE_UK_REF")]
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
        [ColumnName("INF_CD_AIRE__ID")]
        [PrimaryKey("INF_CD_AIRE_PK")]
        [ForeignKeyAttribute("INF_CD_AIRE__INF_AIRE","JOIN_o957")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_AIRE__LIBELLE")]
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
