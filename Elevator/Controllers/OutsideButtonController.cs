﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Elevator.Controllers;

[ApiController]
[Route("[controller]")]
public class OutsideButtonController : ControllerBase
{
    /// <summary>
    /// Вызов лифта с внешних кнопок
    /// </summary>
    /// <param name="setting"></param>
    [HttpPost]
    public void Post(ChangedOutsideFloor setting)
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

public class ChangedOutsideFloor
{
    public int currentFloor { get; set; }
}