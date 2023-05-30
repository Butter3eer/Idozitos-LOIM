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
        DispatcherTimer szinTimer = new DispatcherTimer();
        DispatcherTimer kerdesekTimer = new DispatcherTimer();
        int kattintasok = 0;
        int pontok = 0;

        public MainWindow()
        {
            InitializeComponent();
            Beolvas();

            idoBoxTimer.Interval = TimeSpan.FromSeconds(1);
            idoBoxTimer.Tick += Szamlalo;

            szinTimer.Interval = TimeSpan.FromSeconds(1);
            szinTimer.Tick += Megallo;

            kerdesekTimer.Interval = TimeSpan.FromSeconds(0.5);
            kerdesekTimer.Tick += KerdesReset;
            Idomegy.Text = "31";
        }

        private void KerdesReset(object? sender, EventArgs e)
        {
            if (kuldo is not null)
            {
                Ellenorzes(kuldo);
            }
            Szovegek(kattintasok);
        }

        private void Megallo(object? sender, EventArgs e)
        {
            idoBoxTimer.Start();
            kerdesekTimer.Start();
            (kuldo as Button).Background = SystemColors.ControlBrush;
            foreach (var item in kerdesGrid.Children)
            {
                if (item is Button)
                {
                    if ((item as Button).Name == lista[kattintasok].HelyesValasz)
                    {
                        (item as Button).Background = SystemColors.ControlBrush;
                    }
                }
            }
            kuldo = null;
            kattintasok++;
            szinTimer.Stop();
            Idomegy.Text = "30";
        }

        public void Szamlalo(object? sender, EventArgs e)
        {
            Szamol(); 
        }

        public void Szamol()
        {
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
            kerdesekTimer.Start();
        }

        public void Szovegek(int index)
        {
            if (index < lista.Count)
            {
                Kerdesek item = lista[index];
                  
                Kerdes.Text = item.Id + ". " + item.Kerdes;
                TBA.Text = item.ValaszA;
                TBB.Text = item.ValaszB;
                TBC.Text = item.ValaszC;
                TBD.Text = item.ValaszD;
            }
            else 
            {
                kerdesekTimer.Stop();
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
                (sender as Button).Background = Brushes.Olive;
                szinTimer.Start();
                kerdesekTimer.Stop();
                idoBoxTimer.Stop();
                pontok++;
            }
            else
            {
                (sender as Button).Background = Brushes.Salmon;
                foreach (var item in kerdesGrid.Children)
                {
                    if (item is Button)
                    {
                        if ((item as Button).Name == lista[kattintasok].HelyesValasz)
                        {
                            (item as Button).Background = Brushes.Olive;
                        }
                    }
                }
                szinTimer.Start();
                kerdesekTimer.Stop();
                idoBoxTimer.Stop();
            }  
        }
    }
}
