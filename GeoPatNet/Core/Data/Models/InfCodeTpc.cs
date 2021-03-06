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
	[DisplayName("Code TPC")]
    [TableName("INF_CD_TPC")]
    [SchemaName("INF")]
    public class InfCodeTpc 
    {
    	
        [DisplayName("Terre plein centrals")]
        public virtual ObservableCollection<InfTpc> InfTpcs
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_TPC__CODE")]
        [UniqueKey("INF_CD_TPC_UK_REF")]
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
        [ColumnName("INF_CD_TPC__ID")]
        [PrimaryKey("INF_CD_TPC_PK")]
        [ForeignKeyAttribute("INF_CD_TPC__INF_TPC","JOIN_o1008")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_TPC__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


		public InfCodeTpc ()
		{
            this.InfTpcs = new ObservableCollection<InfTpc>();
		}

    }
}
