


using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace CovarianceAndContravariance
{
    class Program
    {
        delegate Car CarFactoryDel(int id, string name);
        delegate void LogIECCarDetailsDel(ICECar car);
        delegate void LogEVCarDetailsDel(EVCar car);

        public static void Main(string[] args)
        {
            CarFactoryDel carFactoryDel = CarFactory.ReturnICECar;
            Car iceCar = carFactoryDel(7, "Toyota Supra - V8");

            carFactoryDel = CarFactory.ReturnEvCar;
            Car evCar = carFactoryDel(42, "Tesla Model-31");


            LogIECCarDetailsDel logIECCarDetailsDel = LogCarDetails;
            logIECCarDetailsDel(iceCar as ICECar);

            LogEVCarDetailsDel logEVCarDetailsDel = LogCarDetails;
            logEVCarDetailsDel (evCar as EVCar);

            Console.ReadKey();  


        }

        
       public static void LogCarDetails(Car car)
        {
            if(car is ICECar)
            {
                using(StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ICEDetails.txt"), true))
                {
                    sw.WriteLine($"Object Type: {car.GetType()}");
                    sw.WriteLine($"Car Details : {car.GetCarDetails()}");
                };
            }
            else if (car is EVCar)
            {
                Console.WriteLine($"Object Type : {car.GetType()}");
                Console.WriteLine($"Car Details : {car.GetCarDetails()}");
            }
            else
            {
                throw new ArgumentException();
            }
            
        }
    }
    public static class CarFactory
    {
        public static ICECar ReturnICECar(int id, string name)
        {
            return new ICECar { Id = id, Name = name };
        }
        public static EVCar ReturnEvCar(int id, string name)
        {
            return new EVCar{ Id = id,Name = name};
        }
    }

    public abstract class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual string GetCarDetails()
        {
            return $"{Id} - {Name}";
        }
    }
    public class ICECar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Internal Combustion Engine";

        }

    }
    public class EVCar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Electric";
        }
    }
}
/*Covariance and Contravariance in Delegates Example:

This C# code exemplifies the concepts of covariance and contravariance in delegates within the context of a car manufacturing scenario.

#Covariance:

1. **Delegate Definitions:**
   - `CarFactoryDel`: A delegate returning a base type `Car`, demonstrating covariance. Methods returning both `ICECar` and `EVCar` can be assigned to this delegate.

2. **Delegate Assignments:**
   - The `carFactoryDel` delegate is assigned methods from the `CarFactory` class, returning both `ICECar` and `EVCar`. This showcases covariance as the delegate type allows assigning more derived return types.

# Contravariance:

1. **Delegate Parameter Types:**
   - `LogIECCarDetailsDel` and `LogEVCarDetailsDel`: Delegates with parameters of more specific types (`ICECar` and `EVCar` respectively), indicating contravariance. The delegates can accept parameters of less derived types.

2. **Delegate Assignments:**
   - `logIECCarDetailsDel` and `logEVCarDetailsDel` are assigned to the `LogCarDetails` method, which accepts a parameter of type `Car`. This illustrates contravariance as the method can be assigned to delegates expecting more specific types (`ICECar` and `EVCar`), allowing flexibility in handling different car types.

# Summary:

- **Covariance:**
  - Enables flexibility in returning more derived types, demonstrated in the delegate definitions and assignments for the `CarFactoryDel` delegate.

- **Contravariance:**
  - Provides flexibility in accepting more general types, showcased in the delegate definitions and assignments for `LogIECCarDetailsDel` and `LogEVCarDetailsDel` delegates.*/