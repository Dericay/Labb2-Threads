namespace Labb2_Threads

{
    internal class Program
    {
        static void Main(string[] args)
        {
            RaceCars Car1 = new RaceCars("RedBull", 120, 0);
            RaceCars Car2 = new RaceCars("Ferrari", 120, 0);

            RaceCars.cars.Add(Car1);
            RaceCars.cars.Add(Car2);
            

            Thread rc1 = new Thread(() =>
            {
                Car1.startRace();
                Console.WriteLine($"{Car1.Name} has finished the race!");
            });

            Thread rc2 = new Thread(() =>
            {
                Car2.startRace();
                Console.WriteLine($"{Car2.Name} has finished the race!");
            });

            Thread rc3 = new Thread(() =>
            {
                RaceCars.InfoCars(RaceCars.GetAllCars());
            });

            rc1.Start();
            rc2.Start();
            rc3.Start();
            
            

            


        }
    }
}