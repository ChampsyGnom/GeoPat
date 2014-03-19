using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Reflection;
using System.Data.Entity;
using System.Reflection;
using Emash.GeoPatNet.Data.Models;
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;

using System.IO;
using System.Linq.Expressions;
namespace Emash.GeoPatNet.Modules.Document.ViewModels
{
    public class DocumentBrowserViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<DocumentViewModel> RemoveDocumentCommand { get; private set; }
        public DelegateCommand<System.Windows.DragEventArgs> DropCommand { get; private set; }
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
        private DocumentCodeViewModel _selectedCode;

        public DocumentCodeViewModel SelectedCode
        {
            get { return _selectedCode; }
            set { _selectedCode = value; this.RaisePropertyChanged("SelectedCode"); }
        }
        private IDataService DataService { get; set; }
        public ObservableCollection<DocumentCodeViewModel> Codes { get;private  set; }
        private Type ModelType { get;  set; }
        private Int64 ClsId { get;  set; }
        private Object EntityModel { get; set; }
        private EntityTableInfo EntityTableInfo { get; set; }
        public DocumentBrowserViewModel(Type modelType, Object entityModel)
        {
            this.ModelType = modelType;
            this.EntityModel = entityModel ;
            this.DataService = ServiceLocator.Current.GetInstance<IDataService>();
            this.Codes = new ObservableCollection<DocumentCodeViewModel>();
            this.EntityTableInfo = this.DataService.GetEntityTableInfo(this.ModelType);
            PropertyInfo propModelId = modelType.GetProperty("Id");
            Int64 modelId = (Int64)propModelId.GetValue(entityModel);
            String entityTableName = EntityTableInfo.TableName.ToLower();

            String camelSchemaName = EntityTableInfo.SchemaInfo.SchemaName.Substring(0, 1).ToUpper() + EntityTableInfo.SchemaInfo.SchemaName.Substring(1).ToLower();
            DbSet setCodeDoc = this.DataService.GetDbSet(camelSchemaName + "CodeDoc");

            DbSet<PrfParam> parameters = this.DataService.GetDbSet<PrfParam>();

            PrfParam paramPathDoc = (from p in parameters where p.PrfSchema.Name.Equals(camelSchemaName.ToUpper()) && p.Code.Equals("DIRECTORY_DOC") select p).FirstOrDefault();
            
            PropertyInfo propCode = setCodeDoc.ElementType.GetProperty("Code");
            PropertyInfo propPath = setCodeDoc.ElementType.GetProperty("Path");
            PropertyInfo propLibelle = setCodeDoc.ElementType.GetProperty("Libelle");
            PropertyInfo propId = setCodeDoc.ElementType.GetProperty("Id");
            foreach (Object item in setCodeDoc)
            {
                DocumentCodeViewModel vm = new DocumentCodeViewModel(paramPathDoc.Valeur);
                vm.Code = propCode.GetValue(item).ToString();
                vm.Libelle = propLibelle.GetValue(item).ToString();
                vm.Path = propPath.GetValue(item).ToString();
                vm.Id = (Int64)propId.GetValue(item);
                if (!Directory.Exists(vm.AbsolutePath))
                {Directory.CreateDirectory(vm.AbsolutePath);}
                this.Codes.Add(vm);
               
            }

            DbSet setCls = this.DataService.GetDbSet(camelSchemaName + "Cls");
            ParameterExpression expressionBase = System.Linq.Expressions.Expression.Parameter(setCls.ElementType, "item");
            List<Expression> expressions = new List<Expression>();

            expressions.Add(Expression.Equal(Expression.Property(expressionBase, "TableName"), Expression.Constant(EntityTableInfo.TableName)));
            if (this.EntityModel == null)
            {
                expressions.Add(Expression.Equal(Expression.Property(expressionBase, "RowId"), Expression.Constant(null)));
            }
            else
            {
                expressions.Add(Expression.Equal(Expression.Property(expressionBase, "RowId"), Expression.Constant(modelId,typeof(Nullable<Int64>))));
            }
            IQueryable queryable = setCls.AsQueryable();
            Expression ex = Expression.And(expressions[0], expressions[1]);
            System.Linq.Expressions.Expression  whereCallExpression = System.Linq.Expressions.Expression.Call(
                   typeof(Queryable),
                   "Where",
                   new Type[] { queryable.ElementType },
                   queryable.Expression,
                   System.Linq.Expressions.Expression.Lambda(ex, expressionBase));
            queryable = queryable.Provider.CreateQuery(whereCallExpression);
            bool hasCls = false;
            PropertyInfo propClsId = setCls.ElementType.GetProperty("Id");
            foreach (Object item in queryable)
            {
                this.ClsId = (Int64)propClsId.GetValue(item);
                hasCls = true;
                break;
            }
            if (!hasCls)
            {
                Object cls = Activator.CreateInstance(setCls.ElementType);
                PropertyInfo propClsTableName = setCls.ElementType.GetProperty("TableName");
                PropertyInfo propRowId = setCls.ElementType.GetProperty("RowId");
                propClsTableName.SetValue(cls, EntityTableInfo.TableName);
                if (entityModel != null)
                { propRowId.SetValue(cls, modelId); }
                else
                { propRowId.SetValue(cls, null); }
                setCls.Add(cls);
                this.DataService.DataContext.SaveChanges();
                this.ClsId = (Int64)propClsId.GetValue(cls);
            }
            Console.WriteLine("Identifiant vclasseur " + this.ClsId);

            foreach (DocumentCodeViewModel codeVm in this.Codes)
            { this.LoadDocument(codeVm); }

            if (this.Codes.Count > 0)
            { this.SelectedCode = this.Codes.First(); }
            this.DropCommand = new DelegateCommand<System.Windows.DragEventArgs>(DropExecute);
            this.RemoveDocumentCommand = new DelegateCommand<DocumentViewModel>(RemoveDocumentExecute);

        }

