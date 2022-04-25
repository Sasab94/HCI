using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HCI.model
{
    [Serializable]
    public class Dogadjaj
    {
        public Guid ID { get; set; }
        public string Oznaka { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Tip { get; set; }
        public string PosecenostDogadjaja { get; set; }
        public bool DaLiJeHumantiarnogKaraktera { get; set; }
        public string Cena { get; set; }
        public string DrzavaIGradKaoMestoOdrzavanja { get; set; }
        [NonSerialized]
        public List<DateTime> IstorijaDatumaOdrzavanja;
        public List<String> IstorijaDatumaOdrzavanjaString { get; set; }
        [NonSerialized]
        public DateTime DatumOdrzavanjaZaTekucuGodinu;
        public string DatumOdrzavanjaZaTekucuGodinuString { get; set; }
        [NonSerialized]
        public BitmapImage Ikonica;
        public string IkonicaS { get; set; }
        public List<string> ListaEtiketa { get; set; }
        public string ToolTipDogadjaj { get; set; }
        public bool Izmena { get; set; }
        public Point P { get; set; }
        public int RedniBrojNaCanvasu { get; set; }
        public bool prevucen = false;
        public Dictionary<string, string> ListaCekiranihEtiketa;
    }
}
