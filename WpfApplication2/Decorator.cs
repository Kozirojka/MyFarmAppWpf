using System;

namespace WpfApplication2
{

    public interface IBuilding
    {
        String getDescription();

        double getCost();
    }





// By going this route I'll have to create a new subclass
// for an infinite number of building.
// I'd also have to change prices in many classes 
// when just 1 bulding topping cost changes

// Inheritance is static while composition is dynamic
// Through composition I'll be able to add new functionality
// by writing new code rather than by changing current code



    public class PlainBuilding : IBuilding
    {
        public String getDescription()
        {
            return "Floor";
        }

        public double getCost()
        {
            Console.WriteLine("Cost of Floor: " + 4.00);
            return 4.00;
        }


       
// Aggregation Relationship

        public abstract class ToppingDecorator : IBuilding
        {
            protected IBuilding TempBuilding;

       

            public ToppingDecorator(IBuilding newBuilding)
            {
                TempBuilding = newBuilding;
            }

            public virtual String getDescription()
            {
                return TempBuilding.getDescription();
            }

            public virtual double getCost()
            {
                return TempBuilding.getCost();
            }
        }


        public class BuildingLevelTwo : ToppingDecorator
        {
            public BuildingLevelTwo(IBuilding newBuilding) : base(newBuilding)
            {
                Console.WriteLine("Adding Dough");

                Console.WriteLine("Adding Moz");
            }


            public override String getDescription()
            {
                return
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\angarPicture\\generalBuildin1.png";
            }

            public override double getCost()
            {
                Console.WriteLine("Cost of Moz: " + .50);

                return TempBuilding.getCost() + .50;
            }
        }


        public class buildingLever3 : ToppingDecorator
        {
            public buildingLever3(IBuilding newBuilding) : base(newBuilding)
            {
                Console.WriteLine("Adding building");
            }


            public override String getDescription()
            {
                return "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\angarPicture\\buikdingTwo.png";
            }

            public override double getCost()
            {
                Console.WriteLine("Cost of  building: " + .35);

                return TempBuilding.getCost() + .35;
            }
        }
    }
}
