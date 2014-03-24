using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Symbol
{
    public class SymbologyRuleEquals : SymbologyRule
    {

        public override Expression CreateLinqExpression(ParameterExpression expressionBase)
        {
            MemberExpression  expProperty = null;
            if (this.Field.Path.IndexOf(".") != -1)
            {
                String[] items = this.Field.Path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (String item in items)
                {
                    if (expProperty == null)
                    { expProperty = Expression.Property(expressionBase, item); }
                    else
                    { expProperty = Expression.Property(expProperty, item); }
                }
            }
            else
            { expProperty = Expression.Property(expressionBase, this.Field.Path); }

       
            Expression result = Expression.Equal(expProperty, Expression.Constant(this.Value, expProperty.Type));
            return result;
        }
    }
}
