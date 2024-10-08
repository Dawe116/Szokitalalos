using System;
using System.Collections.Generic;
using System.IO;
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

namespace Szokitalalos
{
    /// <summary>
    /// Interaction logic for Rogzit.xaml
    /// </summary>
    public partial class Rogzit : Window
    {
        public int Tipps { get; set; }
        public Rogzit()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter kimenet = new StreamWriter("ranglista.txt");

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
