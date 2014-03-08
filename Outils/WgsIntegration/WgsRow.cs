using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WgsIntegration
{
    public class WgsRow
    {
        //LINE_INDEX;LAYER_NAME;LIAISON;SENS;ABS_DEB;ABS_FIN;X1;Y1;X2;Y2
        public String LayerName { get; set; }
        public int LineIndex { get; set; }
        public String Liaison { get; set; }
        public String Sens { get; set; }
        public int AbsDeb { get; set; }
        public int AbsFin { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
     

    }
}
