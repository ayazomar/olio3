using System;
using System.Collections.Generic;
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

namespace Harjoitus_23
{
    public partial class MainWindow : Window
    {
        private Valinta valinta = Valinta.Lämpötila;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void NumPadBtn_Click(object sender, RoutedEventArgs e)
        {
            Button buttonPressed = (Button)sender;

            if (buttonPressed.Content.Equals("Enter"))
            {
                SetValues();
            }
            else if (buttonPressed.Content.Equals("<"))
            {
                try
                {
                    numPadInput.Text = numPadInput.Text.Substring(0, numPadInput.Text.Length - 1);

                }
                catch (Exception)
                {
                    activityMessage.Text = "Syöttökenttä on tyhjä";
                }
            }
            else
            {
                if (numPadInput.Text.Equals("0") && buttonPressed.Content.ToString().Equals("0"))
                    return;

                if (numPadInput.Text.Equals("0"))
                {
                    numPadInput.Text = buttonPressed.Content.ToString();
                }
                else
                {
                    numPadInput.Text += buttonPressed.Content;
                }
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Content.Equals("Lämpötila"))
            {
                valinta = Valinta.Lämpötila;
            }
            else
            {
                valinta = Valinta.Kosteus;
            }

            activityMessage.Text = "Muokataan " + valinta.ToString() + " arvoja";
        }
        private void SetValues()
        {
            int input = 0;

            try
            {
                input = int.Parse(numPadInput.Text);
            }
            catch (Exception)
            {
                activityMessage.Text = "Syöttökenttä on tyhjä";
                return;
            }

            switch (valinta)
            {
                case Valinta.Lämpötila:
                    if (input > 120 || input < 0)
                    {
                        activityMessage.Text = "olet laittanut virheellinen lämpötila arvo,, lämpötilan pitää olla 0-120 väliltä";
                        return;
                    }
                    else
                    {
                        temperatureField.Text = numPadInput.Text;
                    }
                    break;
                case Valinta.Kosteus:
                    if (input > 100 || input < 0)
                    {
                        activityMessage.Text = "virheellinen kosteus arvo,, kosteus pitää olla väliltä 0-100";
                        return;
                    }
                    else
                    {
                        humidityField.Text = numPadInput.Text;
                    }
                    break;
            }

            numPadInput.Text = "";
        }
    }
}
public enum Valinta
{
    Lämpötila,
    Kosteus
}