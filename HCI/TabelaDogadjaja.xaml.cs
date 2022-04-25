using HCI.help.helpProvider;
using HCI.model;
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
    /// Interaction logic for TabelaDogadjaja.xaml
    /// </summary>
    ///
    public partial class TabelaDogadjaja : Window
    {
        public static ObservableCollection<Dogadjaj> Dogadjaj
        {
            get;
            set;
        }

        public static ObservableCollection<Dogadjaj> Dogadjajiii
        {
            get;
            set;
        }
        public TabelaDogadjaja()
        {
            InitializeComponent();
            this.DataContext = this;
            Dogadjaj = new ObservableCollection<Dogadjaj>();
            Dogadjajiii = new ObservableCollection<Dogadjaj>();
            foreach (KeyValuePair<Guid, Dogadjaj> l in MainWindow.repozitorijumDogadjaja.getAll())
            {
                Dogadjaj.Add(l.Value);
            }
        }


        //private void izmena(object sender, RoutedEventArgs e)
        //{
        //    if (dgrMain.SelectedIndex > -1)
        //    {
        //        var p = new DijalogZaDodavanjeDogadjaja();

        //        Dogadjaj l = new Dogadjaj();
        //        foreach (Dogadjaj dogadjaj in Dogadjaj)
        //        {
        //            if (dgrMain.SelectedValue == dogadjaj)
        //                l = dogadjaj;
        //        }


        //        l.Izmena = true;
        //        p.Tekstboks1.IsReadOnly = true;
        //        p.Oznaka = l.Oznaka;
        //        p.Naziv = l.Naziv;
        //        p.Opis = l.Opis;
        //        p.Tip = l.Tip;
        //        if (l.ListaEtiketa != null)
        //        {
        //            foreach (var ee in l.ListaEtiketa)
        //            {
        //                foreach (var et in DijalogZaDodavanjeDogadjaja.Etikete)
        //                {
        //                    if (ee.Equals(et.Item))
        //                    {
        //                        et.IsChecked = true;
        //                    }
        //                }
        //            }
        //        }
        //        p.ListaEtiketa = l.ListaEtiketa;
        //        p.Ikonica = l.Ikonica;
        //        p.Cena = l.Cena;
        //        if (l.DatumOdrzavanjaZaTekucuGodinuString != null)
        //        {
        //            string[] datumArray = l.DatumOdrzavanjaZaTekucuGodinuString.Split("/");
        //            string[] datumArray2 = datumArray[2].Split(" ");
        //            DateTime datum = new DateTime(int.Parse(datumArray2[0]), int.Parse(datumArray[0]), int.Parse(datumArray[1]));
        //            l.DatumOdrzavanjaZaTekucuGodinu = datum;
        //        }
        //        p.DatumOdrzavanjaZaTekucuGodinu = l.DatumOdrzavanjaZaTekucuGodinu;
        //        p.DatumOdrzavanjaZaTekucuGodinuString = l.DatumOdrzavanjaZaTekucuGodinuString;
        //        if (l.IstorijaDatumaOdrzavanjaString != null)
        //        {
        //            l.IstorijaDatumaOdrzavanja = new List<DateTime>();
        //            foreach (string datumIstorija in l.IstorijaDatumaOdrzavanjaString)
        //            {
        //                string[] datumArray = datumIstorija.Split("/");
        //                string[] datumArray2 = datumArray[2].Split(" ");
        //                DateTime datum = new DateTime(int.Parse(datumArray2[0]), int.Parse(datumArray[0]), int.Parse(datumArray[1]));
        //                l.IstorijaDatumaOdrzavanja.Add(datum);
        //            }
        //        }
        //        p.IstorijaDatumaOdrzavanja = l.IstorijaDatumaOdrzavanja;
        //        p.IstorijaDatumaOdrzavanjaString = l.IstorijaDatumaOdrzavanjaString;
        //        p.DaLiJeHumantiarnogKaraktera = l.DaLiJeHumantiarnogKaraktera;
        //        p.PosecenostDogadjaja = l.PosecenostDogadjaja;
        //        p.DrzavaIGradKaoMestoOdrzavanja = l.DrzavaIGradKaoMestoOdrzavanja;
        //        p.ShowDialog();

        //    }
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
            
        //    if (dgrMain.SelectedIndex > -1)
        //    {
        //        Dogadjaj r = (Dogadjaj)dgrMain.SelectedItem;
        //        MainWindow.repozitorijumDogadjaja.Obrisi(r);
        //        DijalogZaDodavanjeDogadjaja.dogadjaji.Remove(r.Oznaka);
        //        Dogadjaj.Remove(r);
        //        MainWindow.ocDogadjaja.Remove(r);
                
        //    }
        //    else
        //    {
        //        MessageBox.Show("Morate selektovati dogadjaj u tabeli.");
        //    }
        //}

        private void pretraga_Click(object sender, RoutedEventArgs e)
        {
            string pretragaString = pretragaTextBox.Text;
            Dogadjajiii = new ObservableCollection<Dogadjaj>();
            if (pretragaString != null)
            {
                string[] pretragaArray = pretragaString.Split(",");
                int count = 0;
                foreach (string s2 in pretragaArray)
                {
                    string s = s2.Trim().ToLower();
                    if (count == 0)
                    {
                        count++;
                        foreach (Dogadjaj d in Dogadjaj)
                        {
                            if (d.Oznaka.ToLower().Contains(s) |
                                d.Naziv.ToLower().Contains(s) |
                                 d.Tip.ToLower().Contains(s))
                            {
                                if (!Dogadjajiii.Contains(d))
                                    Dogadjajiii.Add(d);
                            }
                            else if (d.Cena != null)
                            {
                                if (d.Cena.ToLower().Contains(s))
                                {
                                    if (!Dogadjajiii.Contains(d))
                                        Dogadjajiii.Add(d);
                                }
                            }
                            else if (d.DrzavaIGradKaoMestoOdrzavanja != null)
                            {
                                if (d.DrzavaIGradKaoMestoOdrzavanja.ToLower().Contains(s))
                                {
                                    if (!Dogadjajiii.Contains(d))
                                        Dogadjajiii.Add(d);
                                }
                            }
                            else if (d.Opis != null)
                            {
                                if (d.Opis.ToLower().Contains(s))
                                {
                                    if (!Dogadjajiii.Contains(d))
                                        Dogadjajiii.Add(d);
                                }
                            }
                        }
                    }
                    else if (count == pretragaArray.Length)
                    {
                        count = 0;
                    }
                    else
                    {
                        int count2 = 0;
                        foreach (Dogadjaj d in Dogadjajiii.ToList())
                        {
                            if (d.Oznaka.ToLower().Contains(s) |
                                d.Naziv.ToLower().Contains(s) |
                                 d.Tip.ToLower().Contains(s))
                            {
                                count2 = 1;
                            }
                            else if (d.Cena != null)
                            {
                                if (d.Cena.ToLower().Contains(s))
                                {
                                    count2 = 1;
                                }
                            }
                            else if (d.DrzavaIGradKaoMestoOdrzavanja != null)
                            {
                                if (d.DrzavaIGradKaoMestoOdrzavanja.ToLower().Contains(s))
                                {
                                    count2 = 1;
                                }
                            }
                            else if (d.Opis != null)
                            {
                                if (d.Opis.ToLower().Contains(s))
                                {
                                    count2 = 1;
                                }
                            }
                            if (count2 == 1)
                            {
                                if (!Dogadjajiii.Contains(d))
                                {
                                    Dogadjajiii.Add(d);
                                }
                                count2 = 0;
                            }
                            else if (count2 == 0)
                            {
                                if (Dogadjajiii.Contains(d))
                                    Dogadjajiii.Remove(d);
                            }


                        }
                    }
                }
                dgrMain.ItemsSource = Dogadjajiii;
            }
            else
            {
                dgrMain.ItemsSource = Dogadjaj;
            }
        }

        private void filtriranjeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (filtriranjeTextBox.Text != "")
            {
                Dogadjajiii = new ObservableCollection<Dogadjaj>();
                foreach (var x in MainWindow.repozitorijumDogadjaja.getAll())
                {
                    Dogadjaj l = x.Value;
                    if (l.Oznaka.ToLower().Contains(filtriranjeTextBox.Text.ToLower()) ||
                        l.Naziv.ToLower().Contains(filtriranjeTextBox.Text.ToLower()) ||
                        l.Tip.ToLower().Contains(filtriranjeTextBox.Text.ToLower())
                        )
                    {
                        Dogadjajiii.Add(l);
                    }
                    else if (l.Cena != null)
                    {
                        if (l.Cena.ToLower().Contains(filtriranjeTextBox.Text.ToLower()))
                        {
                            Dogadjajiii.Add(l);
                        }
                    }
                    else if (l.DrzavaIGradKaoMestoOdrzavanja != null)
                    {
                        if (l.DrzavaIGradKaoMestoOdrzavanja.ToLower().Contains(filtriranjeTextBox.Text.ToLower()))
                        {
                            Dogadjajiii.Add(l);
                        }
                    }
                    else if (l.Opis != null)
                    {
                        if (l.Opis.ToLower().Contains(filtriranjeTextBox.Text.ToLower()))
                        {
                            Dogadjajiii.Add(l);
                        }
                    }
                }
                dgrMain.ItemsSource = Dogadjajiii;
            }
            else
            {
                dgrMain.ItemsSource = Dogadjaj;
            }

        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("TabelaDogadjaja", this);
        }
    }
}
