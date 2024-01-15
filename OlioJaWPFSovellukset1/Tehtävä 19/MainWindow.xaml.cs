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
namespace Tehtävä_19
{
    public partial class MainWindow : Window
    {
        private int tämäKerros = 1;
        public MainWindow()
        {
            InitializeComponent();
            PäivitäTämänKerroksenTeksti();
        }
        private void MoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(valitsemasiKerrosTextBox.Text, out int valitsemasiKerros))
            {
                if (valitsemasiKerros >= 1 && valitsemasiKerros <= 6)
                {
                    if (valitsemasiKerros == tämäKerros)
                    {
                        MessageBox.Show("Olet jo valitsemassasi kerroksessa.");
                    }
                    else
                    {
                        MessageBox.Show("Liikut hissillä kerrokseen: " + valitsemasiKerros);
                        tämäKerros = valitsemasiKerros;
                        PäivitäTämänKerroksenTeksti();
                    }
                }
                else
                {
                    MessageBox.Show("Virheellinen syöte. Valitse kerros 1-6 väliltä.");
                }
            }
            else
            {
                MessageBox.Show("Virheellinen syöte. Valitse kerros 1-6 väliltä.");
            }
        }
        private void PäivitäTämänKerroksenTeksti()
        {
            tämäKerrosTextBlock.Text = tämäKerros.ToString();
        }
    }
}