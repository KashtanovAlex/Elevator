using System;
namespace Elevator.Model
{
	public static class ElevatorMotorModel
	{
        public static int ElevatorSpeed = 2000;// Скорость проезда лифта одного этажа мс

        public static async Task<int> MoveUpAsync(int position)
		{
            Move();
			position += 1;
            return position;
		}
		public static async Task<int> MoveDownAsync(int position)
		{
			Move();
            position -= 1;
            return position;
        }
		private static void Move()
		{
            Thread.Sleep(ElevatorSpeed);
        }
    }
}

