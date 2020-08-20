using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Org.BouncyCastle.Crypto.Engines;
using Application = System.Windows.Forms.Application;
using ComboBox = System.Windows.Forms.ComboBox;
using MessageBox = System.Windows.Forms.MessageBox;
using Path = System.IO.Path;

namespace Sorozatok
{
    /// <summary>
    /// Interaction logic for NewSeries.xaml
    /// </summary>
    public partial class New : Window
    {
        string user;
        string path;
        string tipus;

        public New(string username)
        {
            InitializeComponent();
            user = username;
            type.Items.Add("Film");
            type.Items.Add("Sorozat");
            if(type.SelectedItem == null)
            {
                MessageBox.Show(n.FontSize.ToString());
                n.FontSize = 13;
                n.Content = "Típus kiválasztása";
                s.Visibility = Visibility.Hidden;
                e.Visibility = Visibility.Hidden;
                name1.Visibility = Visibility.Hidden;
                akt_evad.Visibility = Visibility.Hidden;
                akt_resz.Visibility = Visibility.Hidden;
                p.Visibility = Visibility.Hidden;
                button1.Visibility = Visibility.Hidden;
                button2.Visibility = Visibility.Hidden;
            }
        }

        private void name_Click(object sender, RoutedEventArgs e) // Add new series
        {
            if(img1.Source != null) // Ha választva van kép
            {
                if(tipus == "Film")
                {
                    Connection.InsertMovie(user,name1.Text, path);
                    MessageBox.Show("Sikeres film hozzáadása!");
                }
                else
                {
                    Connection.InsertSeries(user, name1.Text, akt_evad.Text, akt_resz.Text, path);
                    MessageBox.Show("Sikeres sorozat hozzáadása!");
                }
            }
            else // Alap kép beállítása
            {
                if (tipus == "Film")
                {
                    path = Application.StartupPath + @"\" + "nopicture.png";
                    path = path.Replace(@"\", @"\\");
                    MessageBox.Show(path);
                    Connection.InsertMovie(user,name1.Text, path);
                    MessageBox.Show("Sikeres film hozzáadása!");
                }
                else
                {
                    path = Application.StartupPath + @"\" + "nopicture.png";
                    path = path.Replace(@"\", @"\\");
                    Connection.InsertSeries(user, name1.Text, akt_evad.Text, akt_resz.Text, path);
                    MessageBox.Show("Sikeres sorozat hozzáadása!");
                }
            }
        }

        private void aktevad_TextChanged(object sender, TextChangedEventArgs e) // Check wether the user write numbers 
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(akt_evad.Text, "^[0-9]"))
            {
                akt_evad.Text = "";
            }
        }

        private void aktresz_TextChanged(object sender, TextChangedEventArgs e) // Same
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(akt_resz.Text, "^[0-9]"))
            {
                akt_resz.Text = "";
            }
        }

        private void akt_evad_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)))
            {
                //label7.Visibility = Visibility.Visible;
                akt_evad.Clear();
            }
            else
            {
                //label7.Visibility = Visibility.Hidden;
            }
        }

        private void akt_resz_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)))
            {
                //label7.Visibility = Visibility.Visible;
                akt_resz.Clear();
            }
            else
            {
                //label7.Visibility = Visibility.Hidden;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e) // Hozzáadás
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Kép kiválasztása";
            file.Filter = "Képfájlok | *.jpg;*.jpeg;*.png;";
            string source = "";
            string despath = "";
            if(file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                despath = Application.StartupPath + @"\";
                source = file.FileName;
                if (File.Exists(despath + Path.GetFileName(file.FileName))) // If the file already exists, we need to delete it first to copy.
                    File.Delete(despath + Path.GetFileName(file.FileName));
                File.Copy(source, despath + Path.GetFileName(file.FileName)); // Copy the file to bin               
                img1.Source = new BitmapImage(new Uri(file.FileName));
                path = Application.StartupPath + @"\" + Path.GetFileName(file.FileName);
                path = path.Replace(@"\", @"\\"); // Replace is essential because of \ sign.
            }
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs d)
        {
            ComboBox t = sender as ComboBox;
            switch (type.SelectedItem)
            {
                case "Film":
                    {
                        tipus = "Film";
                        n.FontSize = 18;
                        s.Visibility = Visibility.Hidden;
                        e.Visibility = Visibility.Hidden;
                        akt_evad.Visibility = Visibility.Hidden;
                        akt_resz.Visibility = Visibility.Hidden;
                        n.Content = "Film neve";
                        name1.Visibility = Visibility.Visible;
                        p.Visibility = Visibility.Visible;
                        button1.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                        button2.Content = "Film hozzáadása";
                        break;
                    }
                case "Sorozat":
                    {
                        tipus = "Sorozat";
                        n.FontSize = 18;
                        n.Content = "Sorozat neve";
                        s.Visibility = Visibility.Visible;             
                        e.Visibility = Visibility.Visible;
                        akt_evad.Visibility = Visibility.Visible;
                        akt_resz.Visibility = Visibility.Visible;
                        name1.Visibility = Visibility.Visible;
                        p.Visibility = Visibility.Visible;
                        button1.Visibility = Visibility.Visible;
                        button2.Visibility = Visibility.Visible;
                        button2.Content = "Sorozat hozzáadása";
                        break;
                    }
            }
        }
    }
}