        private void RemoveDocumentExecute(DocumentViewModel docVm)
        { 
            String camelSchemaName = EntityTableInfo.SchemaInfo.SchemaName.Substring(0, 1).ToUpper() + EntityTableInfo.SchemaInfo.SchemaName.Substring(1).ToLower();
            DbSet setDoc = this.DataService.GetDbSet(camelSchemaName + "Doc");
            DbSet setDocCls = this.DataService.GetDbSet(camelSchemaName + "DocCls");
            ParameterExpression expressionBase = System.Linq.Expressions.Expression.Parameter(setDocCls.ElementType, "item");

            Expression exp = Expression.And(
            Expression.Equal(Expression.Property(expressionBase, "InfClsId"), Expression.Constant(this.ClsId)),
            Expression.Equal(Expression.Property(expressionBase, "InfDocId"), Expression.Constant(docVm.Id))
            );
            IQueryable queryable = setDocCls.AsQueryable();
            System.Linq.Expressions.Expression whereCallExpression = System.Linq.Expressions.Expression.Call(
                   typeof(Queryable),
                   "Where",
                   new Type[] { queryable.ElementType },
                   queryable.Expression,
                   System.Linq.Expressions.Expression.Lambda(exp, expressionBase));
            queryable = queryable.Provider.CreateQuery(whereCallExpression);
            List<Object> itemToRemoves = new List<object>();
            foreach (Object objClsDoc in queryable)
            {itemToRemoves.Add(objClsDoc);}

            foreach (Object objClsDoc in itemToRemoves)
            { setDocCls.Remove(objClsDoc); }

            this.DataService.DataContext.SaveChanges();
            this.LoadDocument(docVm.Code);

        }

