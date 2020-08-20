using System;
using System.Collections.Generic;
using System.Drawing;
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
using Org.BouncyCastle.Asn1.Crmf;
using Brushes = System.Windows.Media.Brushes;
using ComboBox = System.Windows.Controls.ComboBox;
using Label = System.Windows.Controls.Label;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Sorozatok
{
    /// <summary>
    /// Interaction logic for MainProg.xaml
    /// </summary>
    public partial class MainProg : Window
    {
        string user;
        bool utkozes = false;

        List<Sorozat> lists = new List<Sorozat>();
        List<Sorozat> favs = new List<Sorozat>();

        List<Movies> listm = new List<Movies>();
        List<Movies> favm = new List<Movies>();

        string typevalue = "";

        public MainProg(string username)
        {
            InitializeComponent();
            user = username;
            display.Background = Brushes.Red;
            DisplaySeries();
            type.Text = "Nézet";
            type.Items.Add("Filmek");
            type.Items.Add("Sorozatok");
            type.Items.Add("Kedvencek");
            type.Items.Add("Összes");
        }

        public MainProg(List<Sorozat> fs)
        {
            favs = fs;
        }

        private void DisplaySeries()
        {
            if (Connection.FillListS(ref lists,user))
            {
                display.Height = 10;
                int x = 10;
                int y = 10;

                for (int i = 0; i < lists.Count; i++)
                {
                    if (x >= 561)
                    {
                        x = 10;
                        y += 250;
                    }

                    if (x == 10 && y >= display.Height - 250)
                    {
                        display.Height += 250;
                    }

                    if(x == 10 && y <= display.Height - 500)
                    {
                        display.Height -= 250;
                    }
                    lists[i].Margin = new Thickness(x,y,0,0);
                    
                    x += 200;
                    display.Children.Add(lists[i]);
                    lists[i].MouseLeftButtonDown += Click;
                    lists[i].MouseMove += MouseMove;
                    lists[i].MouseLeave += MouseLeave;
                }
            }
            else
            {
                Label label = new Label();
                string no = "Nincs sorozat a listádban!";
                label.Content = no;
                display.Children.Add(label);
            }
        }


        

        private void DisplayMovies()
        {
            if (Connection.FillListM(ref listm, user))
            {
                display.Height = 10;
                int x = 10;
                int y = 10;

                for (int i = 0; i < listm.Count; i++)
                {
                    if (x >= 561)
                    {
                        x = 10;
                        y += 250;
                    }

                    if (x == 10 && y >= display.Height - 250)
                    {
                        display.Height += 250;
                    }

                    if (x == 10 && y <= display.Height - 500)
                    {
                        display.Height -= 250;
                    }
                    lists[i].Margin = new Thickness(x, y, 0, 0);

                    x += 200;
                    display.Children.Add(listm[i]);
                    listm[i].MouseLeftButtonDown += Click;
                    listm[i].MouseMove += MouseMove;
                    listm[i].MouseLeave += MouseLeave;
                }
            }
            else
            {
                Label label = new Label();
                string no = "Nincs sorozat a listádban!";
                label.Content = no;
                display.Children.Add(label);
            }
        }

        private void DisplayAllContents()
        {
            
            int x = 10;
            int y = 10;
            display.Height = y;

            if (Connection.FillListM(ref listm, user))
            {
                for (int i = 0; i < listm.Count; i++)
                {
                    if (x >= 561)
                    {
                        x = 10;
                        y += 250;
                    }

                    if (x == 10 && y >= display.Height)
                    {
                        display.Height += 250;
                    }

                    if (x == 10 && y <= display.Height - 500)
                    {
                        display.Height -= 250;
                    }
                    lists[i].Margin = new Thickness(x, y, 0, 0);

                    x += 200;
                    display.Children.Add(listm[i]);
                    listm[i].MouseLeftButtonDown += Click;
                    listm[i].MouseMove += MouseMove;
                    listm[i].MouseLeave += MouseLeave;
                }
            }
            else
            {
                Label label = new Label();
                string no = "Nincs sorozat a listádban!";
                label.Content = no;
                display.Children.Add(label);
            }

            if (Connection.FillListS(ref lists, user))
            {
                int y2 = y + 140;
                MessageBox.Show(y2.ToString());
                for (int i = 0; i < lists.Count; i++)
                {
                    if (x >= 561)
                    {
                        x = 10;
                        y2 += 250;
                    }

                    if (x == 10 && y2 >= display.Height - 250)
                    {
                        display.Height += 250;
                    }

                    if (x == 10 && y2 <= display.Height - 500)
                    {
                        display.Height -= 250;
                    }
                    lists[i].Margin = new Thickness(x, y2, 0, 0);

                    x += 200;
                    display.Children.Add(lists[i]);
                    lists[i].MouseLeftButtonDown += Click;
                    lists[i].MouseMove += MouseMove;
                    lists[i].MouseLeave += MouseLeave;
                }
            }
            else
            {
                Label label = new Label();
                string no = "Nincs sorozat a listádban!";
                label.Content = no;
                display.Children.Add(label);
            }

        }


        private void DisplayFav()
        {

        }

        private void MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
           if(sender is Sorozat)
            {
                Sorozat move = sender as Sorozat;
                move.Background = display.Background;
            }
            else
            {
                Movies move = sender as Movies;
                move.Background = display.Background;
            }
        }

        private void MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Sorozat)
            {
                Sorozat move = sender as Sorozat;
                move.Background = Brushes.AliceBlue;
            }
            else
            {
                Movies move = sender as Movies;
                move.Background = Brushes.AliceBlue;
            }
        }

        private void Click(object sender, MouseButtonEventArgs e) // Sorozat szerkesztése
        {
            if(sender is Sorozat)
            {
                Sorozat selected = (sender as Sorozat);
                MessageBox.Show(selected.Nev);
                EditSeries s = new EditSeries(selected);
                s.ShowDialog();
                display.Children.Clear();
                Connection.FillListS(ref lists, user);
                DisplaySeries();
            }
            else
            {
                Movies selected = (sender as Movies);
                EditMovie s = new EditMovie();
                s.ShowDialog();
                display.Children.Clear();
                if(typevalue == "Filmek")
                    DisplayMovies();
                else if(typevalue == "Sorozatok")
                    DisplaySeries();
                else if(typevalue == "Összes")
                {
                    DisplayAllContents();
                }
                else
                {

                }
            }
                
        }

        private void button1_Click(object sender, RoutedEventArgs e) // Új sorozat hozzáadása
        {
            New s = new New(user);
            s.ShowDialog();
            display.Children.Clear();
            Connection.FillListS(ref lists, user);
            DisplaySeries();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) // Keresés
        {
            int x = 10;
            int y = 10;
            display.Children.Clear();
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].Nev.Contains(textBox1.Text))
                {
                    if (x >= 561)
                    {
                        x = 10;
                        y += 250;

                    }

                    if (x == 10 && y >= display.Height - 250)
                    {
                        display.Height += 250;
                    }
                    lists[i].Margin = new Thickness(x, y, 0, 0);
                    x += 200;
                    display.Children.Add(lists[i]);
                }
            }

            for (int i = 0; i < listm.Count; i++)
            {
                if (listm[i].Nev.Contains(textBox1.Text))
                {
                    if (x >= 561)
                    {
                        x = 10;
                        y += 250;
                    }

                    if (x == 10 && y >= display.Height - 250)
                    {
                        display.Height += 250;
                    }
                    listm[i].Margin = new Thickness(x, y, 0, 0);
                    x += 200;
                    display.Children.Add(listm[i]);
                }
            }
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e) // Nézet kiválasztása és eltárolása az adatbázisban
        {
            if (type.SelectedItem != null)
            {
                display.Children.Clear();
                Connection.InsertType(type.SelectedItem.ToString(), user);
                switch (type.SelectedItem)
                {
                    case "Filmek":
                        typevalue = "Filmek";
                        DisplayMovies();
                        break;
                    case "Sorozatok":
                        typevalue = "Sorozatok";
                        DisplaySeries();
                        break;
                    case "Kedvencek":
                        typevalue = "Kedvencek";

                        break;
                    case "Összes":
                        typevalue = "Összes";
                        DisplayAllContents();
                        break;
                }
            }
        }
    }
}
