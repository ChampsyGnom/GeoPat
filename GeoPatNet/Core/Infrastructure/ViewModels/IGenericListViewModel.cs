
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Enums;
using Emash.GeoPatNet.Infrastructure.Services;

namespace Emash.GeoPatNet.Infrastructure.ViewModels
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
