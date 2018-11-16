using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Concepts_Std.Interfaces
{
    // Garage contains a set of Car objects.
    public class Garage : IEnumerable
    {
        private Car[] carArray = new Car[4];
        
        // Fill with some Car objects upon startup.
        public Garage()
        {
            carArray[0] = new Car(30, "Rusty");
            carArray[1] = new Car(55, "Clunker");
            carArray[2] = new Car(30, "Zippy");
            carArray[3] = new Car(30, "Fred");
        }

        public IEnumerator GetEnumerator()
        {
            return carArray.GetEnumerator();
        }
    }
}
