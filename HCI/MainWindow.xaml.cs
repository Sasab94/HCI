using HCI.help.helpProvider;
using HCI.list;
using HCI.model;
using HCI.repo;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RepozitorijumEtiketa repozitorijumEtiketa { get; set; }
        public static RepozitorijumTipa repozitorijumTipa { get; set; }
        public static RepozitorijumDogadjaja repozitorijumDogadjaja { get; set; }
        public static ObservableCollection<Dogadjaj> ocDogadjaja;
        Point startPoint = new Point();
        Dogadjaj dogadjaj = new Dogadjaj();
        private Point mousePosition;
        private Image draggedImage;
        private Image image;


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            repozitorijumEtiketa = new RepozitorijumEtiketa();
            repozitorijumTipa = new RepozitorijumTipa();
            repozitorijumDogadjaja = new RepozitorijumDogadjaja();
            ocDogadjaja = new ObservableCollection<Dogadjaj>();
            DijalogZaDodavanjeDogadjaja.Etikete = new ObservableCollection<ListaEtiketa>();
            DijalogZaDodavanjeDogadjaja.Tipovi = new ObservableCollection<string>();
            foreach (KeyValuePair<Guid, Etiketa> e in MainWindow.repozitorijumEtiketa.getAll())
            {
                ListaEtiketa le = new ListaEtiketa(e.Value.OznakaEtikete, false);
                DijalogZaDodavanjeDogadjaja.Etikete.Add(le);
                DijalogZaDodavanjeEtikete.mapaa.Add(e.Value.OznakaEtikete, e.Value);
            }
            foreach (KeyValuePair<Guid, Tip> e in MainWindow.repozitorijumTipa.getAll())
            {
                if (!DijalogZaDodavanjeTipa.tipovi.ContainsKey(e.Value.OznakaTipa))
                {
                    DijalogZaDodavanjeTipa.tipovi.Add(e.Value.OznakaTipa, e.Value);
                }

                DijalogZaDodavanjeDogadjaja.Tipovi.Add(e.Value.OznakaTipa);
            }

            foreach (KeyValuePair<Guid, Dogadjaj> e in MainWindow.repozitorijumDogadjaja.getAll())
            {
                if (DijalogZaDodavanjeDogadjaja.dogadjaji == null)
                {
                    DijalogZaDodavanjeDogadjaja.dogadjaji = new Dictionary<string, Dogadjaj>();
                }
                if (!DijalogZaDodavanjeDogadjaja.dogadjaji.ContainsKey(e.Value.Oznaka))
                {
                    DijalogZaDodavanjeDogadjaja.dogadjaji.Add(e.Value.Oznaka, e.Value);     
                }
                if (!ocDogadjaja.Contains(e.Value)){
                    ocDogadjaja.Add(e.Value);
                }
                Image image = new Image();
                BitmapImage bit = new BitmapImage(new Uri(e.Value.IkonicaS, UriKind.Absolute));
                image.Source = bit;
                image.Width = 25;
                image.Height = 25;

                e.Value.RedniBrojNaCanvasu = canvas.Children.Count;


                Canvas.SetLeft(image, e.Value.P.X - 171);
                Canvas.SetTop(image, e.Value.P.Y - 25);
                canvas.Children.Add(image);
            }
            ocDogadjajListBox.ItemsSource = ocDogadjaja;
        }

        private void Etiketa_Click(object sender, RoutedEventArgs e)
        {
            var v = new DijalogZaDodavanjeEtikete();
            v.ShowDialog();
        }

        private void Tabela_etiketa_Click(object sender, RoutedEventArgs e)
        {
            var v = new TabelaEtiketa();
            v.ShowDialog();
        }

        private void Tip_Click(object sender, RoutedEventArgs e)
        {
            var v = new DijalogZaDodavanjeTipa();
            v.ShowDialog();
        }

        private void Tabela_tipova_Click(object sender, RoutedEventArgs e)
        {
            var v = new TabelaTipa();
            v.ShowDialog();
        }

        private void Dogadjaj_Click(object sender, RoutedEventArgs e)
        {
            var v = new DijalogZaDodavanjeDogadjaja();
            v.ShowDialog();
        }


        private void Tabela_dogadjaja_Click(object sender, RoutedEventArgs e)
        {
            var v = new TabelaDogadjaja();
            v.ShowDialog();
        }

        private void izmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ocDogadjajListBox.SelectedItems.Count == 1) {
                if (ocDogadjajListBox.SelectedIndex > -1)
                {
                    Dogadjaj d = (Dogadjaj)ocDogadjajListBox.SelectedItem;
                    var p = new DijalogZaDodavanjeDogadjaja();
                    d.Izmena = true;            
                    p.Tekstboks1.IsReadOnly = true;
                    p.Oznaka = d.Oznaka;
                    p.Naziv = d.Naziv;
                    p.Opis = d.Opis;
                    p.Tip = d.Tip;
                    if (d.ListaEtiketa != null)
                    {
                        foreach (var ee in d.ListaEtiketa)
                        {
                            foreach (var et in DijalogZaDodavanjeDogadjaja.Etikete)
                            {
                                if (ee.Equals(et.Item))
                                {
                                    et.IsChecked = true;
                                }
                            }
                        }
                    }
                    p.ListaEtiketa = d.ListaEtiketa;
                    p.Ikonica = d.Ikonica;
                    p.Cena = d.Cena;
                    if (d.DatumOdrzavanjaZaTekucuGodinuString != null)
                    {
                        string[] datumArray = d.DatumOdrzavanjaZaTekucuGodinuString.Split("/");
                        string[] datumArray2 = datumArray[2].Split(" ");
                        DateTime datum = new DateTime(int.Parse(datumArray2[0]), int.Parse(datumArray[0]), int.Parse(datumArray[1]));
                        d.DatumOdrzavanjaZaTekucuGodinu = datum;
                    }
                    p.DatumOdrzavanjaZaTekucuGodinu = d.DatumOdrzavanjaZaTekucuGodinu;
                    p.DatumOdrzavanjaZaTekucuGodinuString = d.DatumOdrzavanjaZaTekucuGodinuString;
                    if (d.IstorijaDatumaOdrzavanjaString != null)
                    {
                        d.IstorijaDatumaOdrzavanja = new List<DateTime>();
                        foreach (string datumIstorija in d.IstorijaDatumaOdrzavanjaString)
                        {
                            string[] datumArray = datumIstorija.Split("/");
                            string[] datumArray2 = datumArray[2].Split(" ");
                            DateTime datum = new DateTime(int.Parse(datumArray2[0]), int.Parse(datumArray[0]), int.Parse(datumArray[1]));
                            d.IstorijaDatumaOdrzavanja.Add(datum);
                        }
                    }
                    p.IstorijaDatumaOdrzavanja = d.IstorijaDatumaOdrzavanja;
                    p.IstorijaDatumaOdrzavanjaString = d.IstorijaDatumaOdrzavanjaString;
                    p.DaLiJeHumantiarnogKaraktera = d.DaLiJeHumantiarnogKaraktera;
                    p.PosecenostDogadjaja = d.PosecenostDogadjaja;
                    p.DrzavaIGradKaoMestoOdrzavanja = d.DrzavaIGradKaoMestoOdrzavanja;
                    p.RedniBrojNaCanvasu = d.RedniBrojNaCanvasu;
                    p.P = d.P;
                    p.ShowDialog();
                    if (p.potvrdi == 1)
                    {
                        if (p.RedniBrojNaCanvasu != 0)
                        {
                            foreach (Dogadjaj dogadjaj in ocDogadjaja)
                            {
                                if (dogadjaj.Oznaka.Equals(p.Oznaka))
                                {
                                    Image image = new Image();
                                    BitmapImage bit = new BitmapImage(new Uri(dogadjaj.IkonicaS, UriKind.Absolute));
                                    image.Source = bit;
                                    image.Width = 25;
                                    image.Height = 25;
                                    canvas.Children.RemoveAt(p.RedniBrojNaCanvasu);
                                    dogadjaj.RedniBrojNaCanvasu = canvas.Children.Count;

                                    Canvas.SetLeft(image, dogadjaj.P.X - 171);
                                    Canvas.SetTop(image, dogadjaj.P.Y - 25);
                                    canvas.Children.Add(image);
                                }

                            }
                            p.potvrdi = 0;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Morate selektovati samo jedan dogadjaj iz liste!");
            }
        }

        private void ocDogadjajListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var v = new TabelaDogadjaja();
            Dogadjaj dogadjaj = (Dogadjaj) ocDogadjajListBox.SelectedItem;
            foreach (Dogadjaj d in TabelaDogadjaja.Dogadjaj) {
                if (d.Oznaka.Equals(dogadjaj.Oznaka))
                    v.dgrMain.SelectedItem = d;
            }
            v.Show();
        }

        private void ocDogadjajListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ocDogadjajListBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;

                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                if (listViewItem != null)
                {
                    dogadjaj = (Dogadjaj) listView.ItemContainerGenerator.ItemFromContainer(listViewItem);
                }

                // Initialize the drag & drop operation

                if (dogadjaj != null && dogadjaj.prevucen == false)
                {
                    DataObject dragData = new DataObject("myFormat", dogadjaj);
                    if (dragData != null && listViewItem != null)
                    {
                        DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Copy);
                    }
                }
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedImage != null)
            {
                var position = e.GetPosition(canvas);
                var offset = position - mousePosition;
                mousePosition = position;
                Canvas.SetLeft(draggedImage, Canvas.GetLeft(draggedImage) + offset.X);
                Canvas.SetTop(draggedImage, Canvas.GetTop(draggedImage) + offset.Y);

            }
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.Copy;
            }
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                dogadjaj = e.Data.GetData("myFormat") as Dogadjaj;
                Image image = new Image();
                BitmapImage bit = new BitmapImage(new Uri(dogadjaj.IkonicaS, UriKind.Absolute));
                image.Source = bit;
                image.Width = 25;
                image.Height = 25;
                image.ToolTip = dogadjaj.Oznaka;
                foreach(Dogadjaj d in ocDogadjaja)
                {
                    if((e.GetPosition(this).X >= d.P.X) && (e.GetPosition(this).X <= d.P.X + 25) && (e.GetPosition(this).Y <= d.P.Y + 25) && (e.GetPosition(this).Y >= d.P.Y))
                    {
                        MessageBox.Show("Dogadjaji se ne smeju preklapati");
                        return;
                    }
                }
                dogadjaj.P = e.GetPosition(this);
                Canvas.SetLeft(image, e.GetPosition(this).X - 171);
                Canvas.SetTop(image, e.GetPosition(this).Y - 25);
                dogadjaj.RedniBrojNaCanvasu = canvas.Children.Count;
                canvas.Children.Add(image);
                dogadjaj.prevucen = true;

                MainWindow.ocDogadjaja.Clear();

                foreach (KeyValuePair<Guid, Dogadjaj> eee in MainWindow.repozitorijumDogadjaja.getAll())
                {
                    if (!MainWindow.ocDogadjaja.Contains(eee.Value))
                    {
                        MainWindow.ocDogadjaja.Add(eee.Value);
                    }
                }

                MainWindow.repozitorijumDogadjaja.MemorisiDatoteku();
            }
        }

        private void canvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            foreach (Dogadjaj d in ocDogadjaja)
            {
                 if ((e.GetPosition(this).X >= d.P.X) && (e.GetPosition(this).X <= d.P.X + 25) && (e.GetPosition(this).Y <= d.P.Y + 25) && (e.GetPosition(this).Y >= d.P.Y))
                {
                    if (image != null)
                    {
                        if (!image.Source.ToString().Equals(d.IkonicaS))
                        {
                            MessageBox.Show("Dogadjaji se ne smeju preklapati");
                            return;
                        }
                    }
                }
            }
            if (draggedImage != null)
            {
                canvas.ReleaseMouseCapture();
                Panel.SetZIndex(draggedImage, 0);

                draggedImage = null;
                if (dogadjaj != null)
                {
                    dogadjaj.P = e.GetPosition(null);
                }
                MainWindow.repozitorijumDogadjaja.MemorisiDatoteku();
            }
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image = e.Source as Image;
            if (image != null && !image.Source.ToString().Equals("pack://application:,,,/HCI/;component/images/mapa1.png"))
            {
                foreach (Dogadjaj d in ocDogadjaja)
                {
                    if (image.Source.ToString().Equals(d.IkonicaS) && e.GetPosition(null).X - 25 < d.P.X && e.GetPosition(null).X + 25 > d.P.X)
                    {
                        ocDogadjajListBox.SelectedItem = d;
                        dogadjaj = d;
                    }
                }
            }
            if (image != null && canvas.CaptureMouse())
            {
                mousePosition = e.GetPosition(canvas);
                draggedImage = image;
                //Panel.SetZIndex(draggedImage, 1);
            }
        }

        private void Grafik_sveta_Click(object sender, RoutedEventArgs e)
        {
            var v = new GrafikSveta();
            v.ShowDialog();
        }

        private void obrisi_Click(object sender, RoutedEventArgs e)
        {
            Dogadjaj d = (Dogadjaj) ocDogadjajListBox.SelectedItem;
            if(ocDogadjajListBox.SelectedItem!=null)
            {
                var v = new DijalogZaBrisanjeDogadjaja();
                v.ShowDialog();
                if (DijalogZaBrisanjeDogadjaja.potvrda == true)
                {
                    ocDogadjaja.Remove(d);
                    repozitorijumDogadjaja.Obrisi(d);
                    canvas.Children.RemoveAt(d.RedniBrojNaCanvasu);
                    DijalogZaDodavanjeDogadjaja.dogadjaji.Remove(d.Oznaka);
                    DijalogZaBrisanjeDogadjaja.potvrda = false;
                }
            } 
            else
            {
                MessageBox.Show("Morate selektovati dogadjaj za brisanje!");
            }
        }

        private void DodajDogadjaj_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DodajDogadjaj_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var d = new DijalogZaDodavanjeDogadjaja();
            d.ShowDialog();
        }

        ////////////////

        private void DodajTip_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DodajTip_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var d = new DijalogZaDodavanjeTipa();
            d.ShowDialog();
        }

        ////////////////

        private void DodajEntitet_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DodajEntitet_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var d = new DijalogZaDodavanjeEtikete();
            d.ShowDialog();
        }

        ////////////////

        private void TabelaDogadjaja_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void TabelaDogadjaja_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var t = new TabelaDogadjaja();
            t.ShowDialog();
        }

        ////////////////

        private void TabelaTipa_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void TabelaTipa_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var t = new TabelaTipa();
            t.ShowDialog();
        }

        ////////////////

        private void TabelaEntieta_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void TabelaEntieta_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var t = new TabelaEtiketa();
            t.ShowDialog();
        }

        ////////////////
        private void Grafik_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Grafik_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var t = new GrafikSveta();
            t.ShowDialog();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("PomocPocetnaStranica", this);
        }

        private void pomoc_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("PomocPocetnaStranica", this);
        }


    }
}
