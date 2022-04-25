using HCI.help.helpProvider;
using HCI.model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DijalogZaDodavanjeTipa.xaml
    /// </summary>
    public partial class DijalogZaDodavanjeTipa : Window, INotifyPropertyChanged
    {
        public static Dictionary<string, Tip> tipovi = new Dictionary<string, Tip>();


        private string _OznakaTipa;
        private string _NazivTipa;
        private BitmapImage _IkonicaTipa;
        private string _IkonicaSTipa;
        private string _OpisTipa;
        private bool _PostojiResursSaOvimTipom;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public bool PostojiResursSaOvimTipom
        {
            get
            {
                return _PostojiResursSaOvimTipom;
            }
            set
            {
                if (value != _PostojiResursSaOvimTipom)
                {
                    _PostojiResursSaOvimTipom = value;
                    OnPropertyChanged("PostojiResursSaOvimTipom");
                }
            }
        }

        public string OznakaTipa
        {
            get
            {
                return _OznakaTipa;
            }
            set
            {
                if (value != _OznakaTipa)
                {
                    _OznakaTipa = value;
                    OnPropertyChanged("OznakaTipa");
                }
            }
        }

        public string IkonicaSTipa
        {
            get
            {
                return _IkonicaSTipa;
            }
            set
            {
                if (value != _IkonicaSTipa)
                {
                    _IkonicaSTipa = value;
                    OnPropertyChanged("IkonicaSTipa");
                }
            }
        }

        public string NazivTipa
        {
            get
            {
                return _NazivTipa;
            }
            set
            {
                if (value != _NazivTipa)
                {
                    _NazivTipa = value;
                    OnPropertyChanged("NazivTipa");
                }
            }
        }

        public BitmapImage IkonicaTipa
        {
            get
            {
                return _IkonicaTipa;
            }
            set
            {
                if (value != _IkonicaTipa)
                {
                    _IkonicaTipa = value;
                    OnPropertyChanged("IkonicaTipa");
                }
            }
        }

        public string OpisTipa
        {
            get
            {
                return _OpisTipa;
            }
            set
            {
                if (value != _OpisTipa)
                {
                    _OpisTipa = value;
                    OnPropertyChanged("OpisTipa");
                }
            }
        }


        public DijalogZaDodavanjeTipa()
        {
            InitializeComponent();
            this.DataContext = this;
            foreach (KeyValuePair<Guid, Tip> l in MainWindow.repozitorijumTipa.getAll())
            {
                if (!tipovi.ContainsKey(l.Value.OznakaTipa))
                {
                    tipovi.Add(l.Value.OznakaTipa, l.Value);
                }
            }
        }

        private void Novi_tip(object sender, RoutedEventArgs e)
        {
            Tip t = new Tip();
            t.NazivTipa = NazivTipa;
            t.OpisTipa = OpisTipa;
            t.OznakaTipa = OznakaTipa;
            t.IkonicaTipa = IkonicaTipa;
            if (t.IkonicaTipa != null)
                t.IkonicaSTipa = t.IkonicaTipa.ToString();

            if (t.OznakaTipa != null && t.NazivTipa != null && t.IkonicaSTipa != null)
            {
                if (!tipovi.ContainsKey(t.OznakaTipa))
                {
                    tipovi.Add(t.OznakaTipa, t);
                    MainWindow.repozitorijumTipa.Dodaj(t);
                    if (DijalogZaDodavanjeDogadjaja.Tipovi != null)
                    {
                        DijalogZaDodavanjeDogadjaja.Tipovi.Add(t.OznakaTipa);
                    }
                    if (TabelaTipa.tipovi2 != null)
                    {
                        TabelaTipa.tipovi2.Add(t);
                    }
                    Close();
                }
                else
                {
                    if (tipovi[t.OznakaTipa].Izmena == true)
                    {
                        tipovi[t.OznakaTipa] = t;
                        TabelaTipa.tipovi2[TabelaTipa.indeksSelektovanogT] = t;
                        t.Izmena = false;
                        if (DijalogZaDodavanjeDogadjaja.Tipovi != null)
                        {
                            DijalogZaDodavanjeDogadjaja.Tipovi[TabelaTipa.indeksSelektovanogT] = t.OznakaTipa;

                            foreach (KeyValuePair<Guid, Tip> l in MainWindow.repozitorijumTipa.getAll())
                            {
                                if (l.Value.OznakaTipa.Equals(t.OznakaTipa))
                                {
                                    MainWindow.repozitorijumTipa.izmeni(l.Key, t);
                                    break;
                                }
                            }
                        }
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Već postoji tip sa tom oznakom!");
                    }
                }

            }
            else
            {
                MessageBox.Show("Niste popunili sva obavezna polja!");
            }
        }


        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                IkonicaTipa = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("KreirajTip", this);
        }
    }
}
