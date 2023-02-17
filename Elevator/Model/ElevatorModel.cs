﻿using System;
namespace Elevator.Model
{
    public static class ElevatorModel
    {
        private static int _floorCount;
        public static int FloorCount { get { return _floorCount; } set { if (value > 1) _floorCount = value; } }
        public static int ElevatorSpeed = 2000;
        public static int ElevatorPosition = 1;
        public static List<int> ChangedFloor = new List<int>(); 
        private static bool isMove= false; 

        /// <summary>
        /// Метод запускает движение лифта до тех пор пока не проедет все нужные этажи
        /// </summary>
        /// <param name="goUp">Выбор направления движения лифта в начале</param>
        public static void MoveElevator(bool goUp)
        {
            if (isMove)
            {
                return;
            }
            isMove = true;
            while (ChangedFloor.Count > 0)
            {
                var indexFloor = goUp ? ChangedFloor.Count - 1 : 0;
                
                if (ElevatorPosition > ChangedFloor[indexFloor])
                {
                    if (ChangedFloor.Contains(ElevatorPosition))
                    {
                        ChangedFloor.RemoveAt(ChangedFloor.FindIndex(x => x == ElevatorPosition));
                    }
                    ElevatorPosition--;// Движение вниз
                }
                else if (ElevatorPosition == ChangedFloor[indexFloor])
                {
                    ChangedFloor.RemoveAt(indexFloor);
                    goUp = !goUp;
                }
                else
                {
                    if (ChangedFloor.Contains(ElevatorPosition))
                    {
                        ChangedFloor.RemoveAt(ChangedFloor.FindIndex(x => x == ElevatorPosition));
                    }
                    ElevatorPosition++; // Движение вверх
                }
                Thread.Sleep(ElevatorSpeed);
            }
            isMove = false;
        }
    }
}

