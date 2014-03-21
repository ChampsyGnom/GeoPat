using Emash.GeoPatNet.Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Attributes;
using Microsoft.Practices.ServiceLocation;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Emash.GeoPatNet.Infrastructure.Validations
{
    public class EntityValidationRuleEmpriseChaussee : EntityValidationRule 
    {
        // @TODO Validation emprise chaussée
        public EntityColumnInfo ColumnLocation { get; set; }
        public override  Boolean Validate(Object entityObject, Dictionary<String, String> valueStrings, EntityTableInfo tableInfo, out String message)
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            IReperageService reperageService = ServiceLocator.Current.GetInstance<IReperageService>();
             EntityColumnInfo columnChaussee = (from c in tableInfo.ColumnInfos
                                               where c.ControlType == ControlType.Combo &&
                                                   c.ColumnName.Equals("INF_CHAUSSEE__ID")
                                               select c).FirstOrDefault();
            Object chausseeObj = columnChaussee.Property.GetValue(entityObject);
            if (chausseeObj == null && valueStrings.ContainsKey("InfChaussee.Code") && valueStrings.ContainsKey("InfChaussee.InfLiaison.Code"))
            {
                 DbSet setChaussee = dataService.GetDbSet("InfChaussee");
                 IQueryable queryable = setChaussee.AsQueryable();
                  ParameterExpression expressionBase = Expression.Parameter(setChaussee.ElementType, "item");

                  Expression expressionChausseeCode = Expression.Equal(Expression.Property(expressionBase, "Code"), Expression.Constant(valueStrings["InfChaussee.Code"]));
                  Expression expressionLiaisonCode = Expression.Equal(Expression.Property(Expression.Property(expressionBase, "InfLiaison"), "Code"), Expression.Constant(valueStrings["InfChaussee.InfLiaison.Code"]));
                  Expression expAnd = Expression.And(expressionChausseeCode, expressionLiaisonCode);
               
             
                  MethodCallExpression whereCallExpression = Expression.Call(
                  typeof(Queryable),
                  "Where",
                  new Type[] { queryable.ElementType },
                  queryable.Expression,
                  Expression.Lambda(expAnd, expressionBase));
                  queryable = queryable.Provider.CreateQuery(whereCallExpression);
                  foreach (Object obj in queryable)
                  {chausseeObj = obj;}

            }
            if (chausseeObj == null)
            {
                message = "La chaussée n'existe pas";
                return false;
            }
            else
            {
                Int64 chausseeId = (Int64)chausseeObj.GetType().GetProperty("Id").GetValue(chausseeObj);
                Int64 chausseeAbsDeb = (Int64)chausseeObj.GetType().GetProperty("AbsDeb").GetValue(chausseeObj);
                Int64 chausseeAbsFin = (Int64)chausseeObj.GetType().GetProperty("AbsFin").GetValue(chausseeObj);
                EntityFieldInfo fieldInfo = (from f in tableInfo.FieldInfos where f.ColumnInfo.Equals(ColumnLocation) select f).FirstOrDefault();
                Nullable<Int64> abs = null;
                if (valueStrings[fieldInfo.Path].IndexOf("+") != -1)
                {abs = reperageService.PrToAbs(chausseeId, valueStrings[fieldInfo.Path]); }
                else
                {abs = Int64.Parse(valueStrings[fieldInfo.Path]); }
              
                if (abs.HasValue)
                {
                    if (abs.Value > chausseeAbsFin || abs.Value < chausseeAbsDeb)
                    {
                        message = fieldInfo.DisplayName + " " + valueStrings[fieldInfo.Path] + " ne peut pas être en dehors des bornes de la chaussée ( " + reperageService.AbsToPr(chausseeId, chausseeAbsDeb) + " <-> " + reperageService.AbsToPr(chausseeId, chausseeAbsFin);
                        return false;
                    }
                }
                else
                {
                    message = null;
                    return true;
                }

                message = null;
                return true;
            }
           
        }
    }
}
