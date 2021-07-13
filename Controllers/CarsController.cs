using System.Collections.Generic;
using C_Gregslist.Models;
using C_Gregslist.Services;
using Microsoft.AspNetCore.Mvc;

namespace C_Gregslist.AddControllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    private readonly CarsService _cs;
    public CarsController(CarsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public List<Car> GetCars()
    {
      return _cs.GetAllCars();
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetCarById(int id)
    {
      try
      {
        var car = _cs.GetCarById(id);
        if (car == null)
        {
          return BadRequest("Bad Id");
        }
        return Ok(car);
      }
      catch (System.Exception e)
      {
        return Forbid(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Car> CreateCar([FromBody] Car carData)
    {
      try
      {
        var car = _cs.CreateCar(carData);
        return Created("api/cars/" + car.Id, car);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Car> DeleteCar(int id)
    {
      try
      {
        var car = _cs.DeleteCar(id);
        return Ok(car);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}