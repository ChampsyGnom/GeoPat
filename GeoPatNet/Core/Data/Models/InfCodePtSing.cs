﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Code point singulier")]
    [TableName("INF_CD_PT_SING")]
    [SchemaName("INF")]
    public class InfCodePtSing 
    {
    	
        [DisplayName("Point singuliers")]
        public virtual ObservableCollection<InfPtSing> InfPtSings
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_PT_SING__CODE")]
        [UniqueKey("INF_CD_PT_SING_UK_REF")]
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
        [ColumnName("INF_CD_PT_SING__ID")]
        [PrimaryKey("INF_CD_PT_SING_PK")]
        [ForeignKeyAttribute("INF_CD_PT_SING__INF_PT_SING","JOIN_o1000")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libelle")]
        [ColumnName("INF_CD_PT_SING__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


		public InfCodePtSing ()
		{
            this.InfPtSings = new ObservableCollection<InfPtSing>();
		}

    }
}
