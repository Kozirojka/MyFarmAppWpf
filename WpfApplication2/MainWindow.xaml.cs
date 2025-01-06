using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace WpfApplication2
{
    /// <summary>
    /// TypeBuilding
    /// 1 - ratusha
    /// 2 - peoples fucking
    /// </summary>
    
    public partial class MainWindow : Window
    {
        
        
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }
        
        private void StartGame()
        {
            DifficultyLevelFactory difficultyFactory = null;
            DifficultyLevelFactory second;
            if (EasyRadioButton.IsChecked == true)
            {
                difficultyFactory = new CasualDifficultyFactory(100);
                second = (CasualDifficultyFactory)difficultyFactory;
                
            }
            else if (MediumRadioButton.IsChecked == true)
            {
                difficultyFactory = new NormalDifficultyFactory(200);
                second = (NormalDifficultyFactory)difficultyFactory;
            }
            else
            {
                MessageBox.Show("Please select a difficulty level.");
                return;
            }

            windowBefoStart gameWindow = windowBefoStart.GetInstance(second);
            this.Close();
            gameWindow.Show();
        }

        
    }
}
