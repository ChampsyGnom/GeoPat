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
	[DisplayName("Répartition trafic")]
    [TableName("INF_REPARTITION_TRAFIC")]
    [SchemaName("INF")]
    public class InfRepartitionTrafic : IInfRepartitionTrafic
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("% Poid lourd")]
        [ColumnName("INF_REPARTITION_TRAFIC__PC_PL")]
        public Nullable<Double> PcPl
        {
            get;
            set;
        }
        [DisplayName("Année")]
        [ColumnName("INF_REPARTITION_TRAFIC__ANNEE")]
        [UniqueKey("INF_REPARTITION_TRAFIC_UK_REF")]
        public Int64 Annee
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_REPARTITION_TRAFIC__ABS_DEB")]
        [UniqueKey("INF_REPARTITION_TRAFIC_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_REPARTITION_TRAFIC__ABS_FIN")]
        public Nullable<Int64> AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_REPARTITION_TRAFIC__ID")]
        [PrimaryKey("INF_REPARTITION_TRAFIC_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_REPARTITION_TRAFIC","JOIN_o754")]
        [UniqueKey("INF_REPARTITION_TRAFIC_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }


    }
}
