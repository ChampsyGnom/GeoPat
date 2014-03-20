using Emash.GeoPatNet.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface ISplashService
    {
        void ShowSplash();
        void CloseSplash();
        SplashUserAction SplashUserAction { get; set; }
        Task CreateTaskWaitingUserAction(int ms);
    }
}
