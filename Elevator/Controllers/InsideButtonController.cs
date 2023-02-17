using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Elevator.Controllers;

[ApiController]
[Route("[controller]")]
public class InsideButtonController : ControllerBase
{
    /// <summary>
    /// Вызов лифта с кнопок внутри
    /// </summary>
    /// <param name="setting"></param>
    [HttpPost]
    public void Post(ChangedInsideFloor setting)
    {
        if (Elevator.Model.ElevatorModel.ChangedFloor.Contains(setting.currentFloor))
        {
            return;
        }
        Elevator.Model.ElevatorModel.ChangedFloor.Add(setting.currentFloor);
        Elevator.Model.ElevatorModel.ChangedFloor.Sort();
        Elevator.Model.ElevatorModel.MoveElevator(true);
    }
}

public class ChangedInsideFloor
{
    public int currentFloor { get; set; }    
}