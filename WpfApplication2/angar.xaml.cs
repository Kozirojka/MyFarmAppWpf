using System;
using System.Windows;

namespace WpfApplication2
{
    public partial class angar : Window
    {

        public int amountOfGold;
        
        
        public angar(int farmMapAmountMoney)
        {
            amountOfGold = farmMapAmountMoney;
            
            
            InitializeComponent();
            
        }
        public event EventHandler<bool> ReturnValue;
        private void Andarbutton_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue?.Invoke(this, true);
            Close(); 
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
        
        }
    }
}

