using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class HW1
    {

        public class Vehicle
        {
            public int Year { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public override string ToString()
            {
                return Year + " " + Name + " " + Price;
            }
        }

        public class Car : Vehicle
        {
            public CarBodyType BodyType { get; set; }

            public Car(int year, string name, int price, CarBodyType type)
            {
                Year = year;
                Name = name;
                Price = price;
                BodyType = type;
            }
            public override string ToString()
            {
                return base.ToString()+" "+ BodyType;
            }
        }
        
        public class Motorcycle : Vehicle
        {
            public string Color { get; set; }
            public Motorcycle(int year, string name, int price, string color)
            {
                Year = year;
                Name = name;
                Price = price;
                Color = color;
            }
            public override string ToString()
            {
                return base.ToString() + " " + Color;
            }
        }

        public enum CarBodyType
        {
            Sedan,
            Hatchback,
            Coupe
        }

        public static List<Car> CarsDB = new List<Car>
        {

            new Car(2008, "Skoda", 6000,CarBodyType.Hatchback),
            new Car(2005, "Mers", 5000, CarBodyType.Coupe),
            new Car(2003, "VW", 9000, CarBodyType.Hatchback),
            new Car(1995, "Opel", 16000, CarBodyType.Coupe),
            new Car(2018, "Mazda", 5999, CarBodyType.Hatchback),
            new Car(2008, "Mazda", 6000, CarBodyType.Sedan),
            new Car(2008, "VW", 600, CarBodyType.Sedan)

        };


        public static List<Motorcycle> MotoDB = new List<Motorcycle>
        {

            new Motorcycle(year: 2012, name: "Yamaha", price: 3000, color: "pink"),
            new Motorcycle(2015, "Mers", 2000, "blue"),
            new Motorcycle(2013, "VW", 4000, "black"),
            new Motorcycle(1999, "Opel", 3000, "black"),
            new Motorcycle(2008, "Mazda", 2999, "red"),
            new Motorcycle(2017, "Mazda", 1000, "blue"),
            new Motorcycle(2010, "VW", 600, "black")
        };

        public static IEnumerable<Vehicle> Filter(List<Vehicle> coll,  Func<Vehicle, string, bool> question, string param) 
        {
           return coll.Where(c => question(c,param));
        }


        public static IEnumerable<T> CustomFilter<T>(List<T> coll, Func<T, bool> question) where T: Vehicle
        {
            return coll.Where(c => question(c));
        }

        public static bool YoungerThen(Vehicle a, string param)
        {
            return a.Year < Int32.Parse(param);
        }

        public static bool WithColor(Vehicle a, string param)
        {
            return (a is Motorcycle motoVehichle && motoVehichle.Color.Equals(param));
        }

        public static bool CarBody(Vehicle a, string param)
        {
            return (a is Car car && car.BodyType.ToString().Equals(param));
        }

        public static bool CheaperThan(Vehicle a, string param)
        {
            return a.Price <= Int32.Parse(param);
        }

        public static bool ExpencierThan(Vehicle a, string param)
        {
            return a.Price >= Int32.Parse(param);
        }

        public static bool Name(Vehicle a, string param)
        {
            return a.Name.Equals(param);
        }

        public static void printList(IEnumerable<Vehicle> a, string title)
        {
            Console.WriteLine(title);
            foreach (var item in a)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

        }
       /* static void Main()
        {
            //write single method that returns collection of items filtered by custom criteria passed as param
            List<Vehicle> all = new List<Vehicle>();
            all.AddRange(MotoDB);
            all.AddRange(CarsDB);
            printList(all, "All");
            IEnumerable<Vehicle> list = Filter(all,YoungerThen,"2008");
            printList(list, "Younger than 2008");
            list = Filter(all, WithColor, "blue");
            printList(list, "Blue");
            list = Filter(all, CarBody, "Coupe");
            printList(list, "Coupe cars");
            list = Filter(all, CheaperThan, "5000");
            printList(list, "Cheaper then 5000");
            list = Filter(all, ExpencierThan, "3000");
            printList(list, "Expencier then 3000");

            CustomFilter(all, (Vehicle v) => v.Year > 100);
            CustomFilter(all, (Vehicle v) => v.Name == "asta");

            Console.ReadKey();
            
        }*/

    }

    

}





