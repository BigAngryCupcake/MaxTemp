using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace MaxTemp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Diese Routine (EventHandler des Buttons Auswerten) liest die Werte
        /// zeilenweise aus der Datei temps.csv aus, merkt sich den höchsten Wert
        /// und gibt diesen auf der Oberfläche aus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAuswerten_Click(object sender, RoutedEventArgs e)
        {
            //Zugriff auf Datei erstellen.

            //int zahl1 = 0;

            //lblAusgabe.Content = string.Empty;

            FileStream fs = new FileStream(@"temps.csv", FileMode.Open);

            StreamReader sr = new StreamReader(fs);

            string Teile = sr.ReadLine(); //auslesen von der excel

            string[] zahl = Teile.Split(','); //string ZERHAKEN von 0-1

            double temp = Double.Parse(zahl[2], CultureInfo.InvariantCulture);

            double tempmax = temp;
            double tempmin = temp;

            int zeilen = 0;
            double alles = 0;
            double average = 0;

            //grad = grad.Replace('.', ',');

            while (sr.EndOfStream == false)
            {
                string Teile1 = sr.ReadLine(); //auslesen von der excel

                string[] zahl1 = Teile1.Split(','); //string ZERHAKEN von 0-1

                double temp1 = Double.Parse(zahl1[2], CultureInfo.InvariantCulture);

                // if zum vergleichen der größe der zahlen



                if (tempmax < temp1)
                {
                    tempmax = temp1;
                }


                if (tempmin > temp1)
                {
                    tempmin = temp1;
                }

                alles = alles + temp1;

                // tempstring = Convert.ToString(tempmax, CultureInfo.CurrentCulture); //Convertiert es in einen String damit da ein Komma steht

                //string tempstringmin = Convert.ToString(tempmin, CultureInfo.CurrentCulture);




                zeilen = zeilen + 1;


                average = alles / zeilen;




                // lblAusgabe.Content = sr.ReadLine() + zahl[2] + " °C " + Environment.NewLine; //zeilenausgabe


            }

            lblAusgabe.Content = "Maximale Temperatur von: " + tempmax + " °C" + Environment.NewLine + "Minimale Temperatur von: " + tempmin + " °C" +
            Environment.NewLine + "Durschnitts Temperatur von: " + average + " °C"; //gibt den 3 teil aus

            sr.Close();
            fs.Close();
            //Ganz wichtig! Resourcen freigeben.

            //Anfangswert setzen, um sinnvoll vergleichen zu können.


            //In einer Schleife die Werte holen und auswerten. Den größten Wert "merken".


            //Datei wieder freigeben.


            //Höchstwert auf Oberfläche ausgeben.

            MessageBox.Show("Du hast den Knopf Toll gedrückt");
            //kommentieren Sie die Exception aus.
            //throw new Exception("peng");
        }
    }
}
