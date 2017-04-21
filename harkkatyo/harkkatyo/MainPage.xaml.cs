using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using System.Text;


using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using Windows.Foundation;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace harkkatyo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Opettaja> opettajat = new List<Opettaja>(); //Lista tallennukseen ja lataukseen


        Opettaja Ari = new Opettaja("Ari", 5);
        Opettaja Narsu = new Opettaja("Narsu", 10);
        Opettaja Jarmo = new Opettaja("Jarmo", 15);
        Opettaja Mieskolainen = new Opettaja("Matti", 20);
        Achievements Saavutukset = new Achievements();
        
        
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
            opettajat.Add(Ari);
            opettajat.Add(Narsu);
            opettajat.Add(Jarmo);
            opettajat.Add(Mieskolainen);

        }
        
        

        private ThreadPoolTimer PeriodicTimer1, PeriodicTimer2, PeriodicTimer3, PeriodicTimer4;

        private void Start1Button_Click(object sender, RoutedEventArgs e) //Ensimmäinen startti
        {
            TimeSpan period = TimeSpan.FromSeconds(0.01);
            PeriodicTimer1 = ThreadPoolTimer.CreatePeriodicTimer(ElapsedHander1, period, DestroydHandler);
        }
        private void Start2Button_Click(object sender, RoutedEventArgs e) //Toinen startti
        {
            TimeSpan period = TimeSpan.FromSeconds(0.01);
            PeriodicTimer2 = ThreadPoolTimer.CreatePeriodicTimer(ElapsedHander2, period, DestroydHandler);
        }
        private void Start3Button_Click(object sender, RoutedEventArgs e) //Kolmas startti
        {
            TimeSpan period = TimeSpan.FromSeconds(0.01);
            PeriodicTimer3 = ThreadPoolTimer.CreatePeriodicTimer(ElapsedHander3, period, DestroydHandler);
        }
        private void Start4Button_Click(object sender, RoutedEventArgs e) //Neljäs startti
        {
            TimeSpan period = TimeSpan.FromSeconds(0.01);
            PeriodicTimer4 = ThreadPoolTimer.CreatePeriodicTimer(ElapsedHander4, period, DestroydHandler);
        }
        
        private async void ElapsedHander1(ThreadPoolTimer timer) //Ajaa progressbar1:stä
        {
            // update UI
            await Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    // UI components can be accessed within this scope
                    PBar1.Value = PBar1.Value + 1;
                    if (PBar1.Value == 100) {
                        palkka1TextBlock.Text = Ari.PalkanLasku(double.Parse(palkka1TextBlock.Text)).ToString();
                        double rahat = Ari.Rahat + Narsu.Rahat + Jarmo.Rahat + Mieskolainen.Rahat;
                        totalMoneyTextBlock.Text = rahat.ToString();
                        Ari.Klikit += 1;
                        CheckAchievements(rahat);
                        PBar1.Value = 0;
                    } //Lisää palkkaa joka sekunti
                    
                });
        }
        private async void ElapsedHander2(ThreadPoolTimer timer) //Ajaa progressbar2:sta
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    PBar2.Value = PBar2.Value + 1;
                    if (PBar2.Value == 300) {
                        palkka2TextBlock.Text = Narsu.PalkanLasku(double.Parse(palkka2TextBlock.Text)).ToString();
                        double rahat = Ari.Rahat + Narsu.Rahat + Jarmo.Rahat + Mieskolainen.Rahat;
                        totalMoneyTextBlock.Text = rahat.ToString();
                        Narsu.Klikit += 1;
                        CheckAchievements(rahat);
                        PBar2.Value = 0;
                    } //Lisää palkkaa joka 3. sekunti
                });
        }
        private async void ElapsedHander3(ThreadPoolTimer timer) //Ajaa progressbar3:sta
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    PBar3.Value = PBar3.Value + 1;
                    if (PBar3.Value == 500) {
                        palkka3TextBlock.Text = Jarmo.PalkanLasku(double.Parse(palkka3TextBlock.Text)).ToString();
                        double rahat = Ari.Rahat + Narsu.Rahat + Jarmo.Rahat + Mieskolainen.Rahat;
                        totalMoneyTextBlock.Text = rahat.ToString();
                        Jarmo.Klikit += 1;
                        CheckAchievements(rahat);
                        PBar3.Value = 0;
                    } //Lisää palkkaa joka 5. sekunti
                });
        }
        private async void ElapsedHander4(ThreadPoolTimer timer) //Ajaa progressbar4:sta
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    PBar4.Value = PBar4.Value + 1;
                    if (PBar4.Value == 700) {
                        palkka4TextBlock.Text = Mieskolainen.PalkanLasku(double.Parse(palkka4TextBlock.Text)).ToString();
                        double rahat = Ari.Rahat + Narsu.Rahat + Jarmo.Rahat + Mieskolainen.Rahat;
                        totalMoneyTextBlock.Text = rahat.ToString();
                        Mieskolainen.Klikit += 1;
                        CheckAchievements(rahat);
                        PBar4.Value = 0;
                    } //Lisää palkkaa 7. joka sekunti
                });
        }

        private void Stop1Button_Click(object sender, RoutedEventArgs e) //Lopettaa palkan lisäämisen Arille
        {
            PeriodicTimer1.Cancel();

        }
        private void Stop2Button_Click(object sender, RoutedEventArgs e) //Lopettaa palkan lisäämisen Narsulle
        {
            PeriodicTimer2.Cancel();
        }
        private void Stop3Button_Click(object sender, RoutedEventArgs e) //Lopettaa palkan lisäämisen Jarmolle
        {
            PeriodicTimer3.Cancel();

        }
        private void Stop4Button_Click(object sender, RoutedEventArgs e) //Lopettaa palkan lisäämisen Matille
        {
            PeriodicTimer4.Cancel();

        }

        private async void DestroydHandler(ThreadPoolTimer timer) //Pysäyttää progressbarin
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.High,
            () =>
            {
                // UI components can be accessed within this scope.
            });
        }

        private void palkkaa1Button_Click(object sender, RoutedEventArgs e)
        {
            ShowTeacher(1);
            ykkosRelativePanel.Children.Remove(palkkaa1Button);
        }
        private void palkkaa2Button_Click(object sender, RoutedEventArgs e) //Korvataan "Palkkaa" boxi opettajan palkanjuoksucontroleilla
        {

            ShowTeacher(2);
            kakkosRelativePanel.Children.Remove(palkkaa2Button);
        }
        private void palkkaa3Button_Click(object sender, RoutedEventArgs e) //Korvataan "Palkkaa" boxi opettajan palkanjuoksucontroleilla
        {

            ShowTeacher(3);
            kolmosRelativePanel.Children.Remove(palkkaa3Button);
        }
        private void palkkaa4Button_Click(object sender, RoutedEventArgs e) //Korvataan "Palkkaa" boxi opettajan palkanjuoksucontroleilla
        {
            ShowTeacher(4);
            nelosRelativePanel.Children.Remove(palkkaa4Button);
        }

        public void ShowTeacher(int numero) //Muuttaa opettajat näkyviksi kun "Palkkaa" -nappulaa painetaan
        {

            switch (numero)
            {
                case 1:
                    nimi1TextBlock.Visibility = Visibility.Visible;
                    palkka1TextBlock.Visibility = Visibility.Visible;
                    Start1Button.Visibility = Visibility.Visible;
                    Stop1Button.Visibility = Visibility.Visible;
                    PBar1.Visibility = Visibility.Visible;
                    break;

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

        private async void instructionsButton_Click(object sender, RoutedEventArgs e)
        {

            var msgd = new Windows.UI.Popups.MessageDialog(
                "Ohjeet: Valitse \"Palkkaa\" -nappi palkataksesi haluamasi opettajan. \nKyseisen opettajan palkka alkaa juosta ja tienaat rahaa! Win!");

            msgd.Commands.Add(new Windows.UI.Popups.UICommand("Proceed") { Id = 0 });

            msgd.DefaultCommandIndex = 0;
            var result = await msgd.ShowAsync();
        } //Nayttaa ohjeet pelille

        public void nollausButton_Click(object sender, RoutedEventArgs e)
        {
            Ari.Rahat = 0;
            Narsu.Rahat = 0;
            Jarmo.Rahat = 0;
            Mieskolainen.Rahat = 0;
            totalMoneyTextBlock.Text = 0.ToString();
        }
        
        private async void achievementsButton_Click(object sender, RoutedEventArgs e)
        {
            
            var msgd = new Windows.UI.Popups.MessageDialog(Saavutukset.PrintAchievements());
            msgd.Commands.Add(new Windows.UI.Popups.UICommand("Proceed") { Id = 0 });

            msgd.DefaultCommandIndex = 0;
            var result = await msgd.ShowAsync();
            
        }//Tulostaa achievementit Achievement-luokan kautta
        

        public async void CheckAchievements(double totalmoney)
        {


            if (Saavutukset.is100(totalmoney) == true) //Luo ilmoituksen ja tarkistaa ettei saavutusta jo ole
            {
                var msgd = new Windows.UI.Popups.MessageDialog("Achievement: Gain 100 gold!");

                msgd.Commands.Add(new Windows.UI.Popups.UICommand("Proceed") { Id = 0 });

                msgd.DefaultCommandIndex = 0;
                var result = await msgd.ShowAsync();
            }

            if (Saavutukset.is500(totalmoney) == true) //Luo ilmoituksen ja tarkistaa ettei saavutusta jo ole
            {
                var msgd = new Windows.UI.Popups.MessageDialog("Achievement: Gain 500 gold!");

                msgd.Commands.Add(new Windows.UI.Popups.UICommand("Proceed") { Id = 0 });

                msgd.DefaultCommandIndex = 0;
                var result = await msgd.ShowAsync();
            }

            if (Saavutukset.is1000(totalmoney) == true) //Luo ilmoituksen ja tarkistaa ettei saavutusta jo ole
            {
                var msgd = new Windows.UI.Popups.MessageDialog("Achievement: Gain 1000 gold!");

                msgd.Commands.Add(new Windows.UI.Popups.UICommand("Proceed") { Id = 0 });

                msgd.DefaultCommandIndex = 0;
                var result = await msgd.ShowAsync();
            }

            if (Saavutukset.isAriKlikit(Ari.Klikit) == true)
            {
                var msgd = new Windows.UI.Popups.MessageDialog("Achievement: Ari did 20 loops!");

                msgd.Commands.Add(new Windows.UI.Popups.UICommand("Proceed") { Id = 0 });

                msgd.DefaultCommandIndex = 0;
                Ari.Palkka = Ari.Palkka * 1.5;
                var result = await msgd.ShowAsync();
            }

            if (Saavutukset.isNarsuKlikit(Narsu.Klikit) == true)
            {
                var msgd = new Windows.UI.Popups.MessageDialog("Achievement: Narsu did 20 loops!");

                msgd.Commands.Add(new Windows.UI.Popups.UICommand("Proceed") { Id = 0 });

                msgd.DefaultCommandIndex = 0;
                Narsu.Palkka = Narsu.Palkka * 1.5;
                var result = await msgd.ShowAsync();

            }
            if (Saavutukset.isJarmoKlikit(Jarmo.Klikit) == true)
            {
                var msgd = new Windows.UI.Popups.MessageDialog("Achievement: Jarmo did 20 loops!");

                msgd.Commands.Add(new Windows.UI.Popups.UICommand("Proceed") { Id = 0 });

                msgd.DefaultCommandIndex = 0;
                Jarmo.Palkka = Jarmo.Palkka * 1.5;
                var result = await msgd.ShowAsync();

            }
            if (Saavutukset.isMieskolainenKlikit(Mieskolainen.Klikit) == true)
            {
                var msgd = new Windows.UI.Popups.MessageDialog("Achievement: Matti did 20 loops!");

                msgd.Commands.Add(new Windows.UI.Popups.UICommand("Proceed") { Id = 0 });

                msgd.DefaultCommandIndex = 0;
                Mieskolainen.Palkka = Mieskolainen.Palkka * 1.5;
                var result = await msgd.ShowAsync();

            }
            


        } //Achievementtien saavutus tarkistetaan jokaisen rahanlisäyksen jälkeen
        

        public async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            
            // folder
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            // delete file if exists
            IStorageItem employeesItem = await storageFolder.TryGetItemAsync("friends.dat");
            if (await storageFolder.TryGetItemAsync("friends.dat") != null)
            {
                await employeesItem.DeleteAsync();
            }
             
            StorageFile employeesFile = await storageFolder.CreateFileAsync("friends.dat", CreationCollisionOption.OpenIfExists);
            // save friends to disk
            Stream stream = await employeesFile.OpenStreamForWriteAsync();
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<Opettaja>));
            serializer.WriteObject(stream, opettajat);
            await stream.FlushAsync();
            stream.Dispose();


        }
        
        public async void loadButton_Click(object sender, RoutedEventArgs e)
        {
            
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            Stream stream = await storageFolder.OpenStreamForReadAsync("friends.dat");
            

            // read data
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<Opettaja>));
            opettajat = (List<Opettaja>)serializer.ReadObject(stream);

            foreach (Opettaja opettaja in opettajat)
            {
                testausTextBlock.Text += opettaja.Nimi + " " + opettaja.Rahat + Environment.NewLine;
            }

            palkka1TextBlock.Text = Ari.Palkka.ToString();
            palkka2TextBlock.Text = Narsu.Palkka.ToString();
            palkka3TextBlock.Text = Jarmo.Palkka.ToString();
            palkka4TextBlock.Text = Mieskolainen.Palkka.ToString();
        }

    }
}
