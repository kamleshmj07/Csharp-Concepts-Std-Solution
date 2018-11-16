using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Concepts_Std.Interfaces
{
    public class Car
    {
        // Constant max speed
        public const int MaxSpeed = 100;

        // Car Properties
        public int CurrentSpeed { get; set; }

        public string PetName { get; set; }

        private bool _isCarDead { get; set; }

        public Car()
        {

        }

        public Car(int speed, string name)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public void Accelerate(int delta)
        {
            if (delta < 0)
            {
                throw new ArgumentOutOfRangeException("delta", "Speed must be greater than zero.");
            }


            if (_isCarDead)
            {
                throw new CarIsDeadException(PetName + " is busted !", "Overheated engine due to over acceleration", DateTime.Now);
            }
            else
            {
                CurrentSpeed += delta;

                if (CurrentSpeed > MaxSpeed)
                {
                    Console.WriteLine("{0} is overheated !!!",PetName);
                    _isCarDead = true;
                    CurrentSpeed = 0;
                }
                else
                {
                    Console.WriteLine("{0} now at {1}",PetName,CurrentSpeed);
                }
            }
        }
    }
}
