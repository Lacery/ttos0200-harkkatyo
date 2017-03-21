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

        private void palkkaa4Button_Click(object sender, RoutedEventArgs e) //Korvataan "Palkkaa" boxi opettajan palkanjuoksuobjekteilla
        {

            //Nimi4TextBlock
            TextBlock nimi4TextBlock = new TextBlock();
            nimi4TextBlock.Text = Mieskolainen.Nimi;
            nimi4TextBlock.FontSize = 35;
            Thickness margin = nimi4TextBlock.Margin;
            margin.Left = 30;
            margin.Top = 20;
            nimi4TextBlock.Margin = margin;
            nelosRelativePanel.Children.Add(nimi4TextBlock);
            
            
            //Palkka4TextBlock
            TextBlock palkka4TextBlock = new TextBlock();
            palkka4TextBlock.Text = Mieskolainen.Palkka.ToString();
            palkka4TextBlock.FontSize = 35;
            Thickness margin2 = palkka4TextBlock.Margin;
            margin2.Left = 30;
            margin2.Top = 10;
            palkka4TextBlock.Margin = margin2;
            nelosRelativePanel.Children.Add(palkka4TextBlock);
            RelativePanel.SetBelow(palkka4TextBlock, nimi4TextBlock);

            //Start4Button
            Button Start4Button = new Button();
            Start4Button.Content = "Start";
            Start4Button.FontSize = 35;
            Start4Button.Margin = margin2;
            Start4Button.Click += Start1Button_Click;
            nelosRelativePanel.Children.Add(Start4Button);
            RelativePanel.SetBelow(Start4Button, palkka4TextBlock);
            
            //Stop4Button
            Button Stop4Button = new Button();
            Stop4Button.Content = "Stop";
            Stop4Button.FontSize = 35;
            Stop4Button.Margin = margin2;
            Stop4Button.Click += Stop1Button_Click;
            nelosRelativePanel.Children.Add(Stop4Button);
            RelativePanel.SetRightOf(Stop4Button, Start4Button);
            RelativePanel.SetBelow(Stop4Button, palkka4TextBlock);

            //ProgressBar4
            ProgressBar Pbar4 = new ProgressBar();
            Pbar4.Width = 300;
            Pbar4.Height = 60;
            Pbar4.Value = 300;
            Pbar4.Maximum = 500;
            Pbar4.Margin = margin2;
            nelosRelativePanel.Children.Add(Pbar4);
            RelativePanel.SetBelow(Pbar4, Start4Button);


            nelosRelativePanel.Children.Remove(palkkaa4Button);

        }



        //|-------------------------------------------------------------------------------------------|


    }
}
