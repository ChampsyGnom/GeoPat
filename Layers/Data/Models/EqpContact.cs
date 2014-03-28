using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CONTACT_EQP",Schema="EQP")]
    public partial class EqpContact
    {
        public virtual EqpDoc EqpDoc {get;set;}
        
        [Key]
        [Description("Id document")]
        [Column("DOC_EQP__ID",Order=0)]
        [Required()]
        public Int64 DocEqpId { get; set; }
        
        [Description("Prénom")]
        [Column("CONTACT_EQP__GIVENNAME",Order=1)]
        [MaxLength(60)] 
        public String Givenname { get; set; }
        
        [Description("Nom")]
        [Column("CONTACT_EQP__SN",Order=2)]
        [MaxLength(60)] 
        public String Sn { get; set; }
        
        [Description("Nom complet")]
        [Column("CONTACT_EQP__CN",Order=3)]
        [MaxLength(125)] 
        public String Cn { get; set; }
        
        [Description("Organisation")]
        [Column("CONTACT_EQP__O",Order=4)]
        [MaxLength(60)] 
        public String O { get; set; }
        
        [Description("Email")]
        [Column("CONTACT_EQP__MAIL",Order=5)]
        [MaxLength(60)] 
        public String Mail { get; set; }
        
        [Description("Téléphone fixe")]
        [Column("CONTACT_EQP__TELEPHONENUMBER",Order=6)]
        [MaxLength(20)] 
        public String Telephonenumber { get; set; }
        
        [Description("Téléphone mobile")]
        [Column("CONTACT_EQP__MOBILE",Order=7)]
        [MaxLength(20)] 
        public String Mobile { get; set; }
        
        [Description("Fax")]
        [Column("CONTACT_EQP__FACSIMILETELEPHONENUMBER",Order=8)]
        [MaxLength(20)] 
        public String Facsimiletelephonenumber { get; set; }
        
        [Description("Adresse")]
        [Column("CONTACT_EQP__STREET",Order=9)]
        [MaxLength(60)] 
        public String Street { get; set; }
        
        [Description("Adresse complémentaire")]
        [Column("CONTACT_EQP__MOZILLAWORKSTREET2",Order=10)]
        [MaxLength(60)] 
        public String Mozillaworkstreet2 { get; set; }
        
        [Description("Ville")]
        [Column("CONTACT_EQP__L",Order=11)]
        [MaxLength(60)] 
        public String L { get; set; }
        
        [Description("Code Postal")]
        [Column("CONTACT_EQP__POSTALCODE",Order=12)]
        [MaxLength(12)] 
        public String Postalcode { get; set; }
        
        [Description("Date MAJ")]
        [Column("CONTACT_EQP__MODIFYTIMESTAMP",Order=13)]
        public Nullable<DateTime> Modifytimestamp { get; set; }
        
    }
}
