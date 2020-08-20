using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;
using Label = System.Windows.Controls.Label;

namespace Sorozatok
{
    class Movies : StackPanel
    {
        string name;
        string path;

        Image img { get; set; }
        Label nameinfo { get; set; }

        public Movies(string name,string path)
        {
            this.Width = 150;
            this.Height = 234;
            this.VerticalAlignment = VerticalAlignment.Top;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

            this.name = name;
            this.path = path;

            nameinfo = new Label();
            nameinfo.Content = name;
            nameinfo.Margin = new Thickness(0, 0, 0, 0);
            nameinfo.Width = 150;
            nameinfo.Height = 28;
            nameinfo.FontFamily = new System.Windows.Media.FontFamily("Microsoft Sans Serrif");
            this.Children.Add(nameinfo);

            img = new Image();
            img.Source = new BitmapImage(new Uri(path));
            img.Width = 150;
            img.Height = 182;
            img.Margin = new Thickness(0, 0, 0, 0);
            img.Stretch = Stretch.Uniform;
            this.Children.Add(img);

            this.Cursor = Cursors.Hand;
        }

        public string Nev
        {
            get { return name; }
            set { name = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
    }
}
