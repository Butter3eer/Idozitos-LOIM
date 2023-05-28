using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        object kuldo;
        List<Kerdesek> lista = new List<Kerdesek>();
        DispatcherTimer idoBoxTimer = new DispatcherTimer();
        int kattintasok = 0;
        int pontok = 0;

        public MainWindow()
        {
            InitializeComponent();
            Beolvas();

            idoBoxTimer.Interval = TimeSpan.FromSeconds(1);
            idoBoxTimer.Tick += Szamlalo;
            Idomegy.Text = "31";
        }

        public void Szamlalo(object? sender, EventArgs e)
        {
            Szamol(); 
        }

        public void Szamol()
        {
            if (kuldo is not null)
            {
                Ellenorzes(kuldo);
                kuldo = null;
            }

            Szovegek(kattintasok);

            Idomegy.Text = (Convert.ToInt16(Idomegy.Text) - 1).ToString();
            pontLabel.Content = pontok.ToString();

            if (int.Parse(Idomegy.Text) == 0)
            {
                kattintasok++;
            }
            if (int.Parse(Idomegy.Text) == -1)
            {
                Idomegy.Text = "30";
            }
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
            idoBoxTimer.Start();
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
            }
            else 
            {
                idoBoxTimer.Stop();
                MessageBox.Show($"Vége a játéknak! Pontszámod: {pontok}");
            }
        }

        public void ClickA(object sender, RoutedEventArgs e)
        {
            kuldo = sender;
        }

        public void ClickB(object sender, RoutedEventArgs e)
        {
            kuldo = sender;
        }

        public void ClickC(object sender, RoutedEventArgs e)
        {
            kuldo = sender;
        }

        public void ClickD(object sender, RoutedEventArgs e)
        {
            kuldo = sender;
        }

        public void Ellenorzes(object sender)
        { 
            if ((sender as Button).Name == lista[kattintasok].HelyesValasz)
            {
                kattintasok++;
                pontok++;    
            }
            else
            {
                kattintasok++;
            }
            Idomegy.Text = "31";
        }
    }
}
