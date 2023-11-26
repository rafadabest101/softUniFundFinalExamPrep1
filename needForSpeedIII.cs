using System.Text.RegularExpressions;

namespace softUniFund_FinalExamPrep1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Car> soldCars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i++)
            {
                string[] carDetails = Console.ReadLine().Split('|');
                string name = carDetails[0];
                int mileage = int.Parse(carDetails[1]);
                int fuel = int.Parse(carDetails[2]);

                Car car = new Car(name, mileage, fuel);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            while(command != "Stop")
            {
                string[] commandParts = command.Split(" : ");
                switch(commandParts[0])
                {
                    case "Drive":
                        foreach(Car car in cars)
                        {
                            if(car.Name == commandParts[1])
                            {
                                car.DriveCar(int.Parse(commandParts[2]), int.Parse(commandParts[3]));
                                if(car.Mileage >= 100000)
                                {
                                    Console.WriteLine($"Time to sell the {car.Name}!");
                                    soldCars.Add(car);
                                }
                            }
                        }
                        break;
                    case "Refuel":
                        foreach(Car car in cars)
                        {
                            if(car.Name == commandParts[1]) car.Refuel(int.Parse(commandParts[2]));
                        }
                        break;
                    case "Revert":
                        foreach(Car car in cars)
                        {
                            if(car.Name == commandParts[1]) car.Revert(int.Parse(commandParts[2]));
                        }
                        break;
                }
                command = Console.ReadLine();
            }

            foreach(Car car in cars)
            {
                if(!soldCars.Contains(car)) Console.WriteLine(car);
            }
        }
    }

    class Car
    {
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public Car(string name, int mileage, int fuel)
        {
            Name = name;
            Mileage = mileage;
            Fuel = fuel;
        }

        public override string ToString()
        {
            return $"{Name} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }

        public void DriveCar(int distance, int fuel)
        {
            if(Fuel >= fuel)
            {
                Mileage += distance;
                Fuel -= fuel;
                Console.WriteLine($"{Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
            }
            else Console.WriteLine("Not enough fuel to make that ride");
        }

        public void Refuel(int fuel)
        {
            if(Fuel + fuel >= 75) fuel = 75 - Fuel;
            Fuel += fuel;
            Console.WriteLine($"{Name} refueled with {fuel} liters");
        }

        public void Revert(int kilometers)
        {
            Mileage -= kilometers;
            if(Mileage >= 10000) Console.WriteLine($"{Name} mileage decreased by {kilometers} kilometers");
            else Mileage = 10000;
        }
    }
}