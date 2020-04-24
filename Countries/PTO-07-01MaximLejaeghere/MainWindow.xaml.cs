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

namespace PTO_07_01MaximLejaeghere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

        // in de opdracht stond dat ik een listbox moest gebruiken voor de munteenheden,
        // ik heb dit niet gedaan omdat volgens mij de andere listboxen duidelijk aantoonden dat ik wel genoeg kennis had. 
        // En omdat ik het logischer vond op deze manier.
       
    {
        LandModel bezienswaardigheid = new LandModel(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,  true );

        public MainWindow()
        {   
            InitializeComponent();

            // Standaard eerste landen toevoegen met een bezienswaardigheid in list
            bezienswaardigheid.InitiëleBezienswaardigheden();


            //Aanroepen verschillende landen 
            bezienswaardigheid.LandenAanComboToevoegen();
            foreach (string Land in bezienswaardigheid.TempLijst)
            {
                comboLand.Items.Add(Land);
            }
            


        }

        private void comboLand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Labels en comboBoxen Resetten
            comboBezienswaardigheid.Items.Clear();
            comboStad.Items.Clear();
            comboTalen.Items.Clear();
            lblBezocht.Content = "";
            lblBezocht.Background = new SolidColorBrush(Colors.AliceBlue);

            //Aanroepen verschillende steden 
            bezienswaardigheid.StedenAanComboToevoegen(comboLand.SelectedItem.ToString());


            foreach (string stad in bezienswaardigheid.TempLijst)
            {
                comboStad.Items.Add(stad);
            }
            //Alle Items die enkel gekoppeld zijn aan het land worden hier al getoond
            lblFeestDag.Content = bezienswaardigheid.Feestdag;
            lblHoofdStad.Content = bezienswaardigheid.Hoofdstad;
            lblMunt.Content = bezienswaardigheid.Munteenheid;

            //Veschillende Talen Toevoegen
            bezienswaardigheid.TalenToevoegen(comboLand.SelectedItem.ToString());
            foreach (string Taal in bezienswaardigheid.TempLijst)
            {
                comboTalen.Items.Add(Taal);
            }
        }

        private void comboStad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Labels resetten
            lblBezocht.Content = "";
            lblBezocht.Background = new SolidColorBrush(Colors.AliceBlue);
            comboBezienswaardigheid.Items.Clear();

            
            //zorgt er voor dat de onderstaande berekening niet wordt uitgevoerd als deze SelectionChanged word getriggered door een andere SelectionChanged
            if (comboStad.SelectedItem == null)
            {

            }
            //Aanroepen verschillende steden 
            else
            {
                bezienswaardigheid.BeziensAanComboToevoegen(comboLand.SelectedItem.ToString(), comboStad.SelectedItem.ToString());
                foreach (string bezienswaardigheid in bezienswaardigheid.TempLijst)
                {
                    comboBezienswaardigheid.Items.Add(bezienswaardigheid);

                }
            }
        }

        private void comboBezienswaardigheid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //zorgt er voor dat de onderstaande berekening niet wordt uitgevoerd als deze SelectionChanged word getriggered door een andere SelectionChanged
            if (comboStad.SelectedItem == null || comboBezienswaardigheid.SelectedItem == null)
            {
                
            }

            // Roept een lijst aan met alle Talen in Een land. Opgelet je kan maar 1 land aan 1 bezienswaardigheid koppelen,
            //dus als je 2 talen wilt toevoegen en je hebt maar 1 bezienswaardigheid, zal je deze er 2 keer moeten insteken.
            else
            {
                bezienswaardigheid.BeziensInfoToevoegen(comboLand.SelectedItem.ToString(), comboStad.SelectedItem.ToString(), comboBezienswaardigheid.SelectedItem.ToString());

                foreach (string taal in bezienswaardigheid.TempLijst)
                {
                    comboTalen.Items.Add(taal);

                }
                lblBezocht.Background = new SolidColorBrush(bezienswaardigheid.Kleur);
                lblBezocht.Content = bezienswaardigheid.BezochtOfNiet;
            }
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            bezienswaardigheid.Land = txtLand.Text;
            bezienswaardigheid.Stad = txtStad.Text;
            
            if (checkBezocht.IsChecked == true)
            {
                bezienswaardigheid.Bezocht = true;
            }
            else
            {
                bezienswaardigheid.Bezocht = false;
            }
            bezienswaardigheid.Feestdag = txtFeestdag.Text;
            bezienswaardigheid.Hoofdstad = txtHoofdstad.Text;
            bezienswaardigheid.Talen = txtTaal.Text;
            bezienswaardigheid.Munteenheid = txtMunteenheid.Text;
            bezienswaardigheid.Bezienswaardigheid = txtBezienswaardigheid.Text;

            //
            bezienswaardigheid.BezienswaardighedenToevoegen();

            // Standaard extra landen toevoegen met een bezienswaardigheid in list
            bezienswaardigheid.InitiëleBezienswaardigheden();

            //Aanroepen verschillende landen 
            bezienswaardigheid.LandenAanComboToevoegen();
            comboLand.Items.Clear();
            foreach (string Land in bezienswaardigheid.TempLijst)
            {
                comboLand.Items.Add(Land);
            }



            if (bezienswaardigheid.Fout == true)
            {
                lblFout.Content = "Vul alles Goed in!";
            }
            else
            {
                txtLand.Text = string.Empty;
                txtStad.Text = string.Empty;
                txtFeestdag.Text = string.Empty;
                txtFeestdag.Text = string.Empty;
                txtHoofdstad.Text = string.Empty;
                txtTaal.Text = string.Empty;
                txtMunteenheid.Text = string.Empty;
                checkBezocht.IsChecked = false;
                txtBezienswaardigheid.Text = string.Empty;
                lblFout.Content = string.Empty;
            }
        }

        private void btnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
