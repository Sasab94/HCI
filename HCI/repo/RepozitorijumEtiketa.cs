using HCI.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HCI.repo
{
    public class RepozitorijumEtiketa
    {
        private Dictionary<Guid, Etiketa> _r = new Dictionary<Guid, Etiketa>();
        private readonly string _datoteka;

        public RepozitorijumEtiketa()
        {
            _datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repozitorijumEtiketaTest.podaci");
            UcitajDatoteku();
        }

        public void Dodaj(Etiketa o)
        {
            if (o.ID == Guid.Empty)
                o.ID = Guid.NewGuid();
            if (!_r.ContainsKey(o.ID))
                _r.Add(o.ID, o);
            MemorisiDatoteku();
        }

        public void Obrisi(Etiketa o)
        {
            foreach (KeyValuePair<Guid, Etiketa> key in _r)
            {
                if (key.Value.OznakaEtikete.Equals(o.OznakaEtikete))
                {
                    _r.Remove(key.Key);
                }
            }
            MemorisiDatoteku();
        }

        public Etiketa this[Guid g]
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
                    _r = (Dictionary<Guid, Etiketa>)formatter.Deserialize(stream);
                    foreach (KeyValuePair<Guid, Etiketa> e in _r)
                    {
                        e.Value.Boja = (Color)ColorConverter.ConvertFromString(e.Value.BojaS);
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
                _r = new Dictionary<Guid, Etiketa>();
        }

        public Dictionary<Guid, Etiketa> getAll()
        {
            return _r;
        }

        public void izmeni(Guid g, Etiketa e)
        {
            _r[g] = e;
            MemorisiDatoteku();
        }
    }
}
