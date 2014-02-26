using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class DataFileViewModel : INotifyPropertyChanged
    {
        private String _stateMessage;

        public String StateMessage
        {
            get { return _stateMessage; }
            set { _stateMessage = value;this.RaisePropertyChanged ("StateMessage"); }
        }
        private Dictionary<String, int> _mapping;


        public Dictionary<String,int> Mapping
        {
            get { return _mapping; }           
        }

        private Boolean _import;

        public Boolean Import
        {
            get { return _import; }
            set { _import = value; this.RaisePropertyChanged("Import"); }
        }
        public Dispatcher _dispatcher;
        public List<String> _headers;
        private List<List<String>> _datas;


        public List<List<String>> Datas
        {
            get { return _datas; }           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                this._dispatcher.Invoke(new Action(delegate() { handler(this, new PropertyChangedEventArgs(name)); }));
                
            }
        }

        public DataFileViewModel(string file, EntityTableInfo entityTableInfo, bool isLegacy)
        {
            // TODO: Complete member initialization
            this._dispatcher = System.Windows.Application.Current.Dispatcher;
            this.FilePath = file;
            this.TableInfo = entityTableInfo;
            this.IsLegacy = true;
            this.FileInfo = new FileInfo(this.FilePath);
            this._headers = new List<string>();
            this._datas = new List<List<string>>();
            this.Import = false;
            this._mapping = new Dictionary<String, int>();
            

        }

        public void ReadFile()
        {
            FileStream stream = new FileStream(this.FilePath, FileMode.Open);
            StreamReader reader = null;
            if (this.IsLegacy)
            { reader = new StreamReader (stream , System .Text.Encoding .GetEncoding (1252));}
            else
            {reader = new StreamReader (stream,System.Text.Encoding.Unicode ); }

            String header = reader.ReadLine();
            this._headers = header.Split(";".ToCharArray(), StringSplitOptions.None).ToList ();

            String data = null;
            while ((data = reader.ReadLine()) != null)
            {this._datas.Add(data.Split(";".ToCharArray(), StringSplitOptions.None).ToList());}

            reader.Close();
            reader.Dispose();
            stream.Close();
            stream.Dispose();
            this.RaisePropertyChanged("RowCount");
            this.FillMapping();
        }

        private void FillMapping()
        {
            if (this.IsLegacy)
            {
                if (this.TableInfo.TableName.Equals("INF_CD_SENSIBLE"))
                {
                    this._mapping.Add("Code", this._headers.IndexOf("CODE"));
                    this._mapping.Add("Libelle", this._headers.IndexOf("CODE"));
                    this.Import = true;
                }
                else  if (this.TableInfo.TableName.Equals("INF_FAM_DEC"))
                {
                    this._mapping.Add("Code", this._headers.IndexOf("FAM_DEC"));
                    this._mapping.Add("Libelle", this._headers.IndexOf("LIBELLE"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_CD_GARE"))
                {
                    this._mapping.Add("Code", this._headers.IndexOf("TYPE"));
                    this._mapping.Add("Libelle", this._headers.IndexOf("TYPE"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_CD_LIAISON"))
                {
                    this._mapping.Add("Code", this._headers.IndexOf("CD_LIAISON"));
                    this._mapping.Add("Libelle", this._headers.IndexOf("LIBELLE"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_CD_OCCUPANT"))
                {
                    this._mapping.Add("Code", this._headers.IndexOf("NOM"));
                    this._mapping.Add("Libelle", this._headers.IndexOf("NOM"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_CD_POSIT"))
                {
                    this._mapping.Add("Position", this._headers.IndexOf("POSIT"));
                    this._mapping.Add("Ordre", this._headers.IndexOf("ORDRE"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_CD_PT_SING"))
                {
                    this._mapping.Add("Libelle", this._headers.IndexOf("LIBELLE"));
                    this._mapping.Add("Code", this._headers.IndexOf("CODE"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_CD_TALUS"))
                {
                    this._mapping.Add("Libelle", this._headers.IndexOf("TYPE"));
                    this._mapping.Add("Code", this._headers.IndexOf("TYPE"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_CD_TPC"))
                {
                    this._mapping.Add("Libelle", this._headers.IndexOf("LIBELLE"));
                    this._mapping.Add("Code", this._headers.IndexOf("CODE"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_CD_VOIE"))
                {
                    //VOIE;POSIT;LIBELLE;ROULABLE
                    this._mapping.Add("Libelle", this._headers.IndexOf("LIBELLE"));
                    this._mapping.Add("Code", this._headers.IndexOf("VOIE"));                 
                    this._mapping.Add("Position", this._headers.IndexOf("POSIT"));
                    this._mapping.Add("Roulable", this._headers.IndexOf("ROULABLE"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_LIAISON"))
                {
                    this._mapping.Add("Libelle", this._headers.IndexOf("LIBELLE"));
                    this._mapping.Add("Code", this._headers.IndexOf("LIAISON"));
                    this._mapping.Add("InfCodeLiaison.Code", this._headers.IndexOf("CD_LIAISON_INF__CD_LIAISON"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_CD_DEC"))
                {
                    //FAM_DEC_INF__FAM_DEC;CD_DEC;LIBELLE
                    this._mapping.Add("Libelle", this._headers.IndexOf("LIBELLE"));
                    this._mapping.Add("Code", this._headers.IndexOf("CD_DEC"));
                    this._mapping.Add("InfFamDec.Code", this._headers.IndexOf("FAM_DEC_INF__FAM_DEC"));
                    this.Import = true;
                }

                else if (this.TableInfo.TableName.Equals("INF_REPARTITION_TRAFIC"))
                {
                  
                    this._mapping.Add("InfChaussee.InfLiaison.Code", this._headers.IndexOf("LIAISON_INF__LIAISON"));
                    this._mapping.Add("InfChaussee.Code", this._headers.IndexOf("CHAUSSEE_INF__SENS"));
                    this._mapping.Add("AbsDeb", this._headers.IndexOf("ABS_DEB"));
                    this._mapping.Add("AbsFin", this._headers.IndexOf("ABS_Fin"));
                    this._mapping.Add("PcPl", this._headers.IndexOf("P_PL"));
                    this._mapping.Add("Annee", this._headers.IndexOf("ANNEE"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_CHAUSSEE"))
                {
                    //ABS_DEB;ABS_FIN;LIBELLE;TENANT;ABOUT
                    this._mapping.Add("InfLiaison.Code", this._headers.IndexOf("LIAISON_INF__LIAISON"));
                    this._mapping.Add("Code", this._headers.IndexOf("SENS"));
                    this._mapping.Add("Libelle", this._headers.IndexOf("LIBELLE"));
                    this._mapping.Add("AbsDeb", this._headers.IndexOf("ABS_DEB"));
                    this._mapping.Add("AbsFin", this._headers.IndexOf("ABS_FIN"));
                    this._mapping.Add("Tenant", this._headers.IndexOf("TENANT"));
                    this._mapping.Add("About", this._headers.IndexOf("ABOUT"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_REPERE"))
                {

                    this._mapping.Add("InfChaussee.InfLiaison.Code", this._headers.IndexOf("LIAISON_INF__LIAISON"));
                    this._mapping.Add("InfChaussee.Code", this._headers.IndexOf("CHAUSSEE_INF__SENS"));
                    this._mapping.Add("AbsCum", this._headers.IndexOf("ABS_CUM"));
                    this._mapping.Add("Inter", this._headers.IndexOf("INTER"));
                    this._mapping.Add("Num", this._headers.IndexOf("NUM"));
                    this.Import = true;
                }

                else if (this.TableInfo.TableName.Equals("INF_ECLAIRAGE"))
                {
                    this._mapping.Add("InfChaussee.InfLiaison.Code", this._headers.IndexOf("LIAISON_INF__LIAISON"));
                    this._mapping.Add("InfChaussee.Code", this._headers.IndexOf("CHAUSSEE_INF__SENS"));
                    this._mapping.Add("AbsDeb", this._headers.IndexOf("ABS_DEB"));
                    this._mapping.Add("InfCodeEclaire.Code", this._headers.IndexOf("CD_ECLAIR_INF__TYPE"));
                    this._mapping.Add("InfCodePosit.Code", this._headers.IndexOf("CD_POSIT_INF__POSIT"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_GARE"))
                {
                    //LIAISON_INF__LIAISON;CHAUSSEE_INF__SENS;ABS_DEB;CD_GARE_INF__TYPE;NUM_EXPLOIT;NOM;DATE_MS;VOI_ENTREE;VOI_SORTIE;VOI_MIXTE;VOI_TSA;OBSERV
                    this._mapping.Add("InfChaussee.InfLiaison.Code", this._headers.IndexOf("LIAISON_INF__LIAISON"));
                    this._mapping.Add("InfChaussee.Code", this._headers.IndexOf("CHAUSSEE_INF__SENS"));
                    this._mapping.Add("AbsDeb", this._headers.IndexOf("ABS_DEB"));
                    this._mapping.Add("InfCodeGare.Code", this._headers.IndexOf("CD_GARE_INF__TYPE"));
                    this._mapping.Add("NumExploit", this._headers.IndexOf("NUM_EXPLOIT"));
                    this._mapping.Add("Nom", this._headers.IndexOf("NOM"));
                    this._mapping.Add("DateMs", this._headers.IndexOf("DATE_MS"));
                    this._mapping.Add("NbEntree", this._headers.IndexOf("VOI_ENTREE"));
                    this._mapping.Add("NbSortiee", this._headers.IndexOf("VOI_SORTIE"));
                    this._mapping.Add("NbMixte", this._headers.IndexOf("VOI_MIXTE"));
                    this._mapping.Add("NbTsa", this._headers.IndexOf("VOI_TSA"));
                    this._mapping.Add("Info", this._headers.IndexOf("OBSERV"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_OCCUPATION"))
                {
                    //LIAISON_INF__LIAISON;CHAUSSEE_INF__SENS;ABS_DEB;ABS_FIN;CD_OCCUP_INF__TYPE;CD_OCCUPANT_INF__NOM;DATE_MS;DATE_FV;TRAV;OBS
                    this._mapping.Add("InfChaussee.InfLiaison.Code", this._headers.IndexOf("LIAISON_INF__LIAISON"));
                    this._mapping.Add("InfChaussee.Code", this._headers.IndexOf("CHAUSSEE_INF__SENS"));
                    this._mapping.Add("AbsDeb", this._headers.IndexOf("ABS_DEB"));
                    this._mapping.Add("InfCodeOccupation.Code", this._headers.IndexOf("CD_OCCUP_INF__TYPE"));
                    this._mapping.Add("InfCodeOccupant.Code", this._headers.IndexOf("CD_OCCUPANT_INF__NOM"));
                    this._mapping.Add("DateMs", this._headers.IndexOf("DATE_MS"));
                    this._mapping.Add("DateFv", this._headers.IndexOf("DATE_FV"));
                    this._mapping.Add("Info", this._headers.IndexOf("OBS"));
                    this._mapping.Add("Traverse", this._headers.IndexOf("TRAV"));
                    this.Import = true;
                }
                else if (this.TableInfo.TableName.Equals("INF_PAVE_VOIE"))
                {            
                    this._mapping.Add("InfChaussee.InfLiaison.Code", this._headers.IndexOf("LIAISON_INF__LIAISON"));
                    this._mapping.Add("InfChaussee.Code", this._headers.IndexOf("CHAUSSEE_INF__SENS"));
                    this._mapping.Add("AbsDeb", this._headers.IndexOf("ABS_DEB"));
                    this._mapping.Add("AbsFin", this._headers.IndexOf("ABS_FIN"));
                    this._mapping.Add("InfCodeVoie.Code", this._headers.IndexOf("CD_VOIE_INF__VOIE"));
                    this._mapping.Add("Largeur", this._headers.IndexOf("LARGEUR"));
                    this._mapping.Add("DateMs", this._headers.IndexOf("DATE_MS"));
                   
                    this.Import = true;
                }
            }
            else 
            { }
        }

        public int RowCount
        {
            get {
                return this._datas.Count;
            }
        }
        public int Level
        {
            get { return this.TableInfo.Level; }
        }
        private FileInfo FileInfo { get; set; }
        public String FilePath { get; set; }
        public String FileName
        {
            get
            {
                return this.FileInfo.Name;
            }
        }
        public EntityTableInfo TableInfo { get; set; }
        public Boolean IsLegacy { get; set; }
    }
}
