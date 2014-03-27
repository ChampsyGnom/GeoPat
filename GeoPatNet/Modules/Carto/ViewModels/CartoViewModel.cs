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
using System.ComponentModel;
using System.Windows;
using System.Data.Entity.Infrastructure;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class CartoViewModel : INotifyPropertyChanged
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
        public String DisplayName 
        { 
            get 
            {return "Cartographie";} 
        }

        public Visibility TemplateVisibility
        {
            get
            {
                if (this.TemplatesView != null && this.TemplatesView.CurrentItem != null)
                { return Visibility.Visible; }
                return Visibility.Hidden;
            }
        }
        private Boolean _isModeMove = true;

        public Boolean IsModeMove
        {
            get { return _isModeMove; }
            set { 
                _isModeMove = value;
                if ( this.Map != null)
                {
                    if (this.IsModeMove)
                    { this.Map.FunctionMode = FunctionMode.Pan; }
                    if (this.IsModeZoom)
                    { this.Map.FunctionMode = FunctionMode.ZoomIn; }
                  
                }
                this.RaisePropertyChanged("IsModeMove");
                this.RaisePropertyChanged("IsModeZoom");
            }
        }
        public Boolean IsModeZoom
        {
            get { return !_isModeMove; }
            set {
                this.IsModeMove = !value;
            }
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
                if (arg.ContextMenu.Items.Count > 0)
                { arg.ContextMenu.Items.Clear(); }
            
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
                  
                    arg.ContextMenu.IsOpen = true;
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
                        arg.ContextMenu.Items.Add(new Separator ());
                        MenuItem menuItemRemoveFolder = new MenuItem();
                        menuItemRemoveFolder.Header = "Supprimer ce dossier";
                        menuItemRemoveFolder.Command = new DelegateCommand(new Action(delegate()
                        {
                            this.RemoveFolder(templateViewModel, arg.TreeView.SelectedItem as TemplateNodeFolderViewModel);
                        }));
                        arg.ContextMenu.Items.Add(menuItemRemoveFolder);
                        arg.ContextMenu.IsOpen = true;
                       
                    }
                    else if (arg.TreeView.SelectedItem is TemplateNodeLayerViewModel)
                    {
                        TemplateNodeLayerViewModel templateNodeLayerViewModel = (arg.TreeView.SelectedItem as TemplateNodeLayerViewModel);
                        MenuItem menuItemStyles = new MenuItem();
                        menuItemStyles.Header = "Styles";
                        arg.ContextMenu.Items.Add(menuItemStyles);


                     //   menuItemStyles.Items.Add(new Separator());

                        MenuItem menuItemAddStyle = new MenuItem();
                        menuItemAddStyle.Header = "Créer un style";
                        menuItemAddStyle.Command = new DelegateCommand(new Action(delegate() {
                            this.CreateStyle(templateNodeLayerViewModel);
                        }));
                        menuItemStyles.Items.Add(menuItemAddStyle);


                        arg.ContextMenu.Items.Add(new Separator());
                        MenuItem menuItemRemoveTable = new MenuItem();
                        menuItemRemoveTable.Header = "Supprimer cette table";
                        menuItemRemoveTable.Command = new DelegateCommand(new Action(delegate()
                        {
                            this.RemoveLayerMetier(templateViewModel, templateNodeLayerViewModel);
                        }));
                        arg.ContextMenu.Items.Add(menuItemRemoveTable);
                        arg.ContextMenu.IsOpen = true;
                    }
                }
            }
            else
            { arg.ContextMenuEventArgs.Handled = true;}
        }

        private void CreateStyle(TemplateNodeLayerViewModel templateNodeLayerViewModel)
        {
            StyleViewModel vm = new StyleViewModel();
            vm.DisplayName = "Nouveau style";
            IDialogService dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
            Window window =  dialogService.CreateDialog("CartoStyleRegion", "Création d'un style");
            window.DataContext = vm;
            Nullable<Boolean> result = window.ShowDialog();

        }

        private void RemoveFolder(TemplateViewModel templateViewModel, TemplateNodeFolderViewModel folder)
        {
            DbSet<SigNode> nodes = this.DataService.GetDbSet<SigNode>();
            List<TemplateNodeViewModel> nodeToRemoves = new List<TemplateNodeViewModel>();
            List<TemplateNodeViewModel> subNodes = (from n in folder.Nodes select n).ToList();

            TemplateNodeFolderViewModel parentFolder = null;
            foreach (TemplateNodeViewModel node in subNodes)
            {
                if (node is TemplateNodeLayerViewModel)
                {
                    RemoveLayerMetier(templateViewModel, (node as TemplateNodeLayerViewModel));
                }
                else if (node is TemplateNodeFolderViewModel)
                {

                    TemplateNodeFolderViewModel subFolder = (node as TemplateNodeFolderViewModel);
                    parentFolder = this.GetParentFolder(templateViewModel, templateViewModel.Nodes, subFolder);
                    nodes.Remove(subFolder.Model);
                    this.RemoveFolder(templateViewModel, subFolder);
                    if (parentFolder != null)
                    { parentFolder.Nodes.Remove(subFolder); }
                    else templateViewModel.Nodes.Remove(subFolder);
                    
                }

            }

            parentFolder = this.GetParentFolder(templateViewModel, templateViewModel.Nodes, folder);

            if (parentFolder != null)
            { parentFolder.Nodes.Remove(folder); }
            else templateViewModel.Nodes.Remove(folder);
            nodes.Remove(folder.Model);
            this.DataService.DataContext.SaveChanges();
        }

        private void RemoveLayerMetier(TemplateViewModel templateViewModel, TemplateNodeLayerViewModel templateNodeLayerViewModel)
        {
            DbSet<SigNode> nodes = this.DataService.GetDbSet<SigNode>();
            DbSet<SigLayer> layers = this.DataService.GetDbSet<SigLayer>();

            TemplateNodeFolderViewModel parentFolder = this.GetParentFolder(templateViewModel, templateViewModel.Nodes, templateNodeLayerViewModel);
            if (parentFolder != null)
            {parentFolder.Nodes.Remove(templateNodeLayerViewModel);}
            else
            {templateViewModel.Nodes.Remove(templateNodeLayerViewModel);}
            nodes.Remove(templateNodeLayerViewModel.Model);
            this.DataService.DataContext.Entry(templateNodeLayerViewModel.Model).Reload();
            if (templateNodeLayerViewModel.Model.SigLayerId.HasValue)
            {
                SigLayer layerToRemove = (from l in layers where l.Id == templateNodeLayerViewModel.Model.SigLayerId.Value select l).FirstOrDefault();
                if (layerToRemove != null)
                { layers.Remove(layerToRemove); }
            }
            
          
            this.DataService.DataContext.SaveChanges();


            List<SigNode> nodeMaps = (from n in nodes where n.SigTemplateId == templateViewModel.Id && n.SigLayer != null orderby n.SigLayer.MapOrder select n).ToList();
            int mapOrder = 0;
            foreach (SigNode nodeMap in nodeMaps)
            {
                nodeMap.SigLayer.MapOrder = mapOrder;
                mapOrder++;
            }
            this.DataService.DataContext.SaveChanges();

            int nodeOrder = 0;
            if (parentFolder != null)
            {
                foreach (TemplateNodeViewModel child in parentFolder.Nodes)
                {
                    child.Model.Order = nodeOrder;
                    nodeOrder++;
                }
            }
            else
            {
                foreach (TemplateNodeViewModel child in templateViewModel.Nodes)
                {
                    child.Model.Order = nodeOrder;
                    nodeOrder++;
                }
            }
            
            this.DataService.DataContext.SaveChanges();
            foreach (IMapLayer layer in templateNodeLayerViewModel.Layers)
            {this.Map.Layers.Remove(layer);}
        }

        public TemplateNodeFolderViewModel GetParentFolder(Object parent, ObservableCollection<TemplateNodeViewModel> list, TemplateNodeViewModel node)
        {
            if (list.Contains(node)) return parent as TemplateNodeFolderViewModel;
            else
            {
                foreach (TemplateNodeViewModel n in list)
                {
                    if (n is TemplateNodeFolderViewModel)
                    {
                        return GetParentFolder(n, (n as TemplateNodeFolderViewModel).Nodes, node);
                    }
                }
            }
            return null;
        }
        
        private Int64  GetNextMapOrder()
        {
            if (this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel)
            {
                TemplateViewModel templateViewModel = (this.TemplatesView.CurrentItem as TemplateViewModel);
                DbSet<SigNode> nodes = this.DataService.GetDbSet<SigNode>();
                Nullable<Int64> mapOrder = null;
                foreach (SigNode node in nodes)
                {
                    if (node.SigTemplateId == templateViewModel.Id && node.SigLayer != null)
                    {
                        if (mapOrder.HasValue == false || (mapOrder.HasValue == true && mapOrder.Value < node.SigLayer.MapOrder ))
                        {
                            mapOrder =  node.SigLayer.MapOrder;
                        }
                    }
                }
                if (!mapOrder.HasValue )
                {mapOrder = 0;}
                return mapOrder.Value;
            }
            return 0;
        }
        private void AddLayerMetier(TemplateViewModel templateViewModel, TemplateNodeFolderViewModel parentFolder, EntityTableInfo tableInfo)
        {
            long nextMapOrder = this.GetNextMapOrder();
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
            layer.MapOrder = nextMapOrder;
            layer.EntityName = tableInfo.EntityType.Name;
            layer.SigCodeLayer = (from c in codeLayers where c.Code.Equals("Geocodage") select c).FirstOrDefault();
            layers.Add(layer);           
            this.DataService.DataContext.SaveChanges();
            nodeLayerMetier.SigLayer = layer;
            nodes.Add(nodeLayerMetier);
            this.DataService.DataContext.SaveChanges();
            nodeLayerMetier.SigLayer = layer;
            nodeLayerMetier.SigLayerId = layer.Id;
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
            this.RaisePropertyChanged("TemplateVisibility");
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
                if (layersNode.Envelope != null)
                { env.ExpandToInclude(layersNode.Envelope); }

                foreach (IMapLayer mapLayer in layersNode.Layers)
                {
                    this.Map.Layers.Add(mapLayer);
                  
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
