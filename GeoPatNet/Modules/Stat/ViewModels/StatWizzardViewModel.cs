using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Reflection;
using System.Collections.ObjectModel;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Attributes;
using Emash.GeoPatNet.Infrastructure.Utils;
using System.Data.Entity;
using System.Linq.Expressions;
namespace Emash.GeoPatNet.Modules.Stat.ViewModels
{
    public enum StateType
    {
        Count,
        None
    }
    public  class StatWizzardViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
        public ObservableCollection<StatValueViewModel> StatValues { get; private set; }
        private System.Windows.Visibility _stepConfigurationVisiblity;
        private System.Windows.Visibility _stepPreviewVisiblity;
        private StatFieldViewModel _selectedStatField;


        public StatFieldViewModel SelectedStatField
        {
            get { return _selectedStatField; }
            set 
            {
                _selectedStatField = value;
                this.RaisePropertyChanged("SelectedStatField"); 
                this.UpdateWizzardRepresentation();
                this.UpdateStatValues();
            }
        }

        private void UpdateStatValues()
        {
            this.StatValues.Clear();
            if (_selectedStatType != null && _selectedStatField != null)
            {
                IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
                if (_selectedStatType.StateType == StateType.Count)
                {
                    if (_selectedStatField.BottomColumnInfo.ControlType == ControlType.Combo)
                    {
                        List<Object> distinctValues = new List<object>();
                        DbSet dbSet = dataService.GetDbSet(_selectedStatField.TopColumnInfo.TableInfo.EntityType );
                        IQueryable queryable = dbSet.AsQueryable();
                        foreach (Object o in queryable)
                        {
                            distinctValues.Add(_selectedStatField.TopColumnInfo .Property.GetValue (o));
                        }
                        distinctValues = (from o in distinctValues orderby o select o).Distinct().ToList();

                        DbSet dbSetCurrent = dataService.GetDbSet(this.EntityTableInfo.EntityType );
                        IQueryable currentQueryable = dbSetCurrent.AsQueryable();
                        foreach (Object value in distinctValues)
                        {
                            List<Expression> expressions = new List<Expression>();
                        
                            System.Linq.Expressions.ParameterExpression expressionBase = System.Linq.Expressions.Expression.Parameter(this.EntityTableInfo.EntityType, "item");
                       
                            Expression expression = null;
                            if (_selectedStatField.FieldPath.IndexOf(".") == -1)
                            {
                                expression = Expression.Property(expressionBase, _selectedStatField.FieldPath);
                                expression = Expression.Equal(expression, Expression.Constant(value));
                                expressions.Add(expression);
                            }
                            else
                            {
                                String[] items = _selectedStatField.FieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                                for (int i = 0; i < items.Length; i++)
                                {
                                    if (i == 0)
                                    { expression = Expression.Property(expressionBase, items[i]); }
                                    else
                                    { expression = Expression.Property(expression, items[i]); }
                                }
                                expression = Expression.Equal(expression, Expression.Constant(value));
                                expressions.Add(expression);
                            }


                            

                            if (expressions.Count > 0)
                            {
                                System.Linq.Expressions.Expression expressionAnd = expressions.First();
                                for (int i = 1; i < expressions.Count; i++)
                                { expressionAnd = System.Linq.Expressions.Expression.And(expressionAnd, expressions[i]); }
                                System.Linq.Expressions.MethodCallExpression whereCallExpression = System.Linq.Expressions.Expression.Call(
                                typeof(Queryable),
                                "Where",
                                new Type[] { currentQueryable.ElementType },
                                currentQueryable.Expression,
                                System.Linq.Expressions.Expression.Lambda(expressionAnd, expressionBase));
                                queryable = queryable.Provider.CreateQuery(whereCallExpression);
                            }
                            int count = 0;
                            foreach (Object i in queryable)
                            { count++; }
                            if (count > 0)
                            {
                                StatValueViewModel valueVm = new StatValueViewModel();
                                valueVm.DependentValue = count;
                                valueVm.IndependentValue = value;
                                this.StatValues.Add(valueVm);
                            }
                           

                        }
                        
                    }

                }
            }
        }

        private void UpdateWizzardRepresentation()
        {
            if (this._selectedStatField != null)
            { 
                
            }
        }
        private StatTypeViewModel _selectedStatType;


        public StatTypeViewModel SelectedStatType
        {
            get { return _selectedStatType; }
            set { _selectedStatType = value; this.RaisePropertyChanged("SelectedStatType"); this.UpdateStatFields(); }
        }

        private void UpdateStatFields()
        {
            this.StatFields.Clear();
            if (this._selectedStatType != null && _selectedStatType.StateType == StateType.Count)
            {
                foreach (StatFieldViewModel statField in AllFields)
                {
                    if (statField.BottomColumnInfo.ControlType == Infrastructure.Attributes.ControlType.Combo)
                    {
                        
                        this.StatFields.Add(statField);
                    }
                }
            }
        }
        public ObservableCollection<StatTypeViewModel> StatTypes  { get; private set; }
        public List<StatFieldViewModel> AllFields { get; private set; }
        public ObservableCollection<StatFieldViewModel> StatFields { get; private set; }
        public System.Windows.Visibility StepPreviewVisiblity
        {
            get { return _stepPreviewVisiblity; }
            set { _stepPreviewVisiblity = value; this.RaisePropertyChanged("StepPreviewVisiblity"); }
        }

        public System.Windows.Visibility StepConfigurationVisiblity
        {
            get { return _stepConfigurationVisiblity; }
            set { _stepConfigurationVisiblity = value; this.RaisePropertyChanged("StepConfigurationVisiblity"); }
        }
        public EntityTableInfo EntityTableInfo { get; private set; }

        public StatWizzardViewModel(EntityTableInfo entityTableInfo, List<String> fieldPaths)
        {
            this.StatValues = new ObservableCollection<StatValueViewModel>();
            this.EntityTableInfo = entityTableInfo;
            this.AllFields = new List<StatFieldViewModel>();
            this.StepConfigurationVisiblity = System.Windows.Visibility.Visible;
            this.StepPreviewVisiblity = System.Windows.Visibility.Hidden;
            this.StatTypes = new ObservableCollection<StatTypeViewModel>();
            StatTypeViewModel vmStateTypeCount = new StatTypeViewModel();
            vmStateTypeCount.DisplayName = "Nombre de " + entityTableInfo.DisplayName;
            vmStateTypeCount.StateType = StateType.Count;
            this.StatTypes.Add(vmStateTypeCount);
            this.StatFields = new ObservableCollection<StatFieldViewModel>();
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            List<String> basicFieldPaths = dataService.GetTableFieldPaths(entityTableInfo);

            foreach (String fieldPath in fieldPaths)
            {
                StatFieldViewModel vm = new StatFieldViewModel();
                vm.FieldPath = fieldPath;
                vm.TopColumnInfo = dataService.GetTopColumnInfo(entityTableInfo.EntityType, fieldPath);
                vm.BottomColumnInfo = dataService.GetBottomColumnInfo(entityTableInfo.EntityType, fieldPath);
               

                if (basicFieldPaths.Contains(fieldPath))
                {
                    if (fieldPath.IndexOf(".") == -1)
                    { vm.DisplayName = vm.TopColumnInfo.DisplayName; }
                    else
                    { vm.DisplayName = vm.TopColumnInfo.TableInfo.DisplayName; }
                }
                else
                {
                    vm.DisplayName = vm.TopColumnInfo.TableInfo.DisplayName + " - " + vm.TopColumnInfo.DisplayName;
                }

                this.AllFields.Add(vm);
            }
        }
    }
}
