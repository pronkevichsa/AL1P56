using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL1P26
{
    public class Transport
    { /// <summary>
    /// vvv
    /// </summary>
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }

        public int MaxSpeed { get; set; }
        public float Distance { get; set; }

        public virtual void Move(float km)
        {
            this.Distance += km;
        }
    }

    public class Car : Transport
    {
        public float Engine { get; set; }
    }

    public class FuelCar : Car
    {
        public int Tank { get; set; }
        public float Fuel { get; set; }
        public float FuelUsage { get; set; }

        public override void Move(float km)
        {
            base.Move(km);
            this.Fuel -= km * FuelUsage / 100;
        }

        public static bool operator >(FuelCar f1, FuelCar f2)
        {
            return (f1.Engine > f2.Engine);
        }

        public static bool operator <(FuelCar f1, FuelCar f2)
        {
            return f1.Engine < f2.Engine;
        }

        public static bool operator !=(FuelCar f1, FuelCar f2)
        {
            return f1.Engine != f2.Engine;
        }

        public static bool operator ==(FuelCar f1, FuelCar f2)
        {
            return f1.Engine == f2.Engine;
        }

    }

    public class ElectroCar : Car
    {
        public int Battery { get; set; }
        public float Charged { get; set; }
        public float DistanceBattery { get; set; }

        public override void Move(float km)
        {
            base.Move(km);
            this.Charged -= Battery * km / DistanceBattery;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var kia = new FuelCar() { Engine = 116f };
            var bmw = new FuelCar() { Engine = 200f };
            if (bmw > kia) Console.WriteLine("bmw cool");
            else Console.WriteLine("kia cool");

            Console.ReadKey();
        }

        
    }
}