        private void LoadDocument(DocumentCodeViewModel codeVm)
        {
            codeVm.Documents.Clear();
            String camelSchemaName = EntityTableInfo.SchemaInfo.SchemaName.Substring(0, 1).ToUpper() + EntityTableInfo.SchemaInfo.SchemaName.Substring(1).ToLower();
            DbSet setDocCls = this.DataService.GetDbSet(camelSchemaName + "DocCls");
            ParameterExpression expressionBase = System.Linq.Expressions.Expression.Parameter(setDocCls.ElementType, "item");

            Expression exp = Expression.And(
            Expression.Equal(Expression.Property(expressionBase, "InfClsId"), Expression.Constant(this.ClsId)),
            Expression.Equal(Expression.Property(Expression.Property(expressionBase, "InfDoc"), "InfCodeDocId"), Expression.Constant(codeVm.Id))                 
            );

            IQueryable queryable = setDocCls.AsQueryable();
           
            System.Linq.Expressions.Expression whereCallExpression = System.Linq.Expressions.Expression.Call(
                   typeof(Queryable),
                   "Where",
                   new Type[] { queryable.ElementType },
                   queryable.Expression,
                   System.Linq.Expressions.Expression.Lambda(exp, expressionBase));
            queryable = queryable.Provider.CreateQuery(whereCallExpression);
            PropertyInfo propDoc = setDocCls.ElementType.GetProperty("InfDoc");
            PropertyInfo propDocId = propDoc.PropertyType.GetProperty("Id");
            PropertyInfo propDocFileName = propDoc.PropertyType.GetProperty("Filename");
            PropertyInfo propDocLibelle = propDoc.PropertyType.GetProperty("Libelle");
            foreach (Object item in queryable)
            {
                Object objDoc = propDoc.GetValue(item);
                DocumentViewModel documentViewModel = new DocumentViewModel();
                String fileName = propDocFileName.GetValue (objDoc).ToString ();
                string libelle = propDocLibelle.GetValue (objDoc ).ToString ();
                String path = Path.Combine(codeVm.AbsolutePath, fileName);
                documentViewModel.Code = codeVm;
                documentViewModel.AbsoluteFileName = path;
                documentViewModel.Id = (Int64)propDocId.GetValue(objDoc);
                documentViewModel.Libelle = libelle;
                codeVm.Documents.Add(documentViewModel);
            }
           
        }

        private void DropExecute(System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
                if (this.SelectedCode != null)
                { 
                    foreach (String file in files)
                    {
                        FileInfo srcFile = new FileInfo(file);
                        String dstFileName = Path.Combine(this.SelectedCode.AbsolutePath, srcFile.Name);
                        if (File.Exists(dstFileName))
                        {
                            FileInfo dstFile = new FileInfo(dstFileName);
                            if (dstFile.Length == srcFile.Length)
                            {

                            }
                            else
                            { this.AddFileToCode(this.SelectedCode.Id, srcFile.FullName, dstFileName); }
                        }
                        else
                        { this.AddFileToCode(this.SelectedCode.Id, srcFile.FullName, dstFileName); }
                    }
                    this.LoadDocument(this.SelectedCode);

                }
                Console.WriteLine(files);
            }
        }

        

        private void AddFileToCode(long idCode, string srcFileName, string dstFileName)
        {
            FileInfo srcFile = new FileInfo(srcFileName);
            try {
                File.Copy(srcFileName, dstFileName);
                String camelSchemaName = EntityTableInfo.SchemaInfo.SchemaName.Substring(0, 1).ToUpper() + EntityTableInfo.SchemaInfo.SchemaName.Substring(1).ToLower();          
                DbSet setDoc = this.DataService.GetDbSet(camelSchemaName + "Doc");
                Object objDoc = Activator.CreateInstance(setDoc.ElementType);
                PropertyInfo propDocFilename = setDoc.ElementType.GetProperty("Filename");
                PropertyInfo propDocInfCodeDocId = setDoc.ElementType.GetProperty("InfCodeDocId");
                PropertyInfo propDocLibelle = setDoc.ElementType.GetProperty("Libelle");
                PropertyInfo propDocId = setDoc.ElementType.GetProperty("Id");
                propDocFilename.SetValue(objDoc, srcFile.Name);
                propDocInfCodeDocId.SetValue(objDoc, idCode);
                propDocLibelle.SetValue(objDoc, srcFile.Name);
                setDoc.Add(objDoc);
                this.DataService.DataContext.SaveChanges();
                Int64 docId = (Int64)propDocId.GetValue(objDoc);
                DbSet setDocCls = this.DataService.GetDbSet(camelSchemaName + "DocCls");
                Object objDocCls = Activator.CreateInstance(setDocCls.ElementType);
                PropertyInfo propDocClsId = setDocCls.ElementType.GetProperty("InfClsId");
                PropertyInfo propDocDocId = setDocCls.ElementType.GetProperty("InfDocId");
                propDocClsId.SetValue(objDocCls, this.ClsId);
                propDocDocId.SetValue(objDocCls, docId);
                setDocCls.Add(objDocCls);
                this.DataService.DataContext.SaveChanges();



            }
            catch (Exception ex)
            { }
        }
    }
}
