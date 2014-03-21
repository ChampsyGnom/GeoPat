using Emash.GeoPatNet.Infrastructure.Symbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.Services;
using System.Linq.Expressions;
using System.ComponentModel;

namespace Emash.GeoPatNet.Modules.Stat.ViewModels
{
    public class StatValueViewModel : INotifyPropertyChanged
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
        public Symbology Symbology { get; set; }
        public Object IndependentValue
        {
            get
            {
                return this.Symbology.DisplayName;
            }
        }
        public Double DependentValue
        {
            get;
            private set;
        }
        public Double Percent
        {
            get;
            private set;
        }
        internal void Compute()
        {
            this.DependentValue = 0;
            IDataService dataService =  ServiceLocator.Current.GetInstance<IDataService>();
            DbSet dbSetCurrent = dataService.GetDbSet(this.Symbology.Rule.Field.TableInfo.EntityType);
            IQueryable currentQueryable = dbSetCurrent.AsQueryable();
            System.Linq.Expressions.ParameterExpression expressionBase = System.Linq.Expressions.Expression.Parameter(this.Symbology.Rule.Field.TableInfo.EntityType, "item");
            Expression expression = this.Symbology.Rule.CreateLinqExpression(expressionBase);
            System.Linq.Expressions.MethodCallExpression whereCallExpression = System.Linq.Expressions.Expression.Call(
            typeof(Queryable),
            "Where",
            new Type[] { currentQueryable.ElementType },
            currentQueryable.Expression,
            System.Linq.Expressions.Expression.Lambda(expression, expressionBase));
            currentQueryable = currentQueryable.Provider.CreateQuery(whereCallExpression);
            foreach (Object item in currentQueryable)
            { this.DependentValue = this.DependentValue + 1; }

            this.RaisePropertyChanged("DependentValue");
        }

        internal void ComputePercent(double total)
        {
            this.Percent = 0;
            if (total > 0)
            {this.Percent = (this.DependentValue / total) * 100;}
            this.Percent = Math.Round(this.Percent, 2);
            this.RaisePropertyChanged("Percent");
        }
    }
}
