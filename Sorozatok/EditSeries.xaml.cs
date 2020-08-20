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
using System.Windows.Shapes;

namespace Sorozatok
{
    /// <summary>
    /// Interaction logic for EditSeries.xaml
    /// </summary>
    public partial class EditSeries : Window
    {
        string sname;
        int sakt_evad;
        int sakt_resz;
        string spath;
        List<Sorozat> favourite = new List<Sorozat>();

        public EditSeries(Sorozat p)
        {
            InitializeComponent();
            sname = p.Nev;
            sakt_evad = p.Akt_evad;
            sakt_resz = p.Akt_resz;
            spath = p.Path;
            
            label1.Content = sname;
            
            img1.Source = new BitmapImage(new Uri(spath));
            label2.Content = "Aktuális évad:" + sakt_evad.ToString();
            label3.Content = "Aktuális rész:" + sakt_resz.ToString();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (Connection.DeleteSeries(sname))
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e) // Szerkesztés
        {
            
            Connection.EditSeries(label1.Content.ToString(), textbox1.Text, textbox2.Text, textbox3.Text,spath);
            textbox1.Text = "";
            textbox2.Text = "";
            textbox3.Text = "";
        }

        private void textbox2_TextChanged(object sender, TextChangedEventArgs e) // Új évad
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textbox2.Text, "^[0-9]"))
            {
                textbox2.Text = "";
            }
        }

        private void textbox3_TextChanged(object sender, TextChangedEventArgs e) // Új rész
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textbox3.Text, "^[0-9]"))
            {
                textbox2.Text = "";
            }
        }

        private void textbox2_KeyDown(object sender, KeyEventArgs e)
        {
           if(!((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)))
           {
                label7.Visibility = Visibility.Visible;
                textbox2.Clear();
           }
           else
           {
                label7.Visibility = Visibility.Hidden;
           }
        }

        private void textbox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)))
            {
                label8.Visibility = Visibility.Visible;
                textbox3.Clear();
            }
            else
                label8.Visibility = Visibility.Hidden;
        }

        private void clickfav(object sender, RoutedEventArgs e)
        {
            favourite.Add(new Sorozat(sname, sakt_evad, sakt_resz, spath));
            Connection.InsertFavS(sname);
            MainProg s = new MainProg(favourite);
            MessageBox.Show("Ez a sorozat már a kedvencekben is szerepel!");
        }
    }
}
