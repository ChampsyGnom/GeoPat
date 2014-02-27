using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Data.Infrastructure.Utils
{
    public class LinqHelper
    {
        public static Expression CreateFilterExpression<M>(Dictionary<string, string> values, string path, ParameterExpression expressionBase)
        {
            if (!values.ContainsKey(path)) return null;
            String valueString = values[path];
            if (String.IsNullOrEmpty(valueString.TrimEnd ().TrimStart ())) return null;
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(typeof(M));
            if (path.IndexOf(".") == -1)
            {
                valueString = valueString.TrimStart().TrimEnd();
                EntityColumnInfo columnInfo = dataService.GetBottomColumnInfo(typeof(M), path);

                if (columnInfo.ControlType == Presentation.Infrastructure.Attributes.ControlType.Decimal)
                {

                    if (valueString.IndexOf(";") > 0)
                    {
                        if (columnInfo.AllowNull)
                        {
                            Double valueDouble = 0;
                            List<Nullable<Double>> itemList = new List<Nullable<Double>>();
                            String[] items = valueString.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            foreach (String item in items)
                            {
                                if (!String.IsNullOrEmpty(item))
                                {
                                    if (Double.TryParse(item, out valueDouble))
                                    { itemList.Add(valueDouble); }

                                }
                            }
                            if (itemList.Count > 0)
                            {
                                Expression prop = Expression.Property(expressionBase, path);
                                return Expression.Call(Expression.Constant(itemList, typeof(List<Nullable<Double>>)), typeof(List<Nullable<Double>>).GetMethod("Contains", new Type[] { typeof(Nullable<Double>) }), prop);
                            }
                        }
                        else
                        {
                            Double valueDouble = 0;
                            List<Double> itemList = new List<Double>();
                            String[] items = valueString.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            foreach (String item in items)
                            {
                                if (!String.IsNullOrEmpty(item))
                                {
                                    if (Double.TryParse(item, out valueDouble))
                                    { itemList.Add(valueDouble); }

                                }
                            }
                            if (itemList.Count > 0)
                            {
                                Expression prop = Expression.Property(expressionBase, path);
                                return Expression.Call(Expression.Constant(itemList, typeof(List<Double>)), typeof(List<Double>).GetMethod("Contains", new Type[] { typeof(Double) }), prop);
                            }
                        }

                    }
                    else if (valueString.IndexOf("-") > 0)
                    {
                        String[] items = valueString.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        if (items.Length > 1)
                        {
                            Double value1 = 0;
                            Double value2 = 0;
                            Double valueDeb = 0;
                            Double valueFin = 0;
                            if (Double.TryParse(items[0], out value1) && Double.TryParse(items[1], out value2))
                            {
                                if (value1 > value2)
                                {
                                    valueFin = value1;
                                    valueDeb = value2;
                                }
                                else
                                {
                                    valueFin = value2;
                                    valueDeb = value1;
                                }

                                Expression prop = Expression.Property(expressionBase, path);

                                if (columnInfo.AllowNull)
                                {
                                    Expression expGreaterThanOrEqual = Expression.GreaterThanOrEqual(prop, Expression.Constant(valueDeb, typeof(Nullable<Double>)));
                                    Expression expLessThanOrEqual = Expression.LessThanOrEqual(prop, Expression.Constant(valueFin, typeof(Nullable<Double>)));
                                    Expression exp = Expression.And(expGreaterThanOrEqual, expLessThanOrEqual);
                                    return exp;
                                }
                                else
                                {
                                    Expression expGreaterThanOrEqual = Expression.GreaterThanOrEqual(prop, Expression.Constant(valueDeb));
                                    Expression expLessThanOrEqual = Expression.LessThanOrEqual(prop, Expression.Constant(valueFin));
                                    Expression exp = Expression.And(expGreaterThanOrEqual, expLessThanOrEqual);
                                    return exp;
                                }


                            }
                        }
                    }
                    else if (valueString.StartsWith("<>"))
                    {
                        valueString = valueString.Substring(2);
                        Double valueDouble = 0;
                        if (Double.TryParse(valueString, out valueDouble))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.NotEqual(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Nullable<Double>))); }
                            else
                            { return Expression.NotEqual(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Double))); }

                        }

                    }
                    else if (valueString.StartsWith("<="))
                    {
                        valueString = valueString.Substring(2);
                        Double valueDouble = 0;
                        if (Double.TryParse(valueString, out valueDouble))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.LessThanOrEqual(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Nullable<Double>))); }
                            else
                            { return Expression.LessThanOrEqual(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Double))); }

                        }
                    }
                    else if (valueString.StartsWith(">="))
                    {
                        valueString = valueString.Substring(2);
                        Double valueDouble = 0;
                        if (Double.TryParse(valueString, out valueDouble))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.GreaterThanOrEqual(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Nullable<Double>))); }
                            else
                            { return Expression.GreaterThanOrEqual(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Double))); }

                        }
                    }
                    else if (valueString.StartsWith("<"))
                    {
                        valueString = valueString.Substring(1);
                        Double valueDouble = 0;
                        if (Double.TryParse(valueString, out valueDouble))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.LessThan(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Nullable<Double>))); }
                            else
                            { return Expression.LessThan(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Double))); }

                        }
                    }
                    else if (valueString.StartsWith(">"))
                    {
                        valueString = valueString.Substring(1);
                        Double valueDouble = 0;
                        if (Double.TryParse(valueString, out valueDouble))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.GreaterThan(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Nullable<Double>))); }
                            else
                            { return Expression.GreaterThan(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Double))); }

                        }
                    }
                    else if (valueString.StartsWith("="))
                    {
                        valueString = valueString.Substring(1);
                        Double valueDouble = 0;
                        if (Double.TryParse(valueString, out valueDouble))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.Equal(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Nullable<Double>))); }
                            else
                            { return Expression.Equal(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Double))); }

                        }
                    }
                    else
                    {
                        Double valueDouble = 0;
                        if (Double.TryParse(valueString, out valueDouble))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.Equal(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Nullable<Double>))); }
                            else
                            { return Expression.Equal(Expression.Property(expressionBase, path), Expression.Constant(valueDouble, typeof(Double))); }

                        }
                    }
                }

                if (columnInfo.ControlType == Presentation.Infrastructure.Attributes.ControlType.Integer)
                {
                   
                    if (valueString.IndexOf(";") > 0)
                    {
                        if (columnInfo.AllowNull)
                        {
                            Int64 valueInt64 = 0;
                            List<Nullable<Int64>> itemList = new List<Nullable<Int64>>();
                            String[] items = valueString.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            foreach (String item in items)
                            {
                                if (!String.IsNullOrEmpty(item))
                                {
                                    if (Int64.TryParse(item, out valueInt64))
                                    { itemList.Add(valueInt64); }

                                }
                            }
                            if (itemList.Count > 0)
                            {
                                Expression prop = Expression.Property(expressionBase, path);
                                return Expression.Call(Expression.Constant(itemList, typeof(List<Nullable<Int64>>)), typeof(List<Nullable<Int64>>).GetMethod("Contains", new Type[] { typeof(Nullable<Int64>) }), prop);
                            }
                        }
                        else
                        {
                            Int64 valueInt64 = 0;
                            List<Int64> itemList = new List<Int64>();
                            String[] items = valueString.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            foreach (String item in items)
                            {
                                if (!String.IsNullOrEmpty(item))
                                {
                                    if (Int64.TryParse(item, out valueInt64))
                                    { itemList.Add(valueInt64); }

                                }
                            }
                            if (itemList.Count > 0)
                            {
                                Expression prop = Expression.Property(expressionBase, path);
                                return Expression.Call(Expression.Constant(itemList, typeof(List<Int64>)), typeof(List<Int64>).GetMethod("Contains", new Type[] { typeof(Int64) }), prop);
                            }
                        }
                        
                    }
                    else if (valueString.IndexOf("-") > 0)
                    {
                        String[] items = valueString.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        if (items.Length > 1)
                        {
                            Int64 value1 = 0;
                            Int64 value2 = 0;
                            Int64 valueDeb = 0;
                            Int64 valueFin = 0;
                            if (Int64.TryParse(items[0],out value1) && Int64.TryParse(items[1],out value2))
                            {
                                if (value1 > value2)
                                { 
                                    valueFin = value1;
                                    valueDeb = value2;
                                }
                                else 
                                {
                                    valueFin = value2;
                                    valueDeb = value1;
                                }

                                Expression prop = Expression.Property(expressionBase, path);

                                if (columnInfo.AllowNull)
                                {
                                    Expression expGreaterThanOrEqual = Expression.GreaterThanOrEqual(prop, Expression.Constant(valueDeb,typeof(Nullable<Int64>)));
                                    Expression expLessThanOrEqual = Expression.LessThanOrEqual(prop, Expression.Constant(valueFin, typeof(Nullable<Int64>)));
                                    Expression exp = Expression.And(expGreaterThanOrEqual, expLessThanOrEqual);
                                    return exp;
                                }
                                else
                                {
                                    Expression expGreaterThanOrEqual = Expression.GreaterThanOrEqual(prop, Expression.Constant(valueDeb));
                                    Expression expLessThanOrEqual = Expression.LessThanOrEqual(prop, Expression.Constant(valueFin));
                                    Expression exp = Expression.And(expGreaterThanOrEqual, expLessThanOrEqual);
                                    return exp;
                                }
                               
                                
                            }
                        }
                    }
                    else if (valueString.StartsWith ("<>"))
                    {
                        valueString = valueString.Substring(2);
                        Int64 valueInt64 = 0;
                        if (Int64.TryParse (valueString ,out valueInt64 ))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.NotEqual(Expression.Property(expressionBase, path), Expression.Constant(valueInt64,typeof(Nullable<Int64>))); }
                            else
                            {  return Expression.NotEqual (Expression .Property (expressionBase ,path ),Expression.Constant (valueInt64,typeof(Int64)));}
                        
                        }
                        
                    }
                    else if (valueString.StartsWith("<="))
                    {
                        valueString = valueString.Substring(2);
                        Int64 valueInt64 = 0;
                        if (Int64.TryParse(valueString, out valueInt64))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.LessThanOrEqual  (Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Nullable<Int64>))); }
                            else
                            { return Expression.LessThanOrEqual(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Int64))); }

                        }
                    }
                    else if (valueString.StartsWith(">="))
                    {
                        valueString = valueString.Substring(2);
                        Int64 valueInt64 = 0;
                        if (Int64.TryParse(valueString, out valueInt64))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.GreaterThanOrEqual (Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Nullable<Int64>))); }
                            else
                            { return Expression.GreaterThanOrEqual(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Int64))); }

                        }
                    }
                    else if (valueString.StartsWith("<"))
                    {
                        valueString = valueString.Substring(1);
                        Int64 valueInt64 = 0;
                        if (Int64.TryParse(valueString, out valueInt64))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.LessThan(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Nullable<Int64>))); }
                            else
                            { return Expression.LessThan(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Int64))); }

                        }
                    }
                    else if (valueString.StartsWith(">"))
                    {
                        valueString = valueString.Substring(1);
                        Int64 valueInt64 = 0;
                        if (Int64.TryParse(valueString, out valueInt64))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.GreaterThan(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Nullable<Int64>))); }
                            else
                            { return Expression.GreaterThan(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Int64))); }

                        }
                    }
                    else if (valueString.StartsWith("="))
                    {
                        valueString = valueString.Substring(1);
                        Int64 valueInt64 = 0;
                        if (Int64.TryParse(valueString, out valueInt64))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.Equal(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Nullable<Int64>))); }
                            else
                            { return Expression.Equal(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Int64))); }

                        }
                    }
                    else
                    {
                        Int64 valueInt64 = 0;
                        if (Int64.TryParse(valueString, out valueInt64))
                        {
                            if (columnInfo.AllowNull)
                            { return Expression.Equal(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Nullable<Int64>))); }
                            else
                            { return Expression.Equal(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Int64))); }

                        }
                    }
                }
               else if (columnInfo.ControlType == Presentation.Infrastructure.Attributes.ControlType.Text)
                {
                 
                    // contient
                    if (valueString.StartsWith("*") && valueString.EndsWith ("*"))
                    {
                        valueString = valueString.Substring(1);
                        valueString = valueString.Substring(0, valueString.Length - 1);
                        Expression exp = Expression.Property(expressionBase, path);
                        return exp = Expression.Call(exp, typeof(String).GetMethod("Contains", new Type[] { typeof(String) }), Expression.Constant(valueString));
                       
                    }
                    // finit par
                    else if (valueString.StartsWith("*") )
                    {                    
                        valueString = valueString.Substring(1);                  
                        Expression exp = Expression.Property(expressionBase, path);
                        return exp = Expression.Call(exp, typeof(String).GetMethod("EndsWith", new Type[] { typeof(String) }), Expression.Constant(valueString));
                    }
                    // commence par
                    else if (valueString.EndsWith("*"))
                    {
                        valueString = valueString.Substring(0, valueString.Length - 1);
                        Expression exp = Expression.Property(expressionBase, path);
                        return exp = Expression.Call(exp, typeof(String).GetMethod("StartsWith", new Type[] { typeof(String) }), Expression.Constant(valueString));
                    }
                    // dans la liste
                    else if (valueString.IndexOf(";") > 0)
                    {
                        List<String> itemList = new List<string>();
                        String[] items = valueString.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        foreach (String item in items)
                        {
                            if (!String.IsNullOrEmpty(item))
                            { itemList.Add(item); }
                        }
                        if (itemList.Count > 0)
                        {
                            Expression prop = Expression.Property(expressionBase, path);
                            return Expression.Call(Expression.Constant(itemList, typeof(List<String>)), typeof(List<String>).GetMethod("Contains", new Type[] { typeof(String) }), prop);
                        }
                    }
                    // égale
                    else if (valueString.StartsWith("="))
                    {
                        valueString = valueString.Substring(1);
                        Expression exp = Expression.Property(expressionBase, path);
                        return Expression.Equal(exp, Expression.Constant(valueString));
                    }
                    // égale
                    else 
                    {
                        Expression exp = Expression.Property(expressionBase, path);
                        return Expression.Equal(exp, Expression.Constant(valueString));
                    }
                
                }
            }

            return null;
        }
    }
}
