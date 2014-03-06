using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BruTile;
using BruTile.Cache;
using BruTile.Web;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Projections;
using DotSpatial.Symbology;
using DotSpatial.Topology;
using Extent = DotSpatial.Data.Extent;

namespace Emash.GeoPatNet.Modules.Carto.Layers
{
    [Serializable]
    public class BruTileLayer : IMapLayer
    {
        /// <summary>
        /// Creates a Bing Maps Roads layer using the "Staging" url
        /// </summary>
        public static BruTileLayer CreateBingRoadsLayer()
        {
            return CreateBingRoadsLayer(String.Empty);
        }

        /// <summary>
        /// Creates a Bing Maps Roads layer using the standard url. You need to have a valid token
        /// </summary>
        /// <param name="token">The token for Bing Maps access</param>
        public static BruTileLayer CreateBingRoadsLayer(string token)
        {
            string url = string.IsNullOrWhiteSpace(token)
                             ? BingRequest.UrlBingStaging
                             : BingRequest.UrlBing;

            return new BruTileLayer(
                new BingTileSource(new BingRequest(url, "", BingMapType.Roads)),
                new MemoryCache<byte[]>(100, 200));
        }

        /// <summary>
        /// Creates a Bing Maps hybird layer using the "Staging" url
        /// </summary>
        public static BruTileLayer CreateBingHybridLayer()
        {
            return CreateBingHybridLayer(String.Empty);
        }
        /// <summary>
        /// Creates a Bing Maps hybrid layer using the standard url. You need to have a valid token
        /// </summary>
        /// <param name="token">The token for Bing Maps access</param>
        public static BruTileLayer CreateBingHybridLayer(string token)
        {
            string url = string.IsNullOrWhiteSpace(token)
                             ? BingRequest.UrlBingStaging
                             : BingRequest.UrlBing;

            return new BruTileLayer(
                new BingTileSource(new BingRequest(url, "", BingMapType.Hybrid)),
                new MemoryCache<byte[]>(100, 200));
        }

        /// <summary>
        /// Creates a Bing Maps aerial layer using the "Staging" url
        /// </summary>
        public static BruTileLayer CreateBingAerialLayer()
        {
            return CreateBingAerialLayer(String.Empty);
        }

        /// <summary>
        /// Creates a Bing Maps aerial layer using the standard url. You need to have a valid token
        /// </summary>
        /// <param name="token">The token for Bing Maps access</param>
        public static BruTileLayer CreateBingAerialLayer(string token)
        {
            string url = string.IsNullOrWhiteSpace(token)
                             ? BingRequest.UrlBingStaging
                             : BingRequest.UrlBing;

            return new BruTileLayer(
                new BingTileSource(new BingRequest(url, "", BingMapType.Aerial)),
                new MemoryCache<byte[]>(100, 200));
        }


        public static BruTileLayer CreateOsmLayer()
        {
            return new BruTileLayer(new OsmTileSource(), new MemoryCache<byte[]>(100, 200));
        }

        public static BruTileLayer CreateGoogleMapLayer()
        {
            return new BruTileLayer(new GoogleTileSource(GoogleMapType.GoogleMap), new MemoryCache<byte[]>(100, 200));
        }

        public static BruTileLayer CreateGoogleSatelliteLayer()
        {
            return new BruTileLayer(new GoogleTileSource(GoogleMapType.GoogleSatellite), new MemoryCache<byte[]>(100, 200));
        }
        public static BruTileLayer CreateGoogleTerrainLayer()
        {
            return new BruTileLayer(new GoogleTileSource(GoogleMapType.GoogleTerrain), new MemoryCache<byte[]>(100, 200));
        }

        public ITileSource TileSource { get; private set; }
        public ITileCache<byte[]> TileCache { get; private set; }
        public bool ShowErrorInTile = true;

        /// <summary>
        /// Creates an instance of this class with an OpenStreetMap tile source and
        /// a MemoryCache.
        /// </summary>
        public BruTileLayer()
            : this(new OsmTileSource(), new MemoryCache<byte[]>(100, 200))
        {
        }

        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        /// <param name="tileSource">The tile source to use</param>
        /// <param name="tileCache">The tile cache to use</param>
        public BruTileLayer(ITileSource tileSource, ITileCache<byte[]> tileCache)
        {
            TileSource = tileSource;
            TileCache = tileCache;
            int epsgCode;
            if (int.TryParse(TileSource.Schema.Srs.Substring(5), out epsgCode))
            {
                _projection = new ProjectionInfo();
                _projection = ProjectionInfo.FromEpsgCode(epsgCode);
            }
            else
                _projection = KnownCoordinateSystems.Projected.World.WebMercator;
            LegendItemVisible = true;

        }

