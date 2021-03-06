using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("APPUIS_OA",Schema="OA")]
    public partial class OaAppuis
    {
        [Key]
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Key]
        [Description("Famille d'appuis")]
        [Column("CD_FAM_APPUI_OA__FAM_APP",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdFamAppuiOaFamApp { get; set; }
        
        [Key]
        [Description("Type d'appui")]
        [Column("CD_APPUI_OA__APP",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String CdAppuiOaApp { get; set; }
        
        [Key]
        [Description("Type app appui")]
        [Column("CD_APP_APPUI_OA__APPUI",Order=3)]
        [Required()]
        [MaxLength(60)] 
        public String CdAppAppuiOaAppui { get; set; }
        
        [Description("Nbr app. appui")]
        [Column("NBR_APPAREIL",Order=4)]
        public Nullable<Int64> NbrAppareil { get; set; }
        
        [Description("Date MS app appui")]
        [Column("DATE_MS",Order=5)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=6)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
    }
}
