using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface IDashboardService
    {
        void Initialize();

        void RemoveFolder(Object folder);
        void FillOrder();
        void RemoveTable(Object  table);

        void AddTable(Object parentVm, Object entityTableInfo);
    }
}
