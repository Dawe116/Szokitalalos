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
using Szokitalalos.Controllers;

namespace Szokitalalos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string szo = "farcry";
        static int db = 0;
        static  int hibaSzam = 0;
        static int MaxHiba = 11;
        public MainWindow()
        {
            
            InitializeComponent();
            

        }

        public static void GenerateWord()
        {
            List<string> list = new SzoController().SzoListFromFile();
            Random rnd = new Random();
            szo = list[rnd.Next(list.Count)]; 
        }

        private void Jatekterinit(object sender, RoutedEventArgs e)
        {
            GenerateWord();
            db = 0;
            myStack.Children.Clear();
            foreach (char item in szo)
            {

                FeladvanyButton newButton = new FeladvanyButton()
                {
                    
                    Tartalom = item.ToString(),
                    Content = "_",
                    Width = 50,
                    Height = 50

                };
                myStack.Children.Add(newButton);
            }
        }

        private void TippClick(object sender, RoutedEventArgs e)
        {
            db++;
            bool talalt = false;
            foreach (FeladvanyButton item in myStack.Children)
            { 
                if (item.Tartalom.ToLower() == (sender as Button).Content.ToString())
                {

                    ItStart.IsEnabled = false;
                    item.Felfed();
                    talalt = true;
                }
            }
            if (!talalt)
            {
                MessageBox.Show("Hiba");
                hibaSzam++;
                BitmapImage newImg = new BitmapImage();
                newImg.BeginInit();
                newImg.UriSource = new Uri($"\\Images\\{hibaSzam}.png", UriKind.Relative);
                newImg.EndInit();
                imgFa.Source = newImg;

            }
            if (End())
            {
                if (hibaSzam < MaxHiba)
                {
                    MessageBox.Show($"Ügyi vagy! A kitaláltad a {szo},\n Tippek száma: {db}");
                    Rogzit newWindow = new Rogzit();
                    newWindow.Tipps = db;
                    newWindow.ShowDialog();
                    

                }
                else
                {
                    MessageBox.Show($"Sajnos  vesztettél. Tippek száma: {hibaSzam}");
                    foreach (FeladvanyButton item in myStack.Children)
                    {
                        ItStart.IsEnabled = false;
                        item.Felfed();

                    }
                }
                ItStart.IsEnabled = true;
            }
            ItDB.Header = $"Tippek: {db}";
        }

        private bool End()
        {
            foreach(FeladvanyButton item in myStack.Children)
            {
    
                if (item.Content.ToString() == "_" && hibaSzam < MaxHiba)
                    return false;
            }
            return true;
        }


    }
}
