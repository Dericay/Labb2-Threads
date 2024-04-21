using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Threads
{
    internal class RaceCars
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }

        public RaceCars(string name, int speed, int distance)
        {
            Name = name;
            Speed = speed;
            Distance = distance;
        }

        public static List<RaceCars> cars = new List<RaceCars>();

        public static List<RaceCars> GetAllCars()
        {
            return cars;
        }

        public void OutOfGas()
        {
            Console.WriteLine($"{Name} is out of gas!");
            Thread.Sleep(30000);
        }

        public void FlatTire()
        {
            Console.WriteLine($"{Name} has gotten a flat tire!");
            Thread.Sleep(20000);
        }

        public void Bird()
        {
            Console.WriteLine($"{Name} got a bird on the windshield!");
            Thread.Sleep(10000);
        }
        public void EngineFailure()
        {
            Console.WriteLine($"{Name} got an engine failure!!");
            Speed -= 1;
        }

        public void events()
        {
            Random random = new Random();
            int num = random.Next(1, 50);
            if(num == 1)
            {
                OutOfGas();
            }
            if(num == 20 || num == 40)
            {
                FlatTire();
            }
            if(num >= 13 && num <= 17)
            {
                Bird();
            }
            if(num >= 21 && num <= 30)
            {
                EngineFailure();
            }

        }

        public void startRace()
        {          
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            while (Distance <= 8000)
            {
                Distance += Speed;
                Console.WriteLine($"{Name} Distance: {Distance}");
                Thread.Sleep(1000);
                if (stopwatch.Elapsed.TotalSeconds > 5)
                {
                    events();
                    stopwatch.Restart();
                }
            }
        }

        public static void InfoCars(List<RaceCars> cars)
        {
            while (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                foreach (RaceCars c in cars)
                {
                    Console.WriteLine($"{c.Name} has driven {c.Distance} and speed is {c.Speed}kmh");
                }
            }
        }
    }
}
