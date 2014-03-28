using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CONTACT_INF",Schema="INF")]
    public partial class InfContact
    {
        public virtual InfDoc InfDoc {get;set;}
        
        [Key]
        [Description("Identificant(cpt)")]
        [Column("DOC_INF__ID",Order=0)]
        [Required()]
        public Int64 DocInfId { get; set; }
        
        [Description("Prénom")]
        [Column("CONTACT_INF__givenName",Order=1)]
        [MaxLength(60)] 
        public String Givenname { get; set; }
        
        [Description("Nom")]
        [Column("CONTACT_INF__sn",Order=2)]
        [MaxLength(60)] 
        public String Sn { get; set; }
        
        [Description("Nom complet")]
        [Column("CONTACT_INF__cn",Order=3)]
        [MaxLength(125)] 
        public String Cn { get; set; }
        
        [Description("Organisation")]
        [Column("CONTACT_INF__o",Order=4)]
        [MaxLength(60)] 
        public String O { get; set; }
        
        [Description("Email")]
        [Column("CONTACT_INF__mail",Order=5)]
        [MaxLength(60)] 
        public String Mail { get; set; }
        
        [Description("Téléphone fixe")]
        [Column("CONTACT_INF__telephoneNumber",Order=6)]
        [MaxLength(20)] 
        public String Telephonenumber { get; set; }
        
        [Description("Téléphone mobile")]
        [Column("CONTACT_INF__mobile",Order=7)]
        [MaxLength(20)] 
        public String Mobile { get; set; }
        
        [Description("Fax")]
        [Column("CONTACT_INF__facsimiletelephonenumber",Order=8)]
        [MaxLength(20)] 
        public String Facsimiletelephonenumber { get; set; }
        
        [Description("Adresse")]
        [Column("CONTACT_INF__street",Order=9)]
        [MaxLength(60)] 
        public String Street { get; set; }
        
        [Description("Adresse complémentaire")]
        [Column("CONTACT_INF__mozillaWorkStreet2",Order=10)]
        [MaxLength(60)] 
        public String Mozillaworkstreet2 { get; set; }
        
        [Description("Ville")]
        [Column("CONTACT_INF__l",Order=11)]
        [MaxLength(60)] 
        public String L { get; set; }
        
        [Description("Code Postal")]
        [Column("CONTACT_INF__postalCode",Order=12)]
        [MaxLength(12)] 
        public String Postalcode { get; set; }
        
        [Description("Date MAJ")]
        [Column("CONTACT_INF__modifytimestamp",Order=13)]
        public Nullable<DateTime> Modifytimestamp { get; set; }
        
    }
}
