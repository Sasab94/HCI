using HCI.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HCI.repo
{
    public class RepozitorijumDogadjaja
    {
        private Dictionary<Guid, Dogadjaj> _r = new Dictionary<Guid, Dogadjaj>();
        private readonly string _datoteka;

        public RepozitorijumDogadjaja()
        {
            _datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RepozitorijumDogadjajaTest.podaci");
            UcitajDatoteku();
        }

        public void Dodaj(Dogadjaj o)
        {
            if (o.ID == Guid.Empty)
                o.ID = Guid.NewGuid();
            if (!_r.ContainsKey(o.ID))
                _r.Add(o.ID, o);
            MemorisiDatoteku();
        }

        public void Obrisi(Dogadjaj o)
        {
            foreach (KeyValuePair<Guid, Dogadjaj> key in _r)
            {
                if (key.Value.Oznaka.Equals(o.Oznaka))
                {
                    _r.Remove(key.Key);
                }
            }
            MemorisiDatoteku();
        }

        public Dogadjaj this[Guid g]
        {
            get
            {
                return _r[g];
            }
            set
            {
                _r[g] = value;
            }
        }

        public void MemorisiDatoteku()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;
            try
            {
                stream = File.Open(_datoteka, FileMode.OpenOrCreate);
                formatter.Serialize(stream, _r);
            }
            catch
            {
                // 
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        public void UcitajDatoteku()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(_datoteka))
            {
                try
                {
                    stream = File.Open(_datoteka, FileMode.Open);
                    _r = (Dictionary<Guid, Dogadjaj>)formatter.Deserialize(stream);
                    foreach (KeyValuePair<Guid, Dogadjaj> l in _r)
                    {
                        l.Value.Ikonica = new BitmapImage(new Uri(l.Value.IkonicaS));
                        if (l.Value.DatumOdrzavanjaZaTekucuGodinuString != null)
                        {
                            string[] datumArray = l.Value.DatumOdrzavanjaZaTekucuGodinuString.Split("/");
                            string[] datumArray2 = datumArray[2].Split(" ");
                            DateTime datum = new DateTime(int.Parse(datumArray2[0]), int.Parse(datumArray[0]), int.Parse(datumArray[1]));
                            l.Value.DatumOdrzavanjaZaTekucuGodinu = datum;
                        }
                        if (l.Value.IstorijaDatumaOdrzavanjaString != null)
                        {
                            foreach (string istorijaOdrzavanja in l.Value.IstorijaDatumaOdrzavanjaString)
                            {
                                string[] istorijaOdrzavanjaArray = istorijaOdrzavanja.Split("/");
                                string[] istorijaOdrzavanjaArray2 = istorijaOdrzavanja.Split(" ");
                                DateTime datumIstorijeOdrzavanja = new DateTime(Int32.Parse(istorijaOdrzavanjaArray2[0]), Int32.Parse(istorijaOdrzavanjaArray[0]), Int32.Parse(istorijaOdrzavanjaArray2[1]));
                                l.Value.IstorijaDatumaOdrzavanja.Add(datumIstorijeOdrzavanja);
                            }
                        }
                    }
                }
                catch
                {
                    // 
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
            else
                _r = new Dictionary<Guid, Dogadjaj>();
        }

        public Dictionary<Guid, Dogadjaj> getAll()
        {
            return _r;
        }
    }
}
