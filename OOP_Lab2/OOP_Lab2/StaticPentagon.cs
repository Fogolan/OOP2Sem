using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2_02
{
    static class StaticPentagon
    {
        public static float GetSinCorner(this Pentagon obj)
        {
            return (float)Math.Pow(Math.Sqrt(obj.Square) / obj.Side, 2);
        }

        public static double GetRadius(Pentagon obj)
        {
            return (obj.Square / obj.Side) / 2;
        }

        public static float GetVolume(Pentagon obj)
        {
            return (float)Math.Pow(obj.Side, 3);
        }
    }
}
