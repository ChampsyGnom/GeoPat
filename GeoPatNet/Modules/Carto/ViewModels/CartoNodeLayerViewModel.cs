using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;
using DotSpatial.Controls;
using Emash.GeoPatNet.Modules.Carto.Layers;
using DotSpatial.Projections;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using DotSpatial.Data;
using DotSpatial.Topology;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public abstract class CartoNodeLayerViewModel : CartoNodeViewModel
    {
        public DotSpatial.Controls.Map Map { get; set; }
        public List< IMapLayer> Layers { get;private  set; }


        public abstract void CreateLayer(DotSpatial.Controls.Map map);
       
              
        
        /*
         public FeatureSet(DataTable wkbTable, int wkbColumnIndex, bool indexed, FeatureType type)
            : this()
        {
            if (IndexMode)
            {
                // Assume this DataTable has WKB in column[0] and the rest of the columns are attributes.
                FeatureSetPack result = new FeatureSetPack();
                foreach (DataRow row in wkbTable.Rows)
                {
                    byte[] data = (byte[])row[0];
                    MemoryStream ms = new MemoryStream(data);
                    WkbFeatureReader.ReadFeature(ms, result);
                }

                // convert lists of arrays into a single vertex array for each shape type.
                result.StopEditing();

                // Make sure all the same columns exist in the same order
                result.Polygons.CopyTableSchema(wkbTable);

                // Assume that all the features happened to be polygons
                foreach (DataRow row in wkbTable.Rows)
                {
                    // Create a new row
                    DataRow dest = result.Polygons.DataTable.NewRow();
                    dest.ItemArray = row.ItemArray;
                }
            }
        }
         * */
        private Boolean _isChecked = true;

        public Boolean IsChecked
        {
            get { return _isChecked; }
            set 
            { 
                _isChecked = value;
                if (this.Map != null && this.Layers != null)
                {
                    this.Map.MapFrame.SuspendEvents();
                    foreach (IMapLayer layer in this.Layers)
                    {
                        if (_isChecked && !this.Map.Layers.Contains(layer))
                        { this.Map.Layers.Add(layer); }
                        else if (!_isChecked && this.Map.Layers.Contains(layer))
                        { this.Map.Layers.Remove(layer); }
                    }
                   
                    this.Map.MapFrame.ResumeEvents();
                }
               
                this.RaisePropertyChanged("IsChecked");
                
                
            }
        }
        public CartoNodeLayerViewModel(SigNode model)
            : base(model)
        {
            this.Layers = new List<IMapLayer>();
        }
    }
}
