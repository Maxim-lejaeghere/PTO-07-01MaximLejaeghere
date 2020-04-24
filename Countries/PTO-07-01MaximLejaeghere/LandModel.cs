using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PTO_07_01MaximLejaeghere
{
    class LandModel
    {
        //fields
        private string _land;

        public string Land
        {
            get { return _land; }
            set { _land = value; }
        }
        
        private string _stad;

        public string Stad
        {
            get { return _stad; }
            set { _stad = value; }
        }

       
        private string _hoofdstad;

        public string Hoofdstad
        {
            get { return _hoofdstad; }
            set { _hoofdstad = value; }
        }

        private string _munteenheid;

        public string Munteenheid
        {
            get { return _munteenheid; }
            set { _munteenheid = value; }
        }

        private string _talen;

        public string Talen
        {
            get { return _talen; }
            set { _talen = value; }
        }

        private string _feestdag;

        public string Feestdag
        {
            get { return _feestdag; }
            set { _feestdag = value; }
        }

        private string _bezienswaardigheid;

        public string Bezienswaardigheid
        {
            get { return _bezienswaardigheid; }
            set { _bezienswaardigheid = value; }
        }

        private bool _bezocht;

        public bool Bezocht
        {
            get { return _bezocht; }
            set { _bezocht = value; }
        }

        private bool _checkBezocht;

        public bool CheckBezocht
        {
            get { return _checkBezocht; }
            set { _checkBezocht = value; }
        }

        private bool _fout;

        public bool Fout
        {
            get { return _fout; }
            set { _fout = value; }
        }

        private string _bezochtOfNiet;

        public string BezochtOfNiet
        {
            get { return _bezochtOfNiet; }
            set {_bezochtOfNiet = value; }
        }

        private List<LandModel> _bezienswaardigheidslijst = new List<LandModel>();

        public List<LandModel> BezienwaardigheidLijst
        {
            get { return _bezienswaardigheidslijst; }
            set { _bezienswaardigheidslijst = value; }
        }

        private List<string> _tempLijst = new List<string>();

        public List<string> TempLijst
        {
            get { return _tempLijst; }
            set { _tempLijst = value; }
        }

        private Color _kleur;

        public Color Kleur
        {
            get { return _kleur; }
            set { _kleur = value; }
        }

        //constructors

        public LandModel(string land, string hoofdstad, string stad, string munteenheid, string talen, string feestdag, string bezienswaardigheid, bool bezocht)
        {
            Land = land;
            Hoofdstad = hoofdstad;
            Stad = stad;
            Munteenheid = munteenheid;
            Talen = talen;
            Feestdag = feestdag;
            Bezienswaardigheid = bezienswaardigheid;
            Bezocht = bezocht;
        }

        //Methodes
        

        // Hier worden er al wat info in de lijst gestoken
        public void InitiëleBezienswaardigheden()
        {
            BezienwaardigheidLijst.Add(new LandModel(Land = "België", Hoofdstad = "Brussel", Stad = "Eeklo", Munteenheid = "Euro", Talen = "Nederlands", Feestdag = "21 Juni", Bezienswaardigheid = "Kerk", Bezocht = true));
            BezienwaardigheidLijst.Add(new LandModel(Land = "nederland", Hoofdstad = "Amsterdam", Stad = "Nijmwegen", Munteenheid = "Euro", Talen = "Nederlands", Feestdag = "02 Augustus", Bezienswaardigheid = "Tulpen", Bezocht = false));
            BezienwaardigheidLijst.Add(new LandModel(Land = "België", Hoofdstad = "Brussel", Stad = "Brussel", Munteenheid = "Euro", Talen = "Nederlands", Feestdag = "21 Juni", Bezienswaardigheid = "Mannekenpis", Bezocht = true));
            BezienwaardigheidLijst.Add(new LandModel(Land = "België", Hoofdstad = "Brussel", Stad = "Eeklo", Munteenheid = "Euro", Talen = "Frans", Feestdag = "21 Juni", Bezienswaardigheid = "Markt", Bezocht = false));
        }


        // Deze klasse zorgt er voor dat er een lijst wordt aangemaakt met alle verschillende soorten landen, maar een land kan hier geen 2 keer inzitten.
        public void LandenAanComboToevoegen()
        {
            
            TempLijst.Clear();
            foreach (LandModel Nieuwebezienswaardigheid in BezienwaardigheidLijst)
            {
                Land = Nieuwebezienswaardigheid.Land.ToLower();
                if (TempLijst.Contains(Land) == false)
                {
                        TempLijst.Add(Land);
                }

               
            }
        }

       
        public void StedenAanComboToevoegen(string geselecteerdLand)
        {
            TempLijst.Clear();
            foreach (LandModel Nieuwebezienswaardigheid in BezienwaardigheidLijst)
            {
                // zorgt er voor dat er een lijst wordt aangemaakt met alle verschillende soorten steden, maar een stad kan hier geen 2 keer inzitten.
                Stad = Nieuwebezienswaardigheid.Stad;
                Land = Nieuwebezienswaardigheid.Land;
                if (TempLijst.Contains(Stad) == false && Land == geselecteerdLand)
                {
                    TempLijst.Add(Stad);
                }
                // Hier worden de gegevens van het land toegevoegd in de variabelen, deze zullen we dan in de MainWindow gebruiken om de Labels in te vullen
                if (Land == geselecteerdLand)
                {
                    Land = Nieuwebezienswaardigheid.Land;
                    Hoofdstad = Nieuwebezienswaardigheid.Hoofdstad;
                    Munteenheid = Nieuwebezienswaardigheid.Munteenheid;
                    Talen = Nieuwebezienswaardigheid.Talen;
                    Feestdag = Nieuwebezienswaardigheid.Feestdag;
                }

                
            }

            
        }
        // Deze klasse zorgt er voor dat er een lijst wordt aangemaakt met alle verschillende soorten Talen, maar een Taal kan hier geen 2 keer inzitten.
        public void TalenToevoegen(string geselecteerdLand)
        {
            TempLijst.Clear();
            foreach (LandModel Nieuwebezienswaardigheid in BezienwaardigheidLijst)
            {
                Talen = Nieuwebezienswaardigheid.Talen;
                Land = Nieuwebezienswaardigheid.Land;

                if (TempLijst.Contains(Talen) == false && Land == geselecteerdLand)
                {
                    TempLijst.Add(Nieuwebezienswaardigheid.Talen);
                }
            }
        }

        // Deze klasse zorgt er voor dat er een lijst wordt aangemaakt met alle verschillende soorten Bezienswaardigheiden, maar een bezienswaardigheid kan hier geen 2 keer inzitten.
        public void BeziensAanComboToevoegen(string geselecteerdLand, string geselecteerdStad)
        {
            TempLijst.Clear();
            foreach (LandModel Nieuwebezienswaardigheid in BezienwaardigheidLijst)
            {
                Stad = Nieuwebezienswaardigheid.Stad;
                Land = Nieuwebezienswaardigheid.Land;

                if (TempLijst.Contains(Stad) == false && Land == geselecteerdLand && Stad == geselecteerdStad)
                {
                    TempLijst.Add(Nieuwebezienswaardigheid.Bezienswaardigheid);
                }
            }
        }

        // Deze Klasse zorgt ervoor dat Alle info die is gelinkt aan een bezienswaardigheid,
        //gelinkt worden met de juiste variablen, zodat deze in de Mainwindow kunnen worden gelinkt aan de Labels.
        public void BeziensInfoToevoegen(string land, string stad, string bezienswaardigheid)
        {
            Kleur = Colors.AliceBlue;
            TempLijst.Clear();
            foreach (LandModel Nieuwebezienswaardigheid in BezienwaardigheidLijst)
            {
                Stad = Nieuwebezienswaardigheid.Stad;
                Land = Nieuwebezienswaardigheid.Land;
                Bezienswaardigheid = Nieuwebezienswaardigheid.Bezienswaardigheid;

                if (Land == land && Stad == stad && Bezienswaardigheid == bezienswaardigheid)
                {


                    if (Nieuwebezienswaardigheid.Bezocht == true)
                    {

                        Kleur = Colors.Green;
                        BezochtOfNiet = "BEZOCHT";
                    }
                    else
                    {

                        Kleur = Colors.Red;
                        BezochtOfNiet = "NIET BEZOCHT";
                    }
                }

            }

        }

        public void BezienswaardighedenToevoegen()
        {

            foreach (LandModel Nieuwebezienswaardigheid in BezienwaardigheidLijst)
            {
                if (Land.ToLower() == Nieuwebezienswaardigheid.Land.ToLower() && Hoofdstad.ToLower() == Nieuwebezienswaardigheid.Hoofdstad.ToLower() && Stad.ToLower() == Nieuwebezienswaardigheid.Stad.ToLower() && Munteenheid.ToLower() == Nieuwebezienswaardigheid.Munteenheid.ToLower() && Feestdag.ToLower() == Nieuwebezienswaardigheid.Feestdag.ToLower() && Talen.ToLower() == Nieuwebezienswaardigheid.Talen.ToLower() && Bezienswaardigheid.ToLower() == Nieuwebezienswaardigheid.Bezienswaardigheid.ToLower())
                {

                }

                else if (Land == string.Empty || Hoofdstad == string.Empty || Stad == string.Empty || Munteenheid == string.Empty || Feestdag == string.Empty || Talen == string.Empty || Bezienswaardigheid == string.Empty)
                {
                    Fout = true;
                }
                else
                {
                    BezienwaardigheidLijst.Add(new LandModel(Land, Hoofdstad, Stad, Munteenheid, Talen, Feestdag, Bezienswaardigheid, Bezocht));
                    LandenAanComboToevoegen();
                    break;
                }

            }
        }
    }
}
