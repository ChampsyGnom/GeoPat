using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Presentation.Infrastructure.Services
{
    public interface ISplashService
    {
        void ShowSplash(int maxTimeOut);
        void CloseSplash(Action afterSplashClose);
      
    }
}
