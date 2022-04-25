using HCI.help.helpProvider;
using HCI.list;
using HCI.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace HCI
{
    /// <summary>
    /// Interaction logic for DijalogZaDodavanjeEtikete.xaml
    /// </summary>
    public partial class DijalogZaDodavanjeEtikete : Window, INotifyPropertyChanged
    {
        public static Dictionary<string, Etiketa> mapaa = new Dictionary<string, Etiketa>();

        public event PropertyChangedEventHandler PropertyChanged;
        public string _OznakaEtikete;
        public string _OpisEtikete;
        public Color _Boja;

        public DijalogZaDodavanjeEtikete()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string OznakaEtikete
        {
            get
            {
                return _OznakaEtikete;
            }
            set
            {
                if (value != _OznakaEtikete)
                {
                    _OznakaEtikete = value;
                    OnPropertyChanged("OznakaEtikete");
                }
            }
        }

        public string OpisEtikete
        {
            get
            {
                return _OpisEtikete;
            }
            set
            {
                if (value != _OpisEtikete)
                {
                    _OpisEtikete = value;
                    OnPropertyChanged("OpisEtikete");
                }
            }
        }

        public Color Boja
        {
            get
            {
                return _Boja;
            }
            set
            {
                if (value != _Boja)
                {
                    _Boja = value;
                    OnPropertyChanged("Boja");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Etiketa et = new Etiketa();

            et.OpisEtikete = OpisEtikete;
            et.OznakaEtikete = OznakaEtikete;
            et.Boja = Boja;
            et.BojaS = Boja.ToString();

            if (et.OznakaEtikete != null)
            {
                if (!mapaa.ContainsKey(et.OznakaEtikete))
                {
                    mapaa.Add(et.OznakaEtikete, et);
                    MainWindow.repozitorijumEtiketa.Dodaj(et);
                    if (DijalogZaDodavanjeDogadjaja.Etikete != null)
                    {
                        ListaEtiketa le = new ListaEtiketa(et.OznakaEtikete, false);
                        DijalogZaDodavanjeDogadjaja.Etikete.Add(le);
                    }
                    Close();
                }
                else
                {
                    if (mapaa[et.OznakaEtikete].Izmena == true)
                    {
                        mapaa[et.OznakaEtikete] = et;
                        TabelaEtiketa.etiketa[TabelaEtiketa.IndeksSelektovanogE] = et;
                        et.Izmena = false;
                        if (DijalogZaDodavanjeDogadjaja.Etikete != null)
                        {
                            ListaEtiketa le = new ListaEtiketa(et.OznakaEtikete, false);
                            DijalogZaDodavanjeDogadjaja.Etikete[TabelaEtiketa.IndeksSelektovanogE] = le;

                            foreach (KeyValuePair<Guid, Etiketa> l in MainWindow.repozitorijumEtiketa.getAll())
                            {
                                if (l.Value.OznakaEtikete.Equals(et.OznakaEtikete))
                                {
                                    MainWindow.repozitorijumEtiketa.izmeni(l.Key, et);
                                    break;
                                }
                            }
                        }

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Već postoji etiketa sa tom oznakom!");
                    }
                }

            }
            else
            {
                MessageBox.Show("Niste popunili sva obavezna polja!");
            }
        }

        private void CommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("KreirajEtiketu", this);
        }
    }
}
