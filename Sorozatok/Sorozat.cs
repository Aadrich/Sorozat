using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Brushes = System.Windows.Media.Brushes;
using Cursors = System.Windows.Input.Cursors;
using FontFamily = System.Drawing.FontFamily;
using Image = System.Windows.Controls.Image;
using Label = System.Windows.Controls.Label;
using MessageBox = System.Windows.MessageBox;

namespace Sorozatok
{
    public class Sorozat : StackPanel
    {
        string name;
        int akt_evad;
        int akt_resz;
        string path;
        
        Image img { get; set; }
        Label nameinfo { get; set; }
        Label aktualisok { get; set; }

        public Sorozat(string name,int akt_evad,int akt_resz,string path)
        {
            this.Width = 150;
            this.Height = 234;
            this.VerticalAlignment = VerticalAlignment.Top;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            
            this.name = name;
            this.akt_evad = akt_evad;
            this.akt_resz = akt_resz;
            this.path = path;

            
     
            nameinfo = new Label();
           /*
            if (name.Length > 14)
                name = name.Replace(" ", "\n"); 
                */
            nameinfo.Content = name;
            nameinfo.Margin = new Thickness(0, 0, 0, 0);
            nameinfo.Width = 150;
            nameinfo.Height = 28;
            nameinfo.FontFamily = new System.Windows.Media.FontFamily("Microsoft Sans Serrif");
            //temp
            if (name.Length > 15)
                nameinfo.FontSize = 14;
            else
                nameinfo.FontSize = 16;
            this.Children.Add(nameinfo);
            
            img = new Image();
            img.Source = new BitmapImage(new Uri(path));
            img.Width = 150;
            img.Height = 182;
            img.Margin = new Thickness(0, 0, 0, 0);
            img.Stretch = Stretch.Uniform;
            this.Children.Add(img);

            aktualisok = new Label();
            aktualisok.Content = akt_evad.ToString() + ".évad " + akt_resz.ToString() + ".rész";
            aktualisok.Margin = new Thickness(0, 0, 0, 0);
            aktualisok.Width = 150;
            aktualisok.Height = 26;
            aktualisok.FontFamily = new System.Windows.Media.FontFamily("Microsoft Sans Serrif");
            aktualisok.FontSize = 16;
            this.Children.Add(aktualisok);
            

            this.Cursor = Cursors.Hand;
        }

        public string Nev
        {
            get { return name; }
            set { name = value; }
        }

        public int Akt_evad
        {
            get { return akt_evad; }
            set { akt_evad = value; }
        }

        public int Akt_resz
        {
            get { return akt_resz; }
            set { akt_resz = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
    }
}
