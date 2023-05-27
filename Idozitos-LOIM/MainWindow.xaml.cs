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
        
        List<Kerdesek> lista = new List<Kerdesek>();
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer idoBoxTimer = new DispatcherTimer();
        int kattintasok = 0;
        int pontok = 0;

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
            Szovegek(kattintasok);
            kattintasok++;
        }

        public void Beolvas()
        {
            lista.Clear();
            StreamReader file = new StreamReader("kerdes.txt");
            while (!file.EndOfStream)
            {
                string[] reszek = file.ReadLine().Split(';');
                lista.Add(new Kerdesek(int.Parse(reszek[0]), reszek[1], reszek[2], reszek[3], reszek[4], reszek[5], reszek[6], reszek[7]));
            }
            file.Close();   
            timer.Start();
        }

        public void Szovegek(int index)
        {
            if (index < lista.Count)
            {
                Kerdesek item = lista[index];
                  
                Kerdes.Text = item.Kerdes;
                A.Content = item.ValaszA;
                B.Content = item.ValaszB;
                C.Content = item.ValaszC;
                D.Content = item.ValaszD;

                Idomegy.Text = "10";
                idoBoxTimer.Start();
            }
            else { timer.Stop(); }
        }

        public void ClickA(object sender, RoutedEventArgs e)
        {
            if (A.Content.ToString() == lista[kattintasok].HelyesValasz)
            {
                kattintasok++;
                pontok++;
                pontLabel.Content = pontok.ToString();
                A.IsEnabled = false;
                timer.Stop();
            }
            else
            {
                kattintasok++;
                A.IsEnabled = false;
                timer.Stop();
            }
        }

        public void ClickB(object sender, RoutedEventArgs e)
        {
            if (B.Content.ToString() == lista[kattintasok].HelyesValasz)
            {
                kattintasok++;
                pontok++;
                pontLabel.Content = pontok.ToString();
                B.IsEnabled = false;
                timer.Stop();
            }
            else
            {
                kattintasok++;
                B.IsEnabled = false;
                timer.Stop();
            }
        }

        public void ClickC(object sender, RoutedEventArgs e)
        {
            if (C.Content.ToString() == lista[kattintasok].HelyesValasz)
            {
                kattintasok++;
                pontok++;
                pontLabel.Content = pontok.ToString();
                C.IsEnabled = false;
                timer.Stop();
            }
            else
            {
                kattintasok++;
                C.IsEnabled = false;
                timer.Stop();
            }
        }

        public void ClickD(object sender, RoutedEventArgs e)
        {
            if (D.Content.ToString() == lista[kattintasok].HelyesValasz)
            {
                kattintasok++;
                pontok++;
                pontLabel.Content = pontok.ToString();
                D.IsEnabled = false;
                timer.Stop();
            }
            else
            {
                kattintasok++;
                D.IsEnabled = false;
                timer.Stop();
            }
        }
    }
}
