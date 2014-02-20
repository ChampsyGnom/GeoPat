using Emash.GeoPatNet.Data.Infrastructure.Services;
using Emash.GeoPatNet.Engine.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Engine.Infrastructure.ViewModels
{
    public  interface IGenericListViewModel
    {
        IDataService DataService { get; }
        GenericDataListState State { get;  }    
        void RaiseStateChange();
        void BeginEdit(Object obj);
        bool IsLocked { get;  }
    }
}
