using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Gpio;
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

namespace IoTControlKiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int LED_PIN = 5;
        private GpioPin LED;
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

            LED = gpio.OpenPin(LED_PIN);

            LED.Write(GpioPinValue.Low);

            LED.SetDriveMode(GpioPinDriveMode.Output);

            BUZZ = gpio.OpenPin(BUZZ_PIN);

            BUZZ.Write(GpioPinValue.Low);

            BUZZ.SetDriveMode(GpioPinDriveMode.Output);

            BUZZ.SetDriveMode(GpioPinDriveMode.Output);
        }

        private void Blink_Click(object sender, RoutedEventArgs e)
        {
            if (LED_STATE)
                LED.Write(GpioPinValue.Low);
            else
                LED.Write(GpioPinValue.High);

            LED_STATE = !LED_STATE;
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

    }
}
