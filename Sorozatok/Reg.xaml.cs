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
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            Connection.Insert(textBox1, passwordBox1);
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e) 
        {
            this.Close();
        }
    }
}
