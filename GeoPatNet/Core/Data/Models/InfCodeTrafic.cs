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
	[DisplayName("Classe de trafic")]
    [TableName("INF_CD_TRAFIC")]
    [SchemaName("INF")]
    public class InfCodeTrafic 
    {
    	
        [DisplayName("Section trafics")]
        public virtual ObservableCollection<InfSectionTrafic> InfSectionTrafics
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_TRAFIC__CODE")]
        [UniqueKey("INF_CD_TRAFIC_UK_REF")]
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
        [ColumnName("INF_CD_TRAFIC__ID")]
        [PrimaryKey("INF_CD_TRAFIC_PK")]
        [ForeignKeyAttribute("INF_CD_TRAFIC__INF_SECTION_TRAFIC","JOIN_o990")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_TRAFIC__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


		public InfCodeTrafic ()
		{
            this.InfSectionTrafics = new ObservableCollection<InfSectionTrafic>();
		}

    }
}
