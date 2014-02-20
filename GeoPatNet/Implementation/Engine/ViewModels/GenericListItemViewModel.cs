using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class GenericListItemViewModel<M> 
        where M : class
    {
        public String DisplayName { get; private set; }
        private IDataService _dataService;
        private EntityTableInfo _entityTableInfo;
        public String DisplayRecordCount { get; private set; }
        public String DisplayRecordIndex { get; private set; }
        public DbSet<M> DbSet { get; private set; }

        public DelegateCommand LockUnlockCommand { get; private set; }
        public DelegateCommand InsertCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand CommitCommand { get; private set; }
        public DelegateCommand ClearCommand { get; private set; }
        public DelegateCommand SearchCommand { get; private set; }
        public DelegateCommand QuitCommand { get; private set; }
       


        public GenericListItemViewModel()
        {
            _dataService = ServiceLocator.Current.GetInstance<IDataService>();
            _entityTableInfo = _dataService.GetEntityTableInfo(typeof(M));
            DbSet = _dataService.DataContext.Set<M>();
            this.DisplayRecordCount = (from c in DbSet select c).Count().ToString();
            this.DisplayRecordIndex = "*";
            this.DisplayName = _entityTableInfo.DisplayName;
            this.LockUnlockCommand = new DelegateCommand(LockUnlockExecute, CanLockUnlockExecute);
            this.InsertCommand = new DelegateCommand(InsertExecute, CanInsertExecute);
            this.DeleteCommand = new DelegateCommand(DeleteExecute, CanDeleteExecute);
            this.CancelCommand = new DelegateCommand(CancelExecute, CanCancelExecute);
            this.CommitCommand = new DelegateCommand(CommitExecute, CanCommitExecute);
            this.ClearCommand = new DelegateCommand(ClearExecute, CanClearExecute);
            this.SearchCommand = new DelegateCommand(SearchExecute, CanSearchExecute);
            this.QuitCommand = new DelegateCommand(QuitExecute, CanQuitExecute);
        }

        private void QuitExecute()
        { }

        private Boolean CanQuitExecute()
        { return false; }

        private void SearchExecute()
        { }

        private Boolean CanSearchExecute()
        { return false; }

        private void ClearExecute()
        { }

        private Boolean CanClearExecute()
        { return false; }


        private void CommitExecute()
        { }

        private Boolean CanCommitExecute()
        { return false; }

        private void CancelExecute()
        { }

        private Boolean CanCancelExecute()
        { return false; }


        private void DeleteExecute()
        { }

        private Boolean CanDeleteExecute()
        { return false; }


        private void LockUnlockExecute()
        { }

        private Boolean CanLockUnlockExecute()
        { return false; }

        private void InsertExecute()
        { }

        private Boolean CanInsertExecute()
        { return false; }


    }
}
