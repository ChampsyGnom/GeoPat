using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface ITranslateService
    {
        String Tanslate(string key);

        void Initialize();

        void LoadCurrentLang();
    }
}
