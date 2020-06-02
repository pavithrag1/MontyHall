using MontyHall.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall.Library
{
    public class MontyHallSimulator
    {
        private Random _rand = new Random();
        private MontyHallModel _montyHallModel = new MontyHallModel();

        public MontyHallSimulator(int count, bool hasSwitched)
        {
            Initialize(count, hasSwitched);
        }

        /// <summary>
        /// Logic to simulate the game and get the 'Win' count
        /// </summary>
        /// <returns></returns>
        public MontyHallModel SimulateMontyHall()
        {            
            for (int i = 0; i < _montyHallModel.SimulationCount; i++)
            {
                int selectedDoor = _rand.Next(3);
                int prizeDoor = _rand.Next(3);
                int switchedDoor = 0;

                //Presenter opens a door 
                var presenterDoor = GetDoor(prizeDoor, selectedDoor);

                //Player switches the door
                if (_montyHallModel.HasSwitched)
                    switchedDoor = GetDoor(selectedDoor, presenterDoor);

                if (switchedDoor == prizeDoor)
                    _montyHallModel.Wins++;
            }
            return _montyHallModel;
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="count"></param>
        /// <param name="hasSwitched"></param>
        private void Initialize(int count, bool hasSwitched)
        {
            _montyHallModel.SimulationCount = count;
            _montyHallModel.HasSwitched = hasSwitched;
        }

        /// <summary>
        /// Get random door
        /// </summary>
        /// <param name="door1"></param>
        /// <param name="door2"></param>
        /// <returns></returns>
        private int GetDoor(int door1, int door2)
        {
            int door;
            do
                door = _rand.Next(3);
            while (door == door1 || door == door2);
            return door;
        }
    }
}
