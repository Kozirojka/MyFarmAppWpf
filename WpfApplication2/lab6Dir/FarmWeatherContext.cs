using System;
using System.Windows.Media.Imaging;

namespace WpfApplication2.slimeMovement
{
    // Контекст, який визначає інтерфейс взаємодії зі станами та зберігає
    // поточний стан.
    class FarmWeatherContext
    {
        public WeatherState _state;

        public FarmWeatherContext(WeatherState state)
        {
            this.TransitionTo(state);
        }

        public void TransitionTo(WeatherState state)
        {
            Console.WriteLine($@"Change weather condition on: {state.GetType().Name}.");
            this._state = state;
            this._state.SetContext(this);
        }

        public void SimulateWeatherEffects()
        {
            this._state.SimulateWeatherEffects();
        }
    }

    abstract class WeatherState
    {
        protected FarmWeatherContext _context;

        
        public void SetContext(FarmWeatherContext context)
        {
            this._context = context;
        }

        public abstract void SimulateWeatherEffects();
    }

    class SunnyState : WeatherState
    {
        private BitmapImage[] sunnyFrames;
        
        
        public override void SimulateWeatherEffects()
        {
            Console.WriteLine(@"On farm sunny whether. Herb will good grow.");
            Console.WriteLine(@"People on the farm happy with sun's ray.");
        }
    }

    class RainyState : WeatherState
    {
        private BitmapImage[] RainyFrames;
        public override void SimulateWeatherEffects()
        {
            Console.WriteLine(@"It's raining on the farm. Plants get the necessary moisture.");
            Console.WriteLine(@"People on the farm seek shelter from the rain.");
        }
    }

    class SnowyState : WeatherState
    {
        private BitmapImage[] SnowyFrames;

        public override void SimulateWeatherEffects()
        {
            
            Console.WriteLine(@"It is snowing on the farm. Plants are covered with snow.");
            Console.WriteLine(@"The animals on the farm feel the cold and seek shelter.");
        }
    }

    /*
            // Створення контексту та ініціалізація початкового стану (сонячна погода).
            var context = new FarmWeatherContext(new SunnyState());

            // Симуляція ефектів погоди.
            context.SimulateWeatherEffects();

            // Зміна погоди на дощ.
            context.TransitionTo(new RainyState());
            context.SimulateWeatherEffects();

            // Зміна погоди на снігопад.
            context.TransitionTo(new SnowyState());
            context.SimulateWeatherEffects();
    }*/
}
