using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Attributes;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Validations;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Infrastructure.Utils
{
    public class LinqHelper
    {
        public static Expression CreateFilterExpression<M>(Dictionary<string, string> values, EntityFieldInfo fieldInfo, ParameterExpression expressionBase)
        {
            if (!values.ContainsKey(fieldInfo.Path)) return null;
            String valueString = values[fieldInfo.Path];
            if (String.IsNullOrEmpty(valueString.TrimEnd().TrimStart())) return null;
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();

            if (fieldInfo.ParentColumnInfo == null)
            {
                valueString = valueString.TrimStart().TrimEnd();
                if (fieldInfo.ColumnInfo.PropertyName.Equals("Id"))
                {
                    return CreateFilterExpressionInteger(valueString, fieldInfo.Path, expressionBase, fieldInfo.ColumnInfo);
                }
                else
                {
                    switch (fieldInfo.ColumnInfo.ControlType)
                    {
                        case ControlType.Decimal:
                            return CreateFilterExpressionDecimal(valueString, fieldInfo.Path, expressionBase, fieldInfo.ColumnInfo);

                        case ControlType.Integer:
                            return CreateFilterExpressionInteger(valueString, fieldInfo.Path, expressionBase, fieldInfo.ColumnInfo);

                        case ControlType.Text:
                            return CreateFilterExpressionText(valueString, fieldInfo.Path, expressionBase, fieldInfo.ColumnInfo);

                        case ControlType.Date:
                            return CreateFilterExpressionDate(valueString, fieldInfo.Path, expressionBase, fieldInfo.ColumnInfo);

                    }
                }
            }
            else
            {
            
                String[] items = fieldInfo.Path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                Expression expression = null;
                for (int i = 0; i < (items.Length - 1); i++)
                {
                    if (expression == null)
                    {
                        expression = Expression.Property(expressionBase, items[i]);
                    }
                    else
                    { expression = Expression.Property(expression, items[i]); }
                }
                switch (fieldInfo.ParentColumnInfo.ControlType)
                {
                    case ControlType.Decimal:
                        return CreateFilterExpressionDecimal(valueString, items[items.Length - 1], expression, fieldInfo.ParentColumnInfo);

                    case ControlType.Integer:
                        return CreateFilterExpressionInteger(valueString, items[items.Length - 1], expression, fieldInfo.ParentColumnInfo);

                    case ControlType.Text:
                        return CreateFilterExpressionText(valueString, items[items.Length - 1], expression, fieldInfo.ParentColumnInfo);

                    case ControlType.Date:
                        return CreateFilterExpressionDate(valueString, items[items.Length - 1], expression, fieldInfo.ParentColumnInfo);

                }
            }
            return null;
        }

       

        private static Expression CreateFilterExpressionDate(string valueString, string path, Expression expressionBase, EntityColumnInfo columnInfo)
        {
      
            String message = null;
            DateTime date = DateTime.Now;
            DatePart part = DatePart.None;
            List<DateTime> validDateTime = new List<DateTime>();
            List<DatePart> validDatePart = new List<DatePart>();
            if (valueString.Equals("+") && columnInfo.AllowNull)
            {
                Expression exp = Expression.Property(expressionBase, path);
                return exp = Expression.NotEqual(exp, Expression.Constant(null));
            }
            else if (valueString.Equals("-") && columnInfo.AllowNull)
            {
                Expression exp = Expression.Property(expressionBase, path);
                return exp = Expression.Equal(exp, Expression.Constant(null));
            }
            // contient
            else if (valueString.IndexOf(";") > 0)
            {
                String[] items = valueString.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (items.Length > 1)
                {
                    foreach (String item in items)
                    {
                        if (Validator.ValidateDatePart(item, out message, out date, out part))
                        {
                            validDateTime.Add(date);
                            validDatePart.Add(part);
                        }
                    }
                }
                if (validDatePart.Count > 1)
                {
                    bool allDatePartAreSame = true;
                    for (int i = 1; i < validDatePart.Count; i++)
                    {
                        if (validDatePart[i] != validDatePart[0])
                        { allDatePartAreSame = false; }
                    }
                    Expression prop = Expression.Property(expressionBase, path);
                    if (allDatePartAreSame)
                    {
                        part = validDatePart[0];
                        switch (part)
                        { 
                            case DatePart.Day:
                                if (columnInfo.AllowNull)
                                {
                                    List<Nullable<DateTime>> nullableDateTimes = new List<DateTime?>();
                                    foreach (DateTime t in validDateTime)
                                    { nullableDateTimes.Add(t); }
                                   
                                    return Expression.Call(Expression.Constant(nullableDateTimes, typeof(List<Nullable<DateTime>>)), typeof(List<Nullable<DateTime>>).GetMethod("Contains", new Type[] { typeof(Nullable<DateTime>) }), prop);
                                }
                                else
                                {
                                    return Expression.Call(Expression.Constant(validDateTime, typeof(List<DateTime>)), typeof(List<DateTime>).GetMethod("Contains", new Type[] { typeof(DateTime) }), prop);
                                }
                               
                               
                            case DatePart.Month:
                                //@TODO à implémenter
                               
                                List<String> strMonths = new List<string>();
                                foreach (DateTime t in validDateTime)
                                {strMonths.Add (t.Month.ToString ()+"/"+t.Year.ToString ()); }

                                    Expression propMonth = Expression.Property(prop, "Value");
                                    propMonth = Expression.Property(propMonth, "Month");
                                   propMonth = Expression.Call(propMonth, typeof(Int32).GetMethod("ToString", Type.EmptyTypes));

                                    Expression propYear = Expression.Property(prop, "Value");
                                    propYear = Expression.Property(propYear, "Year");
                                   propYear = Expression.Call(propYear, typeof(Int32).GetMethod("ToString", Type.EmptyTypes));
                               
                                    MethodInfo method =  typeof(String).GetMethod("Concat",new Type[] {typeof (String),typeof (String)});

                                    Expression propValue = Expression.Call(method,propMonth,Expression.Constant ("/"));
                                    propValue = Expression.Call(method, propValue, propYear);
                                    
                                    Expression expHasValue = Expression.Property(prop, "HasValue");
                                    expHasValue = Expression.Equal(expHasValue, Expression.Constant(true));
                                    Expression result = Expression.AndAlso(expHasValue, Expression.Call(Expression.Constant(strMonths, typeof(List<String>)), typeof(List<String>).GetMethod("Contains", new Type[] { typeof(String) }), propValue));

                                    return result;
                               
                                return null;
                            
                            case DatePart.Year:
                                if (columnInfo.AllowNull)
                                {
                                    List<Int32> years = (from d in validDateTime select d.Year).ToList();
                                    prop = Expression.Property(prop, "Value");
                                    prop = Expression.Property(prop, "Year");
                                    return Expression.Call(Expression.Constant(years, typeof(List<Int32>)), typeof(List<Int32>).GetMethod("Contains", new Type[] { typeof(Int32) }), prop);
                                }
                                else
                                {
                                    List<Int32> years = (from d in validDateTime select d.Year).ToList();
                                    prop = Expression.Property(prop, "Year");
                                    return Expression.Call(Expression.Constant(years, typeof(List<Int32>)), typeof(List<Int32>).GetMethod("Contains", new Type[] { typeof(Int32) }), prop);
                     
                                }
                             
                        }
                    }
                }

            }
            else if (valueString.IndexOf("-") > 0)
            {
                String[] items = valueString.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (items.Length > 1)
                {
                    
                }
            }
            else if (valueString.StartsWith("<>"))
            {
                valueString = valueString.Substring(2);
                

            }
            else if (valueString.StartsWith("<="))
            {
                valueString = valueString.Substring(2);
               
            }
            else if (valueString.StartsWith(">="))
            {
                valueString = valueString.Substring(2);
                
            }
            else if (valueString.StartsWith("<"))
            {
                valueString = valueString.Substring(1);
                
            }
            else if (valueString.StartsWith(">"))
            {
                valueString = valueString.Substring(1);
              
            }
            else if (valueString.StartsWith("="))
            {
                valueString = valueString.Substring(1);
               
            }
            else
            {
               
            }
       
         
            return null;
        }

        private static Expression CreateFilterExpressionText(string valueString, string path, Expression expressionBase, EntityColumnInfo columnInfo)
        {
          
            if (valueString.Equals("+") && columnInfo.AllowNull)
            { 
                  Expression exp = Expression.Property(expressionBase, path);
                  return exp = Expression.NotEqual(exp, Expression.Constant(null));
            }
            else if (valueString.Equals("-") && columnInfo.AllowNull)
            {
                Expression exp = Expression.Property(expressionBase, path);
                return exp = Expression.Equal(exp, Expression.Constant(null)); 
            }
            // contient
            else if (valueString.StartsWith("*") && valueString.EndsWith("*"))
            {
                valueString = valueString.Substring(1);
                valueString = valueString.Substring(0, valueString.Length - 1);
                Expression exp = Expression.Property(expressionBase, path);
                return exp = Expression.Call(exp, typeof(String).GetMethod("Contains", new Type[] { typeof(String) }), Expression.Constant(valueString));

            }
            // finit par
            else if (valueString.StartsWith("*"))
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
            else if (valueString.StartsWith("<>"))
            {
                valueString = valueString.Substring(2);
                Expression exp = Expression.Property(expressionBase, path);
                return Expression.NotEqual(exp, Expression.Constant(valueString));
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
            
          
            return null;
        }

        private static Expression CreateFilterExpressionInteger(string valueString, string path, Expression expressionBase, EntityColumnInfo columnInfo)
        {
            
            if (valueString.Equals("+") && columnInfo.AllowNull)
            {
                Expression exp = Expression.Property(expressionBase, path);
                return exp = Expression.NotEqual(exp, Expression.Constant(null));
            }
            else if (valueString.Equals("-") && columnInfo.AllowNull)
            {
                Expression exp = Expression.Property(expressionBase, path);
                return exp = Expression.Equal(exp, Expression.Constant(null));
            }
            
            else    if (valueString.IndexOf(";") > 0)
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
                    if (Int64.TryParse(items[0], out value1) && Int64.TryParse(items[1], out value2))
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
                            Expression expGreaterThanOrEqual = Expression.GreaterThanOrEqual(prop, Expression.Constant(valueDeb, typeof(Nullable<Int64>)));
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
            else if (valueString.StartsWith("<>"))
            {
                valueString = valueString.Substring(2);
                Int64 valueInt64 = 0;
                if (Int64.TryParse(valueString, out valueInt64))
                {
                    if (columnInfo.AllowNull)
                    { return Expression.NotEqual(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Nullable<Int64>))); }
                    else
                    { return Expression.NotEqual(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Int64))); }

                }

            }
            else if (valueString.StartsWith("<="))
            {
                valueString = valueString.Substring(2);
                Int64 valueInt64 = 0;
                if (Int64.TryParse(valueString, out valueInt64))
                {
                    if (columnInfo.AllowNull)
                    { return Expression.LessThanOrEqual(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Nullable<Int64>))); }
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
                    { return Expression.GreaterThanOrEqual(Expression.Property(expressionBase, path), Expression.Constant(valueInt64, typeof(Nullable<Int64>))); }
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
        
           
            return null;
        }

        private static Expression CreateFilterExpressionDecimal(string valueString, String path, Expression expressionBase, EntityColumnInfo columnInfo)
        {
           
            if (valueString.Equals("+") && columnInfo.AllowNull)
            {
                Expression exp = Expression.Property(expressionBase, path);
                return exp = Expression.NotEqual(exp, Expression.Constant(null));
            }
            else if (valueString.Equals("-") && columnInfo.AllowNull)
            {
                Expression exp = Expression.Property(expressionBase, path);
                return exp = Expression.Equal(exp, Expression.Constant(null));
            }
            else
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
            
         
            return null;
        }



       
    }
}