        /// <summary>
        /// Tests this object against the comparison object.  If any of the 
        /// value type members are different, or if any of the properties
        /// are IMatchable and do not match, then this returns false.
        /// </summary>
        /// <param name="other">The other IMatcheable object of the same type</param>
        /// <param name="mismatchedProperties">The list of property names that do not match</param>
        /// <returns>Boolean, true if the properties are comparably equal.</returns>
        public bool Matches(IMatchable other, out List<string> mismatchedProperties)
        {
            var matches = true;

            mismatchedProperties = new List<string>();
            var otherBruTileLayer = other as BruTileLayer;
            if (otherBruTileLayer == null)
            {
                AddAllProperties(mismatchedProperties);
                return false;
            }

            if (!ReferenceEquals(TileSource, otherBruTileLayer.TileSource))
            {
                mismatchedProperties.Add("TileSource");
                matches = false;
            }

            if (!ReferenceEquals(TileCache, otherBruTileLayer.TileCache))
            {
                mismatchedProperties.Add("TileCache");
                matches = false;
            }

            if (ShowErrorInTile != otherBruTileLayer.ShowErrorInTile)
            {
                mismatchedProperties.Add("ShowErrorInTile");
                matches = false;
            }

            return matches;
        }

        private static void AddAllProperties(List<string> properties)
        {
            properties.AddRange(new[] { "TileSource", "TileCache", "ShowErrorsInTile" });
        }

        /// <summary>
        /// This method will set the values for this class with random values that are
        /// within acceptable parameters for this class.
        /// </summary>
        /// <param name="generator">An existing random number generator so that the random seed can be controlled</param>
        public void Randomize(Random generator)
        {
        }

        /// <summary>
        /// Erstellt ein neues Objekt, das eine Kopie der aktuellen Instanz darstellt.
        /// </summary>
        /// <returns>
        /// Ein neues Objekt, das eine Kopie dieser Instanz darstellt.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public object Clone()
        {
            return new BruTileLayer(TileSource, TileCache) { ShowErrorInTile = ShowErrorInTile };
        }

        /// <summary>
        /// This copies the public descriptor properties from the specified object to
        /// this object.
        /// </summary>
        /// <param name="other">An object that has properties that match the public properties on this object.</param>
        public void CopyProperties(object other)
        {
            var otherBrutileLayer = other as BruTileLayer;
            if (otherBrutileLayer == null)
                throw new ArgumentException();
        }

        public event EventHandler ItemChanged;
        public event EventHandler RemoveItem;

        private ILegendItem _parentItem;
        /// <summary>
        /// Gets the parent item relative to this item.
        /// </summary>
        public ILegendItem GetParentItem()
        {
            return _parentItem;
        }

        /// <summary>
        /// Sets teh parent legend item for this item
        /// </summary>
        /// <param name="value"></param>
        public void SetParentItem(ILegendItem value)
        {
            _parentItem = value;
        }

        /// <summary>
        /// Tests the specified legend item to determine whether or not
        /// it can be dropped into the current item.
        /// </summary>
        /// <param name="item">Any object that implements ILegendItem</param>
        /// <returns>Boolean that is true if a drag-drop of the specified item will be allowed.</returns>
        public bool CanReceiveItem(ILegendItem item)
        {
            return false;
        }

        /// <summary>
        /// Instructs this legend item to perform custom drawing for any symbols.
        /// </summary>
        /// <param name="g">A Graphics surface to draw on</param>
        /// <param name="box">The rectangular coordinates that confine the symbol.</param>
        public void LegendSymbol_Painted(Graphics g, Rectangle box)
        {
           // g.DrawImage(Properties.Resources.BruTileLogoBig, box);
        }

        /// <summary>
        /// Prints the formal legend content without any resize boxes or other notations.
        /// </summary>
        /// <param name="g">The graphics object to print to</param>
        /// <param name="font">The system.Drawing.Font to use for the lettering</param>
        /// <param name="fontColor">The color of the font</param>
        /// <param name="maxExtent">Assuming 0, 0 is the top left, this is the maximum extent</param>
        public void PrintLegendItem(Graphics g, Font font, Color fontColor, SizeF maxExtent)
        {
            g.DrawString(TileSource.Schema.Name, font, new SolidBrush(fontColor), new RectangleF(new PointF(0, 0), maxExtent));
        }

        /// <summary>
        /// Gets the size of the symbol to be drawn to the legend
        /// </summary>
        public Size GetLegendSymbolSize()
        {
            return new Size(25, 25);
        }

