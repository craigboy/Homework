using CppSensors;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System;


namespace CompassApp
{
    public sealed partial class MainPage : Page
    {
        private Sensors mySensors;
        SolidColorBrush greenBrush;
        SolidColorBrush redBrush;

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            mySensors = new Sensors();

            this.greenBrush = new SolidColorBrush(Colors.Green);
            this.redBrush = new SolidColorBrush(Colors.Red);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.mySensors.ReadingChanged += async (bool accelerometer, bool compass) =>
            {
                //Use dispatcher to change UI
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {

                    //Set color of text
                    this.AccelText.Foreground = accelerometer ? greenBrush : redBrush;
                    this.CompassText.Foreground = compass ? greenBrush : redBrush;

                    if (accelerometer && compass)
                    {
                        this.OutputText.Text = "YEAH BUDDY!";
                    }
                    else
                    {
                        this.OutputText.Text = "NO DICE";
                    }
                });
            };
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //disable the start button after pressed so that the event token does not change and prevent not being able to unregister from event
            this.mySensors.startMonitoringSensors();
            this.StartButton.IsEnabled = false;
            this.StopButton.IsEnabled = true;

        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            this.mySensors.stopMonitoringSensors();
            this.StartButton.IsEnabled = true;
            this.StopButton.IsEnabled = false;
        }
    }
}
