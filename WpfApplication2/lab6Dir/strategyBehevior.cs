using System;

namespace WpfApplication2.slimeMovement
{
    public interface IManagementStrategy
    {
        void Manage();
    }

    
    
    public class IrrigationStrategy : IManagementStrategy
    {
        public void Manage()
        {
            Console.WriteLine("Irrigating crops...");
            // Реалізація логіки поливу рослин
        }
    }

    public class FeedingStrategy : IManagementStrategy
    {
        public void Manage()
        {
            Console.WriteLine("Feeding animals...");
            // Реалізація логіки годівлі тварин
        }
    }

    public class HarvestingStrategy : IManagementStrategy
    {
        public void Manage()
        {
            Console.WriteLine("Harvesting crops...");
            // Реалізація логіки збирання врожаю
        }
    }

    public class FarmManager
    {
        private IManagementStrategy _strategy;

        public FarmManager(IManagementStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IManagementStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteManagement()
        {
            _strategy.Manage();
        }
    }

    
    /*
       
            FarmManager farmManager = new FarmManager(new IrrigationStrategy());
            farmManager.ExecuteManagement();

            // Зміна стратегії на годівлю тварин
            farmManager.SetStrategy(new FeedingStrategy());
            farmManager.ExecuteManagement();

            // Зміна стратегії на збирання врожаю
            farmManager.SetStrategy(new HarvestingStrategy());
            farmManager.ExecuteManagement();
        }
    }*/
}
