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
	[DisplayName("Aménagement")]
    [TableName("INF_AMENAGEMENT")]
    [SchemaName("INF")]
    public class InfAmenagement 
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_AMENAGEMENT",null)]
        [UniqueKey("INF_AMENAGEMENT_UK_REF")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code aménagement")]
        [ColumnName("INF_CD_AMENAGEMENT__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_AMENAGEMENT__INF_AMENAGEMENT",null)]
        [UniqueKey("INF_AMENAGEMENT_UK_REF")]
        public virtual InfCodeAmenagement InfCodeAmenagement
        {
            get;
            set;
        }
        [DisplayName("Commentaire")]
        [ColumnName("INF_AMENAGEMENT__INFO")]
        [MaxCharLength(500)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Info
        {
            get;
            set;
        }
        [DisplayName("Coût")]
        [ColumnName("INF_AMENAGEMENT__COUT")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(true)]
        public Nullable<Int64> Cout
        {
            get;
            set;
        }
        [DisplayName("Date début")]
        [ColumnName("INF_AMENAGEMENT__DATE_DEB")]
        [UniqueKey("INF_AMENAGEMENT_UK_REF")]
        [ControlType(ControlType.Date)]
        [AllowNull(false)]
        public DateTime DateDeb
        {
            get;
            set;
        }
        [DisplayName("Date fin")]
        [ColumnName("INF_AMENAGEMENT__DATE_FIN")]
        [ControlType(ControlType.Date)]
        [AllowNull(true)]
        public Nullable<DateTime> DateFin
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_AMENAGEMENT__ABS_DEB")]
        [LocationAttribute(LocationAttributeType.ReferenceDeb)]
        [UniqueKey("INF_AMENAGEMENT_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [RulePr("INF_CHAUSSEE__ID")]
        [ControlType(ControlType.Pr)]
        [RuleEmprise("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_AMENAGEMENT__ABS_FIN")]
        [LocationAttribute(LocationAttributeType.ReferenceFin)]
        [RangeValue(-999999999999,999999999999)]
        [RulePr("INF_CHAUSSEE__ID")]
        [ControlType(ControlType.Pr)]
        [RuleEmprise("INF_CHAUSSEE__ID")]
        [AllowNull(true)]
        public Nullable<Int64> AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_AMENAGEMENT__ID")]
        [PrimaryKey("INF_AMENAGEMENT_PK")]
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
        [DisplayName("Identifiant code aménagement")]
        [ColumnName("INF_CD_AMENAGEMENT__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeAmenagementId
        {
            get;
            set;
        }


		public InfAmenagement ()
		{

		}

    }
}
