namespace ElevatorTests;

public class ElevatorTest
{
    [Fact]
    public void SetFloorCountTest()
    {
        var testValue = 13;
        Elevator.Model.ElevatorModel.FloorCount = testValue;
        Assert.Equal(testValue, Elevator.Model.ElevatorModel.FloorCount);
        testValue = -13;
        Elevator.Model.ElevatorModel.FloorCount = testValue;
        Assert.NotEqual(testValue, Elevator.Model.ElevatorModel.FloorCount);
    }

    [Fact]
    public void MovieElevatorTest()
    {
        Elevator.Model.ElevatorMotorModel.ElevatorSpeed = 100;
        var testValue = 5;
        Elevator.Model.ElevatorModel.ElevatorPosition = 1;
        Elevator.Model.ElevatorModel.ChangedFloor = new List<int> { testValue };
        Elevator.Model.ElevatorModel.MoveElevator(true);
        Assert.Equal(testValue, Elevator.Model.ElevatorModel.ElevatorPosition);

        testValue = 1;
        Elevator.Model.ElevatorModel.ChangedFloor = new List<int> { testValue, 2 , 3 };
        Elevator.Model.ElevatorModel.MoveElevator(true);
        Assert.Equal(testValue, Elevator.Model.ElevatorModel.ElevatorPosition);

        testValue = 12;
        Elevator.Model.ElevatorModel.ElevatorPosition = 1;
        Elevator.Model.ElevatorModel.ChangedFloor = new List<int> { testValue, 11, 3, 1, };
        Elevator.Model.ElevatorModel.MoveElevator(true);
        Assert.Equal(testValue, Elevator.Model.ElevatorModel.ElevatorPosition);
    }

    [Fact]
    public async void ElevatorMotorTest()
    {
        Elevator.Model.ElevatorMotorModel.ElevatorSpeed = 100;
        var testValue = 5;
        Elevator.Model.ElevatorModel.ElevatorPosition = 1;
        var moveResult = await Elevator.Model.ElevatorMotorModel.MoveUpAsync(testValue);
        moveResult = await Elevator.Model.ElevatorMotorModel.MoveDownAsync(moveResult);
        Assert.Equal(testValue, moveResult);
    }
}
