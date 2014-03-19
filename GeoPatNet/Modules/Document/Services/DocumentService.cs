using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Modules.Document.ViewModels;
using Microsoft.Practices.ServiceLocation;
namespace Emash.GeoPatNet.Modules.Document.Services
{
    public class DocumentService : IDocumentService
    {
        private IDataService DataService { get; set; }

        public DocumentService(IDataService dataService)
        {
            this.DataService = dataService;
        }

        public void Initialize()
        {
            foreach (EntitySchemaInfo schemaInfo in this.DataService.SchemaInfos)
            {
                String camelSchemaName = schemaInfo.SchemaName.Substring(0, 1).ToUpper() + schemaInfo.SchemaName.Substring(1).ToLower();
                DbSet set = this.DataService.GetDbSet(camelSchemaName + "CodeDoc");
                System.Linq.Expressions.MethodCallExpression whereCallExpression;
                Expression exp;
                if (set != null)
                {
                    ParameterExpression expressionBase = System.Linq.Expressions.Expression.Parameter(set.ElementType, "item");
                    set = this.DataService.GetDbSet(camelSchemaName + "CodeDoc");
                    IQueryable queryable = set.AsQueryable();
                   
                    exp = Expression.Equal(Expression.Property(expressionBase, "Code"), Expression.Constant("PHOTOS"));
                    whereCallExpression = System.Linq.Expressions.Expression.Call(
                    typeof(Queryable),
                    "Where",
                    new Type[] { queryable.ElementType },
                    queryable.Expression,
                    System.Linq.Expressions.Expression.Lambda(exp, expressionBase));
                    queryable = queryable.Provider.CreateQuery(whereCallExpression);
                    bool hasCodePhoto = false;
                    foreach (Object item in queryable)
                    {hasCodePhoto = true;}
                    if (!hasCodePhoto)
                    {
                        Object item = Activator.CreateInstance(set.ElementType);
                        PropertyInfo propCode = set.ElementType.GetProperty("Code");
                        PropertyInfo propPath = set.ElementType.GetProperty("Path");
                        PropertyInfo propLibelle = set.ElementType.GetProperty("Libelle");
                        propCode.SetValue(item, "PHOTOS");
                        propPath.SetValue(item, "PHOTOS");
                        propLibelle.SetValue(item, "Photographies ou images");
                        set.Add(item);
                        this.DataService.DataContext.SaveChanges();
                    }

                    set = this.DataService.GetDbSet(camelSchemaName + "CodeDoc");
                    queryable = set.AsQueryable();
                    exp = Expression.Equal(Expression.Property(expressionBase, "Code"), Expression.Constant("PLANS"));
                    whereCallExpression = System.Linq.Expressions.Expression.Call(
                    typeof(Queryable),
                    "Where",
                    new Type[] { queryable.ElementType },
                    queryable.Expression,
                    System.Linq.Expressions.Expression.Lambda(exp, expressionBase));
                    queryable = queryable.Provider.CreateQuery(whereCallExpression);
                    bool hasCodePlan = false;
                    Console.WriteLine(queryable);
                    foreach (Object item in queryable)
                    { hasCodePlan = true; }
                    if (!hasCodePlan)
                    {
                        Object item = Activator.CreateInstance(set.ElementType);
                        PropertyInfo propCode = set.ElementType.GetProperty("Code");
                        PropertyInfo propPath = set.ElementType.GetProperty("Path");
                        PropertyInfo propLibelle = set.ElementType.GetProperty("Libelle");
                        propCode.SetValue(item, "PLANS");
                        propPath.SetValue(item, "PLANS");
                        propLibelle.SetValue(item, "Plans");
                        set.Add(item);
                        this.DataService.DataContext.SaveChanges();
                    }
                }
                

            }
        }


        public void ShowDocument(Type modelType, object entityModel)
        {
            if (entityModel != null)
            {
                DocumentBrowserViewModel viewModel = new DocumentBrowserViewModel(modelType,entityModel);
                IDialogService dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
                System.Windows.Window window =  dialogService.CreateDialog("DocumentBrowserRegion", "Documents associés");
                window.DataContext = viewModel;
                window.Show();
            }
        }
    }
}
