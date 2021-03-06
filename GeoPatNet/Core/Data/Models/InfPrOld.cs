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
	[DisplayName("Ancien repérage")]
    [TableName("INF_PR_OLD")]
    [SchemaName("INF")]
    public class InfPrOld 
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_PR_OLD",null)]
        [UniqueKey("INF_PR_OLD_UK_REF")]
        [UniqueKey("INF_PR_OLD_UK2")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Abscisse")]
        [ColumnName("INF_PR_OLD__ABS_CUM")]
        [LocationAttribute(LocationAttributeType.ReferenceDeb)]
        [UniqueKey("INF_PR_OLD_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 AbsCum
        {
            get;
            set;
        }
        [DisplayName("Distance inter PR")]
        [ColumnName("INF_PR_OLD__INTER")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 Inter
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_PR_OLD__ID")]
        [PrimaryKey("INF_PR_OLD_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [LocationAttribute(LocationAttributeType.ReferenceId)]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("N° de PR")]
        [ColumnName("INF_PR_OLD__NUM")]
        [UniqueKey("INF_PR_OLD_UK2")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 Num
        {
            get;
            set;
        }


		public InfPrOld ()
		{

		}

    }
}
