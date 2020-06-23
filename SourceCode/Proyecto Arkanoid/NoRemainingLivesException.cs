using System;

namespace Proyecto_Arkanoid
{
    public class NoRemainingLivesException: Exception
    {
        public NoRemainingLivesException(string message) : base(message)
        {
        }
    }
}