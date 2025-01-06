using System;

namespace WpfApplication2
{
    public class VegetableManager
    {
        public void AddVegetable(string vegetableType)
        {
            // Логіка додавання нового овоча на ферму
            Console.WriteLine($"Added a new {vegetableType} to the farm.");
        }
    }

    public class VegetableCareManager
    {
        public void WaterVegetables()
        {
            Console.WriteLine("Watering the vegetables.");
        }

        public void PruneVegetables()
        {
            Console.WriteLine("Pruning the vegetables.");
        }
    }

    public class WorkerManager
    {
        public void SendWorkersToField()
        {
            Console.WriteLine("Sending workers to the field.");
        }

        public (int X, int Y) SendWorkersToVegetableGarden(int targetX, int petX, int targetY, int petY, int speed)
        {
            int deltaX = targetX - petX;
            int deltaY = targetY - petY;

            // Calculate the distance to move in each step
            int moveX = Math.Sign(deltaX) * Math.Min(speed, Math.Abs(deltaX));
            int moveY = Math.Sign(deltaY) * Math.Min(speed, Math.Abs(deltaY));
            return (moveX, moveY);
        }

    }

    public class FarmFacade
    {
        private VegetableManager vegetableManager;
        private VegetableCareManager vegetableCareManager;
        private WorkerManager workerManager;

        public FarmFacade()
        {
            vegetableManager = new VegetableManager();
            vegetableCareManager = new VegetableCareManager();
            workerManager = new WorkerManager();
        }

        public void AddVegetable(string vegetableType)
        {
            vegetableManager.AddVegetable(vegetableType);
        }

        public void WaterAndPruneVegetables()
        {
            vegetableCareManager.WaterVegetables();
            vegetableCareManager.PruneVegetables();
        }

        public (int x, int y) SendWorkersToWork(int targetX, int petX, int targetY, int petY, int speed)
        {
            int moveX = workerManager.SendWorkersToVegetableGarden(targetX, petX, targetY, petY, 2).X;
            int moveY = workerManager.SendWorkersToVegetableGarden(targetX, petX, targetY, petY, 2).Y;
            
            
            return (moveX, moveY);

        }
    }
}
