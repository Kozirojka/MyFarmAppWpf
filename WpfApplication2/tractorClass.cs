using System;
using System.Collections.Generic;

namespace WpfApplication2
{
    public interface IComponent
    {
        void PerformTask();
    }

    class FieldProcessingDevice : IComponent
    {
        public void PerformTask()
        {
            Console.WriteLine("Field processing device is performing its task.");
        }
    }

    class NavigationPanel : IComponent
    {
        public void PerformTask()
        {
            Console.WriteLine("Navigation panel is performing its task.");
        }
    }

public class Tractor : IComponent
    {
        private List<IComponent> components = new List<IComponent>();

        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            components.Remove(component);
        }

        public bool HasAdditionalComponents()
        {
            return components.Count > 0;
        }

        
        public List<string> GetAdditionalComponentNames()
        {
            List<string> componentNames = new List<string>();

            foreach (var component in components)
            {
                componentNames.Add(component.GetType().Name);
            }

            return componentNames;
        }
        
        
        public void PerformTask()
        {
            Console.WriteLine("Tractor is performing its tasks:");

            foreach (var component in components)
            {
                component.PerformTask();
            }
        }
    }

}
