using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using System.Threading;
using Windows.Media;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System.Threading;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace harkkatyo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            this.InitializeComponent();
            PBar.Value = 10;
        }

        private ThreadPoolTimer PeriodicTimer;
        

        private void StartButton_Click(object sender, RoutedEventArgs e)
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
            PBar.Value = PBar.Value+1;
                });
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            PeriodicTimer.Cancel();
        }

        private async void DestroydHandler(ThreadPoolTimer timer)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.High,
            () =>
            {
        // UI components can be accessed within this scope.
        PBar.Value = 5;
            });
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void testButton_Click(object sender, RoutedEventArgs e) //Luo MessageDialogin joka muuttaa testButtonin sisältöä vastaukse perusteella
        {
            var dialog = new Windows.UI.Popups.MessageDialog(
                "Aliquam laoreet magna sit amet mauris iaculis ornare. " +
                "Morbi iaculis augue vel elementum volutpat.",
                "Lorem Ipsum");
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 0 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 1 });


            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            var result = await dialog.ShowAsync();

            var btn = sender as Button;
            btn.Content = $"Result: {result.Label} ({result.Id})"; //Näyttää vastauksen ja vastauksen ID:n


            if (Convert.ToInt32(result.Id) == 0) { btn.Content = "Yay"; } //Jos vastaa ID:n 0 (eli kyllä)
        }

        
    }
}
