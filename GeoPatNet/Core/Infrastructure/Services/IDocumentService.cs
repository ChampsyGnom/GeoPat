using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface IDocumentService
    {
        void Initialize();

        void ShowDocument(Type modelType,object modelObject);
    }
}
