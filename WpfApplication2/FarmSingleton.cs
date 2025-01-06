using System.Collections.Generic;

namespace WpfApplication2
{
    /// <summary>
    /// this will be file for implement save thread singleton
    /// </summary>

    public sealed class Ferm
    {
        public Dictionary<int, Person> peopleDictionary = new Dictionary<int, Person>();
        public PrototypeRegistry registry = new PrototypeRegistry();


        public int amountMoney;
        public int amontOfPeople = 0;

        public int getAmountOfMoney()
        {
            return amountMoney;
        }

        public void incrementTheZolotoo(int amount)
        {
            amountMoney += amount;
        }

        public void addPeople(int i)
        {
            amountMoney += i;
        }

        public Ferm()
        {
            amountMoney = 10;
        }

    }
}