// See https://aka.ms/new-console-template for more information
using FactoryMethod;

Console.WriteLine("Hello, World!");

VehicleFactory factory;

factory = new CarFactory();

IVehicle vehicle = factory.CreateVehicle();
vehicle.Drive();

factory = new Bikefactory();
IVehicle vehicle1 = factory.CreateVehicle();
vehicle1.Drive();
