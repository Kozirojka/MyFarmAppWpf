using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication2
{
    public partial class Ratusha : Window
    {
        private int amountOfMoney;
        private int costOfBob = 25;
        
        public Ratusha(int amountOfMoney)
        {
            this.amountOfMoney = amountOfMoney;
            
            InitializeComponent();
        }

        public event EventHandler<bool> ReturnValue;
        
        private void createBob(bool what)
        {
            ReturnValue?.Invoke(this, what);
            Close(); // Close the modal window
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (amountOfMoney > costOfBob)
            {
                Console.WriteLine("Created");
                createBob(true);
            }
            else
            {
                Console.WriteLine("Not created");
                createBob(false);
            }
        }
    }
}

