using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HCI.model
{
    [Serializable]
    public class Tip
    {
        public string OznakaTipa { get; set; }
        public string NazivTipa { get; set; }
        public string OpisTipa { get; set; }
        [NonSerialized]
        public BitmapImage IkonicaTipa;
        public string IkonicaSTipa { get; set; }
        public Guid ID { get; set; }
        public bool Izmena { get; set; }
        public bool PostojiDogadjajSaOvimTipom { get; set; }

        public Tip()
        {
            this.PostojiDogadjajSaOvimTipom = false;
            this.Izmena = false;
        }
    }
}
