using Emash.GeoPatNet.Generator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.ViewModels
{
    [DisplayName ("Colonne")]
    public class DbColumnViewModel : DbItemViewModel
    {
        [Browsable(false)]
        public DbColumn Model { get; set; }


       


        [Category("Donnée")]
        [ReadOnly(true)]
        [DisplayName("Type de donnée")]
        public String DataType { get; set; }

        [Category("Donnée")]
        [ReadOnly(true)]
        [DisplayName("Null autorisé")]
        public Boolean AllowNull { get; set; }

        [Category("Donnée")]
        [ReadOnly(true)]
        [DisplayName("Taille")]
        public Nullable<Int32> Length { get; set; }

        public DbColumnViewModel(DbColumn model)
        {
            // TODO: Complete member initialization
            this.Model = model;
            this.DisplayName = model.DisplayName;
            this.Name = model.Name;
            this.DataType = model.DataType;
            this.AllowNull = model.AllowNull;
            this.Length = model.Length;
            this.Id = model.Id;
        }
    }
}
