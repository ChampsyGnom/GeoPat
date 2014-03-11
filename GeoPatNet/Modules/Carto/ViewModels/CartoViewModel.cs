using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Extensions;
using Emash.GeoPatNet.Data.Models;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Data;
using System.Windows.Threading;
using System.Data.Entity;
using DotSpatial.Controls;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Modules.Carto.Adapters;
using Emash.GeoPatNet.Infrastructure.Behaviors;
using System.Windows;
using System.Windows.Controls;
using DotSpatial.Projections;
using System.ComponentModel;
using Emash.GeoPatNet.Modules.Carto.Layers;
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
        public Map Map { get;  set; }
      
        public ListCollectionView TemplatesView { get; private set; }
        public ObservableCollection<TemplateViewModel> Templates { get; private set; }
        public DelegateCommand CreateTemplateCommand { get; private set; }
        public DelegateCommand EditTemplateCommand { get; private set; }
        public DelegateCommand PublishTemplateCommand { get; private set; }
        public DelegateCommand DeleteTemplateCommand { get; private set; }

        public DelegateCommand<TreeViewContextMenuOpeningBehaviorEventArg> TreeViewContextMenuOpeningCommand { get; private set; }

        public IDataService DataService { get; private set; }
        public IEngineService EngineService { get; private set; }
        public Dispatcher Dispatcher { get; private set; }

        private Boolean _isModeZoom;
        private Boolean _isModeMove;


        public Boolean IsModeMove
        {
            get { return _isModeMove; }
            set { 
                _isModeMove = value;
                if (_isModeMove)
                {
                    _isModeZoom = false;
                    this.Map.FunctionMode = FunctionMode.Pan;
                }               
                this.RaisePropertyChanged("IsModeMove");
                this.RaisePropertyChanged("IsModeZoom"); 
            }
        }


        public Boolean IsModeZoom
        {
            get { return _isModeZoom; }
            set 
            { 
                _isModeZoom = value;
                if (_isModeZoom)
                {
                    _isModeMove = false;
                    this.Map.FunctionMode = FunctionMode.ZoomIn;
                }    
                this.RaisePropertyChanged("IsModeZoom");
                this.RaisePropertyChanged("IsModeMove");
            }
        }

     
        public CartoViewModel(IDataService dataService,IEngineService engineService)
        {
          
            this.DataService = dataService;
            this.Dispatcher = System.Windows.Application.Current.Dispatcher;
            this.EngineService = engineService;
            this._isModeMove = true;
            this._isModeZoom = false;
            this.Templates = new ObservableCollection<TemplateViewModel>();
            this.TemplatesView = new ListCollectionView(this.Templates);
            DbSet<SigTemplate> set = this.DataService.GetDbSet<SigTemplate>();
            foreach (SigTemplate tpl in set)
            {
                TemplateViewModel vm = new TemplateViewModel(tpl);
                this.Templates.Add(vm);
                    
            }
            foreach (TemplateViewModel vm in this.Templates)
            {
                DbSet<SigNode> setNodes = this.DataService.GetDbSet<SigNode>();
                List<SigNode> templateNodes = (from n in setNodes where n.SigTemplateId == vm.Model.Id select n).ToList();
                this.RecurseBuildTemplateNodes(-1, vm.Nodes, templateNodes);
            }
            this.CreateTemplateCommand = new DelegateCommand(CreateTemplateExecute);
            this.EditTemplateCommand = new DelegateCommand(EditTemplateExecute,CanEditTemplate );
            this.DeleteTemplateCommand = new DelegateCommand(DeleteTemplateExecute, CanDeleteTemplate);
            this.PublishTemplateCommand = new DelegateCommand(PublishTemplateExecute, CanPublishTemplate);           
            this.TemplatesView.CurrentChanged += TemplatesView_CurrentChanged;           
            this.TreeViewContextMenuOpeningCommand = new DelegateCommand<TreeViewContextMenuOpeningBehaviorEventArg>(OnTreeViewContextMenuOpening);
        }
        private void OnTreeViewContextMenuOpening(TreeViewContextMenuOpeningBehaviorEventArg arg)
        {
            CartoNodeViewModel contexMenuData = null;
            if (arg.ContextMenuEventArgs.OriginalSource != null && arg.ContextMenuEventArgs.OriginalSource is DependencyObject)
            {
                DependencyObject originalSourceDependencyObject = (arg.ContextMenuEventArgs.OriginalSource as DependencyObject);
                TreeViewItem treeViewItem =   originalSourceDependencyObject.FindParentControl<TreeViewItem>();
                if (treeViewItem != null)
                {
                    if (treeViewItem.DataContext != null && treeViewItem.DataContext is CartoNodeViewModel)
                    { contexMenuData = (treeViewItem.DataContext as CartoNodeViewModel); }                    
                }
            }
            arg.ContextMenu.Items.Clear();
            if (contexMenuData == null)
            {
                MenuItem itemAddFolder = new MenuItem();
                itemAddFolder.Header = "Ajouter un dossier";
                itemAddFolder.Command = new DelegateCommand(new Action(delegate() { AddFolderExecute(contexMenuData); }));
                arg.ContextMenu.Items.Add(itemAddFolder);

                MenuItem itemAddLayers = new MenuItem();
                itemAddLayers.Header = "Ajouter une couche";
                arg.ContextMenu.Items.Add(itemAddLayers);

                MenuItem itemAddLayersWebs = new MenuItem();
                itemAddLayersWebs.Header = "Web";
                itemAddLayers.Items.Add(itemAddLayersWebs);

                MenuItem itemAddLayerWebOsm = new MenuItem();
                itemAddLayerWebOsm.Header = "Open Street Map";
                itemAddLayerWebOsm.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData,"Osm"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebOsm);
              
                MenuItem itemAddLayerWebGoogleMap = new MenuItem();
                itemAddLayerWebGoogleMap.Header = "Google Map";
                itemAddLayerWebGoogleMap.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "GoogleMap"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebGoogleMap);

                MenuItem itemAddLayerWebGoogleSatelite = new MenuItem();
                itemAddLayerWebGoogleSatelite.Header = "Google Satelite";
                itemAddLayerWebGoogleSatelite.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "GoogleSatelite"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebGoogleSatelite);

                MenuItem itemAddLayerWebGoogleTerrain= new MenuItem();
                itemAddLayerWebGoogleTerrain.Header = "Google Terrain";
                itemAddLayerWebGoogleTerrain.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "GoogleTerrain"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebGoogleTerrain);

                MenuItem itemAddLayerWebBingRoad = new MenuItem();
                itemAddLayerWebBingRoad.Header = "Bing Road";
                itemAddLayerWebBingRoad.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "BingRoad"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebBingRoad);

                MenuItem itemAddLayerWebBingHybrid = new MenuItem();
                itemAddLayerWebBingHybrid.Header = "Bing Hybride";
                itemAddLayerWebBingHybrid.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "BingHybrid"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebBingHybrid);

                MenuItem itemAddLayerWebBingAerial = new MenuItem();
                itemAddLayerWebBingAerial.Header = "Bing Aérien";
                itemAddLayerWebBingAerial.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "BingAerial"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebBingAerial);




                MenuItem itemAddLayersMetiers = new MenuItem();
                itemAddLayersMetiers.Header = "Metier";
                itemAddLayers.Items.Add(itemAddLayersMetiers);


                foreach (EntitySchemaInfo schemaInfo in this.DataService.SchemaInfos)
                {
                    foreach (EntityTableInfo tableInfo in schemaInfo.TableInfos)
                    {
                        if (FeatureSetAdapter.CanAdapt(DataService.GetDbSet(tableInfo.EntityType)))
                        {
                            MenuItem itemAddLayerMetier = new MenuItem();
                            itemAddLayerMetier.Header = tableInfo.DisplayName;
                            itemAddLayerMetier.Command = new DelegateCommand(new Action(delegate() { AddLayerMetierExecute(contexMenuData, tableInfo); }));
                            itemAddLayersMetiers.Items.Add(itemAddLayerMetier);
                        }
                    }
                }

            }
            else if (contexMenuData is CartoNodeFolderViewModel )
            {
                MenuItem itemAddFolder = new MenuItem();
                itemAddFolder.Header = "Ajouter un dossier";
                itemAddFolder.Command = new DelegateCommand(new Action(delegate() { AddFolderExecute(contexMenuData); }));
                arg.ContextMenu.Items.Add(itemAddFolder);

                MenuItem itemAddLayers = new MenuItem();
                itemAddLayers.Header = "Ajouter une couche";
                arg.ContextMenu.Items.Add(itemAddLayers);

                MenuItem itemAddLayersWebs = new MenuItem();
                itemAddLayersWebs.Header = "Web";
                itemAddLayers.Items.Add(itemAddLayersWebs);

                MenuItem itemAddLayerWebOsm = new MenuItem();
                itemAddLayerWebOsm.Header = "Open Street Map";
                itemAddLayerWebOsm.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "Osm"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebOsm);

                MenuItem itemAddLayerWebGoogleMap = new MenuItem();
                itemAddLayerWebGoogleMap.Header = "Google Map";
                itemAddLayerWebGoogleMap.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "GoogleMap"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebGoogleMap);

                MenuItem itemAddLayerWebGoogleSatelite = new MenuItem();
                itemAddLayerWebGoogleSatelite.Header = "Google Satelite";
                itemAddLayerWebGoogleSatelite.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "GoogleSatelite"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebGoogleSatelite);

                MenuItem itemAddLayerWebGoogleTerrain = new MenuItem();
                itemAddLayerWebGoogleTerrain.Header = "Google Terrain";
                itemAddLayerWebGoogleTerrain.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "GoogleTerrain"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebGoogleTerrain);

                MenuItem itemAddLayerWebBingRoad = new MenuItem();
                itemAddLayerWebBingRoad.Header = "Bing Road";
                itemAddLayerWebBingRoad.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "BingRoad"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebBingRoad);

                MenuItem itemAddLayerWebBingHybrid = new MenuItem();
                itemAddLayerWebBingHybrid.Header = "Bing Hybride";
                itemAddLayerWebBingHybrid.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "BingHybrid"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebBingHybrid);

                MenuItem itemAddLayerWebBingAerial = new MenuItem();
                itemAddLayerWebBingAerial.Header = "Bing Aérien";
                itemAddLayerWebBingAerial.Command = new DelegateCommand(new Action(delegate() { AddLayerWebExecute(contexMenuData, "BingAerial"); }));
                itemAddLayersWebs.Items.Add(itemAddLayerWebBingAerial);




                MenuItem itemAddLayersMetiers = new MenuItem();
                itemAddLayersMetiers.Header = "Metier";
                itemAddLayers.Items.Add(itemAddLayersMetiers);


                foreach (EntitySchemaInfo schemaInfo in this.DataService.SchemaInfos)
                {
                    foreach (EntityTableInfo tableInfo in schemaInfo.TableInfos)
                    {

                        if (FeatureSetAdapter.CanAdapt(DataService.GetDbSet(tableInfo.EntityType)))
                        {
                            MenuItem itemAddLayerMetier = new MenuItem();
                            itemAddLayerMetier.Header = tableInfo.DisplayName;
                            itemAddLayerMetier.Command = new DelegateCommand(new Action(delegate() { AddLayerMetierExecute(contexMenuData, tableInfo); }));
                            itemAddLayersMetiers.Items.Add(itemAddLayerMetier);
                        }
                       

                    }
                }
                arg.ContextMenu.Items.Add(new Separator());
                MenuItem itemRemoveFolder = new MenuItem();
                itemRemoveFolder.Header = "Supprimer ce dossier";
                itemRemoveFolder.Command = new DelegateCommand(new Action(delegate() { RemoveFolderExecute(contexMenuData); }));
                arg.ContextMenu.Items.Add(itemRemoveFolder);

            }
            else if (contexMenuData is CartoNodeLayerViewModel )
            {                
                MenuItem itemRemoveLayer = new MenuItem();
                itemRemoveLayer.Header = "Supprimer cete couche";
                itemRemoveLayer.Command = new DelegateCommand(new Action(delegate() { RemoveLayerExecute(contexMenuData); }));
                arg.ContextMenu.Items.Add(itemRemoveLayer);
            }
            Console.WriteLine ( arg.ContextMenuEventArgs.Source +" --> "+arg.ContextMenuEventArgs.OriginalSource.ToString ());
           
        }

        private void CreateCodeLayerIfNeeded( string codeLayerValue)
        {
             DbSet<SigCodeLayer> codeLayers = this.DataService.GetDbSet<SigCodeLayer>();
            if ((from c in codeLayers where c.Code.Equals(codeLayerValue) select c).Any() == false)
            {
                SigCodeLayer codeLayerGoogle = new SigCodeLayer();
                codeLayerGoogle.Code = codeLayerValue;
                codeLayerGoogle.Libelle = codeLayerValue;
                codeLayers.Add(codeLayerGoogle);
                this.DataService.DataContext.SaveChanges();
            }
        }

        private void AddLayerMetierExecute(CartoNodeViewModel contexMenuData, EntityTableInfo tableInfo)
        {
            DbSet<SigCodeLayer> codeLayers = this.DataService.GetDbSet<SigCodeLayer>();
            DbSet<SigCodeNode> codeNodes = this.DataService.GetDbSet<SigCodeNode>();
            DbSet<SigLayer> layers = this.DataService.GetDbSet<SigLayer>();
            DbSet<SigNode> nodes = this.DataService.GetDbSet<SigNode>();


            string layerCode = "@Entity@" + tableInfo.EntityType.Name;
            this.CreateCodeLayerIfNeeded(layerCode);
            SigLayer layer = new SigLayer ();
            layer.Libelle = tableInfo.DisplayName;
            layer.SigCodeLayer = (from c in codeLayers where c.Code.Equals (layerCode) select c).FirstOrDefault();
            layers.Add(layer);
            this.DataService.DataContext.SaveChanges();

            SigNode node = new SigNode();
            node.SigTemplate = (this.TemplatesView.CurrentItem as TemplateViewModel).Model;
            node.SigCodeNode = (from c in codeNodes where c.Code.Equals("Layer") select c).FirstOrDefault();
            node.SigLayer = layer;

            ObservableCollection<CartoNodeViewModel> parentNodes = null;
            if (contexMenuData != null && contexMenuData is CartoNodeFolderViewModel)
            {
                parentNodes = (contexMenuData as CartoNodeFolderViewModel).Nodes;
                node.ParentId = (contexMenuData as CartoNodeFolderViewModel).Model.Id;
            }
            else
            {
                node.ParentId = -1;
                parentNodes = (this.TemplatesView.CurrentItem as TemplateViewModel).Nodes;
            }
           
            node.Libelle = tableInfo.DisplayName;
            nodes.Add(node);
            this.DataService.DataContext.SaveChanges();
            CartoNodeLayerViewModel vm = new CartoNodeLayerMetierViewModel(node);
            parentNodes.Add(vm);
            if (contexMenuData != null && contexMenuData is CartoNodeFolderViewModel)
            {(contexMenuData as CartoNodeFolderViewModel).IsExpanded = true;}            
            this.FixNodeOrder(parentNodes);
            this.LoadMap();
        }
        public void RemoveFolderExecute(Object obj)
        {
            if (obj != null && obj is CartoNodeFolderViewModel)
            {
                CartoNodeFolderViewModel cartoNodeFolderViewModel = obj as CartoNodeFolderViewModel;
                List<SigNode> allFolderNodes = new List<SigNode>();
                this.RecurseFindFolderNode(allFolderNodes, cartoNodeFolderViewModel);
                DbSet<SigNode> setNodes = this.DataService.GetDbSet<SigNode>();
                foreach (SigNode node in allFolderNodes)
                { setNodes.Remove(node);  }
                this.DataService.DataContext.SaveChanges();
                if (this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel )
                {
                    TemplateViewModel templateViewModel = this.TemplatesView.CurrentItem as TemplateViewModel;
                    CartoNodeFolderViewModel parentFolder = this.RecurseFindParentFolder(cartoNodeFolderViewModel,null, templateViewModel.Nodes);
                    if (parentFolder != null)
                    {
                        parentFolder.Nodes.Remove(cartoNodeFolderViewModel);
                        this.FixNodeOrder(parentFolder.Nodes);
                    }
                    else
                    {
                        templateViewModel.Nodes.Remove(cartoNodeFolderViewModel);
                        this.FixNodeOrder(templateViewModel.Nodes);
                    }
                    this.LoadMap();
                }                
            }
        }

        private CartoNodeFolderViewModel RecurseFindParentFolder(CartoNodeViewModel child,CartoNodeFolderViewModel parent, ObservableCollection<CartoNodeViewModel> items)
        {
            foreach (CartoNodeViewModel item in items)
            {
                if (item.Equals(child))
                { return parent; }
                else if (item is CartoNodeFolderViewModel)
                {
                    return RecurseFindParentFolder(child, (item as CartoNodeFolderViewModel), (item as CartoNodeFolderViewModel).Nodes);
                }
            }
            return null;
        }

        private void RecurseFindFolderNode(List<SigNode> allFolderNodes, CartoNodeFolderViewModel cartoNodeFolderViewModel)
        {
            allFolderNodes.Add(cartoNodeFolderViewModel.Model);
            foreach (CartoNodeViewModel vm in cartoNodeFolderViewModel.Nodes)
            { 
                if (vm is CartoNodeFolderViewModel )
                {
                    CartoNodeFolderViewModel subFolder = (vm as CartoNodeFolderViewModel);
                    RecurseFindFolderNode(allFolderNodes, subFolder);
                }
                else
                {
                    allFolderNodes.Add(vm.Model);
                }
            }
        }
        public void AddLayerWebExecute(Object parent,String codeLayer)
        {
            TemplateViewModel tpl = this.TemplatesView.CurrentItem as TemplateViewModel;
            DbSet<SigCodeNode> codeNodes = this.DataService.GetDbSet<SigCodeNode>();
            DbSet<SigCodeLayer> codeLayers = this.DataService.GetDbSet<SigCodeLayer>();

            DbSet<SigLayer> layers = this.DataService.GetDbSet<SigLayer>();


            SigNode node = new SigNode();
            if (parent != null && parent is CartoNodeFolderViewModel)
            { node.ParentId = (parent as CartoNodeFolderViewModel).Model.Id; }
            else { node.ParentId = -1; }
            node.Libelle = codeLayer;
            node.SigCodeNode = (from c in codeNodes where c.Code.Equals("Layer") select c).FirstOrDefault();
            node.SigLayer = null;
            node.SigTemplateId = tpl.Model.Id;
            SigNode addedNode = this.EngineService.ShowAddDialog<SigNode>(node, new String[] { "Libelle" });
            if (addedNode != null)
            {
                SigLayer layer = new SigLayer();
                layer.Libelle = codeLayer;
                layer.MapOrder = 0;
                layer.SigCodeLayer = (from c in codeLayers where c.Code.Equals(codeLayer) select c).FirstOrDefault();
                layers.Add(layer);
                this.DataService.DataContext.SaveChanges();
                addedNode.SigLayer = layer;
                if (parent != null && parent is CartoNodeFolderViewModel)
                { addedNode.ParentId = (parent as CartoNodeFolderViewModel).Model.Id; }
                else
                { addedNode.ParentId = -1; }
                this.DataService.DataContext.SaveChanges();
                CartoNodeLayerViewModel vm = new CartoNodeLayerWebViewModel(addedNode,this.Map );               
                if (parent != null && parent is CartoNodeFolderViewModel)
                {
                    (parent as CartoNodeFolderViewModel).Nodes.Add(vm);
                    (parent as CartoNodeFolderViewModel).IsExpanded = true;
                }
                else
                {
                    (this.TemplatesView.CurrentItem as TemplateViewModel).Nodes.Add(vm);
                }
            }
            this.LoadMap();
        }
        void TemplatesView_CurrentChanged(object sender, EventArgs e)
        {
            this.EditTemplateCommand.RaiseCanExecuteChanged();
            this.DeleteTemplateCommand.RaiseCanExecuteChanged();
            this.PublishTemplateCommand.RaiseCanExecuteChanged();
            this.LoadMap();
        }

        private void LoadMap()
        {
            this.Map.Layers.Clear();
            this.Map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
            if (this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel )
            {
                TemplateViewModel templateViewModel = (this.TemplatesView.CurrentItem as TemplateViewModel );
                List<CartoNodeLayerViewModel> layers = new List<CartoNodeLayerViewModel>();
                this.RecurseGetLayers(layers, templateViewModel.Nodes);
                this.Map.MapFrame.SuspendEvents();
              
                foreach (CartoNodeLayerViewModel layerVm in layers)
                {
                    foreach (IMapLayer layer in layerVm.LayerGroup)
                    {
                        this.Map.Layers.Remove(layer);
                    
                       
                       
                        
                    }
                    layerVm.LayerGroup.Load();
                    foreach (IMapLayer layer in layerVm.LayerGroup)
                    {
                        
                        this.Map.Layers.Add(layer);


                    }

                }
                Console.WriteLine("Nombre de layer " + this.Map.Layers.Count);                
                this.Map.MapFrame.ResumeEvents();
                this.Map.Refresh();
            }
            
        }

        private void RecurseGetLayers(List<CartoNodeLayerViewModel> layers, ObservableCollection<CartoNodeViewModel> list)
        {
            foreach (CartoNodeViewModel n in list)
            {
                if (n is CartoNodeFolderViewModel)
                {
                    RecurseGetLayers(layers, (n as CartoNodeFolderViewModel).Nodes);
                }
                if (n is CartoNodeLayerViewModel)
                {
                    layers.Add((n as CartoNodeLayerViewModel));
                }
            }
        }
        private void RemoveLayerExecute(Object obj)        
        {
            if (obj != null && obj is CartoNodeLayerViewModel)
            {
                CartoNodeLayerViewModel layerNode = (obj as CartoNodeLayerViewModel);
                this.DataService.GetDbSet<SigNode>().Remove(layerNode.Model);
                this.DataService.DataContext.SaveChanges();
                CartoNodeFolderViewModel parentFolder=   this.RecurseFindParentFolder(layerNode,null,(this.TemplatesView.CurrentItem as TemplateViewModel ).Nodes);
                if (parentFolder == null)
                {
                    (this.TemplatesView.CurrentItem as TemplateViewModel).Nodes.Remove(layerNode);
                    this.FixNodeOrder((this.TemplatesView.CurrentItem as TemplateViewModel).Nodes);
                }
                else
                { 
                    parentFolder.Nodes.Remove(layerNode);
                    this.FixNodeOrder(parentFolder.Nodes);
                }
            }
            this.LoadMap();
        }

        private void RecurseBuildTemplateNodes(long parentId, ObservableCollection<CartoNodeViewModel> parent, List<SigNode> allNodes)
        {
            List<SigNode> nodes = (from n in allNodes where n.ParentId == parentId orderby n.Order select n).ToList();
            foreach (SigNode node in nodes)
            {
                if (node.SigCodeNode.Code.Equals("Folder"))
                {
                    CartoNodeFolderViewModel vm = new CartoNodeFolderViewModel(node);    
                    parent.Add(vm);
                    this.RecurseBuildTemplateNodes(node.Id, vm.Nodes, allNodes);

                }
                if (node.SigCodeNode.Code.Equals("Layer"))
                {
                    if (node.SigLayer.SigCodeLayer.Code.StartsWith("@Entity@"))
                    {
                        CartoNodeLayerViewModel vm = new CartoNodeLayerMetierViewModel(node);
                       
                        parent.Add(vm);
                    }
                    else
                    {
                        CartoNodeLayerViewModel vm = new CartoNodeLayerWebViewModel(node, this.Map);
                       
                        parent.Add(vm);
                    }
                   
                }

            }
        }


        public void AddFolderExecute(CartoNodeViewModel parent)
        {
            TemplateViewModel tpl = this.TemplatesView.CurrentItem as TemplateViewModel;
            DbSet<SigCodeNode> codeNodes = this.DataService.GetDbSet<SigCodeNode>();
            SigNode node = new SigNode();

            ObservableCollection<CartoNodeViewModel> parentNodes = null;           
            if (parent != null && parent is CartoNodeFolderViewModel)
            {
                parentNodes = (parent as CartoNodeFolderViewModel).Nodes;
                node.ParentId = (parent as CartoNodeFolderViewModel).Model.Id;             
            }
            else 
            {
                node.ParentId = -1;
                parentNodes = (this.TemplatesView.CurrentItem as TemplateViewModel).Nodes;              
            }
            node.Order = (from i in parentNodes select i).Count() + 1;
            node.Libelle = "Nouveau dossier";
            node.SigCodeNode = (from c in codeNodes where c.Code.Equals("Folder") select c).FirstOrDefault();
            node.SigLayer = null;
            node.SigTemplateId = tpl.Model.Id;
            
            SigNode addedNode =  this.EngineService.ShowAddDialog<SigNode>(node,new String[] {"Libelle"});
            if (addedNode != null)
            {
                CartoNodeFolderViewModel vm = new CartoNodeFolderViewModel(addedNode);
                parentNodes.Add(vm);
                if (parent != null && parent is CartoNodeFolderViewModel)
                {(parent as CartoNodeFolderViewModel).IsExpanded = true; }
                this.FixNodeOrder(parentNodes);
                
            }
           
        }
        private void FixNodeOrder(ObservableCollection<CartoNodeViewModel> nodes)
        {
            List<CartoNodeViewModel> orderedNodes = (from n in nodes orderby n.Model.Order select n).ToList();
            for (int i = 0; i < orderedNodes.Count; i++)
            {orderedNodes[i].Model.Order = i; }
            this.DataService.DataContext.SaveChanges();
        }
        private void PublishTemplateExecute()
        {

        }

        private Boolean CanPublishTemplate()
        {
            return this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel;
        }


        private void DeleteTemplateExecute()
        {
            TemplateViewModel tpl = this.TemplatesView.CurrentItem as TemplateViewModel;
            DbSet<SigTemplate> set = this.DataService.GetDbSet<SigTemplate>();
            set.Remove(tpl.Model);
            this.DataService.DataContext.SaveChanges();
            this.Templates.Remove(tpl);
        }

        private Boolean CanDeleteTemplate()
        {
            return this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel;
        }

       

      

       

        private Boolean CanEditTemplate()
        {
            return this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel;
        }
        private void EditTemplateExecute()
        {
            TemplateViewModel tpl = this.TemplatesView.CurrentItem as TemplateViewModel;
            SigTemplate template = this.EngineService.ShowEditDialog<SigTemplate>(tpl.Model);
            if (template != null)
            {
               
                tpl.SetModel(template);
               
               
            }
            else 
            {
                Console.WriteLine("pas oki");
            }
        }
        private void CreateTemplateExecute()
        {
            SigTemplate template = this.EngineService.ShowAddDialog<SigTemplate>();
            if (template != null)
            {
                    TemplateViewModel vm = new TemplateViewModel(template);
                    this.Templates.Add(vm);
                    this.TemplatesView.MoveCurrentTo(vm);
               
              
            }
            else
            {
                Console.WriteLine("pas oki");
            }
            /*
            DbSet<SigTemplate> set = this.DataService.GetDbSet<SigTemplate>();
             DbSet<SigCodeTemplate> setCode = this.DataService.GetDbSet<SigCodeTemplate>();
            SigTemplate template = new SigTemplate();
            template.Libelle = "Nouveau modèle";
            template.SigCodeTemplate = (from i in setCode where i.Code.Equals ("Detail") select i).FirstOrDefault();
            set.Add(template);
            this.DataService.DataContext.SaveChanges();
            TemplateViewModel vm = new TemplateViewModel(template);
            this.Templates.Add(vm);
            this.TemplatesView.MoveCurrentTo(vm);
             * */
        }

        public String DisplayName 
        {
            
            get
            {
                return "Carte";
            }
            
        }
    }
}
