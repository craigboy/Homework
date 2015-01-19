using CppSensors;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace CompassApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.mySensors.ReadingChanged += async (bool accelerometer, bool compass) =>
            {
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
