using System;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;



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
        

        private void page2Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Page2));
        }
        


        private ThreadPoolTimer PeriodicTimer;


        private void Start1Button_Click(object sender, RoutedEventArgs e) //Käynnistää ajastimen palkan lisäämiselle
        {
            TimeSpan period = TimeSpan.FromSeconds(0.01);
            PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer(ElapsedHander, period, DestroydHandler);

        }

        private async void ElapsedHander(ThreadPoolTimer timer) //Ajaa progressbaria
        {
            // update UI
            await Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    // UI components can be accessed within this scope
                    PBar1.Value = PBar1.Value + 1;
                    if (PBar1.Value == 500) { palkka1TextBlock.Text = Ari.PalkanLasku(double.Parse(palkka1TextBlock.Text)).ToString(); PBar1.Value = 0; } //Lisää palkkaa joka 5. sekunti
                    PBar2.Value = PBar2.Value + 1;
                    if (PBar2.Value == 300) { palkka2TextBlock.Text = Narsu.PalkanLasku(double.Parse(palkka2TextBlock.Text)).ToString(); PBar2.Value = 0; } //Lisää palkkaa joka 3. sekunti
                    PBar3.Value = PBar3.Value + 1;
                    if (PBar3.Value == 100) { palkka3TextBlock.Text = Jarmo.PalkanLasku(double.Parse(palkka3TextBlock.Text)).ToString(); PBar3.Value = 0; } //Lisää palkkaa joka sekunti
                    PBar4.Value = PBar4.Value + 1;
                    if (PBar4.Value == 700) { palkka4TextBlock.Text = Mieskolainen.PalkanLasku(double.Parse(palkka4TextBlock.Text)).ToString(); PBar4.Value = 0; } //Lisää palkkaa 7. joka sekunti
                });
        }


        private void Stop1Button_Click(object sender, RoutedEventArgs e) //Lopettaa palkan lisäämisen Stop nappulasta
        {
            PeriodicTimer.Cancel();
        }

        private async void DestroydHandler(ThreadPoolTimer timer) //Pysäyttää progressbarin
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.High,
            () =>
            {
                // UI components can be accessed within this scope.
            });
        }
        
        private void palkkaa2Button_Click(object sender, RoutedEventArgs e) //Korvataan "Palkkaa" boxi opettajan palkanjuoksucontroleilla
        {

            LuoOpettaja(2);
            kakkosRelativePanel.Children.Remove(palkkaa2Button);
        }

        private void palkkaa3Button_Click(object sender, RoutedEventArgs e) //Korvataan "Palkkaa" boxi opettajan palkanjuoksucontroleilla
        {

            LuoOpettaja(3);
            kolmosRelativePanel.Children.Remove(palkkaa3Button);
        }
        
        private void palkkaa4Button_Click(object sender, RoutedEventArgs e) //Korvataan "Palkkaa" boxi opettajan palkanjuoksucontroleilla
        {
            LuoOpettaja(4);
            nelosRelativePanel.Children.Remove(palkkaa4Button);
        }

        public void LuoOpettaja(int numero)
        {

            switch (numero)
            {
                case 1:

                case 2:

                    nimi2TextBlock.Visibility = Visibility.Visible;
                    palkka2TextBlock.Visibility = Visibility.Visible;
                    Start2Button.Visibility = Visibility.Visible;
                    Stop2Button.Visibility = Visibility.Visible;
                    PBar2.Visibility = Visibility.Visible;
                    break;


                case 3:

                    nimi3TextBlock.Visibility = Visibility.Visible;
                    palkka3TextBlock.Visibility = Visibility.Visible;
                    Start3Button.Visibility = Visibility.Visible;
                    Stop3Button.Visibility = Visibility.Visible;
                    PBar3.Visibility = Visibility.Visible;
                    break;

                case 4:

                    nimi4TextBlock.Visibility = Visibility.Visible;
                    palkka4TextBlock.Visibility = Visibility.Visible;
                    Start4Button.Visibility = Visibility.Visible;
                    Stop4Button.Visibility = Visibility.Visible;
                    PBar4.Visibility = Visibility.Visible;
                    break;

            }
            
        
            

        }

    }
}
