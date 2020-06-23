using System;

namespace Proyecto_Arkanoid
{
    public class OutOfBoundsException: Exception
    {
        public OutOfBoundsException(string message) : base(message)
        {
        }
    }
}