        /// <summary>
        /// This is a list of menu items that should appear for this layer.
        /// These are in addition to any that are supported by default.
        /// Handlers should be added to this list before it is retrieved.
        /// </summary>
        public List<SymbologyMenuItem> ContextMenuItems
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets or sets whether or not this legend item should be visible.
        /// This will not be altered unless the LegendSymbolMode is set
        /// to CheckBox.
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// Gets or sets whether this legend item is expanded.
        /// </summary>
        public bool IsExpanded { get; set; }

        /// <summary>
        /// Gets or sets whether this legend item is currently selected (and therefore drawn differently)
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Gets whatever the child collection is and returns it as an IEnumerable set of legend items
        /// in order to make it easier to cycle through those values.
        /// </summary>
        public IEnumerable<ILegendItem> LegendItems
        {
            get { yield break; }
        }

        /// <summary>
        /// Gets or sets a boolean, that if false will prevent this item, or any of its child items
        /// from appearing in the legend when the legend is drawn.
        /// </summary>
        public bool LegendItemVisible { get; set; }

        /// <summary>
        /// Gets the symbol mode for this legend item.
        /// </summary>
        public SymbolMode LegendSymbolMode
        {
            get { return SymbolMode.Symbol; }
        }

        /// <summary>
        /// The text that will appear in the legend 
        /// </summary>
        public string LegendText
        {
            get { return TileSource.ToString(); }
            set { }
        }

        /// <summary>
        /// Gets or sets a pre-defined behavior in the legend when referring to drag and drop functionality.
        /// </summary>
        public LegendType LegendType
        {
            get { return LegendType.Custom; }
        }

        public event EventHandler<EnvelopeArgs> EnvelopeChanged;
        public event EventHandler Invalidated;
        public event EventHandler VisibleChanged;

        /// <summary>
        /// Invalidates the drawing methods
        /// </summary>
        public void Invalidate()
        {
        }

        /// <summary>
        /// Obtains an IEnvelope in world coordinates that contains this object
        /// </summary>
        /// <returns></returns>
        public Extent Extent
        {
            get
            {
                var tileExtent = TileSource.Schema.Extent;
                return new Extent(tileExtent.MinX, tileExtent.MinY, tileExtent.MaxX, tileExtent.MaxY);
            }
        }

        /// <summary>
        /// Gets whether or not the unmanaged drawing structures have been created for this item
        /// </summary>
        public bool IsInitialized
        {
            get { return true; }
        }

        /// <summary>
        /// If this is false, then the drawing function will not render anything.
        /// Warning!  This will also prevent any execution of calculations that take place
        /// as part of the drawing methods and will also abort the drawing methods of any
        /// sub-members to this IRenderable.
        /// </summary>
        public bool IsVisible { get; set; }

        public event EventHandler SelectionChanged;

        /// <summary>
        /// Removes any members from existing in the selected state
        /// </summary>
        public bool ClearSelection(out IEnvelope affectedArea)
        {
            affectedArea = null;
            return false;
        }

        /// <summary>
        /// Inverts the selected state of any members in the specified region.
        /// </summary>
        /// <param name="tolerant">The geographic region to invert the selected state of members</param>
        /// <param name="strict">The geographic region when working with absolutes, without a tolerance</param>
        /// <param name="mode">The selection mode determining how to test for intersection</param>
        /// <param name="affectedArea">The geographic region encapsulating the changed members</param>
        /// <returns>Boolean, true if members were changed by the selection process.</returns>
        public bool InvertSelection(IEnvelope tolerant, IEnvelope strict, SelectionMode mode, out IEnvelope affectedArea)
        {
            affectedArea = null;
            return false;
        }

        /// <summary>
        /// Adds any members found in the specified region to the selected state as long as
        /// SelectionEnabled is set to true.
        /// </summary>
        /// <param name="tolerant">The geographic region where selection occurs</param>
        /// <param name="strict">The geographic region when working with absolutes, without a tolerance</param>
        /// <param name="mode">The selection mode</param>
        /// <param name="affectedArea">The envelope affected area</param>
        /// <returns>Boolean, true if any members were added to the selection</returns>
        public bool Select(IEnvelope tolerant, IEnvelope strict, SelectionMode mode, out IEnvelope affectedArea)
        {
            affectedArea = null;
            return false;
        }

