using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication2
{
    public partial class ModalWindow : Window
    {
        public ModalWindow()
        {
            InitializeComponent();
        }
        
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            var mediaElement = sender as MediaElement;
            mediaElement.Position = TimeSpan.Zero; 
        }

        public event EventHandler<int> ReturnValue;
        
        private void SonOfAnarchyButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue?.Invoke(this, 3);
            Close();
        }

        private void ArcherButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue?.Invoke(this, 2);
            Close(); 
        }

        private void KnightButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue?.Invoke(this, 1);
            Close(); // Close the modal window
        }


        private void CarrotGarden_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue?.Invoke(this, 4);
            Close(); // Close the modal window
        }

        private void AngarGarden_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue?.Invoke(this,5);
            Close();
        }

        private void Tractor_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue?.Invoke(this,6);
            Close();
        }
    }
}

