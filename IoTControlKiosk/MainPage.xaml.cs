using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IoTControlKiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int RED_PIN = 13;
        private GpioPin RED_LED;
        private int GREEN_PIN = 5;
        private GpioPin GREEN_LED;
        private int BLUE_PIN = 26;
        private GpioPin BLUE_LED;

        private bool LED_STATE = false;

        private int BUZZ_PIN = 24;
        private GpioPin BUZZ;
        private bool BUZZ_STATE = false;

        public MainPage()
        {
            this.InitializeComponent();
            InitGPIO();
        }

        private void InitGPIO()
        {
            var gpio = GpioController.GetDefault();

            RED_LED = gpio.OpenPin(RED_PIN);

            RED_LED.Write(GpioPinValue.High);

            RED_LED.SetDriveMode(GpioPinDriveMode.Output);

            GREEN_LED = gpio.OpenPin(GREEN_PIN);

            GREEN_LED.Write(GpioPinValue.High);

            GREEN_LED.SetDriveMode(GpioPinDriveMode.Output);

            BLUE_LED = gpio.OpenPin(BLUE_PIN);

            BLUE_LED.Write(GpioPinValue.High);

            BLUE_LED.SetDriveMode(GpioPinDriveMode.Output);

            BUZZ = gpio.OpenPin(BUZZ_PIN);

            BUZZ.Write(GpioPinValue.Low);

            BUZZ.SetDriveMode(GpioPinDriveMode.Output);

            BUZZ.SetDriveMode(GpioPinDriveMode.Output);
        }

        private void Blink_Click(object sender, RoutedEventArgs e)
        {
            var redState = redLedToggleButton.IsChecked.Value;
            var greenState = greenLedToggleButton.IsChecked.Value;
            var blueState = blueLedToggleButton.IsChecked.Value;

            if (redState)
            {
                RED_LED.Write(GpioPinValue.Low);
            }
            else
            {
                RED_LED.Write(GpioPinValue.High);

            }

            if (greenState)
            {
                GREEN_LED.Write(GpioPinValue.Low);
            }
            else
            {
                GREEN_LED.Write(GpioPinValue.High);

            }

            if (blueState)
            {
                BLUE_LED.Write(GpioPinValue.Low);
            }
            else
            {
                BLUE_LED.Write(GpioPinValue.High);

            }
        }

        private void Buzz_Click(object sender, RoutedEventArgs e)
        {

            var clickTime = DateTime.Now;

            while (DateTime.Now < clickTime.AddSeconds(1))
            {
                BUZZ.Write(GpioPinValue.High);
            }
            BUZZ.Write(GpioPinValue.High);
        }

        private void redLedToggleButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
