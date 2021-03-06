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
	[DisplayName("Sécurité")]
    [TableName("INF_SECURITE")]
    [SchemaName("INF")]
    public class InfSecurite 
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_SECURITE",null)]
        [UniqueKey("INF_SECURITE_UK_REF")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code position")]
        [ColumnName("INF_CD_POSIT__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_POSIT__INF_SECURITE",null)]
        [UniqueKey("INF_SECURITE_UK_REF")]
        public virtual InfCodePosit InfCodePosit
        {
            get;
            set;
        }
        [DisplayName("Code sécurité")]
        [ColumnName("INF_CD_SECURITE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_SECURITE__INF_SECURITE",null)]
        [UniqueKey("INF_SECURITE_UK_REF")]
        public virtual InfCodeSecurite InfCodeSecurite
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_SECURITE__ABS_DEB")]
        [LocationAttribute(LocationAttributeType.ReferenceDeb)]
        [UniqueKey("INF_SECURITE_UK_REF")]
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
        [ColumnName("INF_SECURITE__ABS_FIN")]
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
        [ColumnName("INF_SECURITE__ID")]
        [PrimaryKey("INF_SECURITE_PK")]
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
        [DisplayName("Identifiant code position")]
        [ColumnName("INF_CD_POSIT__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodePositId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code sécurité")]
        [ColumnName("INF_CD_SECURITE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeSecuriteId
        {
            get;
            set;
        }


		public InfSecurite ()
		{

		}

    }
}
