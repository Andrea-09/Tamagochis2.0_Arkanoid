using System;

namespace Proyecto_Arkanoid
{
    public class LongerNicknameException : Exception
    {
        public LongerNicknameException(string message) : base(message)
        {
        }
    }
}