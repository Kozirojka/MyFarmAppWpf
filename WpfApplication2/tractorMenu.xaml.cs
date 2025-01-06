using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication2
{
    public partial class tractorMenu : Window
    {
        public tractorMenu(int farmMapAmountMoney)
        {
            InitializeComponent();
        }
        
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            var mediaElement = sender as MediaElement;
            mediaElement.Position = TimeSpan.Zero; 
        }

        public event EventHandler<int> ReturnValue;


        private void EnginetButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue?.Invoke(this, 1);
            Close(); // Close the modal window
        }

        private void GPSButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue?.Invoke(this, 2);
            Close(); // Close the modal window
        }
    }
}

