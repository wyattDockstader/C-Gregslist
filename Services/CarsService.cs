using System;
using System.Collections.Generic;
using C_Gregslist.Data;
using C_Gregslist.Models;

namespace C_Gregslist.Services
{
  public class CarsService
  {
    public List<Car> GetAllCars()
    {
      return FakeDb.Cars;
    }

    public Car GetCarById(int id)
    {
      return FakeDb.Cars.Find(c => c.Id == id);
    }

    public Car CreateCar(Car carData)
    {
      var r = new Random();
      carData.Id = r.Next(10000, 99999);
      FakeDb.Cars.Add(carData);
      return carData;
    }

    public Car EditCar(int id, Car carData)
    {
      var car = FakeDb.Cars.Find(c => c.Id == id);
      if (car == null)
      {
        throw new Exception("Bad Id");
      }
      FakeDb.Cars.Remove(car);
      FakeDb.Cars.Add(carData);
      return carData;
    }

    public Car DeleteCar(int id)
    {
      var car = FakeDb.Cars.Find(c => c.Id == id);
      if (car == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDb.Cars.Remove(car);
      return car;
    }
  }
}