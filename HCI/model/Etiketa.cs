using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HCI.model
{
    [Serializable]
    public class Etiketa
    {
        public string OznakaEtikete { get; set; }
        public Guid ID { get; set; }
        [NonSerialized]
        public Color Boja;
        public string BojaS { get; set; }
        public string OpisEtikete { get; set; }
        public bool PostojiDogadjajSaOvomEtiketom { get; set; }
        public bool Izmena { get; set; }

        public Etiketa()
        {
            this.PostojiDogadjajSaOvomEtiketom = false;
            this.Izmena = false;
        }
    }
}
