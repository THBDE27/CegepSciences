using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CegepSciences
{
    class Vector2
    {
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X;
        public float Y;

        public static Vector2 operator *(float x, Vector2 vector)
        {
            return new Vector2(x * vector.X, x * vector.Y);
        }
    }
}
