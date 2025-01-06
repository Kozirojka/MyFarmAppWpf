using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApplication2
{
    public abstract class DifficultyLevelFactory
    {
        public abstract Enemy CreateVirus();

        public  int live;
        
        public void ScheduleDeletion(Dictionary<int, Person> dictionary, int key)
        {
            Timer timer = new Timer((state) =>
            {
                Console.WriteLine($"Object with key {key} deleted after 30 seconds.");
                dictionary.Remove(key);
            }, null, TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(-1));
        }
        
        
    }
    
    public class CasualDifficultyFactory : DifficultyLevelFactory
    {
        public CasualDifficultyFactory(int initialLive)
        {
            live = initialLive;
        }
        
        public void ScheduleDeletion(Canvas gameCanvas, Dictionary<int, Person> dictionary, int key, double x, double y)
        {
           
        }

        
        public override Enemy CreateVirus()
        {
            return new FoxEazy();
        } 
    }
    public class NormalDifficultyFactory : DifficultyLevelFactory
    {
        public NormalDifficultyFactory(int initialLive)
        {
            live = initialLive;
        }
        public override Enemy CreateVirus()
        {
            return new WolfMiddle();
        }
        
        public void ScheduleDeletion(Canvas gameCanvas, Dictionary<int, Person> dictionary, int key, double x, double y)
        {
            Thread deletionThread = new Thread(() =>
            {
                Timer timer = new Timer((state) =>
                {
                    Console.WriteLine($"Object with key {key} deleted after 30 seconds.");
            
                    dictionary.Remove(key);

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.Width = 100; 
                        rectangle.Height = 100; 
                        rectangle.Fill = Brushes.LightGray; 
                        rectangle.SetValue(Canvas.LeftProperty, x - 50); 
                        rectangle.SetValue(Canvas.TopProperty, y -50); 

                        gameCanvas.Children.Add(rectangle);
                    });
            
                }, null, TimeSpan.FromSeconds(3), TimeSpan.FromMilliseconds(-1));
            });

            deletionThread.Start();
        }
        
    }
    

    public interface Enemy
    {
        void Infect();
    }

    public class FoxEazy : Enemy
    {
        public void Infect()
        {
        }
    }

    public class WolfMiddle : Enemy
    {
        public void Infect()
        {
        }
    }


}
