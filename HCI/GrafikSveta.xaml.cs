using HCI.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCI
{
    /// <summary>
    /// Interaction logic for GrafikSveta.xaml
    /// </summary>
    public partial class GrafikSveta : Window
    {
        private int EuCount=0;
        private int SACount=0;
        private int JACount=0;
        private int AzijaCount=0;
        private int AfrikaCount = 0;
        private int AustraliaCount = 0;
        private int NaN = 0;
        public GrafikSveta()
        {
            InitializeComponent();
            
            foreach(Dogadjaj d in MainWindow.ocDogadjaja)
            {
                if(d.P.X>332 && d.P.X<481 && d.P.Y>254 && d.P.Y<485)
                {
                    JACount += 1;
                }
                else if (d.P.X > 175 && d.P.X < 535 && d.P.Y > 25 && d.P.Y < 253)
                {
                    SACount += 1;
                }
                else if (d.P.X > 563 && d.P.X < 716 && d.P.Y > 63 && d.P.Y < 178)
                {
                    EuCount += 1;
                }
                else if (d.P.X > 748 && d.P.X < 1046 && d.P.Y > 40 && d.P.Y < 334)
                {
                    AzijaCount += 1;
                }
                else if (d.P.X > 512 && d.P.X < 747 && d.P.Y > 179 && d.P.Y < 417)
                {
                    AfrikaCount += 1;
                } 
                else if (d.P.X > 031 && d.P.X < 1118 && d.P.Y > 337 && d.P.Y < 450)
                {
                    AustraliaCount += 1;
                }
                else
                {
                    NaN += 1;
                }
            }
            LoadColumnChartData();
        }

        private void LoadColumnChartData()
        {
            ((ColumnSeries)mcChart.Series[0]).ItemsSource =
                new KeyValuePair<string, int>[]{
                    new KeyValuePair<string, int>("Evropa", EuCount),
                    new KeyValuePair<string, int>("Afrika", AfrikaCount),
                    new KeyValuePair<string, int>("Azija", AzijaCount),
                    new KeyValuePair<string, int>("S.Amerika", SACount),
                    new KeyValuePair<string, int>("J.Amerika", JACount),
                    new KeyValuePair<string, int>("Australija", AustraliaCount),
                    new KeyValuePair<string, int>("NaN", NaN) };
        }
    }
}
