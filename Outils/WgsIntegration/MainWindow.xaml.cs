using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;
using System.IO;
namespace WgsIntegration
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private List<WgsRow> WgsRows {get;set;}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WgsRows = new List<WgsRow>();
            NpgsqlConnection connection = new NpgsqlConnection("HOST=127.0.0.1;PORT=5432;DATABASE=test;USER ID=postgres;PASSWORD=Emash21;PRELOADREADER=true;");
            connection.Open();
            FileStream stream = new FileStream(@"C:\Users\Champ\Documents\GitHub\GeoPat\Data\APRR\Data\WGS_INF.CSV", FileMode.Open);
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.GetEncoding(1252));
            reader.ReadLine();
            String line = null;
            while ((line = reader.ReadLine()) != null)
            {
                String[] strs = line.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                WgsRow row = new WgsRow();
                row.LineIndex = Int32.Parse(strs[0]);
                row.LayerName = strs[1];
                row.Liaison = strs[2];
                row.Sens = strs[3];
                row.AbsDeb = int.Parse(strs[4].Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture);
                row.AbsFin = int.Parse(strs[5].Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture);
               
                row.X1 = double.Parse(strs[6].Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture);
                row.Y1 = double.Parse(strs[7].Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture);
                row.X2 = double.Parse(strs[8].Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture);
                row.Y2 = double.Parse(strs[9].Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture);
                this.WgsRows.Add(row);
            }

            reader.Close();
            reader.Dispose();
            stream.Close();
            stream.Dispose();

            Console.WriteLine(this.WgsRows.Count + " lignes chargées");
            List<String> liaisons = (from r in WgsRows where r.LayerName.Equals ("SIG_REF_DETAIL") select r.Liaison).Distinct().ToList();
            foreach (String liaison in liaisons)
            {
                List<String> senss = (from r in WgsRows where r.Liaison.Equals(liaison) && r.LayerName.Equals("SIG_REF_DETAIL") select r.Sens).Distinct().ToList();
                foreach (String sens in senss)
                {
                    List<int> lineIndexes = (from r in WgsRows where r.Liaison.Equals(liaison) && r.Sens.Equals(sens) && r.LayerName.Equals("SIG_REF_DETAIL") select r.LineIndex).Distinct().ToList();
                    if (lineIndexes.Count == 1)
                    {
                        List<String> strCoords = new List<string>();
                        //LINESTRING(3.45 4.23,10 50,20 25)
                        List<WgsRow> rowLines = (from r in WgsRows where r.Liaison.Equals(liaison) && r.Sens.Equals(sens) && r.LineIndex == lineIndexes[0] && r.LayerName.Equals("SIG_REF_DETAIL") orderby r.LineIndex, r.AbsDeb select r).Distinct().ToList();
                        foreach (WgsRow rowLine in rowLines)
                        {
                            strCoords.Add(rowLine.X1.ToString().Replace(",", ".") + " " + rowLine.Y1.ToString().Replace(",", "."));
                            strCoords.Add(rowLine.X2.ToString().Replace(",", ".") + " " + rowLine.Y2.ToString().Replace(",", "."));
                        }
                        String wktString = "LINESTRING(" + string.Join(",", strCoords) + ")";
                        String sqlIdChaussee = "select inf_chaussee__id from inf.inf_chaussee,inf.inf_liaison where inf_chaussee.inf_chaussee__code='" + sens + "' and inf_liaison.inf_liaison__code='" + liaison + "' and inf_chaussee.inf_liaison__id=inf_liaison.inf_liaison__id";
                        NpgsqlCommand command = new NpgsqlCommand(sqlIdChaussee, connection);
                        NpgsqlDataReader readerData = command.ExecuteReader();
                        Nullable<Int32> idChaussee = null;
                        if (readerData.Read())
                        {idChaussee = Int32.Parse(readerData.GetValue(0).ToString());}
                        readerData.Close();
                        readerData.Dispose();
                        if (idChaussee.HasValue)
                        {
                            String sqlUpdateGem = "update inf.inf_chaussee set inf_chaussee__geom='" + wktString + "' where inf_chaussee__id=" + idChaussee.Value;
                            command = new NpgsqlCommand(sqlUpdateGem, connection);
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        
                        List<String> lineCoords = new List<string>();
                        foreach (int lineIndex in lineIndexes)
                        {
                            List<String> strCoords = new List<string>();
                            List<WgsRow> rowLines = (from r in WgsRows where r.Liaison.Equals(liaison) && r.Sens.Equals(sens) && r.LineIndex == lineIndex && r.LayerName.Equals("SIG_REF_DETAIL") orderby r.LineIndex, r.AbsDeb select r).Distinct().ToList();
                            foreach (WgsRow rowLine in rowLines)
                            {
                                strCoords.Add(rowLine.X1.ToString().Replace(",", ".") + " " + rowLine.Y1.ToString().Replace(",", "."));
                                strCoords.Add(rowLine.X2.ToString().Replace(",", ".") + " " + rowLine.Y2.ToString().Replace(",", "."));
                            }
                            lineCoords.Add("("+String.Join(",", strCoords)+")");

                        }
                        String wktString = "MULTILINESTRING(" + string.Join(",", lineCoords) + ")";
                        String sqlIdChaussee = "select inf_chaussee__id from inf.inf_chaussee,inf.inf_liaison where inf_chaussee.inf_chaussee__code='" + sens + "' and inf_liaison.inf_liaison__code='" + liaison + "' and inf_chaussee.inf_liaison__id=inf_liaison.inf_liaison__id";
                        NpgsqlCommand command = new NpgsqlCommand(sqlIdChaussee, connection);
                        NpgsqlDataReader readerData = command.ExecuteReader();
                        Nullable<Int32> idChaussee = null;
                        if (readerData.Read())
                        { idChaussee = Int32.Parse(readerData.GetValue(0).ToString()); }
                        readerData.Close();
                        readerData.Dispose();
                        if (idChaussee.HasValue)
                        {
                            String sqlUpdateGem = "update inf.inf_chaussee set inf_chaussee__geom='" + wktString + "' where inf_chaussee__id=" + idChaussee.Value;
                            command = new NpgsqlCommand(sqlUpdateGem, connection);
                            command.ExecuteNonQuery();
                        }
                    }
                }

          
            }
            connection.Close();
            connection.Dispose();
            
        }
    }
}
