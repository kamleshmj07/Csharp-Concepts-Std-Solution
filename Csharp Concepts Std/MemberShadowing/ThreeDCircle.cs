using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Concepts_Std.MemberShadowing
{
    public class ThreeDCircle : Circle
    {
        //public void Draw()

        // Hides Parent class method implementation
        public new void Draw()
        {
            Console.WriteLine("This is a 3D Circle !");
        }
    }
}
