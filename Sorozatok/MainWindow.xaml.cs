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

namespace Sorozatok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void log_Click(object sender, RoutedEventArgs e)
        {
            if(Connection.Login(textBox1, passwordBox1))
            {
                MainProg s = new MainProg(textBox1.Text);
                this.Hide();
                s.Show();
                
            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            Reg s = new Reg();
            s.ShowDialog();
        }

        private void log_MouseMove(object sender, MouseEventArgs e)
        {
            log.Foreground = Brushes.Gray;
        }

        private void log_MouseLeave(object sender, MouseEventArgs e)
        {
            log.Foreground = Brushes.Black;
        }


        private void reg_MouseLeave(object sender, MouseEventArgs e)
        {
            reg.Foreground = Brushes.Black;
        }

        private void reg_MouseMove(object sender, MouseEventArgs e)
        {
            reg.Foreground = Brushes.Gray;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainProg s = new MainProg(textBox1.Text);
            this.Hide();
            s.Show();
        }
    }
}
