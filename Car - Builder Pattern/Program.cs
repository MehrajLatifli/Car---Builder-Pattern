using System;
namespace Car___Builder_Pattern
{
    public class Model
    {
        public Model()
        {
        }
        public Model(string model)
        {
            ModelVer = model;
        }
        public string ModelVer { get; set; }
        public override string ToString()
        {
            return $" Model {ModelVer} \n";
        }
    }

    public class Vendor
    {
        public Vendor()
        {
        }
        public Vendor(string vendor)
        {
            Vendorname = vendor;
        }
        public string Vendorname { get; set; }
        public override string ToString()
        {
            return $"Vendor {Vendorname} \n";
        }
    }
    public class Seat
    {
        public int Seat_number { get; set; }
        public Seat()
        {
        }
        public Seat(int seat_number)
        {
            Seat_number = seat_number;
        }
        public override string ToString()
        {
            return $"Seat {Seat_number} \n";
        }
    }
    public class Spoiler
    {
        public Spoiler()
        {
        }
        public Spoiler(bool hasSpoiler)
        {
            HasSpoiler = hasSpoiler;
        }
        public bool HasSpoiler { get; set; }
        public override string ToString()
        {
            return $"HasSpoiler {HasSpoiler} \n";
        }
    }
    public class GPS
    {
        public GPS()
        {
        }
        public GPS(bool hasGPS)
        {
            HasGPS = hasGPS;
        }
        public bool HasGPS { get; set; }
        public override string ToString()
        {
            return $"HasGPS {HasGPS} \n";
        }
    }
    public class Engine
    {
        public Engine()
        {
        }
        public Engine(string engine)
        {
            EngineVer = engine;
        }
        public string EngineVer { get; set; }
        public override string ToString()
        {
            return $"Engine {EngineVer} \n";
        }
    }
    public class Monitor
    {
        public Monitor()
        {
        }
        public Monitor(bool hasMonitor)
        {
            HasMonitor = hasMonitor;
        }
        public bool HasMonitor { get; set; }
        public override string ToString()
        {
            return $"HasMonitor {HasMonitor} \n";
        }
    }



    class Car
    {
        public Car()
        {
        }

  
        public Model Model { get; set; }
        public Vendor Vendor { get; set; }
        public Engine Engine { get; set; }
        public GPS GPS { get; set; }
        public Monitor Monitor { get; set; }
        public Spoiler Spoiler { get; set; }
        public Seat Seat { get; set; }
        public override string ToString()
        {
            return $"{Model} {Vendor} {Engine?.ToString()} " +
            $"{GPS?.ToString()} {Monitor?.ToString()} {Spoiler?.ToString()} {Seat?.ToString()} \n";
        }
    }


    abstract class CarBuilder
    {
        public Car car = new Car();


        public CarBuilder()
        {
        }

        public abstract CarBuilder SetModel(Model model);
        public abstract CarBuilder SetVendor(Vendor vendor);
        public abstract CarBuilder SetEngine(Engine engine);
        public abstract CarBuilder SetGPS(GPS gps);
        public abstract CarBuilder SetMonitor(Monitor monitor);
        public abstract CarBuilder SetSpoiler(Spoiler spoiler);
        public abstract CarBuilder SetSeat(Seat seat);


    }


    class SimpleCarBuilder : CarBuilder
    {

        public override CarBuilder SetModel(Model model)
        {
            car.Model = model;
            return this;
        }

        public override CarBuilder SetVendor(Vendor vendor)
        {
            car.Vendor = vendor;
            return this;
        }

        public override CarBuilder SetEngine(Engine engine)
        {
            car.Engine = engine;
            return this;
        }


        public override CarBuilder SetGPS(GPS gps)
        {
            car.GPS = gps;
            return this;
        }


        public override CarBuilder SetMonitor(Monitor monitor)
        {
            car.Monitor = monitor;
            return this;
        }


        public override CarBuilder SetSeat(Seat seat)
        {
            car.Seat = seat;
            return this;
        }


        public override CarBuilder SetSpoiler(Spoiler spoiler)
        {
            car.Spoiler = spoiler;
            return this;
        }

    }


    class SportCarBuilder : CarBuilder
    {
        public override CarBuilder SetModel(Model model)
        {
            car.Model = model;
            return this;
        }

        public override CarBuilder SetVendor(Vendor vendor)
        {
            car.Vendor = vendor;
            return this;
        }

        public override CarBuilder SetEngine(Engine engine)
        {
            car.Engine = engine;
            return this;
        }

        public override CarBuilder SetGPS(GPS gps)
        {
            car.GPS = gps;
            return this;
        }

        public override CarBuilder SetMonitor(Monitor monitor)
        {
            car.Monitor = monitor;
            return this;
        }

        public override CarBuilder SetSeat(Seat seat)
        {
            car.Seat = seat;
            return this;
        }

        public override CarBuilder SetSpoiler(Spoiler spoiler)
        {
            car.Spoiler = spoiler;
            return this;
        }

    }


    class Director
    {
        public Director()
        {

        }
        public Car Make(CarBuilder carBuilder)
        {


            return carBuilder.car;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();


            SimpleCarBuilder simpleCarBuilder = new SimpleCarBuilder();

            simpleCarBuilder.SetModel(new Model("Ege"));

            simpleCarBuilder.SetVendor(new Vendor("Fiat"));

            simpleCarBuilder.SetEngine(new Engine { EngineVer = "1.6 Mechanic" });
            simpleCarBuilder.SetMonitor(new Monitor { HasMonitor = true });
            simpleCarBuilder.SetGPS(new GPS { HasGPS = true });
            simpleCarBuilder.SetSeat(new Seat { Seat_number = 5 });
            simpleCarBuilder.SetSpoiler(new Spoiler { HasSpoiler = false });

       


            var car = director.Make(simpleCarBuilder);
            Console.WriteLine(car);




            SportCarBuilder sportCarBuilder = new SportCarBuilder();

            sportCarBuilder.SetModel(new Model("BMW"));

            sportCarBuilder.SetVendor(new Vendor("X6"));

            sportCarBuilder.SetEngine(new Engine { EngineVer = "V8" });
            sportCarBuilder.SetMonitor(new Monitor { HasMonitor = true });
            sportCarBuilder.SetGPS(new GPS { HasGPS = true });
            sportCarBuilder.SetSeat(new Seat { Seat_number = 5 });
            sportCarBuilder.SetSpoiler(new Spoiler { HasSpoiler = true });

            var car2 = director.Make(sportCarBuilder);
            Console.WriteLine(car2);
        }
    }
}