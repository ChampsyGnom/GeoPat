using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Projections;
using System.Collections .ObjectModel;
using System.Windows.Data;
using Microsoft.Practices.Prism.Commands;
using Emash.GeoPatNet.Infrastructure.Services;
using System.Data.Entity;
using Emash.GeoPatNet.Data.Models;
using DotSpatial.Symbology;
using Emash.GeoPatNet.Infrastructure.Behaviors;
using System.Windows.Controls;
using Emash.GeoPatNet.Infrastructure.Reflection;
using System.Reflection;
using DotSpatial.Topology;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class CartoViewModel
    {
        public String DisplayName 
        { 
            get 
            {return "Cartographie";} 
        }
        public DelegateCommand<TreeViewContextMenuOpeningBehaviorEventArg> TreeTemplateContextMenuOpeningCommand { get; private set; }
        public DelegateCommand CreateTemplateCommand { get;private  set; }
        private ObservableCollection<TemplateViewModel> Templates { get; set; }
        public ListCollectionView TemplatesView { get; private set; }
        public DotSpatial.Controls.Map Map { get; set; }     
        public IDataService DataService { get; private set; }
        public IEngineService EngineService { get; private set; }
        public ICartoService CartoService { get; private set; }
        public Dictionary<EntitySchemaInfo,List<EntityTableInfo>> GeocodableEntityTables { get; private set; }
        public CartoViewModel(IDataService dataService, IEngineService engineService, ICartoService cartoService)
        {
            this.CartoService = cartoService;
            this.DataService = dataService;
            this.EngineService = engineService;
            this.Templates = new ObservableCollection<TemplateViewModel>();
            this.TemplatesView = new ListCollectionView(this.Templates);
            this.TemplatesView.CurrentChanged += TemplatesView_CurrentChanged;
            this.CreateTemplateCommand = new DelegateCommand(CreateTemplateExecute);
            this.LoadGeocodableEntityTypes();
            this.LoadTemplates();
            this.TreeTemplateContextMenuOpeningCommand = new DelegateCommand<TreeViewContextMenuOpeningBehaviorEventArg>(TreeTemplateContextMenuOpeningExecute);

        }

        private void LoadGeocodableEntityTypes()
        {
            this.GeocodableEntityTables = new Dictionary<EntitySchemaInfo,List<EntityTableInfo>> ();
            foreach (EntitySchemaInfo schemaInfo in this.DataService.SchemaInfos)
            {
                List<EntityTableInfo> tbls = (from t in schemaInfo.TableInfos orderby t.DisplayName  select t).ToList();
                foreach (EntityTableInfo tableInfo in tbls)
                {
                    Boolean isGeocodable = false;
                    PropertyInfo propertyGeom = tableInfo.EntityType.GetProperty("Geom");
                    if (propertyGeom != null)
                    {isGeocodable = true;}
                    else
                    {
                        EntityColumnInfo columnInfoLocRef = (from c in tableInfo.ColumnInfos where c.IsLocalisationReferenceId select c).FirstOrDefault();
                        EntityColumnInfo columnInfoLocDeb = (from c in tableInfo.ColumnInfos where c.IsLocalisationDeb select c).FirstOrDefault();
                        isGeocodable = columnInfoLocDeb != null && columnInfoLocDeb != null;
                    }
                    if (isGeocodable)
                    {
                        if (!this.GeocodableEntityTables.ContainsKey(schemaInfo))
                        {this.GeocodableEntityTables.Add(schemaInfo, new List<EntityTableInfo>());}
                        this.GeocodableEntityTables[schemaInfo].Add(tableInfo);
                    }
                }

            }
        }
        private void TreeTemplateContextMenuOpeningExecute(TreeViewContextMenuOpeningBehaviorEventArg arg)
        {
            if (this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel)
            {
                TemplateViewModel templateViewModel = ( this.TemplatesView.CurrentItem as TemplateViewModel);
                arg.ContextMenu.Items.Clear();
                if (arg.TreeView.SelectedItem == null)
                {

                    MenuItem menuItemAddfolder = new MenuItem();
                    menuItemAddfolder.Header = "Ajouter un dossier";
                    menuItemAddfolder.Command = new DelegateCommand(new Action(delegate()
                    {
                        this.AddFolder(templateViewModel, arg.TreeView.SelectedItem as TemplateNodeFolderViewModel);
                    }));
                    arg.ContextMenu.Items.Add(menuItemAddfolder);
                   
                    MenuItem menuItemAddTables = new MenuItem();
                    menuItemAddTables.Header = "Ajouter une table";
                    foreach (EntitySchemaInfo schemaInfo in this.GeocodableEntityTables.Keys )
                    {
                        MenuItem menuItemSchema = new MenuItem();
                        menuItemSchema.Header = schemaInfo.SchemaName;
                       foreach (EntityTableInfo tableInfo in this.GeocodableEntityTables[schemaInfo])
                        {
                            MenuItem menuItemAddTable = new MenuItem();
                            menuItemAddTable.Header = tableInfo.DisplayName;
                           menuItemAddTable.Command = new DelegateCommand (new Action (delegate(){
                               this.AddLayerMetier(templateViewModel, arg.TreeView.SelectedItem as TemplateNodeFolderViewModel, tableInfo);
                           }));
                            menuItemSchema.Items.Add(menuItemAddTable);
                        }
                        menuItemAddTables.Items.Add(menuItemSchema);
                    }
                    arg.ContextMenu.Items.Add(menuItemAddTables);
                }
                else
                {
                    if (arg.TreeView.SelectedItem is TemplateNodeFolderViewModel)
                    {
                        MenuItem menuItemAddfolder = new MenuItem();
                        menuItemAddfolder.Header = "Nouveau dossier";
                        menuItemAddfolder.Command = new DelegateCommand(new Action(delegate()
                        {
                            this.AddFolder(templateViewModel, arg.TreeView.SelectedItem as TemplateNodeFolderViewModel);
                        }));
                        arg.ContextMenu.Items.Add(menuItemAddfolder);


                        MenuItem menuItemAddTables = new MenuItem();
                        menuItemAddTables.Header = "Ajouter une table";
                        foreach (EntitySchemaInfo schemaInfo in this.GeocodableEntityTables.Keys)
                        {
                            MenuItem menuItemSchema = new MenuItem();
                            menuItemSchema.Header = schemaInfo.SchemaName;
                            foreach (EntityTableInfo tableInfo in this.GeocodableEntityTables[schemaInfo])
                            {
                                MenuItem menuItemAddTable = new MenuItem();
                                menuItemAddTable.Header = tableInfo.DisplayName;
                                menuItemSchema.Items.Add(menuItemAddTable);
                                menuItemAddTable.Command = new DelegateCommand(new Action(delegate()
                                {
                                    this.AddLayerMetier(templateViewModel, arg.TreeView.SelectedItem as TemplateNodeFolderViewModel, tableInfo);
                                }));
                            }
                            menuItemAddTables.Items.Add(menuItemSchema);
                        }
                        arg.ContextMenu.Items.Add(menuItemAddTables);
                    }
                    else if (arg.TreeView.SelectedItem is TemplateNodeLayerViewModel)
                    { }
                }
            }
            else
            { arg.ContextMenuEventArgs.Handled = true;}
        }
        private Int64  GetNextMapOrder()
        {
            if (this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel)
            {
                TemplateViewModel templateViewModel = (this.TemplatesView.CurrentItem as TemplateViewModel);
                DbSet<SigNode> nodes = this.DataService.GetDbSet<SigNode>();
                if ((from n in nodes where n.SigTemplateId == templateViewModel.Id && n.SigLayer != null select n.SigLayer.MapOrder).Any())
                {

                    long maxOrder = (from n in nodes where n.SigTemplateId == templateViewModel.Id && n.SigLayer != null select n.SigLayer.MapOrder).Max();
                    return maxOrder + 1;
                }
            }
            return 0;
        }
        private void AddLayerMetier(TemplateViewModel templateViewModel, TemplateNodeFolderViewModel parentFolder, EntityTableInfo tableInfo)
        {
            DbSet<SigNode> nodes = this.DataService.GetDbSet<SigNode>();
            DbSet<SigLayer> layers = this.DataService.GetDbSet<SigLayer>();


            DbSet<SigCodeNode> codeNodes = this.DataService.GetDbSet<SigCodeNode>();
            DbSet<SigCodeLayer> codeLayers = this.DataService.GetDbSet<SigCodeLayer>();
           
            SigNode nodeLayerMetier = new SigNode();
            nodeLayerMetier.SigTemplateId = templateViewModel.Id;
            if (parentFolder != null)
            {
                nodeLayerMetier.ParentId = parentFolder.Model.Id;
                nodeLayerMetier.Order = parentFolder.Nodes.Count;
            }
            else
            {
                nodeLayerMetier.ParentId = -1;
                nodeLayerMetier.Order = templateViewModel.Nodes.Count;
            }
            nodeLayerMetier.SigCodeNode = (from c in codeNodes where c.Code.Equals("Layer") select c).FirstOrDefault();
            nodeLayerMetier.Libelle = tableInfo.DisplayName;
            SigLayer layer = new SigLayer();
            layer.Libelle = tableInfo.DisplayName;
            layer.MapOrder = this.GetNextMapOrder();
            layer.EntityName = tableInfo.EntityType.Name;
            layer.SigCodeLayer = (from c in codeLayers where c.Code.Equals("Geocodage") select c).FirstOrDefault();
            layers.Add(layer);
            this.DataService.DataContext.SaveChanges();
            nodeLayerMetier.SigLayer = layer;
            nodes.Add(nodeLayerMetier);
            this.DataService.DataContext.SaveChanges();
            TemplateNodeLayerViewModel vm = new TemplateNodeLayerViewModel(nodeLayerMetier);
            if (parentFolder == null)
            { templateViewModel.Nodes.Add(vm); }
            else
            { parentFolder.Nodes.Add(vm); }
            vm.CreateLayers();
            foreach (IMapLayer mapLayer in vm.Layers)
            {this.Map.Layers.Add(mapLayer);}
        }

        private void AddFolder(TemplateViewModel templateViewModel, TemplateNodeFolderViewModel parentFolder)
        {
           SigNode nodeFolder = new SigNode ();
           if (parentFolder != null)
           {
               nodeFolder.ParentId = parentFolder.Model.Id;
               nodeFolder.Order = parentFolder.Nodes.Count;
           }
           else
           {
               nodeFolder.ParentId = -1;
               nodeFolder.Order = templateViewModel.Nodes.Count;
           }
           nodeFolder.SigTemplateId = templateViewModel.Id;
           DbSet<SigCodeNode> codeNodes = this.DataService.GetDbSet<SigCodeNode>();
           nodeFolder.SigCodeNode = (from c in codeNodes where c.Code.Equals("Folder") select c).FirstOrDefault();
           nodeFolder = this.EngineService.ShowAddDialog<SigNode>(nodeFolder, new String[] {"Libelle" });
           if (nodeFolder != null)
           {
               if (parentFolder == null)
               { templateViewModel.Nodes.Add(new TemplateNodeFolderViewModel(nodeFolder)); }
               else
               { parentFolder.Nodes.Add(new TemplateNodeFolderViewModel(nodeFolder)); }
           }
        }

        private void LoadTemplates()
        {
            DbSet<SigTemplate> templateSet = this.DataService.GetDbSet<SigTemplate>();
            foreach (SigTemplate templateItem in templateSet)
            {
                TemplateViewModel vm = new TemplateViewModel(templateItem);
                this.Templates.Add(vm);
            }
        }

        private void CreateTemplateExecute()
        {
            DbSet<SigTemplate> templateSet = this.DataService.GetDbSet<SigTemplate>();
            SigTemplate template = this.EngineService.ShowAddDialog<SigTemplate>();
            if (template != null)
            {                      
                TemplateViewModel vm = new TemplateViewModel(template);
                this.Templates.Add(vm);
                this.TemplatesView.MoveCurrentTo(vm);
            }
        }

        void TemplatesView_CurrentChanged(object sender, EventArgs e)
        {
            this.ClearLayers();
            if (this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel)
            {
                TemplateViewModel template = (this.TemplatesView.CurrentItem as TemplateViewModel);
                this.LoadTemplate(template);
            }
        }

        private void LoadTemplate(TemplateViewModel template)
        {
            template.Nodes.Clear();
            this.Map.Layers.Clear();
            DbSet<SigNode> nodeSet = this.DataService.GetDbSet<SigNode>();
            List<TemplateNodeLayerViewModel> layersNodes = new List<TemplateNodeLayerViewModel>();
            this.RecurseLoadTemplate(nodeSet, template, template.Nodes, -1, layersNodes);
            Envelope env = new Envelope();
            layersNodes = (from ln in layersNodes where ln.Model.SigLayer != null orderby ln.Model.SigLayer.MapOrder  select ln).ToList();
            foreach (TemplateNodeLayerViewModel layersNode in layersNodes)
            {
                layersNode.CreateLayers();
                foreach (IMapLayer mapLayer in layersNode.Layers)
                {
                    this.Map.Layers.Add(mapLayer);
                    env.ExpandToInclude(mapLayer.Extent.ToEnvelope());
                }
            }
            this.Map.ViewExtents = env.ToExtent();
        }

        private void RecurseLoadTemplate(DbSet<SigNode> nodeSet, TemplateViewModel template, ObservableCollection<TemplateNodeViewModel> nodes, Int64  parentId,List<TemplateNodeLayerViewModel> layersNodes)
        {
            List<SigNode> levelNodes = (from n in nodeSet where n.SigTemplateId == template.Id && n.ParentId == parentId orderby n.Order select n).ToList();
            foreach (SigNode levelNode in levelNodes)
            {
                if (levelNode.SigCodeNode.Code.Equals("Folder"))
                {
                    TemplateNodeFolderViewModel vm = new TemplateNodeFolderViewModel(levelNode);
                    nodes.Add(vm);
                    this.RecurseLoadTemplate(nodeSet, template, vm.Nodes, levelNode.Id, layersNodes);
                }
                else if (levelNode.SigCodeNode.Code.Equals("Layer"))
                {
                    TemplateNodeLayerViewModel vm = new TemplateNodeLayerViewModel(levelNode);
                    nodes.Add(vm);
                    layersNodes.Add(vm);
                }
            }
        }

      
        private void ClearLayers()
        {

            this.Map.Layers.Clear();
        }


       
    }
}
