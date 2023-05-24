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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Idozitos_LOIM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Kerdesek> kerdesek = new List<Kerdesek>();
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer idoBoxTimer = new DispatcherTimer();
        string helyes = "";
        bool talalt = false;
        int pontok = 0;
        int index = 0;
        public MainWindow()
        {
            InitializeComponent();
            Beolvas();
            
            timer.Interval = TimeSpan.FromSeconds(11);
            timer.Tick += Game;

            idoBoxTimer.Interval = TimeSpan.FromSeconds(1);
            idoBoxTimer.Tick += Szamlalo;
        }

        public void Szamlalo(object? sender, EventArgs e)
        {
            Szamol();
        }

        public void Szamol()
        {  
            Idomegy.Text = (Convert.ToInt16(Idomegy.Text) - 1).ToString();
            if (int.Parse(Idomegy.Text) == 0)
            {
                idoBoxTimer.Stop();
            }    
        }

        public void Game(object? sender, EventArgs e)
        {
            if (talalt)
            {
                index++;
                idoBoxTimer.Stop();
            }
            else
            {
                Szovegek(index);
                index++;
            }
        }

        public void Beolvas()
        {
            kerdesek.Clear();
            StreamReader file = new StreamReader("kerdes.txt");
            while (!file.EndOfStream)
            {
                string[] reszek = file.ReadLine().Split(';');
                kerdesek.Add(new Kerdesek(int.Parse(reszek[0]), reszek[1], reszek[2], reszek[3], reszek[4], reszek[5], reszek[6], reszek[7]));
            }
            file.Close();   
            timer.Start();
        }

        public void Szovegek(int index)
        {
            if (index < kerdesek.Count)
            {
                Kerdesek item = kerdesek[index];

                Kerdes.Text = item.Kerdes;
                A.Content = item.ValaszA;
                B.Content = item.ValaszB;
                C.Content = item.ValaszC;
                D.Content = item.ValaszD;
                helyes = item.HelyesValasz;
                Idomegy.Text = "10";
                idoBoxTimer.Start();
            }
            else { timer.Stop(); }
        }

        public void ClickA(object sender, RoutedEventArgs e)
        {
            if (helyes == A.Name)
            {
                pontok++;
                pontLabel.Content = pontok.ToString();
                talalt = true;
                A.IsEnabled = false;
            }
            else
            {
                A.Background = Brushes.Red;
            }
        }

        public void ClickB(object sender, RoutedEventArgs e)
        {
            if (helyes == B.Name)
            {
                pontok++;
                pontLabel.Content = pontok.ToString();
                talalt = true;
                B.IsEnabled = false;
            }
            else
            {
                B.Background = Brushes.Red;
            }
        }

        public void ClickC(object sender, RoutedEventArgs e)
        {
            if (helyes == C.Name)
            {
                pontok++;
                pontLabel.Content = pontok.ToString();
                talalt = true;
                C.IsEnabled = false;
            }
            else
            {
                C.Background = Brushes.Red;
            }
        }

        public void ClickD(object sender, RoutedEventArgs e)
        {
            if (helyes == D.Name)
            {
                pontok++;
                pontLabel.Content = pontok.ToString();
                talalt = true;
                D.IsEnabled = false;
            }
            else
            {
                D.Background = Brushes.Red;
            }
        }
    }
}
