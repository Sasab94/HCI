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
    /// Interaction logic for TabelaEtiketa.xaml
    /// </summary>
    public partial class TabelaEtiketa : Window
    {
        public static ObservableCollection<Etiketa> etiketa { get; set; }
        public static int IndeksSelektovanogE { get; set; }
        public TabelaEtiketa()
        {
            InitializeComponent();
            this.DataContext = this;
            etiketa = new ObservableCollection<Etiketa>();
            foreach (KeyValuePair<Guid, Etiketa> t in MainWindow.repozitorijumEtiketa.getAll())
            {
                etiketa.Add(t.Value);
            }
        }

        private void izmena(object sender, RoutedEventArgs e)
        {
            var p = new DijalogZaDodavanjeEtikete();

            Etiketa l = new Etiketa();
            if (dgrMain.SelectedIndex > -1)
            {
                foreach (Etiketa etiketa in etiketa)
                {
                    if (dgrMain.SelectedValue == etiketa)
                        l = etiketa;
                }

                l.Izmena = true;

                p.OznakaEtikete = l.OznakaEtikete;
                p.Boja = l.Boja;
                p.OpisEtikete = l.OpisEtikete;
                p.oznakaEtiketeTextBox.IsReadOnly = true;

                p.ShowDialog();
            }

        }

        private void brisanje(object sender, RoutedEventArgs e)
        {
            if (dgrMain.SelectedIndex > -1)
            {

                Etiketa l = (Etiketa)dgrMain.SelectedItem;

                if (l.PostojiDogadjajSaOvomEtiketom == true)
                {
                    MessageBox.Show("Postoji Dogadjaj s ovom etiketom,stoga je nemoguce obrisati etiketu!");
                }
                else
                {
                    var p = new DijalogZaBrisanjeEtikete();
                    p.ShowDialog();
                    if (DijalogZaBrisanjeEtikete.potvrda == true)
                    {

                        MainWindow.repozitorijumEtiketa.Obrisi(l);
                        DijalogZaDodavanjeEtikete.mapaa.Remove(l.OznakaEtikete);
                        etiketa.RemoveAt(dgrMain.SelectedIndex);
                        DijalogZaBrisanjeEtikete.potvrda = false;
                    }
                }
            }
        }

        private void tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbox.Text != "")
            {
                foreach (var x in MainWindow.repozitorijumEtiketa.getAll())
                {
                    Etiketa l = x.Value;
                    if (l.OznakaEtikete.Contains(tbox.Text))
                    {
                        dgrMain.SelectedItem = l;
                    }
                }
            }
            else
            {
                dgrMain.SelectedItem = null;
                opisEtiketeTextBox = null;
                oznakaEtiketeTextBox = null;
                color.SelectedColor = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("TabelaEtikete", this);
        }
    }
}
