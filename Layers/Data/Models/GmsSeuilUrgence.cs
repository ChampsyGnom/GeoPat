using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SEUIL_URGENCE_GMS",Schema="GMS")]
    public partial class GmsSeuilUrgence
    {
        [Key]
        [Description("No Ordre")]
        [Column("SEUIL_URGENCE_GMS__ORDRE",Order=0)]
        [Required()]
        public Int64 Ordre { get; set; }
        
        [Description(">= Nbre de note")]
        [Column("SEUIL_URGENCE_GMS__NBR_NOTE",Order=1)]
        public Nullable<Int64> NbrNote { get; set; }
        
        [Description("Valeur de note")]
        [Column("SEUIL_URGENCE_GMS__VAL_NOTE",Order=2)]
        public Nullable<Int64> ValNote { get; set; }
        
        [Description("Ind dégradation")]
        [Column("SEUIL_URGENCE_GMS__INDICE",Order=3)]
        public Nullable<Int64> Indice { get; set; }
        
    }
}
