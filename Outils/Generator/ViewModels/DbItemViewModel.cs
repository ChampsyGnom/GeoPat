using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.ViewModels
{
    public class DbItemViewModel : ViewModelBase
    {
        [Category("Identification")]
        [ReadOnly(true)]
        [DisplayName("Identifiant")]
        public String Id { get; set; }


        [Category("Identification")]
        [ReadOnly(true)]
        [DisplayName("Libellé")]
        public String DisplayName { get; set; }

        [Category("Identification")]
        [ReadOnly(true)]
        [DisplayName("Nom")]
        public String Name { get; set; }
    }
}
