using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace Emash.GeoPatNet.Presentation.Adapters
{
    public class Win32WindowAdapter : System.Windows.Forms.IWin32Window
    {
        IntPtr _handle;

        public Win32WindowAdapter(Window wpfWindow)
        {
            _handle = new WindowInteropHelper(wpfWindow).Handle;
        }

        #region IWin32Window Members

        IntPtr System.Windows.Forms.IWin32Window.Handle
        {
            get { return _handle; }
        }

    #endregion
    }
}
