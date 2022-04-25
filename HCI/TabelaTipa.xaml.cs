using HCI.help.helpProvider;
using HCI.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TabelaTipa.xaml
    /// </summary>
    public partial class TabelaTipa : Window
    {
        public static ObservableCollection<Tip> tipovi2 { get; set; }
        public static int indeksSelektovanogT { get; set; }

        public TabelaTipa()
        {
            InitializeComponent();
            this.DataContext = this;
            tipovi2 = new ObservableCollection<Tip>();
            foreach (KeyValuePair<Guid, Tip> t in MainWindow.repozitorijumTipa.getAll())
            {
                tipovi2.Add(t.Value);
            }
        }

        private void izmena(object sender, RoutedEventArgs e)
        {
            var p = new DijalogZaDodavanjeTipa();

            Tip l = new Tip();
            if (dgrMain.SelectedIndex > -1)
            {
                foreach (Tip tip in tipovi2)
                {
                    if (dgrMain.SelectedValue == tip)
                        l = tip;
                }

                l.Izmena = true;
                p.oznakaTipaTextBox.IsReadOnly = true;
                p.OznakaTipa = l.OznakaTipa;
                p.NazivTipa = l.NazivTipa;
                p.IkonicaTipa = l.IkonicaTipa;
                p.OpisTipa = l.OpisTipa;


                p.ShowDialog();
            }
        }

        private void brisanje(object sender, RoutedEventArgs e)
        {
            Tip l = (Tip)dgrMain.SelectedItem;
            l.PostojiDogadjajSaOvimTipom = false;
            if (DijalogZaDodavanjeDogadjaja.dogadjaji != null)
            {
                foreach (var tip in DijalogZaDodavanjeDogadjaja.dogadjaji)
                {
                    if (tip.Value.Tip.Equals(l.OznakaTipa))
                    {
                        l.PostojiDogadjajSaOvimTipom = true;
                        break;
                    }
                }
            }

            if (l.PostojiDogadjajSaOvimTipom == true)
            {
                MessageBox.Show("Postoji dogadjaj s ovim tipom,nemogucnost brisanja!");
            }
            else
            {
                if (dgrMain.SelectedIndex > -1)
                {
                    var p = new DijalogZaBrisanjeTipa();
                    p.ShowDialog();
                    if (DijalogZaBrisanjeTipa.potvrda == true)
                    {
                        DijalogZaDodavanjeTipa.tipovi.Remove(l.OznakaTipa);
                        tipovi2.RemoveAt(dgrMain.SelectedIndex);
                        MainWindow.repozitorijumTipa.Obrisi(l);
                        DijalogZaBrisanjeTipa.potvrda = false;
                    }
                }
            }
        }

        private void pretragaa_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (pretragaa.Text != "")
            {
                if (pretragaaCB.Text.Equals("Oznaka"))
                {
                    foreach (var x in MainWindow.repozitorijumTipa.getAll())
                    {
                        Tip l = x.Value;
                        if (l.OznakaTipa.Contains(pretragaa.Text))
                        {
                            dgrMain.SelectedItem = l;
                        }
                    }
                }
                else if (pretragaaCB.Text.Equals("Naziv"))
                {
                    foreach (var x in MainWindow.repozitorijumTipa.getAll())
                    {
                        Tip l = x.Value;
                        if (l.NazivTipa.Contains(pretragaa.Text))
                        {
                            dgrMain.SelectedItem = l;
                        }
                    }
                }
            }
            else
            {
                dgrMain.SelectedItem = null;
                opisTipaTextBox = null;
                nazivTipaTextBox = null;
                oznakaTipaTextBox = null;
                image2.Source = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
             HelpProvider.ShowHelp("TabelaTipa", this);
        }
    }
}
