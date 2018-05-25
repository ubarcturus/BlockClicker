using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockClicker
{
    public partial class BlockClickerForm : Form
    {
        Timer countdownTimer = new Timer(); //Timer deklarieren

        public BlockClickerForm()
        {
            InitializeComponent();

            this.countdownTimer.Interval = 1000; //Timer Intervall festlegen

            this.countdownTimer.Tick += CountdownTimer_Tick; //festlegen was passiert, wenn der Timer abgelaufen ist

            this.countdownTimer.Start(); //Timer starten
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            double elapsedTime = this.countdownTimer.Interval / 1000.0; //verstrichene Zeit berechnen
            double newTime = Convert.ToDouble(lblTimer.Text) - elapsedTime; //aktuelle Zeit berechnen

            BlockClickerForm_Load(sender, e); //neue Blöcke erzeugen

            lblTimer.Text = newTime.ToString(); //neue Zeit auf Benutzeroberfläche ausgeben

            if (newTime <= 0) //wenn Zeit abgelaufen
            {
                this.countdownTimer.Stop(); //Timer stoppen

                MessageBox.Show(this, "Zeit abgelaufen."); //Nachricht ausgeben
            }

        }

        private void BlockClickerForm_Load(object sender, EventArgs e)
        {
            Random zufall = new Random(); //Zufallsgenerator

            for (int i = 0; i < 3; i++) //Schleife
            {
                Label newBlock = new Label(); //neues Label erzeugen

                newBlock.AutoSize = false; //Text entfernen
                newBlock.Text = "";

                newBlock.Top = zufall.Next(0, 300); //zufällige Position setzen
                newBlock.Left = zufall.Next(0, 300);

                newBlock.Width = 50; //Breite und Höhe setzen
                newBlock.Height = 25;

                //newBlock.BackColor = Color.Red;                           //Farbe setzen
                newBlock.BackColor =
                    Color.FromArgb( //Ersatz der oberen Zeile, um die Farben der Blöcke zufällig zu wählen
                        zufall.Next(255), //zufälliger Rotanteil
                        zufall.Next(255), //zufälliger Blauanteil
                        zufall.Next(255)); //zufälliger Grünanteil

                newBlock.Click += NewBlockOnClick; //Aufruf der Klick-Aktion

                Controls.Add(newBlock); //Block zur Form hinzufügen
            }
        }

        private void NewBlockOnClick(object sender, EventArgs eventArgs)
        {
 
            int newScore = Convert.ToInt32(this.lblScore.Text) + 1; //neue Punktzahl berechnen

            this.lblScore.Text = newScore.ToString(); //neue Punktzahl anzeigen

            this.Controls.Remove((Label) sender); //Block von der Anzeige entfernen
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}