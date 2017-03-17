using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace harkkatyo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Opettaja Ari = new Opettaja("Ari", 2000);
        Opettaja Narsu = new Opettaja("Narsu", 5);
        Opettaja Jarmo = new Opettaja("Jarmo", 3000);
        Opettaja Mieskolainen = new Opettaja("Matti", 100000);
        
        
        public MainPage()
        {
            this.InitializeComponent();
            nimi1TextBlock.Text = Ari.Nimi;
            palkka1TextBlock.Text = Ari.Palkka.ToString();
            nimi2TextBlock.Text = Narsu.Nimi;
            palkka2TextBlock.Text = Narsu.Palkka.ToString();
            nimi3TextBlock.Text = Jarmo.Nimi;
            palkka3TextBlock.Text = Jarmo.Palkka.ToString();
            nimi4TextBlock.Text = Mieskolainen.Nimi;
            palkka4TextBlock.Text = Mieskolainen.Palkka.ToString();

        }

        private void addPalkka1Button_Click(object sender, RoutedEventArgs e)
        {
            double muuttuja = double.Parse(palkka1TextBlock.Text);
            palkka1TextBlock.Text = Ari.PalkanLasku(muuttuja).ToString();
        }

        private void addPalkka2Button_Click(object sender, RoutedEventArgs e)
        {
            double muuttuja = double.Parse(palkka2TextBlock.Text);
            palkka2TextBlock.Text = Narsu.PalkanLasku(muuttuja).ToString();
        }

        private void addPalkka3Button_Click(object sender, RoutedEventArgs e)
        {
            double muuttuja = double.Parse(palkka3TextBlock.Text);
            palkka3TextBlock.Text = Jarmo.PalkanLasku(muuttuja).ToString();
        }

        private void addPalkka4Button_Click(object sender, RoutedEventArgs e)
        {
            double muuttuja = double.Parse(palkka4TextBlock.Text);
            palkka4TextBlock.Text = Mieskolainen.PalkanLasku(muuttuja).ToString();
        }
    }
}
