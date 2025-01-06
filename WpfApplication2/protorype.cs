using System;
using System.Collections.Generic;
using System.Management.Instrumentation;

namespace WpfApplication2
{
    

    public abstract class Person
    {

        protected Person(string name, int price)
        {
            Price = price;
            Name = name;
        }
        public string Name { get; set;}
        public int Price { get; set;}
        public abstract Person Clone();
    }

    public class KnightConcreate : Person
    {
        public KnightConcreate(string name, string couse) : base(name, 2)
        {
            Course = couse;
        }
        public string Course { get; set; }

        public override Person Clone()
        {
            KnightConcreate knightConcreateClone = (KnightConcreate)MemberwiseClone();
            knightConcreateClone.Course = this.Course;
            return knightConcreateClone;    
            
        }
    }

    public class ArcherConcreate : Person
    {
        //Concrea prototype 2
        private int BudgetMoney;
        public ArcherConcreate(string name, int budgetMoney) : base(name, 5)
        {
            BudgetMoney = budgetMoney;
        }
        public override Person Clone()
        {
            //deep copy
            ArcherConcreate archerConcreateClone = (ArcherConcreate)MemberwiseClone();
            archerConcreateClone.BudgetMoney = this.BudgetMoney;
            return archerConcreateClone;    
        }
    }
    
    public class SonOfAnarchy : Person
    {
        //Concrea prototype 2
        private string SwordsNmae;
        public SonOfAnarchy(string name, string swordName) : base(name, 8)
        {
            SwordsNmae = swordName;
        }
        public override Person Clone()
        {
            SonOfAnarchy SonOfAnarchyClone = (SonOfAnarchy)MemberwiseClone();
            SonOfAnarchyClone.SwordsNmae = this.SwordsNmae;
            return SonOfAnarchyClone;    
        }
    }
    
    
    public class Bob : Person
    {
        //Concrea prototype 2
        private string _amountOfLove;
        private int _cointInSecond10Second;
        public Bob(string name, string swordName, int cointInSecond) : base(name, 8)
        {
            _amountOfLove = swordName;
            this._cointInSecond10Second = cointInSecond;
        }
        public override Person Clone()
        {
            //deep copy
            Bob cloneBob = (Bob)MemberwiseClone();
            cloneBob._amountOfLove = this._amountOfLove;
            cloneBob._cointInSecond10Second = this._cointInSecond10Second;
            return cloneBob;    
        }
    }
    public class PrototypeRegistry
    {
        private Dictionary<string, Person> prototypes = new Dictionary<string, Person>();

        // Add a prototype to the registry
        public void AddPrototype(string key, Person prototype)
        {
            prototypes[key] = prototype;
        }

        // Get a clone of a prototype based on the key
        public Person GetClone(string key)
        {
            if (prototypes.TryGetValue(key, out Person prototype))
            {
                return prototype.Clone();
            }
            else
            {
                throw new ArgumentException("Prototype with the given key does not exist.");
            }
        }
    }
}