        /// <summary>
        /// Removes any members found in the specified region from the selection
        /// </summary>
        /// <param name="tolerant">The geographic region to investigate</param>
        /// <param name="strict">The geographic region when working with absolutes, without a tolerance</param>
        /// <param name="mode">The selection mode to use for selecting items</param>
        /// <param name="affectedArea">The geographic region containing all the shapes that were altered</param>
        /// <returns>Boolean, true if any members were removed from the selection</returns>
        public bool UnSelect(IEnvelope tolerant, IEnvelope strict, SelectionMode mode, out IEnvelope affectedArea)
        {
            affectedArea = null;
            return false;
        }

        /// <summary>
        /// Gets or sets the Boolean indicating whether this item is actively supporting selection
        /// </summary>
        public bool SelectionEnabled
        {
            get { return false; }
            set { }
        }

        /// <summary>
        /// Dynamic visibility represents layers that only appear when you zoom in close enough.
        /// This value represents the geographic width where that happens.
        /// </summary>
        public double DynamicVisibilityWidth { get; set; }

        /// <summary>
        /// This controls whether the layer is visible when zoomed in closer than the dynamic 
        /// visiblity width or only when further away from the dynamic visibility width
        /// </summary>
        public DynamicVisibilityMode DynamicVisibilityMode { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether dynamic visibility should be enabled.
        /// </summary>
        public bool UseDynamicVisibility
        {
            get { return false; }
            set { }
        }

        /// <summary>
        /// Führt anwendungsspezifische Aufgaben durch, die mit der Freigabe, der Zurückgabe oder dem Zurücksetzen von nicht verwalteten Ressourcen zusammenhängen.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Locks dispose.  This typically adds one instance of an internal reference counter.
        /// </summary>
        public void LockDispose()
        {
        }

        /// <summary>
        /// Gets a value indicating whether an existing reference is requesting that the object is not disposed of.
        /// </summary>
        public bool IsDisposeLocked
        {
            get { return false; }
        }

        /// <summary>
        /// Unlocks dispose.  This typically removes one instance of an internal reference counter.
        /// </summary>
        public void UnlockDispose()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the DotSpatial.Projections assembly is loaded.  If 
        /// not, this returns false, and neither ProjectionInfo nor the Reproject() method should
        /// be used.
        /// </summary>
        /// <returns>Boolean, true if the value can reproject.</returns>
        public bool CanReproject
        {
            get { return false; }
        }

        private readonly ProjectionInfo _projection;
        /// <summary>
        /// Gets or sets the proj4 string for the projection for this dataset
        /// </summary>
        public ProjectionInfo Projection
        {
            get { return _projection; }
            set { }
        }

        /// <summary>
        /// Gets or sets the proj4 string for this dataset.  This exists in 
        /// case the Projections library is not loaded.  If the projection
        /// library is loaded, this also updates the Projection property.
        /// Setting this behaves like defining the projection and will not 
        /// reproject the values.
        /// </summary>
        public string ProjectionString
        {
            get { return _projection.ToProj4String(); }
            set { }
        }

        /// <summary>
        /// Reprojects all of the in-ram vertices of vectors, or else this
        /// simply updates the "Bounds" of image and raster objects
        /// This will also update the projection to be the specified projection.
        /// </summary>
        /// <param name="targetProjection">
        /// The projection information to reproject the coordinates to.
        /// </param>
        public void Reproject(ProjectionInfo targetProjection)
        {
        }

        public event HandledEventHandler ShowProperties;
        public event EventHandler<EnvelopeArgs> ZoomToLayer;
        public event EventHandler<LayerSelectedEventArgs> LayerSelected;
        public event EventHandler FinishedLoading;

        /// <summary>
        /// Given a geographic extent, this tests the "IsVisible", "UseDynamicVisibility", 
        /// "DynamicVisibilityMode" and "DynamicVisibilityWidth"
        /// In order to determine if this layer is visible. 
        /// </summary>
        /// <param name="geographicExtent">The geographic extent, where the width will be tested.</param>
        /// <returns>Boolean, true if this layer should be visible for this extent.</returns>
        public bool VisibleAtExtent(Extent geographicExtent)
        {
            return Extent.Intersects(geographicExtent);
        }

        /// <summary>
        /// Notifies the layer that the next time an area that intersects with this region
        /// is specified, it must first re-draw content to the image buffer.
        /// </summary>
        /// <param name="region">The envelope where content has become invalidated.</param>
        public void Invalidate(Extent region)
        {

        }

        /// <summary>
        /// Queries this layer and the entire parental tree up to the map frame to determine if
        /// this layer is within the selected layers.
        /// </summary>
        public bool IsWithinLegendSelection()
        {
            return true;
        }

        /// <summary>
        /// Gets or sets the core dataset for this layer.
        /// </summary>
        public IDataSet DataSet
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets the currently invalidated region.
        /// </summary>
        public Extent InvalidRegion
        {
            get
            {
                if (MapFrame != null && MapFrame.ViewExtents != null)
                    return MapFrame.ViewExtents;
                return null;
            }
        }

        /// <summary>
        /// Gets the MapFrame that contains this layer.
        /// </summary>
        public IFrame MapFrame { get; set; }

        /// <summary>
        /// Gets or sets the progress handler
        /// </summary>
        public IProgressHandler ProgressHandler { get; set; }

        private static BruTile.Extent ToBrutileExtent(Extent extent)
        {
            return new BruTile.Extent(extent.MinX, extent.MinY, extent.MaxX, extent.MaxY);
        }

        /*
        private static Extent FromBruTileExtent(BruTile.Extent extent)
        {
            return new Extent(extent.MinX, extent.MinY, extent.MaxX, extent.MaxY);
        }
         */

        /// <summary>
        /// This draws content from the specified geographic regions onto the specified graphics
        /// object specified by MapArgs.
        /// </summary>
        public void DrawRegions(MapArgs args, List<Extent> regions)
        {
            System.Windows.Threading.Dispatcher dispatcher = System.Windows.Application.Current.Dispatcher;
            BruTile.Extent extent = ToBrutileExtent(args.GeographicExtents);
            double pixelSize = extent.Width / args.ImageRectangle.Width;

            int level = Utilities.GetNearestLevel(TileSource.Schema.Resolutions, pixelSize);
            IList<TileInfo> tiles = TileSource.Schema.GetTilesInView(extent, level);

            IList<WaitHandle> waitHandles = new List<WaitHandle>();

            foreach (TileInfo info in tiles)
            {
                if (TileCache.Find(info.Index) != null) continue;
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                waitHandles.Add(waitHandle);
                ThreadPool.QueueUserWorkItem(GetTileOnThread,
                                             new object[] { TileSource.Provider, info, TileCache, waitHandle });
            }
            
                foreach (WaitHandle handle in waitHandles)
                    handle.WaitOne();

                foreach (TileInfo info in tiles)
                {
                    using (Image bitmap = Image.FromStream(new MemoryStream(TileCache.Find(info.Index))))
                    {
                        PointF min = args.ProjToPixel(new Coordinate(info.Extent.MinX, info.Extent.MinY));
                        PointF max = args.ProjToPixel(new Coordinate(info.Extent.MaxX, info.Extent.MaxY));

                        min = new PointF((float)Math.Round(min.X), (float)Math.Round(min.Y));
                        max = new PointF((float)Math.Round(max.X), (float)Math.Round(max.Y));
                       
                        args.Device.DrawImage(bitmap,
                                    new Rectangle((int)min.X, (int)max.Y, (int)(max.X - min.X), (int)(min.Y - max.Y)),
                                    0, 0, TileSource.Schema.Width, TileSource.Schema.Height,
                                    GraphicsUnit.Pixel);
                    
                       

                    }

                }
           
        }

        private void GetTileOnThread(object parameter)
        {
            object[] parameters = (object[])parameter;
            if (parameters.Length != 4) throw new ArgumentException("Four parameters expected");
            ITileProvider tileProvider = (ITileProvider)parameters[0];
            TileInfo tileInfo = (TileInfo)parameters[1];
            ITileCache<byte[]> bitmaps = (ITileCache<byte[]>)parameters[2];
            AutoResetEvent autoResetEvent = (AutoResetEvent)parameters[3];

            try
            {
                byte[] bytes = tileProvider.GetTile(tileInfo);
                //Bitmap bitmap = new Bitmap(new MemoryStream(bytes));
                bitmaps.Add(tileInfo.Index, bytes);
            }
            catch (WebException ex)
            {
                if (ShowErrorInTile)
                {
                    //an issue with this method is that one an error tile is in the memory cache it will stay even
                    //if the error is resolved. PDD.
                    Bitmap bitmap = new Bitmap(TileSource.Schema.Width, TileSource.Schema.Height);
                    Graphics graphics = Graphics.FromImage(bitmap);
                    graphics.DrawString(ex.Message, new Font(FontFamily.GenericSansSerif, 12), new SolidBrush(Color.Black),
                        new RectangleF(0, 0, TileSource.Schema.Width, TileSource.Schema.Height));
                    graphics.Dispose();

                    using (MemoryStream m = new MemoryStream())
                    {
                        bitmap.Save(m, ImageFormat.Png);
                        bitmaps.Add(tileInfo.Index, m.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                //todo: log and use other ways to report to user.
            }
            finally
            {
                autoResetEvent.Set();
            }
        }


    }
}