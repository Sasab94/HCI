using HCI.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HCI.repo
{
    public class RepozitorijumTipa
    {
        private Dictionary<Guid, Tip> _r = new Dictionary<Guid, Tip>();
        private readonly string _datoteka;

        public RepozitorijumTipa()
        {
            _datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repozitorijumTipaTest.podaci");
            UcitajDatoteku();
        }

        public void Dodaj(Tip o)
        {
            if (o.ID == Guid.Empty)
                o.ID = Guid.NewGuid();
            if (!_r.ContainsKey(o.ID))
                _r.Add(o.ID, o);
            MemorisiDatoteku();
        }

        public void Obrisi(Tip o)
        {
            foreach (KeyValuePair<Guid, Tip> key in _r)
            {
                if (key.Value.OznakaTipa.Equals(o.OznakaTipa))
                {
                    _r.Remove(key.Key);
                }
            }
            MemorisiDatoteku();
        }

        public Tip this[Guid g]
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

        private void MemorisiDatoteku()
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

        private void UcitajDatoteku()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(_datoteka))
            {
                try
                {
                    stream = File.Open(_datoteka, FileMode.Open);
                    _r = (Dictionary<Guid, Tip>)formatter.Deserialize(stream);
                    foreach (KeyValuePair<Guid, Tip> l in _r)
                    {
                        l.Value.IkonicaTipa = new BitmapImage(new Uri(l.Value.IkonicaSTipa));
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
                _r = new Dictionary<Guid, Tip>();
        }

        public Dictionary<Guid, Tip> getAll()
        {
            return _r;
        }

        public void izmeni(Guid g, Tip e)
        {
            _r[g] = e;
            MemorisiDatoteku();
        }
    }
}
