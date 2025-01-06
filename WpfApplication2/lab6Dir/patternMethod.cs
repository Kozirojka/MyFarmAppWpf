using System;

namespace WpfApplication2.slimeMovement
{
    // Абстрактний клас, що визначає загальну структуру кормлення тварин
    abstract class AnimalFeedingSystem
    {
        public void FeedAnimals()
        {
            PrepareFood();
            DispenseFood();
            CleanUp();
        }

        protected abstract void PrepareFood();

        protected abstract void DispenseFood();

        protected virtual void CleanUp()
        {
            Console.WriteLine("Cleaning up after feeding.");
        }
    }

    // Конкретний клас для годування корів
    class CowFeedingSystem : AnimalFeedingSystem
    {
        protected override void PrepareFood()
        {
            Console.WriteLine("Preparing grass for cows.");
        }

        protected override void DispenseFood()
        {
            Console.WriteLine("Dispensing grass for cows.");
        }
    }

    class ChickenFeedingSystem : AnimalFeedingSystem
    {
        protected override void PrepareFood()
        {
            Console.WriteLine("Preparing grains for chickens.");
        }

        protected override void DispenseFood()
        {
            Console.WriteLine("Dispensing grains for chickens.");
        }

        protected override void CleanUp()
        {
            Console.WriteLine("Cleaning up chicken coop after feeding.");
        }
    }

    /*
            Console.WriteLine("Feeding cows:");
            AnimalFeedingSystem cowFeedingSystem = new CowFeedingSystem();
            cowFeedingSystem.FeedAnimals();

            Console.WriteLine("\nFeeding chickens:");
            AnimalFeedingSystem chickenFeedingSystem = new ChickenFeedingSystem();
            chickenFeedingSystem.FeedAnimals();
    */
}
