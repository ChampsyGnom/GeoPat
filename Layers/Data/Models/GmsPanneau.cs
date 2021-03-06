using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PANNEAU_GMS",Schema="GMS")]
    public partial class GmsPanneau
    {
        [Key]
        [Description("No GMS")]
        [Column("DSC_GMS__NUM_GMS",Order=0)]
        [Required()]
        [MaxLength(17)] 
        public String DscGmsNumGms { get; set; }
        
        [Key]
        [Description("Position")]
        [Column("CD_POS_PAN_GMS__POSIT",Order=1)]
        [Required()]
        [MaxLength(4)] 
        public String CdPosPanGmsPosit { get; set; }
        
        [Description("Type")]
        [Column("CD_PANNEAU_GMS__TYPE",Order=2)]
        [MaxLength(60)] 
        public String CdPanneauGmsType { get; set; }
        
        [Description("Type de liaison GMS")]
        [Column("CD_INTERFACE_GMS__TYPE",Order=3)]
        [MaxLength(60)] 
        public String CdInterfaceGmsType { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_GMS__ENTREPRISE",Order=4)]
        [MaxLength(60)] 
        public String CdEntpGmsEntreprise { get; set; }
        
        [Description("Fournisseur")]
        [Column("CD_FOURNISSEUR_GMS__NOM",Order=5)]
        [MaxLength(60)] 
        public String CdFournisseurGmsNom { get; set; }
        
        [Description("Mise en service")]
        [Column("DATE_MS",Order=6)]
        [Required()]
        public DateTime DateMs { get; set; }
        
        [Description("Hauteur panneau (m)")]
        [Column("HAUTEUR",Order=7)]
        public Nullable<Double> Hauteur { get; set; }
        
        [Description("Largeur (m)")]
        [Column("LARGEUR",Order=8)]
        public Nullable<Double> Largeur { get; set; }
        
        [Description("Mention")]
        [Column("MENTION",Order=9)]
        [MaxLength(255)] 
        public String Mention { get; set; }
        
        [Description("Réserve %")]
        [Column("RESERVE",Order=10)]
        public Nullable<Int64> Reserve { get; set; }
        
    }
}
