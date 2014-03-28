using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ENTP_GMS",Schema="GMS")]
    public partial class GmsCdEntp
    {
        public virtual ICollection<GmsDsc> GmsDscs { get; set; }
        
        public virtual ICollection<GmsTravaux> GmsTravauxs { get; set; }
        
        public virtual ICollection<GmsPanneau> GmsPanneaus { get; set; }
        
        public virtual ICollection<GmsDscTemp> GmsDscTemps { get; set; }
        
        [Key]
        [Description("Entreprise")]
        [Column("CD_ENTP_GMS__ENTREPRISE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Entreprise { get; set; }
        
    }
}
