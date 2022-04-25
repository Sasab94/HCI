using HCI.help.helpProvider;
using HCI.list;
using HCI.model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace HCI
{
    /// <summary>
    /// Interaction logic for DijalogZaDodavanjeDogadjaja.xaml
    /// </summary>
    public partial class DijalogZaDodavanjeDogadjaja : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static Dictionary<string, Dogadjaj> dogadjaji { get; set; }
        public static ObservableCollection<string> Tipovi { get; set; }
        public static ObservableCollection<ListaEtiketa> Etikete { get; set; }

        public string _oznaka;
        public string _Naziv;
        public string _opis;
        public string _tip;
        public List<string> _ListaEtiketa;
        public string _PosecenostDogadjaja;
        public bool _DaLiJeHumantiarnogKaraktera;
        public string _cena;
        public string _DrzavaIGradKaoMestoOdrzavanja;
        public DateTime _DatumOdrzavanjaZaTekucuGodinu;
        public string _DatumOdrzavanjaZaTekucuGodinuString;
        public List<DateTime> _IstorijaDatumaOdrzavanja;
        public List<string> _IstorijaDatumaOdrzavanjaString;
        public BitmapImage _ikonica;
        public Point _p;
        public string ToolTipDogadjaj;
        public bool _prevucen;
        public int _redniBrojNaCanvasu;
        public Dictionary<string, string> _ListaCekiranihEtiketa;
        public int potvrdi;



        public Point P
        {
            get
            {
                return _p;
            }
            set
            {
                if (value != _p)
                {
                    _p = value;
                    OnPropertyChanged("P");
                }
            }
        }

        public List<string> ListaEtiketa
        {
            get
            {
                return _ListaEtiketa;
            }
            set
            {
                if (value != _ListaEtiketa)
                {
                    _ListaEtiketa = value;
                    OnPropertyChanged("ListaEtiketa");
                }
            }
        }

        public Dictionary<string, string> ListaCekiranihEtiketa
        {
            get
            {
                return _ListaCekiranihEtiketa;
            }
            set
            {
                if (value != _ListaCekiranihEtiketa)
                {
                    _ListaCekiranihEtiketa = value;
                    OnPropertyChanged("ListaCekiranihEtiketa");
                }
            }
        }

        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public string Naziv
        {
            get
            {
                return _Naziv;
            }
            set
            {
                if (value != _Naziv)
                {
                    _Naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }


        public string Cena
        {
            get
            {
                return _cena;
            }
            set
            {
                if (value != _cena)
                {
                    _cena = value;
                    OnPropertyChanged("Cena");
                }
            }
        }

        public string Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                if (value != _tip)
                {
                    _tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }
        public string PosecenostDogadjaja
        {
            get
            {
                return _PosecenostDogadjaja;
            }
            set
            {
                if (value != _PosecenostDogadjaja)
                {
                    _PosecenostDogadjaja = value;
                    OnPropertyChanged("PosecenostDogadjaja");
                }
            }
        }

        public bool DaLiJeHumantiarnogKaraktera
        {
            get
            {
                return _DaLiJeHumantiarnogKaraktera;
            }
            set
            {
                if (value != _DaLiJeHumantiarnogKaraktera)
                {
                    _DaLiJeHumantiarnogKaraktera = value;
                    OnPropertyChanged("DaLiJeHumantiarnogKaraktera");
                }
            }
        }

        public string DrzavaIGradKaoMestoOdrzavanja
        {
            get
            {
                return _DrzavaIGradKaoMestoOdrzavanja;
            }
            set
            {
                if (value != _DrzavaIGradKaoMestoOdrzavanja)
                {
                    _DrzavaIGradKaoMestoOdrzavanja = value;
                    OnPropertyChanged("DrzavaIGradKaoMestoOdrzavanja");
                }
            }
        }
        public DateTime DatumOdrzavanjaZaTekucuGodinu
        {
            get
            {
                return _DatumOdrzavanjaZaTekucuGodinu;
            }
            set
            {
                if (value != _DatumOdrzavanjaZaTekucuGodinu)
                {
                    _DatumOdrzavanjaZaTekucuGodinu = value;
                    OnPropertyChanged("DatumOdrzavanjaZaTekucuGodinu");
                }
            }
        }

        public string DatumOdrzavanjaZaTekucuGodinuString
        {
            get
            {
                return _DatumOdrzavanjaZaTekucuGodinuString;
            }
            set
            {
                if (value != _DatumOdrzavanjaZaTekucuGodinuString)
                {
                    _DatumOdrzavanjaZaTekucuGodinuString = value;
                    OnPropertyChanged("DatumOdrzavanjaZaTekucuGodinuString");
                }
            }
        }

        public List<DateTime> IstorijaDatumaOdrzavanja
        {
            get
            {
                return _IstorijaDatumaOdrzavanja;
            }
            set
            {
                if (value != _IstorijaDatumaOdrzavanja)
                {
                    _IstorijaDatumaOdrzavanja = value;
                    OnPropertyChanged("IstorijaDatumaOdrzavanja");
                }
            }
        }
        public List<string> IstorijaDatumaOdrzavanjaString
        {
            get
            {
                return _IstorijaDatumaOdrzavanjaString;
            }
            set
            {
                if (value != _IstorijaDatumaOdrzavanjaString)
                {
                    _IstorijaDatumaOdrzavanjaString = value;
                    OnPropertyChanged("IstorijaDatumaOdrzavanjaString");
                }
            }
        }
        public bool prevucen
        {
            get
            {
                return _prevucen;
            }
            set
            {
                if (value != _prevucen)
                {
                    _prevucen = value;
                    OnPropertyChanged("Prevucen");
                }
            }
        }

        public int RedniBrojNaCanvasu
        {
            get
            {
                return _redniBrojNaCanvasu;
            }
            set
            {
                if (value != _redniBrojNaCanvasu)
                {
                    _redniBrojNaCanvasu = value;
                    OnPropertyChanged("RedniBrojNaCanvasu");
                }
            }
        }

        public BitmapImage Ikonica
        {
            get
            {
                return _ikonica;
            }
            set
            {
                if (value != _ikonica)
                {
                    _ikonica = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        #region PropertyChangedNotifier
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        public DijalogZaDodavanjeDogadjaja()
        {
            DatumOdrzavanjaZaTekucuGodinu = DateTime.Today;
            InitializeComponent();
            this.DataContext = this;
            dogadjaji = new Dictionary<string, Dogadjaj>();
            Tipovi = new ObservableCollection<string>();
            Etikete = new ObservableCollection<ListaEtiketa>();

            foreach (KeyValuePair<Guid, Etiketa> e in MainWindow.repozitorijumEtiketa.getAll())
            {
                ListaEtiketa le = new ListaEtiketa(e.Value.OznakaEtikete, false);
                Etikete.Add(le);
            }
            foreach (KeyValuePair<Guid, Tip> e in MainWindow.repozitorijumTipa.getAll())
            {
                if (!DijalogZaDodavanjeTipa.tipovi.ContainsKey(e.Value.OznakaTipa))
                {
                    DijalogZaDodavanjeTipa.tipovi.Add(e.Value.OpisTipa, e.Value);
                }

                Tipovi.Add(e.Value.OznakaTipa);
            }
            foreach (KeyValuePair<Guid, Dogadjaj> e in MainWindow.repozitorijumDogadjaja.getAll())
            {
                if (!dogadjaji.ContainsKey(e.Value.Oznaka))
                {
                    dogadjaji.Add(e.Value.Oznaka, e.Value);
                }
            }
            potvrdi = 0;
        }

        private void dodajTip_Click(object sender, RoutedEventArgs e)
        {
            var d = new DijalogZaDodavanjeTipa();
            d.ShowDialog();
        }

        private void dodajEtiketu_Click(object sender, RoutedEventArgs e)
        {
            var d = new DijalogZaDodavanjeEtikete();
            d.ShowDialog();
        }

        private void dodajDatum_Click(object sender, RoutedEventArgs e)
        {
            if (IstorijaDatumaOdrzavanja == null)
            {
                IstorijaDatumaOdrzavanja = new List<DateTime>();
            }
            if (istorijaDatumaDatePicker.SelectedDate != null)
            {
                if (!IstorijaDatumaOdrzavanja.Contains((DateTime)istorijaDatumaDatePicker.SelectedDate))
                {
                    //istorijaOdrzavanjaListBox.Items.Add((DateTime)istorijaDatumaDatePicker.SelectedDate);
                    istorijaOdrzavanjaListBox.ClearValue(ItemsControl.ItemsSourceProperty);
                    IstorijaDatumaOdrzavanja.Add((DateTime)istorijaDatumaDatePicker.SelectedDate);
                    istorijaOdrzavanjaListBox.ItemsSource = IstorijaDatumaOdrzavanja;
                }
                else
                {
                    MessageBox.Show("Dati datum se vec nalazi na listi!");
                }

            }
            else
            {
                MessageBox.Show("Morate selektovati datum.");
            }


        }

        private void obrisiDatum_Click(object sender, RoutedEventArgs e)
        {
            if (istorijaOdrzavanjaListBox.SelectedItem != null)
            {
                IstorijaDatumaOdrzavanja.Remove((DateTime)istorijaOdrzavanjaListBox.SelectedItem);
                istorijaOdrzavanjaListBox.ClearValue(ItemsControl.ItemsSourceProperty);
                istorijaOdrzavanjaListBox.ItemsSource = IstorijaDatumaOdrzavanja;
            }
            else
            {
                MessageBox.Show("Morate selektovati datum iz liste kako bi ga obrisali!");
            }
        }

        private void ikonicaIzaberi_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                Ikonica = new BitmapImage(new Uri(op.FileName));
                ikonica.Source = new BitmapImage(new Uri(op.FileName));
            }
        }


        private void zatvori_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void noviDogadjaj_Click(object sender, RoutedEventArgs e)
        {
            Dogadjaj dogadjaj = new Dogadjaj();



            dogadjaj.Oznaka = Oznaka;
            dogadjaj.Naziv = Naziv;
            dogadjaj.Opis = Opis;
            dogadjaj.Tip = Tip;
            dogadjaj.P = P;
            dogadjaj.Ikonica = Ikonica;
            if (dogadjaj.Ikonica != null)
                dogadjaj.IkonicaS = dogadjaj.Ikonica.ToString();

            if (dogadjaj.Ikonica == null && dogadjaj.Ikonica == null)
            {
                if (dogadjaj.Tip != null)
                {
                    if (DijalogZaDodavanjeTipa.tipovi.ContainsKey(dogadjaj.Tip))
                    {
                        if (DijalogZaDodavanjeTipa.tipovi[Tip].IkonicaTipa != null)
                        {
                            dogadjaj.Ikonica = DijalogZaDodavanjeTipa.tipovi[Tip].IkonicaTipa;
                            dogadjaj.IkonicaS = dogadjaj.Ikonica.ToString();
                        }
                    }
                }
            }
            dogadjaj.DaLiJeHumantiarnogKaraktera = DaLiJeHumantiarnogKaraktera;
            dogadjaj.Cena = Cena;
            dogadjaj.DatumOdrzavanjaZaTekucuGodinu = DatumOdrzavanjaZaTekucuGodinu;
            dogadjaj.DatumOdrzavanjaZaTekucuGodinuString = DatumOdrzavanjaZaTekucuGodinu.ToString();
            dogadjaj.IstorijaDatumaOdrzavanja = IstorijaDatumaOdrzavanja;
            dogadjaj.IstorijaDatumaOdrzavanjaString = new List<string>();
            if (IstorijaDatumaOdrzavanja != null)
            {
                foreach (DateTime datum in IstorijaDatumaOdrzavanja)
                {
                    dogadjaj.IstorijaDatumaOdrzavanjaString.Add(datum.ToString());
                }
            }
            dogadjaj.PosecenostDogadjaja = PosecenostDogadjaja;
            dogadjaj.DrzavaIGradKaoMestoOdrzavanja = DrzavaIGradKaoMestoOdrzavanja;
            dogadjaj.ToolTipDogadjaj = "- Oznaka: " + Oznaka;

            foreach (var et in DijalogZaDodavanjeDogadjaja.Etikete)
            {
                if (et.IsChecked == true)
                {
                    if (dogadjaj.ListaEtiketa != null)
                    {
                        dogadjaj.ListaEtiketa.Add(et.Item);
                    }
                    else
                    {
                        dogadjaj.ListaEtiketa = new List<string>();
                        dogadjaj.ListaEtiketa.Add(et.Item);
                    }
                }
            }


            if (dogadjaj.Oznaka != null && dogadjaj.Naziv != null && dogadjaj.Tip != null && dogadjaj.Ikonica != null)
            {
                if (!dogadjaji.ContainsKey(dogadjaj.Oznaka))
                {
                    dogadjaji.Add(dogadjaj.Oznaka, dogadjaj);
                    MainWindow.repozitorijumDogadjaja.Dodaj(dogadjaj);
                    MainWindow.ocDogadjaja.Add(dogadjaj);
                    Close();
                }
                else
                {
                    if (dogadjaji[dogadjaj.Oznaka].Izmena == true)
                    {
                        potvrdi = 1;
                        try
                        {

                            dogadjaji[dogadjaj.Oznaka] = dogadjaj;
                            foreach (KeyValuePair<Guid, Dogadjaj> lok in MainWindow.repozitorijumDogadjaja.getAll())
                            {
                                if (lok.Value.Oznaka.Equals(dogadjaji[dogadjaj.Oznaka].Oznaka))
                                {
                                    MainWindow.repozitorijumDogadjaja.Obrisi(dogadjaji[dogadjaj.Oznaka]);
                                    MainWindow.repozitorijumDogadjaja.Dodaj(dogadjaj);                       
                                    if (TabelaDogadjaja.Dogadjaj != null)
                                    {
                                        foreach (Dogadjaj d in TabelaDogadjaja.Dogadjaj)
                                        {
                                            if (d.Oznaka.Equals(dogadjaj.Oznaka))
                                            {
                                                TabelaDogadjaja.Dogadjaj.Remove(d);
                                                TabelaDogadjaja.Dogadjaj.Add(dogadjaj);    
                                            }
                                        }
                                    }
                                    if (MainWindow.ocDogadjaja != null)
                                    {
                                        foreach (Dogadjaj d in MainWindow.ocDogadjaja)
                                        {
                                            if (d.Oznaka.Equals(dogadjaj.Oznaka))
                                            {
                                                MainWindow.ocDogadjaja.Remove(d);
                                                MainWindow.ocDogadjaja.Add(dogadjaj);                                              
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            dogadjaji[dogadjaj.Oznaka] = dogadjaj;
                            Close();
                        }
                        catch
                        {
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Već postoji dogadjaj sa tom oznakom!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Niste popunili sva obavezna polja!");
            }
        }

        private void istorijaOdrzavanjaListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("KreirajDogadjaj", this);
        }
    }

}
