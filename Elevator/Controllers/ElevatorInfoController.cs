using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Elevator.Model;

namespace Elevator.Controllers;

[ApiController]
[Route("[controller]")]
public class ElevatorInfoController : ControllerBase
{
    /// <summary>
    /// Получение положения лифта
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public int Get()
    {
        return Elevator.Model.ElevatorModel.ElevatorPosition;
    }
    /// <summary>
    /// Установка количества этажей в здании
    /// </summary>
    /// <param name="setting"></param>
    [HttpPost]
    public void Post(SettingsElevator setting)
    {
        Elevator.Model.ElevatorModel.FloorCount = setting.floorCount;
    }
}

public class SettingsElevator
{
    public int floorCount { get; set; }    
}