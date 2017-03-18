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

        //TÄSTÄ ALASPÄIN ON ADDPALKKAXBUTTON:IEN KOODIT

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

        private void page2Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Page2));
        }


        //TÄSTÄ ETEENPÄIN TULEE PROGRESSBAR1:N KOODIT
        //Timerit vaatii namespacet:
        //using System;
        //using Windows.UI.Core;
        //using Windows.UI.Xaml;
        //using Windows.UI.Xaml.Controls;
        //using Windows.System.Threading;



        private ThreadPoolTimer PeriodicTimer;


        private void StartButton_Click(object sender, RoutedEventArgs e) //Käynnistää ajastimen palkan lisäämiselle
        {
            TimeSpan period = TimeSpan.FromSeconds(1);
            PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer(ElapsedHander, period, DestroydHandler);

        }


        private async void ElapsedHander(ThreadPoolTimer timer)
        {
            // update UI
            await Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    // UI components can be accessed within this scope
                    PBar.Value = PBar.Value + 1;
                    if (PBar.Value == 5) { palkka1TextBlock.Text = Ari.PalkanLasku(double.Parse(palkka1TextBlock.Text)).ToString(); PBar.Value = 0; } //Lisää palkkaa joka 5. sekunti
                });
        }

        private void StopButton_Click(object sender, RoutedEventArgs e) //Lopettaa palkan lisäämisen Stop nappulasta
        {
            PeriodicTimer.Cancel();
        }

        private async void DestroydHandler(ThreadPoolTimer timer)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.High,
            () =>
            {
                // UI components can be accessed within this scope.
            });
        }

    }
}
