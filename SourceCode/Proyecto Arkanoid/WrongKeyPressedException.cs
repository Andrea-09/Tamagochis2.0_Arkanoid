using System;

namespace Proyecto_Arkanoid
{
    public class WrongKeyPressedException: Exception
    {
        public WrongKeyPressedException(string message) : base(message)
        {
        }
    }
}